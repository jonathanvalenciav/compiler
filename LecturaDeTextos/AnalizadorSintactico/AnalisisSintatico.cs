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
            depurar = true;
            depurarGramatica("Iniciando analisis sintáctico");
            cadenaCategorias = "";
            cadenaLexemas = "";
            

            componente = analex.analizar();
            gramatica();

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

        // <Gramatica> := SELECT <campo> FROM <tabla> <wherePrima> <orderByPrima>

        private void gramatica()
        {
            depurarGramatica("Iniciando evaluación regla <gramatica>");
            obtenerComponente("IDENTIFICADOR");
            campo();
            obtenerComponente("IDENTIFICADOR");
            tabla();
            wherePrima();
            orderByPrima();
            depurarGramatica("Finalizando evaluación regla <gramatica>");
        }

        // <wherePrima> := WHERE <condicion> | Epsilon

        private void wherePrima()
        {
            depurarGramatica("Iniciando evaluación regla <wherePrima>");
            if ("IDENTIFICADOR".Equals(componente.Categoria))
            {
                obtenerComponente("IDENTIFICADOR");
                condicion();
            }
            depurarGramatica("Finalizando evaluación regla <wherePrima>");
        }

        // <orderByPrima> := ORDER BY <ordenadores> | Epsilon

        private void orderByPrima()
        {
            depurarGramatica("Iniciando evaluación regla <orderByPrima>");
            if ("IDENTIFICADOR".Equals(componente.Categoria))
            {
                obtenerComponente("IDENTIFICADOR");
                obtenerComponente("IDENTIFICADOR");
                ordenadores();
            }
            depurarGramatica("Finalizando evaluación regla <orderByPrima>");
        }

        // <campo> := CAMPO <campoPrima>

        private void campo()
        {
            depurarGramatica("Iniciando evaluación regla <campo>");
            obtenerComponente("IDENTIFICADOR");
            campoPrima();
            depurarGramatica("Finalizando evaluación regla <campo>");
        }

        // <campoPrima> := DELIMITADOR <campo> | Epsilon

        private void campoPrima()
        {
            depurarGramatica("Iniciando evaluación regla <campoPrima>");
            if ("DELIMITADOR".Equals(componente.Categoria))
            {
                obtenerComponente("DELIMITADOR");
                campo();
            }
            depurarGramatica("Finalizando evaluación regla <campoPrima>");
        }

        // <tabla> := TABLA <tablaPrima>

        private void tabla()
        {
            depurarGramatica("Iniciando evaluación regla <tabla>");
            obtenerComponente("TABLA");
            tablaPrima();
            depurarGramatica("Finalizando evaluación regla <tabla>");
        }

        // <tablaPrima> := DELIMITADOR <tabla> | Epsilon

        private void tablaPrima()
        {
            depurarGramatica("Iniciando evaluación regla <tablaPrima>");
            if ("DELIMITADOR".Equals(componente.Categoria))
            {
                obtenerComponente("DELIMITADOR");
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

        // <condicionPrima> := AND<condicion> | OR <condicion> | Epsilon

        private void condicionPrima()
        {
            depurarGramatica("Iniciando evaluación regla <condicionPrima>");
            if ("IDENTIFICADOR".Equals(componente.Categoria))
            {
                obtenerComponente("IDENTIFICADOR");
                condicion();
            }
            else if ("IDENTIFICADOR".Equals(componente.Categoria))
            {
                obtenerComponente("IDENTIFICADOR");
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
                obtenerComponente("LITERAL");
            }
            else if ("NÚMERO ENTERO".Equals(componente.Categoria))
            {
                obtenerComponente("NÚMERO ENTERO");
            }
            else if ("NÚMERO DECIMAL".Equals(componente.Categoria))
            {
                obtenerComponente("NÚMERO DECIMAL");
            }
            else
            {
                campo();
            }
            depurarGramatica("Finalizando evaluación regla <operando>");
        }

        // <operador> := MAYOR QUE | MENOR QUE | IGUAL QUE | MAYOR O IGUAL QUE | MENOR O IGUAL QUE | DIFERENTE QUE

        private void operador()
        {
            depurarGramatica("Iniciando evaluación regla <operador>");
            if ("MAYOR QUE".Equals(componente.Categoria))
            {
                obtenerComponente("MAYOR QUE");
            }
            else if ("MENOR QUE".Equals(componente.Categoria))
            {
                obtenerComponente("MENOR QUE");
            }
            else if ("IGUAL QUE".Equals(componente.Categoria))
            {
                obtenerComponente("IGUAL QUE");
            }
            else if ("MAYOR O IGUAL QUE".Equals(componente.Categoria))
            {
                obtenerComponente("MAYOR O IGUAL QUE");
            }
            else if ("MENOR O IGUAL QUE".Equals(componente.Categoria))
            {
                obtenerComponente("MENOR O IGUAL QUE");
            }
            else if ("DIFERENTE QUE".Equals(componente.Categoria))
            {
                obtenerComponente("DIFERENTE QUE");
            }
            depurarGramatica("Finalizando evaluación regla <operador>");
        }

        // <ordenadores> := <columna> ASC | <columna> DESC

        private void ordenadores()
        {
            depurarGramatica("Iniciando evaluación regla <ordenadores>");
            columna();
            if ("IDENTIFICADOR".Equals(componente.Categoria))
            {
                obtenerComponente("IDENTIFICADOR");
            }
            else if ("IDENTIFICADOR".Equals(componente.Categoria))
            {
                obtenerComponente("IDENTIFICADOR");
            }
            depurarGramatica("Finalizando evaluación regla <ordenadores>");
        }

        // <columna> := <campo> | <indice>

        private void columna()
        {
            depurarGramatica("Iniciando evaluación regla <columna>");
            columna();
            if ("CAMPO".Equals(componente.Categoria))
            {
                campo();
            }
            else if ("NÚMERO ENTERO".Equals(componente.Categoria))
            {
                indice();
            }
            depurarGramatica("Finalizando evaluación regla <columna>");
        }

        // <indice> := NUMERO ENTERO <indicePrima>

        private void indice()
        {
            depurarGramatica("Iniciando evaluación regla <indice>");
            if ("NÚMERO ENTERO".Equals(componente.Categoria))
            {
                obtenerComponente("NÚMERO ENTERO");
                indicePrima();
            }
            depurarGramatica("Finalizando evaluación regla <indice>");
        }

        // <indicePrima> := DELIMITADOR <indice>

        private void indicePrima()
        {
            depurarGramatica("Iniciando evaluación regla <indicePrima>");
            if ("DELIMITADOR".Equals(componente.Categoria))
            {
                obtenerComponente("DELIMITADOR");
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
