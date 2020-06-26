using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodeGenerator.Controller;
using System.IO;
using CodeGenerator.Datamodel;

namespace CodeGenerator.GUI
{
    public partial class Form1 : Form
    {
        #region Constructor
        public Form1()
        {
            InitializeComponent();
            // Sobald das Form erstellt wurde, wird die Höhe des Preview Fensters berechnet(Formhöhe- Oberer Abstand)
            PreviewTableLayoutPanel.Height = this.Height - 170;
            // Ausserdem wird der Gesamtabstand zwischen Form und PreviewPanel berechnet(Oben und Unten)
            PreviewOffset = this.Height - PreviewTableLayoutPanel.Height;
        }
        #endregion

        #region Attributes
        // Die Eigenschaft Offset beinhaltet den Abstand zwischen Form und PreviewPanel
        int PreviewOffset { get; set; }
        #endregion

        #region CreateController
        /// <summary>
        /// Erstellt neues Controller-Objekt und ruft dessen StartProcess-Methode auf.
        /// Wenn die Methode eine message zurückgibt, wird Form2 mit der message aufgerufen.
        /// </summary>
        /// <param name="filePath_Model">Dateipfad im Typ string</param>
        /// <param name="filePath_Output">Ausgabepfad im Typ string</param>
        public void CreateController(string filePath_Model, string filePath_Output)
        {
            Controller.Controller controller = new Controller.Controller();
            string message = controller.StartProcess(filePath_Model, filePath_Output, out Datamodel.Datamodel dtm);
            if (message != null)
            {
                new Form2(message).ShowDialog();
                this.Show();
            }
            else if (dtm != null)
            {
                WritePrewiev(filePath_Output, dtm);
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Events
        #region Clicks
        /// <summary>
        /// Wenn der SelectFileButton geklickt wird, wird die openFileDialog-Komponente aufgerufen, 
        /// um die Modellierdatei auszuwählen. Wenn ein Dateipfad ausgewählt wurde, wird 
        /// dieser in das Path_Model-Label geschrieben.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            if(openFileDialogFile.ShowDialog()==DialogResult.OK)
            {
                PathModelLabel.Text = openFileDialogFile.FileName;
            }
        }

        /// <summary>
        /// Wenn der SelectOutputButton geklickt wird, wird die folderBrowserDialog-Komponente 
        /// aufgerufen, um den Ausgabeort auszuwählen. Wenn ein Ausgabeort ausgewählt wurde, wird 
        /// dieser in das Path_Output-Label geschrieben.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectOutputButton_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialogOutput.ShowDialog() == DialogResult.OK)
            {
                PathOutputLabel.Text = folderBrowserDialogOutput.SelectedPath;
            }
        }

        /// <summary>
        /// Wenn der GenerateButton geklickt wird, werden die beiden ausgewählten Pfade in
        /// string Variablen gespeichert, geprüft ob diese ausgewählt wurden und CreateController() aufgerufen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateButton_Click(object sender, EventArgs e)
        {
            string filePath_Model = PathModelLabel.Text;
            string filePath_Output = PathOutputLabel.Text;
            string noModel = "Keine Datei ausgewählt!";
            string noOutput = "Keinen Ausgabeort ausgewählt!";
            

            // Wenn Datei nicht ausgewählt und Ausgabeort ausgewählt wurde, wird 
            // FilePictureBox rot und der ErrorProvider ausgelöst.
            if (filePath_Model == noModel && filePath_Output != noOutput)
            {
                errorProvider1.SetError(FilePictureBox,"Bitte wählen Sie eine \".graphml\"- Datei!");
                FilePictureBox.BackColor = Color.Red;
            }

            // Wenn Datei ausgewählt und Ausgabeort nicht ausgewählt wurde, wird
            // OutputPictureBox rot und der ErrorProvider ausgelöst
            else if (filePath_Output == noOutput && filePath_Model != noModel)
            {
                errorProvider1.SetError(OutputPictureBox, "Bitte wählen Sie einen Ausgabeort!");
                OutputPictureBox.BackColor = Color.Red;
            }

            // Wenn beide nicht ausgewählt wurden, werden bei beiden PictureBoxes rot und ErrorProvider ausgelöst.
            else if (filePath_Output == noOutput && filePath_Model == noModel)
            {
                errorProvider1.SetError(FilePictureBox, "Bitte wählen Sie eine \".graphml\"- Datei!");
                errorProvider1.SetError(OutputPictureBox, "Bitte wählen Sie einen Ausgabeort!");
                OutputPictureBox.BackColor = Color.Red;
                FilePictureBox.BackColor = Color.Red;
            }

            // Letzte Möglichkeit: Beide ausgewählt. Im Status Label wird der Text ersetzt und
            // CreateController wird ausgeführt.
            else
            {
                Cursor = Cursors.WaitCursor;
                toolStripStatusLabel1.Text = "Dateien werden erstellt...";
                CreateController(filePath_Model, filePath_Output);
            }
                
        }

