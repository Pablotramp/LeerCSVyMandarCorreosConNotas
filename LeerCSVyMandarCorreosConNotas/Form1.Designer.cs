namespace LeerCSVyMandarCorreosConNotas
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnCargarFichero = new System.Windows.Forms.Button();
            this.LblRutaFichero = new System.Windows.Forms.Label();
            this.BtnEnviarEmails = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // BtnCargarFichero
            // 
            this.BtnCargarFichero.Location = new System.Drawing.Point(113, 58);
            this.BtnCargarFichero.Name = "BtnCargarFichero";
            this.BtnCargarFichero.Size = new System.Drawing.Size(92, 23);
            this.BtnCargarFichero.TabIndex = 0;
            this.BtnCargarFichero.Text = "Cargar Fichero";
            this.BtnCargarFichero.UseVisualStyleBackColor = true;
            this.BtnCargarFichero.Click += new System.EventHandler(this.BtnCargarFichero_Click);
            // 
            // LblRutaFichero
            // 
            this.LblRutaFichero.AutoSize = true;
            this.LblRutaFichero.Location = new System.Drawing.Point(239, 63);
            this.LblRutaFichero.Name = "LblRutaFichero";
            this.LblRutaFichero.Size = new System.Drawing.Size(42, 13);
            this.LblRutaFichero.TabIndex = 1;
            this.LblRutaFichero.Text = "Fichero";
            // 
            // BtnEnviarEmails
            // 
            this.BtnEnviarEmails.Location = new System.Drawing.Point(113, 106);
            this.BtnEnviarEmails.Name = "BtnEnviarEmails";
            this.BtnEnviarEmails.Size = new System.Drawing.Size(92, 23);
            this.BtnEnviarEmails.TabIndex = 2;
            this.BtnEnviarEmails.Text = "Enviar Emails";
            this.BtnEnviarEmails.UseVisualStyleBackColor = true;
            this.BtnEnviarEmails.Click += new System.EventHandler(this.BtnEnviarEmails_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnEnviarEmails);
            this.Controls.Add(this.LblRutaFichero);
            this.Controls.Add(this.BtnCargarFichero);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCargarFichero;
        private System.Windows.Forms.Label LblRutaFichero;
        private System.Windows.Forms.Button BtnEnviarEmails;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

