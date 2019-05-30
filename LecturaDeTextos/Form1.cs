using System;
using System.Linq;
using System.Windows.Forms;
using LecturaDeTextos.Transversal;
using LecturaDeTextos.AnalizadorLexico;
using LecturaDeTextos.AnalizadorSintactico;
using System.Drawing;

namespace LecturaDeTextos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }        
        
        private void buttonCargarConsola_Click_1(object sender, EventArgs e)
        {

            if (!(textBoxPorConsola.Text == ""))
            {
                Cache cache = Cache.obtenerCache();
                string[] aLines = textBoxPorConsola.Text.Split('\r');

                string cadena = "";
                foreach (string line in aLines)
                {
                    cadena += line;
                }

                string[] lineas = cadena.Split('\n');
                for (int ins = 0; ins < lineas.Length; ins++)
                {
                    cache.agregarLinea(new Linea(ins + 1, lineas.ElementAt(ins)));
                }
                MessageBox.Show("Se cargo correctamente la chache");

            }
            else
            {
                MessageBox.Show("no se ha ingresado texto, intentelo de nuevo");
            }
        }

        private void toolLoadCache_Click(object sender, EventArgs e)
        {
            if (!(textBoxPorConsola.Text == ""))
            {
                Cache cache = Cache.obtenerCache();
                string[] aLines = textBoxPorConsola.Text.Split('\r');

                string cadena = "";
                foreach (string line in aLines)
                {
                    cadena += line;
                }

                string[] lineas = cadena.Split('\n');
                for (int ins = 0; ins < lineas.Length; ins++)
                {
                    cache.agregarLinea(new Linea(ins + 1, lineas.ElementAt(ins)));
                }

                imgStatusAnalysis.Image = Image.FromFile("../../Contenido/success.png");
                lblStatusAnalysis.Text = "Se cargó la caché correctamente";
            }
            else
            {
                imgStatusAnalysis.Image = Image.FromFile("../../Contenido/error.png");
                lblStatusAnalysis.Text = "No se ha ingresado texto. Por favor revise e intente de nuevo";
            }
        }

        private void toolLexicAnalysis_Click(object sender, EventArgs e)
        {
            AnalisisLexico analex = new AnalisisLexico();

            try
            {
                ComponenteLexico tmp = analex.analizar();
                int fila = 0;
                while (!"@EOF@".Equals(tmp.Lexema))
                {
                    TablaSimbolos.Rows.Add();

                    TablaSimbolos[0, fila].Value = fila + 1;
                    TablaSimbolos[1, fila].Value = tmp.tipo;
                    TablaSimbolos[2, fila].Value = tmp.Lexema;
                    TablaSimbolos[3, fila].Value = tmp.Categoria;
                    TablaSimbolos[4, fila].Value = tmp.numeroLinea;
                    TablaSimbolos[5, fila].Value = tmp.posicionInicial;
                    TablaSimbolos[6, fila].Value = tmp.posicionFinal;
                    fila++;

                    TablaErrores.DataSource = ManejadorErrores.obtenerManejadorErrores().ObtenerErroresTotales();
                    TablaReservadas.DataSource = TablaPalabrasReservadas.obtenerTablaPalabrasReservadas().obtenerPalabrasReservadas();
                    tmp = analex.analizar();
                }
                imgStatusAnalysis.Image = Image.FromFile("../../Contenido/success.png");
                lblStatusAnalysis.Text = "El análisis léxico se ejecutó correctamente.";
            }
            catch (Exception exp)
            {
                imgStatusAnalysis.Image = Image.FromFile("../../Contenido/error.png");
                lblStatusAnalysis.Text = "El análisis léxico falló";
                MessageBox.Show(exp.Message);
            }
        }

        private void toolSemanticAnalysis_Click(object sender, EventArgs e)
        {
            AnalisisSintactico analix = new AnalisisSintactico();
            analix.analizar();
            TablaErrores.DataSource = ManejadorErrores.obtenerManejadorErrores().ObtenerErroresTotales();

            if (ManejadorErrores.obtenerManejadorErrores().hayErrores())
            {
                imgStatusAnalysis.Image = Image.FromFile("../../Contenido/error.png");
                lblStatusAnalysis.Text = "El análisis sintáctico falló";
            }
            else
            {
                imgStatusAnalysis.Image = Image.FromFile("../../Contenido/success.png");
                lblStatusAnalysis.Text = "El análisis sintáctico se ejecutó correctamente.";
            }
        }

        private void toolRestoreAnalysis_Click(object sender, EventArgs e)
        {
            textBoxPorConsola.Clear();
            TablaLiterales.limpiarTabla();
            TablaMaestro.limpiarTabla();
            TablaDummy.limpiarTabla();
            Transversal.TablaSimbolos.limpiarTabla();
            Cache.obtenerCache().limpiarCache();

            imgStatusAnalysis.Image = Image.FromFile("../../Contenido/success.png");
            lblStatusAnalysis.Text = "El análisis ha sido restablecido.";
        }
    }
}