        /// <summary>
        /// Wenn der ShowHelp-Button im Menu-Strip angeklickt wird, wird automatisch die Readme-Datei geöffnet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HilfeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string currentDir = Environment.CurrentDirectory;
            int index = currentDir.IndexOf(@"\CodeGenerator");
            string FilePath = currentDir.Substring(0, index) + @"\README.md";
            System.Diagnostics.Process.Start(FilePath);
        }

        /// <summary>
        /// Beim Klicken wird, fals Ausgabeort ausgewählt wurde, der Ausgabeort geöffnet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AusgabeortÖffnenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = PathOutputLabel.Text;
                if (filePath != "Keinen Ausgabeort ausgewählt!")
                {
                    System.Diagnostics.Process.Start(filePath);
                }
            }
            catch(UnauthorizedAccessException)
            {
                new Form2("Dateien konnten im ausgewählten Verzeichnis nicht erstellt werden. Schreibberechtigung verweigert! Bitte überprüfen Sie die Eigenschaften des Verzeichnisses oder ändern Sie den Ausgabeort!");
                this.Show();
            }
        }

        /// <summary>
        /// Beim Klicken wird, fals Dateipfad ausgewählt wurde, das Diagram geöffnet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DiagrammÖffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = PathModelLabel.Text;
            if (filePath != "Keine Datei ausgewählt!")
            {
                System.Diagnostics.Process.Start(filePath);
            }
        }
        #endregion

        #region MouseHover
        /// <summary>
        /// Wenn die Maus über den SelectFileButton geht, wird im StatusLabel der Text angezeigt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectFileButton_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Klicken Sie hier, um ein Diagramm, aus ihrem lokalen Speicher hochzuladen.";
        }

        /// <summary>
        /// Wenn die Maus über den SelectOutputButton geht, wird im StatusLabel der Text angezeigt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectOutputButton_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Klicken Sie hier, um einen Speicherort, der zu generierenden Dateien auszuwählen.";
        }

        /// <summary>
        /// Wenn die Maus über das PathModelLabel geht und eine Datei ausgewählt wurde, 
        /// wird im StatusLabel der Pafad angezeigt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PathModelLabel_MouseHover(object sender, EventArgs e)
        {
            if (PathModelLabel.Text != "Keine Datei ausgewählt!")
                toolStripStatusLabel1.Text = PathModelLabel.Text;
        }

        /// <summary>
        /// Wenn die Maus über das PathOutputLabel geht und ein Ausgabeort ausgewählt wurde, 
        /// wird im StatusLabel der Pfad angezeigt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PathOutputLabel_MouseHover(object sender, EventArgs e)
        {
            if (PathOutputLabel.Text != "Keinen Ausgabeort ausgewählt!")
                toolStripStatusLabel1.Text = PathOutputLabel.Text;
        }

        /// <summary>
        /// Wenn die Maus über den GenerateButton geht, wird im StatusLabel der Text angezeigt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateButton_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Klicken Sie hier, um aus dem Diagramm den Code generieren zu lassen.";
        }

        /// <summary>
        /// Wenn die Maus über das HilfeStripMenu geht, wird im StatusLabel der Text angezeigt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HilfeToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Sie benötigen Hilfe? Wir helfen gern!";
        }

        /// <summary>
        /// Wenn die Maus über die PreviewTextBox geht, wird im StatusLabel der entsprechende Text angezeigt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewTextBox_MouseHover(object sender, EventArgs e)
        {
            if (PreviewTextBox.Text == "Hier steht nachher der generierte Code.")
                toolStripStatusLabel1.Text = "Sobald Sie beide Pfade ausgewählt und auf Generieren geklickt haben. Sehen Sie hier den generierten Code.";
            else
                toolStripStatusLabel1.Text = "Sie sehen nun hier die generierten \".cs-Dateien\" untereinander aufgelistet.";
        }

        /// <summary>
        /// Wenn die Maus über das ExampleDiagramPictureBox geht, wird im StatusLabel der Text angezeigt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExampleDiagramPictureBox_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Hier sehen Sie ein Beispiel für ein zulässiges Klassendiagramm. Fals es Probleme bei der Erstellung der Dateien gibt orientieren Sie sich hieran. Für Hilfe: Strg + h";
        }

        /// <summary>
        /// Wenn die Maus über das AusgabeortÖffnenStripMenu geht, wird im StatusLabel der Text angezeigt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AusgabeortÖffnenToolStripMenuItem1_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Klicken Sie hier, sobald Sie einen Ausgabeort ausgewählt haben, um den Ausgabeort zu öffnen";
        }

        /// <summary>
        /// Wenn die Maus über das KlassendiagrammÖffnenMenuStrip geht, wird im StatusLabel der Text angezeigt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KlassendiagrammÖffnenToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Klicken Sie hier, sobald Sie eine Klassendiagramm-Datei ausgewählt haben, um die Datei zu öffnen";
        }
        #endregion

        #region MouseLeave
        /// <summary>
        /// Wenn die Maus den SelectFileButton verlässt, wird der Text im StatusLabel gelöscht.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectFileButton_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        /// <summary>
        /// Wenn die Maus den SelectOutputButton verlässt, wird der Text im StatusLabel gelöscht.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectOutputButton_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        /// <summary>
        /// Wenn die Maus das PathModelLabel verlässt, wird der Text im StatusLabel gelöscht.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PathModelLabel_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        /// <summary>
        /// Wenn die Maus das PathOutputLabel verlässt, wird der Text im StatusLabel gelöscht.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PathOutputLabel_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        /// <summary>
        /// Wenn die Maus den GeneratButton verlässt, wird der Text im StatusLabel gelöscht.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateButton_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        /// <summary>
        /// Wenn die Maus das HilfeStripMenu verlässt, wird der Text im StatusLabel gelöscht.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HilfeToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        /// <summary>
        /// Wenn die Maus die PreviewTextBox verlässt, wird der Text im StatusLabel gelöscht.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewTextBox_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        /// <summary>
        /// Wenn die Maus die ExampleDiagramPictureBox verlässt, wird der Text im StatusLabel gelöscht.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExampleDiagramPictureBox_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        /// <summary>
        /// Wenn die Maus das AusgabeortÖffnenStripMenu verlässt, wird der Text im StatusLabel gelöscht.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AusgabeortÖffnenToolStripMenuItem1_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        /// <summary>
        /// Wenn die Maus das KlassendiagrammÖffnenStripMenu verlässt, wird der Text im StatusLabel gelöscht.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KlassendiagrammÖffnenToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }
        #endregion

        #region TextChanged
        /// <summary>
        /// Wenn sich der Text im PathModelLabel ändert wird der ErrorProvider und die PictureBox zurückgesetzt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PathModelLabel_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(FilePictureBox, null);
            FilePictureBox.BackColor = DefaultBackColor;

        }

        /// <summary>
        /// /// Wenn sich der Text im PathOutputLabel ändert wird der ErrorProvider und die PictureBox zurückgesetzt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PathOutputLabel_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(OutputPictureBox, null);
            OutputPictureBox.BackColor = DefaultBackColor;
        }
        #endregion

        #region Resize
        /// <summary>
        /// Sobald man die Größe des Forms verändert, wird die Höhe des Preview Panels mit Hilfe der
        /// Eigenschaften PreviewOffset und der Höhe des Forms, sowie der untere Abstand "35", neu angepasst.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Resize(object sender, EventArgs e)
        {
            PreviewTableLayoutPanel.Height = this.Height - PreviewOffset -35;
        }
        #endregion
        #endregion

        #region PreviewMethods
        #region WritingMethods
        /// <summary>
        /// Beschreibt die Preview-TextBox, indem es aus dem Datamodel die Klassen ausliest
        /// und bei jeder Klassendatei den gesamten Inhalt ausliest
        /// </summary>
        /// <param name="FilePath_Output">der Ausgabepfad damit der Reader weiss, wo er lesen soll</param>
        /// <param name="dtm">das Datamodel, um die erstellten Klassen zu ermitteln</param>
        /// <returns>true, wenn keine Exception ausgelöst wurde.</returns>
        public bool WritePrewiev(string FilePath_Output, Datamodel.Datamodel dtm)
        {
            try
            {
                PreviewTextBox.Text = "";

                // Die Dateien im Ausgabepfad werden nacheinander mit StreamReader gelesen und in die PreviewTextBox geschrieben.
                foreach(UML_Class umlClass in dtm.umlClasses)
                {
                    string filePath = FilePath_Output + "\\" + umlClass.name + ".cs";
                    AddingFileToTextBox(filePath);
                }

                foreach(UML_Interface umlInterface in dtm.umlInterfaces)
                {
                    string filePath = FilePath_Output + "\\" + umlInterface.name + ".cs";
                    AddingFileToTextBox(filePath);
                }
                // Der Text wird wie in Visual Studio gefärbt
                GiveColorKeywords();
                GiveColorNames(dtm);
            }
            catch(Exception)
            {
                new Form2("Wir bitten um Entschuldigung, da ist etwas im System falsch gelaufen. Bitte wenden Sie sich an den Hersteller!").ShowDialog();
                this.Show();
            }
            return true;
        }

        /// <summary>
        /// Addet Datei im Parameter auf die PreviewTextBox und nummeriert die Zeilen
        /// </summary>
        /// <param name="filePath">.cs-Dateipfad für jede Klasse oder Interface</param>
        public void AddingFileToTextBox(string filePath)
        {
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                int lines = System.IO.File.ReadAllLines(filePath).Length;
                for (int i = 1; i <= lines; i++)
                    PreviewTextBox.Text += i + "          " + streamReader.ReadLine() + "\n";
                PreviewTextBox.Text += "\n\n";
            }
        }
        #endregion

        #region ColoringMethods
        /// <summary>
        /// Färbt ein bestimmtes Keyword entsprechend seiner Farbe, so oft wie es vorhanden ist.
        /// </summary>
        /// <param name="word">ein bestimmtes c# Keyword</param>
        /// <param name="color">die Farbe, in welche gefärbt werden soll</param>
        public void GiveColor(string word, Color color)
        {
            // Bis zum letzten Index des Wortes wird gesucht, wenn es gefunden wurde gefärbt 
            // und nach dem Wort weitergesucht
            for (int index = 0; index < PreviewTextBox.Text.LastIndexOf(word); index++)
            {
                PreviewTextBox.Find(word, index, PreviewTextBox.TextLength, RichTextBoxFinds.None);
                PreviewTextBox.SelectionColor = color;
                index = PreviewTextBox.Text.IndexOf(word, index);
            }
        }

        /// <summary>
        /// Färbt alle Keywords von C#, die im Ausgabeort generiert werden können, im Previewfenster.
        /// </summary>
        public void GiveColorKeywords()
        {
            string[] keywords = {"bool", "byte", "sbyte", "short", "ushort", "int", "uint", "long", "ulong",
                    "double", "float", "decimal","string", "String", "char", "void", "public", "private", "internal",
                    "protected", "static", "readonly", "partial", "sealed", "new", "override", "abstract", "virtual",
                    "const", "ref", "out", "params", "this", "base", "using", "class", "struct", "interface", "get", "set"};

            foreach (string keyword in keywords)
                GiveColor(keyword, Color.RoyalBlue);


            GiveColor("throw", Color.Pink);
            GiveColor("NotImplementedException", Color.MediumAquamarine);
            GiveColor("// Methods", Color.LimeGreen);
            GiveColor("// Attributes", Color.LimeGreen);
        }

        /// <summary>
        /// Färbt alle Methodennamen gelb und Eigenschaftsnamen weiß, damit fals sie Keywords enthalten weiß bleiben.
        /// </summary>
        /// <param name="dtm">Das Datamodel damit nach den Methoden und Eigenschaftsnamen gesucht werden kann.</param>
        public void GiveColorNames(Datamodel.Datamodel dtm)
        {
            foreach (UML_Class umlClass in dtm.umlClasses)
            {
                foreach (UML_Method umlMethod in umlClass.umlMethods)
                {
                    GetNames<UML_Method>(umlMethod, Color.Khaki, "(", false);
                }

                foreach (UML_Attribute umlAttribute in umlClass.umlAttributes)
                {
                    GetNames<UML_Attribute>(umlAttribute, Color.White, " { get;", false);
                }
                GetNames<UML_Class>(umlClass, Color.MediumAquamarine, "class ", true);
            }


            foreach (UML_Interface umlInterface in dtm.umlInterfaces)
            {
                foreach (UML_Method umlMethod in umlInterface.umlMethods)
                {
                    GetNames<UML_Method>(umlMethod, Color.Khaki, "(", false);
                }

                foreach (UML_Attribute umlAttribute in umlInterface.umlAttributes)
                {
                    GetNames<UML_Attribute>(umlAttribute, Color.White, " { get;", false);
                }
                GetNames<UML_Interface>(umlInterface, Color.LightGreen, "interface ", true);
            }
        }

        /// <summary>
        /// Sucht alle Namen im Previewfenster
        /// </summary>
        /// <typeparam name="T"> Generischer Typ kann UML_Interface, UML_Class, UML_Method oder UML_Eigenscaft sein</typeparam>
        /// <param name="umlUnit"> Die Unit von der gesucht wird</param>
        /// <param name="color"> Farbe nach Visual Studio</param>
        /// <param name="searchKey"> Suchschlüssel, der vor oder hinter dem gesuchten Namen steht</param>
        /// <param name="searchKeyIsOnFront">Gibt an ob der Suchschlüssel vor dem Namen ist.</param>
        public void GetNames<T>(T umlUnit, Color color, string searchKey, bool searchKeyIsOnFront) where T : Datamodel.UML_Base
        {
            int start;
            if (searchKeyIsOnFront)
                start = PreviewTextBox.Text.IndexOf(searchKey + umlUnit.name) + searchKey.Length;
            else
                start = PreviewTextBox.Text.IndexOf(umlUnit.name + searchKey);

            int end = start + umlUnit.name.Length;
            PreviewTextBox.Find(umlUnit.name, start, end, RichTextBoxFinds.None);
            PreviewTextBox.SelectionColor = color;
        }

        #endregion

        #endregion
    }
}
