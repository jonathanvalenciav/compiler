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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonRestablecer = new System.Windows.Forms.Button();
            this.buttonCargarConsola = new System.Windows.Forms.Button();
            this.textBoxPorConsola = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Analizador = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.Simbolos = new System.Windows.Forms.TabPage();
            this.TablaSimbolos = new System.Windows.Forms.DataGridView();
            this.Identificador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lexema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroLinea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PosInicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PosFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Errores = new System.Windows.Forms.TabPage();
            this.TablaErrores = new System.Windows.Forms.DataGridView();
            this.Reservadas = new System.Windows.Forms.TabPage();
            this.TablaReservadas = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.Analizador.SuspendLayout();
            this.Simbolos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TablaSimbolos)).BeginInit();
            this.Errores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TablaErrores)).BeginInit();
            this.Reservadas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TablaReservadas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Script";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gainsboro;
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(499, 77);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 33);
            this.button1.TabIndex = 15;
            this.button1.Text = "Iniciar análisis léxico";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonRestablecer
            // 
            this.buttonRestablecer.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonRestablecer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonRestablecer.Location = new System.Drawing.Point(499, 120);
            this.buttonRestablecer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonRestablecer.Name = "buttonRestablecer";
            this.buttonRestablecer.Size = new System.Drawing.Size(178, 33);
            this.buttonRestablecer.TabIndex = 14;
            this.buttonRestablecer.Text = "Restablecer análisis";
            this.buttonRestablecer.UseVisualStyleBackColor = false;
            this.buttonRestablecer.Click += new System.EventHandler(this.buttonRestablecer_Click);
            // 
            // buttonCargarConsola
            // 
            this.buttonCargarConsola.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonCargarConsola.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonCargarConsola.Location = new System.Drawing.Point(499, 34);
            this.buttonCargarConsola.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCargarConsola.Name = "buttonCargarConsola";
            this.buttonCargarConsola.Size = new System.Drawing.Size(178, 33);
            this.buttonCargarConsola.TabIndex = 12;
            this.buttonCargarConsola.Text = "Cargar caché";
            this.buttonCargarConsola.UseVisualStyleBackColor = false;
            this.buttonCargarConsola.Click += new System.EventHandler(this.buttonCargarConsola_Click_1);
            // 
            // textBoxPorConsola
            // 
            this.textBoxPorConsola.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxPorConsola.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPorConsola.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxPorConsola.Location = new System.Drawing.Point(10, 37);
            this.textBoxPorConsola.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxPorConsola.Multiline = true;
            this.textBoxPorConsola.Name = "textBoxPorConsola";
            this.textBoxPorConsola.Size = new System.Drawing.Size(458, 200);
            this.textBoxPorConsola.TabIndex = 11;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Analizador);
            this.tabControl1.Controls.Add(this.Simbolos);
            this.tabControl1.Controls.Add(this.Errores);
            this.tabControl1.Controls.Add(this.Reservadas);
            this.tabControl1.Location = new System.Drawing.Point(12, 21);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(808, 312);
            this.tabControl1.TabIndex = 17;
            // 
            // Analizador
            // 
            this.Analizador.Controls.Add(this.button2);
            this.Analizador.Controls.Add(this.label1);
            this.Analizador.Controls.Add(this.textBoxPorConsola);
            this.Analizador.Controls.Add(this.button1);
            this.Analizador.Controls.Add(this.buttonCargarConsola);
            this.Analizador.Controls.Add(this.buttonRestablecer);
            this.Analizador.Location = new System.Drawing.Point(4, 29);
            this.Analizador.Name = "Analizador";
            this.Analizador.Padding = new System.Windows.Forms.Padding(3);
            this.Analizador.Size = new System.Drawing.Size(800, 279);
            this.Analizador.TabIndex = 0;
            this.Analizador.Text = "Analizador";
            this.Analizador.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Gainsboro;
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Location = new System.Drawing.Point(499, 163);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(178, 33);
            this.button2.TabIndex = 17;
            this.button2.Text = "Analisis Sintactico";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Simbolos
            // 
            this.Simbolos.Controls.Add(this.TablaSimbolos);
            this.Simbolos.Location = new System.Drawing.Point(4, 29);
            this.Simbolos.Name = "Simbolos";
            this.Simbolos.Padding = new System.Windows.Forms.Padding(3);
            this.Simbolos.Size = new System.Drawing.Size(800, 279);
            this.Simbolos.TabIndex = 1;
            this.Simbolos.Text = "Tabla de símbolos";
            this.Simbolos.UseVisualStyleBackColor = true;
            // 
            // TablaSimbolos
            // 
            this.TablaSimbolos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaSimbolos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Identificador,
            this.Tipo,
            this.Lexema,
            this.Categoria,
            this.NumeroLinea,
            this.PosInicial,
            this.PosFinal});
            this.TablaSimbolos.Location = new System.Drawing.Point(17, 27);
            this.TablaSimbolos.Name = "TablaSimbolos";
            this.TablaSimbolos.Size = new System.Drawing.Size(750, 218);
            this.TablaSimbolos.TabIndex = 18;
            // 
            // Identificador
            // 
            this.Identificador.HeaderText = "ID";
            this.Identificador.Name = "Identificador";
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            // 
            // Lexema
            // 
            this.Lexema.HeaderText = "Lexema";
            this.Lexema.Name = "Lexema";
            // 
            // Categoria
            // 
            this.Categoria.HeaderText = "Categoría";
            this.Categoria.Name = "Categoria";
            // 
            // NumeroLinea
            // 
            this.NumeroLinea.HeaderText = "NúmeroLinea";
            this.NumeroLinea.Name = "NumeroLinea";
            // 
            // PosInicial
            // 
            this.PosInicial.HeaderText = "PosInicial";
            this.PosInicial.Name = "PosInicial";
            // 
            // PosFinal
            // 
            this.PosFinal.HeaderText = "PosFinal";
            this.PosFinal.Name = "PosFinal";
            // 
            // Errores
            // 
            this.Errores.Controls.Add(this.TablaErrores);
            this.Errores.Location = new System.Drawing.Point(4, 29);
            this.Errores.Name = "Errores";
            this.Errores.Size = new System.Drawing.Size(800, 279);
            this.Errores.TabIndex = 3;
            this.Errores.Text = "Tabla de errores";
            this.Errores.UseVisualStyleBackColor = true;
            // 
            // TablaErrores
            // 
            this.TablaErrores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaErrores.Location = new System.Drawing.Point(26, 29);
            this.TablaErrores.Name = "TablaErrores";
            this.TablaErrores.Size = new System.Drawing.Size(756, 218);
            this.TablaErrores.TabIndex = 20;
            // 
            // Reservadas
            // 
            this.Reservadas.Controls.Add(this.TablaReservadas);
            this.Reservadas.Location = new System.Drawing.Point(4, 29);
            this.Reservadas.Name = "Reservadas";
            this.Reservadas.Size = new System.Drawing.Size(800, 279);
            this.Reservadas.TabIndex = 4;
            this.Reservadas.Text = "Tabla de palabras reservadas";
            this.Reservadas.UseVisualStyleBackColor = true;
            // 
            // TablaReservadas
            // 
            this.TablaReservadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaReservadas.Location = new System.Drawing.Point(22, 30);
            this.TablaReservadas.Name = "TablaReservadas";
            this.TablaReservadas.Size = new System.Drawing.Size(756, 218);
            this.TablaReservadas.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(836, 363);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Analizador Léxico";
            this.tabControl1.ResumeLayout(false);
            this.Analizador.ResumeLayout(false);
            this.Analizador.PerformLayout();
            this.Simbolos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TablaSimbolos)).EndInit();
            this.Errores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TablaErrores)).EndInit();
            this.Reservadas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TablaReservadas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonRestablecer;
        private System.Windows.Forms.Button buttonCargarConsola;
        private System.Windows.Forms.TextBox textBoxPorConsola;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Analizador;
        private System.Windows.Forms.TabPage Simbolos;
        private System.Windows.Forms.DataGridView TablaSimbolos;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage Errores;
        private System.Windows.Forms.TabPage Reservadas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Identificador;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lexema;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroLinea;
        private System.Windows.Forms.DataGridViewTextBoxColumn PosInicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn PosFinal;
        private System.Windows.Forms.DataGridView TablaErrores;
        private System.Windows.Forms.DataGridView TablaReservadas;
    }
}

