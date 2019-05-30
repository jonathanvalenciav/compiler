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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPorConsola = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Analizador = new System.Windows.Forms.TabPage();
            this.Simbolos = new System.Windows.Forms.TabPage();
            this.Errores = new System.Windows.Forms.TabPage();
            this.TablaErrores = new System.Windows.Forms.DataGridView();
            this.Reservadas = new System.Windows.Forms.TabPage();
            this.TablaReservadas = new System.Windows.Forms.DataGridView();
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.toolLoadCache = new System.Windows.Forms.ToolStripButton();
            this.toolLexicAnalysis = new System.Windows.Forms.ToolStripButton();
            this.toolSemanticAnalysis = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolRestoreAnalysis = new System.Windows.Forms.ToolStripButton();
            this.lblStatusAnalysis = new System.Windows.Forms.Label();
            this.imgStatusAnalysis = new System.Windows.Forms.PictureBox();
            this.PosFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PosInicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroLinea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lexema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Identificador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TablaSimbolos = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.Analizador.SuspendLayout();
            this.Simbolos.SuspendLayout();
            this.Errores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TablaErrores)).BeginInit();
            this.Reservadas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TablaReservadas)).BeginInit();
            this.toolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgStatusAnalysis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TablaSimbolos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Script";
            // 
            // textBoxPorConsola
            // 
            this.textBoxPorConsola.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxPorConsola.Font = new System.Drawing.Font("Lucida Console", 11F);
            this.textBoxPorConsola.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxPorConsola.Location = new System.Drawing.Point(10, 28);
            this.textBoxPorConsola.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxPorConsola.Multiline = true;
            this.textBoxPorConsola.Name = "textBoxPorConsola";
            this.textBoxPorConsola.Size = new System.Drawing.Size(783, 378);
            this.textBoxPorConsola.TabIndex = 11;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Analizador);
            this.tabControl1.Controls.Add(this.Simbolos);
            this.tabControl1.Controls.Add(this.Errores);
            this.tabControl1.Controls.Add(this.Reservadas);
            this.tabControl1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 42);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(808, 447);
            this.tabControl1.TabIndex = 17;
            // 
            // Analizador
            // 
            this.Analizador.Controls.Add(this.label1);
            this.Analizador.Controls.Add(this.textBoxPorConsola);
            this.Analizador.Location = new System.Drawing.Point(4, 29);
            this.Analizador.Name = "Analizador";
            this.Analizador.Padding = new System.Windows.Forms.Padding(3);
            this.Analizador.Size = new System.Drawing.Size(800, 414);
            this.Analizador.TabIndex = 0;
            this.Analizador.Text = "Analizador";
            this.Analizador.UseVisualStyleBackColor = true;
            // 
            // Simbolos
            // 
            this.Simbolos.Controls.Add(this.TablaSimbolos);
            this.Simbolos.Location = new System.Drawing.Point(4, 29);
            this.Simbolos.Name = "Simbolos";
            this.Simbolos.Padding = new System.Windows.Forms.Padding(3);
            this.Simbolos.Size = new System.Drawing.Size(800, 414);
            this.Simbolos.TabIndex = 1;
            this.Simbolos.Text = "Tabla de símbolos";
            this.Simbolos.UseVisualStyleBackColor = true;
            // 
            // Errores
            // 
            this.Errores.Controls.Add(this.TablaErrores);
            this.Errores.Location = new System.Drawing.Point(4, 29);
            this.Errores.Name = "Errores";
            this.Errores.Size = new System.Drawing.Size(800, 414);
            this.Errores.TabIndex = 3;
            this.Errores.Text = "Tabla de errores";
            this.Errores.UseVisualStyleBackColor = true;
            // 
            // TablaErrores
            // 
            this.TablaErrores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaErrores.Location = new System.Drawing.Point(17, 27);
            this.TablaErrores.Name = "TablaErrores";
            this.TablaErrores.Size = new System.Drawing.Size(756, 373);
            this.TablaErrores.TabIndex = 20;
            // 
            // Reservadas
            // 
            this.Reservadas.Controls.Add(this.TablaReservadas);
            this.Reservadas.Location = new System.Drawing.Point(4, 29);
            this.Reservadas.Name = "Reservadas";
            this.Reservadas.Size = new System.Drawing.Size(800, 414);
            this.Reservadas.TabIndex = 4;
            this.Reservadas.Text = "Tabla de palabras reservadas";
            this.Reservadas.UseVisualStyleBackColor = true;
            // 
            // TablaReservadas
            // 
            this.TablaReservadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaReservadas.Location = new System.Drawing.Point(17, 27);
            this.TablaReservadas.Name = "TablaReservadas";
            this.TablaReservadas.Size = new System.Drawing.Size(756, 371);
            this.TablaReservadas.TabIndex = 21;
            // 
            // toolbar
            // 
            this.toolbar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.toolbar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolLoadCache,
            this.toolLexicAnalysis,
            this.toolSemanticAnalysis,
            this.toolStripSeparator1,
            this.toolRestoreAnalysis});
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(832, 31);
            this.toolbar.TabIndex = 18;
            this.toolbar.Text = "toolbar";
            // 
            // toolLoadCache
            // 
            this.toolLoadCache.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolLoadCache.Image = ((System.Drawing.Image)(resources.GetObject("toolLoadCache.Image")));
            this.toolLoadCache.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolLoadCache.Name = "toolLoadCache";
            this.toolLoadCache.Size = new System.Drawing.Size(28, 28);
            this.toolLoadCache.Text = "Cargar caché";
            this.toolLoadCache.ToolTipText = "Cargar caché";
            this.toolLoadCache.Click += new System.EventHandler(this.toolLoadCache_Click);
            // 
            // toolLexicAnalysis
            // 
            this.toolLexicAnalysis.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolLexicAnalysis.Image = ((System.Drawing.Image)(resources.GetObject("toolLexicAnalysis.Image")));
            this.toolLexicAnalysis.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolLexicAnalysis.Name = "toolLexicAnalysis";
            this.toolLexicAnalysis.Size = new System.Drawing.Size(28, 28);
            this.toolLexicAnalysis.Text = "Análisis léxico";
            this.toolLexicAnalysis.ToolTipText = "Análisis léxico";
            this.toolLexicAnalysis.Click += new System.EventHandler(this.toolLexicAnalysis_Click);
            // 
            // toolSemanticAnalysis
            // 
            this.toolSemanticAnalysis.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSemanticAnalysis.Image = ((System.Drawing.Image)(resources.GetObject("toolSemanticAnalysis.Image")));
            this.toolSemanticAnalysis.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSemanticAnalysis.Name = "toolSemanticAnalysis";
            this.toolSemanticAnalysis.Size = new System.Drawing.Size(28, 28);
            this.toolSemanticAnalysis.Text = "Análisis semántico";
            this.toolSemanticAnalysis.ToolTipText = "Análisis semántico";
            this.toolSemanticAnalysis.Click += new System.EventHandler(this.toolSemanticAnalysis_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolRestoreAnalysis
            // 
            this.toolRestoreAnalysis.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolRestoreAnalysis.Image = ((System.Drawing.Image)(resources.GetObject("toolRestoreAnalysis.Image")));
            this.toolRestoreAnalysis.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolRestoreAnalysis.Name = "toolRestoreAnalysis";
            this.toolRestoreAnalysis.Size = new System.Drawing.Size(28, 28);
            this.toolRestoreAnalysis.Text = "Restablecer análisis";
            this.toolRestoreAnalysis.ToolTipText = "Restablecer análisis";
            this.toolRestoreAnalysis.Click += new System.EventHandler(this.toolRestoreAnalysis_Click);
            // 
            // lblStatusAnalysis
            // 
            this.lblStatusAnalysis.AutoSize = true;
            this.lblStatusAnalysis.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusAnalysis.Location = new System.Drawing.Point(36, 494);
            this.lblStatusAnalysis.Name = "lblStatusAnalysis";
            this.lblStatusAnalysis.Size = new System.Drawing.Size(0, 20);
            this.lblStatusAnalysis.TabIndex = 19;
            // 
            // imgStatusAnalysis
            // 
            this.imgStatusAnalysis.Location = new System.Drawing.Point(13, 497);
            this.imgStatusAnalysis.Name = "imgStatusAnalysis";
            this.imgStatusAnalysis.Size = new System.Drawing.Size(16, 16);
            this.imgStatusAnalysis.TabIndex = 20;
            this.imgStatusAnalysis.TabStop = false;
            // 
            // PosFinal
            // 
            this.PosFinal.HeaderText = "PosFinal";
            this.PosFinal.Name = "PosFinal";
            // 
            // PosInicial
            // 
            this.PosInicial.HeaderText = "PosInicial";
            this.PosInicial.Name = "PosInicial";
            // 
            // NumeroLinea
            // 
            this.NumeroLinea.HeaderText = "NúmeroLinea";
            this.NumeroLinea.Name = "NumeroLinea";
            // 
            // Categoria
            // 
            this.Categoria.HeaderText = "Categoría";
            this.Categoria.Name = "Categoria";
            // 
            // Lexema
            // 
            this.Lexema.HeaderText = "Lexema";
            this.Lexema.Name = "Lexema";
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            // 
            // Identificador
            // 
            this.Identificador.HeaderText = "ID";
            this.Identificador.Name = "Identificador";
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
            this.TablaSimbolos.Size = new System.Drawing.Size(744, 381);
            this.TablaSimbolos.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(832, 520);
            this.Controls.Add(this.imgStatusAnalysis);
            this.Controls.Add(this.lblStatusAnalysis);
            this.Controls.Add(this.toolbar);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compilador";
            this.tabControl1.ResumeLayout(false);
            this.Analizador.ResumeLayout(false);
            this.Analizador.PerformLayout();
            this.Simbolos.ResumeLayout(false);
            this.Errores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TablaErrores)).EndInit();
            this.Reservadas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TablaReservadas)).EndInit();
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgStatusAnalysis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TablaSimbolos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPorConsola;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Analizador;
        private System.Windows.Forms.TabPage Simbolos;
        private System.Windows.Forms.TabPage Errores;
        private System.Windows.Forms.TabPage Reservadas;
        private System.Windows.Forms.DataGridView TablaErrores;
        private System.Windows.Forms.DataGridView TablaReservadas;
        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolLoadCache;
        private System.Windows.Forms.ToolStripButton toolSemanticAnalysis;
        private System.Windows.Forms.ToolStripButton toolLexicAnalysis;
        private System.Windows.Forms.ToolStripButton toolRestoreAnalysis;
        private System.Windows.Forms.Label lblStatusAnalysis;
        private System.Windows.Forms.PictureBox imgStatusAnalysis;
        private System.Windows.Forms.DataGridView TablaSimbolos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Identificador;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lexema;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroLinea;
        private System.Windows.Forms.DataGridViewTextBoxColumn PosInicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn PosFinal;
    }
}

