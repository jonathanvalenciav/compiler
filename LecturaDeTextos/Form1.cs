using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LecturaDeTextos.Transversal;
using LecturaDeTextos.AnalizadorLexico;
using LecturaDeTextos.AnalizadorSintactico;

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

        private void buttonRestablecer_Click(object sender, EventArgs e)
        {
            textBoxPorConsola.Clear();
            TablaLiterales.limpiarTabla();
            TablaMaestro.limpiarTabla();
            TablaDummy.limpiarTabla();
            Transversal.TablaSimbolos.limpiarTabla();
            Cache.obtenerCache().limpiarCache();
            MessageBox.Show("Analisís restablecido.");




        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            // CODIGO
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
                    

                    //MessageBox.Show(tmp.Imprimir());



                }
              
            }

            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // CODIGO
                AnalisisSintactico analix = new AnalisisSintactico();
                analix.analizar();

        }


    }
}
