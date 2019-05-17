using LecturaDeTextos.AnalizadorLexico;
using LecturaDeTextos.Transversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LecturaDeTextos.AnalizadorSintactico
{
    public class AnalisisSintatico
    {
        private bool depurar = false;
        private AnalisisLexico analex = new AnalizadorLexico.AnalisisLexico();
        private ComponenteLexico componente;
        private String cadenaCategorias;
        private String cadenaLexemas;
        private String causa;
        private String falla;
        private String solucion;

        public void analizar()
        {

            try
            {
            depurar = false;
            depurarGramatica("Iniciando analisis sintáctico");
            cadenaCategorias = "";
            cadenaLexemas = "";
            

            componente = analex.analizar();
            expresion();

            if (ManejadorErrores.obtenerManejadorErrores().hayErrores())
            {
                MessageBox.Show("El analisis ha terminado. el programa esta mal escrito, verifique el detalle ");
            }
            else
            {
                if("FIN ARCHIVO".Equals(componente.Categoria))
                {
                    MessageBox.Show("El programa esta bien escrito");
                }
                else
                {
                    MessageBox.Show("aunque esta bien escrito, faltaron componentes por evaluar.");
                }
            }

            depurarGramatica("Finalizando analisis sintáctico");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
               
            }
        }

        //<Expresion> := <Termino><ExpresionPrima>
        private void expresion()
        {
            depurarGramatica("Iniciando evaluacion  de regla <expresion>");

            termino();
            expresionPrima();

            depurarGramatica("finalizando  evaluacion  de regla <expresion>");

        }

        //<Termino> := <Factor><TerminoPrima>
        private void termino()
        {
            depurarGramatica("Iniciando evaluacion  de regla <termino>");

            factor();
            terminoPrima();
            depurarGramatica("finalizando  evaluacion  de regla <termino>");

        }

        //<ExpresionPrima> := SUMA<Expresion>|RESTA<Expresion>|Epsilon
        private void expresionPrima()
        {
            depurarGramatica("Iniciando evaluacion  de regla <expresionPrima>");

            if ("SUMA".Equals(componente.Categoria))
            {
                obtenerComponente("SUMA");
                expresion();
            }
            else if ("RESTA".Equals(componente.Categoria))
            {
                obtenerComponente("RESTA");
                expresion();
            }

            depurarGramatica("finalizando  evaluacion  de regla <expresionPrima>");

        }

        //<Factor> := NUMERO ENTERO|NUMERO DECIMAL|PARENTESIS ABRE<Expresion>PARENTESIS CIERRA
        private void factor()
        {
            depurarGramatica("Iniciando evaluacion  de regla <factor>");

            if ("NUMERO ENTERO".Equals(componente.Categoria))
            {
                obtenerComponente("NUMERO ENTERO");
           
            }
            else if ("NUMERO DECIMAL".Equals(componente.Categoria))
            {
                obtenerComponente("NUMERO DECIMAL");
             
            }
            else if ("PARENTESIS ABRE".Equals(componente.Categoria))
            {
                obtenerComponente("PARENTESIS ABRE");
                expresion();
                obtenerComponente("PARENTESIS CIERRA");

            }
            else
            {
                causa = "Se esperaba NUMERO ENTERO o NUMERO DECIMAL O PARENTESIS ABRE y recibi " + componente.Categoria;
                falla = "Problemas en la validacion de la gramatica que no la hace valida";
                solucion = "Asegure que se tenga NUMERO ENTERO o NUMERO DECIMAL O PARENTESIS ABRE  en el lugar donde se ha presentado el error";
                ManejadorErrores.obtenerManejadorErrores().agregarError(formarError(componente.Lexema, causa, falla, solucion));
                throw new Exception("No es posible  continuar con el analisis, verifique y solucione los errores");
            }

            depurarGramatica("finalizando  evaluacion  de regla <factor>");

        }

        //<TerminoPrima> := MULTIPLICACION<Termino>|DIVISION<Termino>|Epsilon
        private void terminoPrima()
        {
            depurarGramatica("Iniciando evaluacion  de regla <TerminoPrima>");

            if ("MULTIPLICACION".Equals(componente.Categoria))
            {
                obtenerComponente("MULTIPLICACION");
                termino();
            }
            else if ("DIVISION".Equals(componente.Categoria))
            {
                obtenerComponente("DIVISION");
                termino();
            }

            depurarGramatica("finalizando  evaluacion  de regla <TerminoPrima>");

        }

        private void depurarGramatica(String mensage)
        {
            if (depurar)
            {
                MessageBox.Show(mensage);
            }
        }

        private void imprimirDerivacion()
        {
            cadenaCategorias += "->" + componente.Categoria;
            cadenaLexemas += "->" + componente.Lexema;
            depurarGramatica(cadenaCategorias + "\n" + cadenaLexemas);
        }

        private void obtenerComponente(String categoriaValida)
        {
            if(componente.Categoria.Equals(categoriaValida))
            {
                imprimirDerivacion();
                componente = analex.analizar();
            }
            else
            {
                causa = "Se esperaba " + categoriaValida + "y recibio " + componente.Categoria;
                falla = "Problemas en la validacion de la gramatica que no la hace valida";
                solucion = "Asegure que se tenga " + categoriaValida + " en el lugar donde se ha presentado el error";
                ManejadorErrores.obtenerManejadorErrores().agregarError(formarError(componente.Lexema, causa, falla, solucion));
            }
        }

        private Error formarError(String lexema, String causa, String falla, String solucion)
        {
            return Error.Crear(lexema, "Error", componente.numeroLinea, componente.posicionInicial, componente.posicionFinal, 
                causa, falla, solucion, TipoError.SINTACTICO);
        }
    }
}
