namespace CodeGenerator.GUI
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SelectFileButton = new System.Windows.Forms.Button();
            this.PathModelLabel = new System.Windows.Forms.Label();
            this.SelectOutputButton = new System.Windows.Forms.Button();
            this.PathOutputLabel = new System.Windows.Forms.Label();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.openFileDialogFile = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialogOutput = new System.Windows.Forms.FolderBrowserDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.öffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AusgabeortÖffnenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.DiagrammÖffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeAnzeigenLassenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.PreviewTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.PreviewTextBox = new System.Windows.Forms.RichTextBox();
            this.PreviewFensterLabel = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.exampleDiagramPictureBox = new System.Windows.Forms.PictureBox();
            this.FilePictureBox = new System.Windows.Forms.PictureBox();
            this.OutputPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.PreviewTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exampleDiagramPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SelectFileButton
            // 
            this.SelectFileButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SelectFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectFileButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SelectFileButton.Location = new System.Drawing.Point(32, 48);
            this.SelectFileButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SelectFileButton.MaximumSize = new System.Drawing.Size(180, 31);
            this.SelectFileButton.MinimumSize = new System.Drawing.Size(180, 31);
            this.SelectFileButton.Name = "SelectFileButton";
            this.SelectFileButton.Size = new System.Drawing.Size(180, 31);
            this.SelectFileButton.TabIndex = 0;
            this.SelectFileButton.Text = "Datei auswählen...";
            this.SelectFileButton.UseVisualStyleBackColor = false;
            this.SelectFileButton.Click += new System.EventHandler(this.SelectFileButton_Click);
            this.SelectFileButton.MouseLeave += new System.EventHandler(this.SelectFileButton_MouseLeave);
            this.SelectFileButton.MouseHover += new System.EventHandler(this.SelectFileButton_MouseHover);
            // 
            // PathModelLabel
            // 
            this.PathModelLabel.BackColor = System.Drawing.SystemColors.MenuBar;
            this.PathModelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PathModelLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PathModelLabel.Location = new System.Drawing.Point(231, 53);
            this.PathModelLabel.Name = "PathModelLabel";
            this.PathModelLabel.Size = new System.Drawing.Size(350, 20);
            this.PathModelLabel.TabIndex = 1;
            this.PathModelLabel.Text = "Keine Datei ausgewählt!";
            this.PathModelLabel.TextChanged += new System.EventHandler(this.PathModelLabel_TextChanged);
            this.PathModelLabel.MouseLeave += new System.EventHandler(this.PathModelLabel_MouseLeave);
            this.PathModelLabel.MouseHover += new System.EventHandler(this.PathModelLabel_MouseHover);
            // 
            // SelectOutputButton
            // 
            this.SelectOutputButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SelectOutputButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectOutputButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SelectOutputButton.Location = new System.Drawing.Point(32, 88);
            this.SelectOutputButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SelectOutputButton.MaximumSize = new System.Drawing.Size(180, 31);
            this.SelectOutputButton.MinimumSize = new System.Drawing.Size(180, 31);
            this.SelectOutputButton.Name = "SelectOutputButton";
            this.SelectOutputButton.Size = new System.Drawing.Size(180, 31);
            this.SelectOutputButton.TabIndex = 2;
            this.SelectOutputButton.Text = "Ausgabeort auswählen...";
            this.SelectOutputButton.UseVisualStyleBackColor = false;
            this.SelectOutputButton.Click += new System.EventHandler(this.SelectOutputButton_Click);
            this.SelectOutputButton.MouseLeave += new System.EventHandler(this.SelectOutputButton_MouseLeave);
            this.SelectOutputButton.MouseHover += new System.EventHandler(this.SelectOutputButton_MouseHover);
            // 
            // PathOutputLabel
            // 
            this.PathOutputLabel.BackColor = System.Drawing.SystemColors.MenuBar;
            this.PathOutputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PathOutputLabel.Location = new System.Drawing.Point(231, 96);
            this.PathOutputLabel.Name = "PathOutputLabel";
            this.PathOutputLabel.Size = new System.Drawing.Size(350, 20);
            this.PathOutputLabel.TabIndex = 3;
            this.PathOutputLabel.Text = "Keinen Ausgabeort ausgewählt!";
            this.PathOutputLabel.TextChanged += new System.EventHandler(this.PathOutputLabel_TextChanged);
            this.PathOutputLabel.MouseLeave += new System.EventHandler(this.PathOutputLabel_MouseLeave);
            this.PathOutputLabel.MouseHover += new System.EventHandler(this.PathOutputLabel_MouseHover);
            // 
            // GenerateButton
            // 
            this.GenerateButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.GenerateButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.GenerateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenerateButton.Location = new System.Drawing.Point(605, 51);
            this.GenerateButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(149, 66);
            this.GenerateButton.TabIndex = 4;
            this.GenerateButton.Text = "Generieren";
            this.GenerateButton.UseVisualStyleBackColor = false;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            this.GenerateButton.MouseLeave += new System.EventHandler(this.GenerateButton_MouseLeave);
            this.GenerateButton.MouseHover += new System.EventHandler(this.GenerateButton_MouseHover);
            // 
            // openFileDialogFile
            // 
            this.openFileDialogFile.Filter = "GRAPHML FILES (*.graphml)|*.graphml";
            this.openFileDialogFile.Title = "Select a \".graphml\" file";
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(21, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 31);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Turquoise;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(215, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 24);
            this.panel2.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(21, 88);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 31);
            this.panel3.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightBlue;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(215, 93);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 24);
            this.panel4.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.hilfeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(762, 30);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.öffnenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(59, 26);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // öffnenToolStripMenuItem
            // 
            this.öffnenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AusgabeortÖffnenToolStripMenuItem1,
            this.DiagrammÖffnenToolStripMenuItem});
            this.öffnenToolStripMenuItem.Name = "öffnenToolStripMenuItem";
            this.öffnenToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.öffnenToolStripMenuItem.Text = "Öffnen";
            // 
            // AusgabeortÖffnenToolStripMenuItem1
            // 
            this.AusgabeortÖffnenToolStripMenuItem1.Image = global::CodeGenerator.GUI.Properties.Resources.open_folder_icon;
            this.AusgabeortÖffnenToolStripMenuItem1.Name = "AusgabeortÖffnenToolStripMenuItem1";
            this.AusgabeortÖffnenToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.AusgabeortÖffnenToolStripMenuItem1.Size = new System.Drawing.Size(312, 26);
            this.AusgabeortÖffnenToolStripMenuItem1.Text = "Ausgabeort öffnen";
            this.AusgabeortÖffnenToolStripMenuItem1.Click += new System.EventHandler(this.AusgabeortÖffnenToolStripMenuItem1_Click);
            this.AusgabeortÖffnenToolStripMenuItem1.MouseLeave += new System.EventHandler(this.AusgabeortÖffnenToolStripMenuItem1_MouseLeave);
            this.AusgabeortÖffnenToolStripMenuItem1.MouseHover += new System.EventHandler(this.AusgabeortÖffnenToolStripMenuItem1_MouseHover);
            // 
            // DiagrammÖffnenToolStripMenuItem
            // 
            this.DiagrammÖffnenToolStripMenuItem.Image = global::CodeGenerator.GUI.Properties.Resources.diagram_icon;
            this.DiagrammÖffnenToolStripMenuItem.Name = "DiagrammÖffnenToolStripMenuItem";
            this.DiagrammÖffnenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.DiagrammÖffnenToolStripMenuItem.Size = new System.Drawing.Size(312, 26);
            this.DiagrammÖffnenToolStripMenuItem.Text = "Klassendiagramm öffnen";
            this.DiagrammÖffnenToolStripMenuItem.Click += new System.EventHandler(this.DiagrammÖffnenToolStripMenuItem_Click);
            this.DiagrammÖffnenToolStripMenuItem.MouseLeave += new System.EventHandler(this.KlassendiagrammÖffnenToolStripMenuItem_MouseLeave);
            this.DiagrammÖffnenToolStripMenuItem.MouseHover += new System.EventHandler(this.KlassendiagrammÖffnenToolStripMenuItem_MouseHover);
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hilfeAnzeigenLassenToolStripMenuItem});
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(55, 26);
            this.hilfeToolStripMenuItem.Text = "Hilfe";
            this.hilfeToolStripMenuItem.MouseLeave += new System.EventHandler(this.HilfeToolStripMenuItem_MouseLeave);
            this.hilfeToolStripMenuItem.MouseHover += new System.EventHandler(this.HilfeToolStripMenuItem_MouseHover);
            // 
            // hilfeAnzeigenLassenToolStripMenuItem
            // 
            this.hilfeAnzeigenLassenToolStripMenuItem.Image = global::CodeGenerator.GUI.Properties.Resources.question_mark_symbol;
            this.hilfeAnzeigenLassenToolStripMenuItem.Name = "hilfeAnzeigenLassenToolStripMenuItem";
            this.hilfeAnzeigenLassenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.hilfeAnzeigenLassenToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.hilfeAnzeigenLassenToolStripMenuItem.Text = "Hilfe anzeigen";
            this.hilfeAnzeigenLassenToolStripMenuItem.Click += new System.EventHandler(this.HilfeToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 431);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(762, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 16);
            // 
            // PreviewTableLayoutPanel
            // 
            this.PreviewTableLayoutPanel.ColumnCount = 1;
            this.PreviewTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PreviewTableLayoutPanel.Controls.Add(this.PreviewTextBox, 0, 0);
            this.PreviewTableLayoutPanel.Location = new System.Drawing.Point(21, 171);
            this.PreviewTableLayoutPanel.Name = "PreviewTableLayoutPanel";
            this.PreviewTableLayoutPanel.RowCount = 1;
            this.PreviewTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PreviewTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 257F));
            this.PreviewTableLayoutPanel.Size = new System.Drawing.Size(733, 257);
            this.PreviewTableLayoutPanel.TabIndex = 12;
            // 
            // PreviewTextBox
            // 
            this.PreviewTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.PreviewTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PreviewTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PreviewTextBox.ForeColor = System.Drawing.Color.White;
            this.PreviewTextBox.Location = new System.Drawing.Point(3, 3);
            this.PreviewTextBox.Name = "PreviewTextBox";
            this.PreviewTextBox.ReadOnly = true;
            this.PreviewTextBox.Size = new System.Drawing.Size(727, 251);
            this.PreviewTextBox.TabIndex = 0;
            this.PreviewTextBox.Text = "Hier steht nachher der generierte Code.";
            this.PreviewTextBox.MouseLeave += new System.EventHandler(this.PreviewTextBox_MouseLeave);
            this.PreviewTextBox.MouseHover += new System.EventHandler(this.PreviewTextBox_MouseHover);
            // 
            // PreviewFensterLabel
            // 
            this.PreviewFensterLabel.AutoSize = true;
            this.PreviewFensterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreviewFensterLabel.Location = new System.Drawing.Point(27, 137);
            this.PreviewFensterLabel.Name = "PreviewFensterLabel";
            this.PreviewFensterLabel.Size = new System.Drawing.Size(154, 25);
            this.PreviewFensterLabel.TabIndex = 13;
            this.PreviewFensterLabel.Text = "Preview-Fenster";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.MediumPurple;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Location = new System.Drawing.Point(21, 137);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(10, 28);
            this.panel5.TabIndex = 15;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Orange;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Location = new System.Drawing.Point(780, 140);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(10, 28);
            this.panel6.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(786, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "Beispiel Klassendiagramm";
            // 
            // exampleDiagramPictureBox
            // 
            this.exampleDiagramPictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.exampleDiagramPictureBox.Image = global::CodeGenerator.GUI.Properties.Resources.BeispielDiagramm1;
            this.exampleDiagramPictureBox.Location = new System.Drawing.Point(760, 174);
            this.exampleDiagramPictureBox.Name = "exampleDiagramPictureBox";
            this.exampleDiagramPictureBox.Size = new System.Drawing.Size(841, 419);
            this.exampleDiagramPictureBox.TabIndex = 16;
            this.exampleDiagramPictureBox.TabStop = false;
            this.exampleDiagramPictureBox.MouseLeave += new System.EventHandler(this.ExampleDiagramPictureBox_MouseLeave);
            this.exampleDiagramPictureBox.MouseHover += new System.EventHandler(this.ExampleDiagramPictureBox_MouseHover);
            // 
            // FilePictureBox
            // 
            this.FilePictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.FilePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FilePictureBox.Location = new System.Drawing.Point(228, 51);
            this.FilePictureBox.Name = "FilePictureBox";
            this.FilePictureBox.Size = new System.Drawing.Size(355, 24);
            this.FilePictureBox.TabIndex = 5;
            this.FilePictureBox.TabStop = false;
            // 
            // OutputPictureBox
            // 
            this.OutputPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.OutputPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OutputPictureBox.Location = new System.Drawing.Point(228, 93);
            this.OutputPictureBox.Name = "OutputPictureBox";
            this.OutputPictureBox.Size = new System.Drawing.Size(355, 24);
            this.OutputPictureBox.TabIndex = 6;
            this.OutputPictureBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(762, 453);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exampleDiagramPictureBox);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.PreviewFensterLabel);
            this.Controls.Add(this.PreviewTableLayoutPanel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.GenerateButton);
            this.Controls.Add(this.PathOutputLabel);
            this.Controls.Add(this.SelectOutputButton);
            this.Controls.Add(this.PathModelLabel);
            this.Controls.Add(this.SelectFileButton);
            this.Controls.Add(this.FilePictureBox);
            this.Controls.Add(this.OutputPictureBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(780, 500);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CodeGenerator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.PreviewTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exampleDiagramPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectFileButton;
        private System.Windows.Forms.Label PathModelLabel;
        private System.Windows.Forms.Button SelectOutputButton;
        private System.Windows.Forms.Label PathOutputLabel;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.OpenFileDialog openFileDialogFile;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogOutput;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox FilePictureBox;
        private System.Windows.Forms.PictureBox OutputPictureBox;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hilfeAnzeigenLassenToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TableLayoutPanel PreviewTableLayoutPanel;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label PreviewFensterLabel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.RichTextBox PreviewTextBox;
        private System.Windows.Forms.ToolStripMenuItem öffnenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AusgabeortÖffnenToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem DiagrammÖffnenToolStripMenuItem;
        private System.Windows.Forms.PictureBox exampleDiagramPictureBox;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label1;
    }
}

