namespace LecturaDeTextos
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonCargarArchivo = new System.Windows.Forms.Button();
            this.textBoxPorArchivo = new System.Windows.Forms.TextBox();
            this.buttonCargarConsola = new System.Windows.Forms.Button();
            this.textBoxPorConsola = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(442, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Carga de archivo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(126, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Carga por consola";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Silver;
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(274, 206);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 54);
            this.button1.TabIndex = 15;
            this.button1.Text = "Analisis Lexico";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // buttonCargarArchivo
            // 
            this.buttonCargarArchivo.BackColor = System.Drawing.Color.Silver;
            this.buttonCargarArchivo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonCargarArchivo.Location = new System.Drawing.Point(466, 206);
            this.buttonCargarArchivo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCargarArchivo.Name = "buttonCargarArchivo";
            this.buttonCargarArchivo.Size = new System.Drawing.Size(204, 54);
            this.buttonCargarArchivo.TabIndex = 14;
            this.buttonCargarArchivo.Text = "Cargar Archivo";
            this.buttonCargarArchivo.UseVisualStyleBackColor = false;
            // 
            // textBoxPorArchivo
            // 
            this.textBoxPorArchivo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBoxPorArchivo.Location = new System.Drawing.Point(363, 64);
            this.textBoxPorArchivo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxPorArchivo.Multiline = true;
            this.textBoxPorArchivo.Name = "textBoxPorArchivo";
            this.textBoxPorArchivo.Size = new System.Drawing.Size(307, 132);
            this.textBoxPorArchivo.TabIndex = 13;
            // 
            // buttonCargarConsola
            // 
            this.buttonCargarConsola.BackColor = System.Drawing.Color.Silver;
            this.buttonCargarConsola.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonCargarConsola.Location = new System.Drawing.Point(33, 206);
            this.buttonCargarConsola.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCargarConsola.Name = "buttonCargarConsola";
            this.buttonCargarConsola.Size = new System.Drawing.Size(233, 54);
            this.buttonCargarConsola.TabIndex = 12;
            this.buttonCargarConsola.Text = "Cargar Cache";
            this.buttonCargarConsola.UseVisualStyleBackColor = false;
            this.buttonCargarConsola.Click += new System.EventHandler(this.buttonCargarConsola_Click_1);
            // 
            // textBoxPorConsola
            // 
            this.textBoxPorConsola.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBoxPorConsola.Location = new System.Drawing.Point(33, 64);
            this.textBoxPorConsola.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxPorConsola.Multiline = true;
            this.textBoxPorConsola.Name = "textBoxPorConsola";
            this.textBoxPorConsola.Size = new System.Drawing.Size(322, 132);
            this.textBoxPorConsola.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(702, 299);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonCargarArchivo);
            this.Controls.Add(this.textBoxPorArchivo);
            this.Controls.Add(this.buttonCargarConsola);
            this.Controls.Add(this.textBoxPorConsola);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Analizador Léxico";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonCargarArchivo;
        private System.Windows.Forms.TextBox textBoxPorArchivo;
        private System.Windows.Forms.Button buttonCargarConsola;
        private System.Windows.Forms.TextBox textBoxPorConsola;
    }
}

