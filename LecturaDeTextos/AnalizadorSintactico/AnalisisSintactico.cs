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
    public class AnalisisSintactico
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
            depurar = true;
            depurarGramatica("Iniciando analisis sintáctico");
            cadenaCategorias = "";
            cadenaLexemas = "";


            componente = analex.analizar();
            select();

            if (ManejadorErrores.obtenerManejadorErrores().hayErrores())
            {
                MessageBox.Show("El analisis ha terminado. el programa esta mal escrito, verifique el detalle ");
            }
            else
            {
                if("FIN DE ARCHIVO".Equals(componente.Categoria))
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

        // <Select> := SELECT <campo> FROM <tabla> <wherePrima> <orderByPrima>

        private void select()
        {
            depurarGramatica("Iniciando evaluación regla <select>");
            pedirComponente("SELECT");
            campo();
            pedirComponente("FROM");
            tabla();
            wherePrima();
            orderByPrima();
            depurarGramatica("Finalizando evaluación regla <select>");
        }

        // <wherePrima> := WHERE <condicion> | Epsilon

        private void wherePrima()
        {
            depurarGramatica("Iniciando evaluación regla <wherePrima>");
            if ("WHERE".Equals(componente.Categoria))
            {
                pedirComponente("WHERE");
                condicion();
            }
            depurarGramatica("Finalizando evaluación regla <wherePrima>");
        }

        // <orderByPrima> := ORDER BY <ordenadores> | Epsilon

        private void orderByPrima()
        {
            depurarGramatica("Iniciando evaluación regla <orderByPrima>");
            if ("ORDER".Equals(componente.Categoria))
            {
                pedirComponente("ORDER");
                pedirComponente("BY");
                ordenadores();
            }
            depurarGramatica("Finalizando evaluación regla <orderByPrima>");
        }

        // <campo> := CAMPO <campoPrima>

        private void campo()
        {
            depurarGramatica("Iniciando evaluación regla <campo>");
            pedirComponente("CAMPO");
            campoPrima();
            depurarGramatica("Finalizando evaluación regla <campo>");
        }

        // <campoPrima> := COMA <campo> | Epsilon

        private void campoPrima()
        {
            depurarGramatica("Iniciando evaluación regla <campoPrima>");
            if ("DELIMITADOR".Equals(componente.Categoria))
            {
                pedirComponente("DELIMITADOR");
                campo();
            }
            depurarGramatica("Finalizando evaluación regla <campoPrima>");
        }

        // <tabla> := TABLA <tablaPrima>

        private void tabla()
        {
            depurarGramatica("Iniciando evaluación regla <tabla>");
            pedirComponente("TABLA");
            tablaPrima();
            depurarGramatica("Finalizando evaluación regla <tabla>");
        }

        // <tablaPrima> := COMA <tabla> | Epsilon

        private void tablaPrima()
        {
            depurarGramatica("Iniciando evaluación regla <tablaPrima>");
            if ("DELIMITADOR".Equals(componente.Categoria))
            {
                pedirComponente("DELIMITADOR");
                tabla();
            }
            depurarGramatica("Finalizando evaluación regla <tablaPrima>");
        }

        // <condicion> := <operando> <operador> <operando> <condicionPrima>

        private void condicion()
        {
            depurarGramatica("Iniciando evaluación regla <condicion>");
            operando();
            operador();
            operando();
            condicionPrima();
            depurarGramatica("Finalizando evaluación regla <condicion>");
        }

        // <condicionPrima> := CONECTOR Y<condicion> | CONECTOR O <condicion> | Epsilon

        private void condicionPrima()
        {
            depurarGramatica("Iniciando evaluación regla <condicionPrima>");
            if ("AND".Equals(componente.Categoria))
            {
                pedirComponente("AND");
                condicion();
            }
            else if ("OR".Equals(componente.Categoria))
            {
                pedirComponente("OR");
                condicion();
            }
            depurarGramatica("Finalizando evaluación regla <condicionPrima>");
        }

        // <operando> := <campo> | LITERAL | NUMERO ENTERO | NUMERO DECIMAL

        private void operando()
        {
            depurarGramatica("Iniciando evaluación regla <operando>");


            if ("LITERAL".Equals(componente.Categoria))
            {
                pedirComponente("LITERAL");
            }
            else if ("NUMERO ENTERO".Equals(componente.Categoria))
            {
                pedirComponente("NUMERO ENTERO");
            }
            else if ("NUMERO DECIMAL".Equals(componente.Categoria))
            {
                pedirComponente("NUMERO DECIMAL");
            }
            else if ("CAMPO".Equals(componente.Categoria))
            {
                campo();
            }
            else
            {
                // Gestionar Error
                String causa = "Se esperaba un CAMPO, LITERAL o NUMERO y recibi " + componente.Categoria;
                String falla = "Problemas en la validación de la gramatica que no la hace valida.";
                String solucion = "Asegure que se tenga un CAMPO, LITERAL o NUMERO en el lugar donde se ha presentado el error";
                ManejadorErrores.obtenerManejadorErrores().agregarError(formarError(componente.Lexema, causa, falla, solucion));
                throw new Exception("No es posible continuar con el análisis sintáctico. Verifique y solucione los errores presentados.");
            }
            depurarGramatica("Finalizando evaluación regla <operando>");
        }

        // <operador> := MAYOR QUE | MENOR QUE | IGUAL QUE | MAYOR O IGUAL QUE | MENOR O IGUAL QUE | DIFERENTE QUE

        private void operador()
        {
            depurarGramatica("Iniciando evaluación regla <operador>");
            if ("MAYOR QUE".Equals(componente.Categoria))
            {
                pedirComponente("MAYOR QUE");
            }
            else if ("MENOR QUE".Equals(componente.Categoria))
            {
                pedirComponente("MENOR QUE");
            }
            else if ("IGUAL QUE".Equals(componente.Categoria))
            {
                pedirComponente("IGUAL QUE");
            }
            else if ("MAYOR O IGUAL QUE".Equals(componente.Categoria))
            {
                pedirComponente("MAYOR O IGUAL QUE");
            }
            else if ("MENOR O IGUAL QUE".Equals(componente.Categoria))
            {
                pedirComponente("MENOR O IGUAL QUE");
            }
            else if ("DIFERENTE QUE".Equals(componente.Categoria))
            {
                pedirComponente("DIFERENTE QUE");
            }
            else
            {
                // Gestionar Error
                String causa = "Se esperaba un operador y recibi " + componente.Categoria;
                String falla = "Problemas en la validación de la gramatica que no la hace valida.";
                String solucion = "Asegure que se tenga un operador en el lugar donde se ha presentado el error";
                ManejadorErrores.obtenerManejadorErrores().agregarError(formarError(componente.Lexema, causa, falla, solucion));
                throw new Exception("No es posible continuar con el análisis sintáctico. Verifique y solucione los errores presentados.");
            }
            depurarGramatica("Finalizando evaluación regla <operador>");
        }

        // <ordenadores> := <columna> ASCENDENTE | <columna> DESCENDENTE

        private void ordenadores()
        {
            depurarGramatica("Iniciando evaluación regla <ordenadores>");
            columna();
            if ("ASC".Equals(componente.Categoria))
            {
                pedirComponente("ASC");
            }
            else if ("DESC".Equals(componente.Categoria))
            {
                pedirComponente("DESC");
            }

            depurarGramatica("Finalizando evaluación regla <ordenadores>");
        }

        // <columna> := <campo> | <indice>

        private void columna()
        {
            depurarGramatica("Iniciando evaluación regla <columna>");
            if ("CAMPO".Equals(componente.Categoria))
            {
                campo();
            }
            else if ("NUMERO ENTERO".Equals(componente.Categoria))
            {
                indice();
            }
            else
            {
                // Gestionar Error
                String causa = "Se esperaba un INDICE o COLUMNA y recibi " + componente.Categoria;
                String falla = "Problemas en la validación de la gramatica que no la hace valida.";
                String solucion = "Asegure que se tenga un INDICE o COLUMNA en el lugar donde se ha presentado el error";
                ManejadorErrores.obtenerManejadorErrores().agregarError(formarError(componente.Lexema, causa, falla, solucion));
                throw new Exception("No es posible continuar con el análisis sintáctico. Verifique y solucione los errores presentados.");
            }
            depurarGramatica("Finalizando evaluación regla <columna>");
        }

        // <indice> := NUMERO ENTERO <indicePrima>

        private void indice()
        {
            depurarGramatica("Iniciando evaluación regla <indice>");
            if ("NUMERO ENTERO".Equals(componente.Categoria))
            {
                pedirComponente("NUMERO ENTERO");
                indicePrima();
            }
            depurarGramatica("Finalizando evaluación regla <indice>");
        }

        // <indicePrima> := COMA <indice> | Epsilon

        private void indicePrima()
        {
            depurarGramatica("Iniciando evaluación regla <indicePrima>");
            if ("DELIMITADOR".Equals(componente.Categoria))
            {
                pedirComponente("DELIMITADOR");
                indice();
            }
            depurarGramatica("Finalizando evaluación regla <indicePrima>");
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

        private void pedirComponente(String categoriaValida)
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
