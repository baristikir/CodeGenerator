namespace CodeGenerator.GUI
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OkErrorButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ErrorDescribtionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // OkErrorButton
            // 
            this.OkErrorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OkErrorButton.Location = new System.Drawing.Point(155, 190);
            this.OkErrorButton.Name = "OkErrorButton";
            this.OkErrorButton.Size = new System.Drawing.Size(108, 34);
            this.OkErrorButton.TabIndex = 1;
            this.OkErrorButton.Text = "OK";
            this.OkErrorButton.UseVisualStyleBackColor = true;
            this.OkErrorButton.Click += new System.EventHandler(this.OkErrorButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CodeGenerator.GUI.Properties.Resources.error_image_icon;
            this.pictureBox1.Location = new System.Drawing.Point(12, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(111, 109);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // ErrorDescribtionLabel
            // 
            this.ErrorDescribtionLabel.Location = new System.Drawing.Point(129, 39);
            this.ErrorDescribtionLabel.Name = "ErrorDescribtionLabel";
            this.ErrorDescribtionLabel.Size = new System.Drawing.Size(302, 135);
            this.ErrorDescribtionLabel.TabIndex = 2;
            this.ErrorDescribtionLabel.Text = "Beschreibung des Fehlers.";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(443, 250);
            this.Controls.Add(this.ErrorDescribtionLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.OkErrorButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(461, 297);
            this.MinimumSize = new System.Drawing.Size(461, 297);
            this.Name = "Form2";
            this.ShowIcon = false;
            this.Text = "ERROR";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button OkErrorButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label ErrorDescribtionLabel;
    }
}