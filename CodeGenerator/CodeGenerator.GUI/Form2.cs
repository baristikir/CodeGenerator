using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace CodeGenerator.GUI
{
    public partial class Form2 : Form
    {
        public Form2(string message)
        {
            InitializeComponent();

            // Nachdem das Form erstellt wird, wird das Label mit einer Message überschrieben,
            // die den Nutzer auf einen Fehler hinweist.
            ErrorDescribtionLabel.Text = message;
        }

        /// <summary>
        /// Wenn Der Ok-Button geklickt wird, wird das Form geschlossen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OkErrorButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
