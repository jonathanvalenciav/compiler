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
    class AnalisisSintactico
    {
        private bool depurar = false;
        private AnalisisLexico analisisLexico = new AnalisisLexico();
        private ComponenteLexico componente;
        private String cadenaCategorias = "";
        private String cadenaLemexas = "";

        public void analizar()
        {
            try
            {
                depurar = false;
                depurarGramatica("Iniciando analisis sintactico");
                cadenaCategorias = "";
                cadenaLemexas = "";

                componente = analisisLexico.analizar();
                Gramatica();

                if (Transversal.ManejadorErrores.obtenerManejadorErrores().hayErrores())
                {
                    MessageBox.Show("El analisis ha terminado. El programa está mal escrito. Verifique el detalle");
                }
                else
                {
                    if ("FIN DE ARCHIVO".Equals(componente.Categoria))
                    {
                        MessageBox.Show("El programa está bien escrito.");
                    }
                    else
                    {
                        MessageBox.Show("Aunque está bien escrita, faltaron componentes por evaluar.");
                    }
                }
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message);
            }

            depurarGramatica("Finalizando analisis sintactico");
        }

        // <Gramatica> := SELECT <Campos> FROM <Tablas> | SELECT <Campos> FROM <Tablas> <Opcionales>
        private void Gramatica()
        {
            depurarGramatica("Iniciando evaluación regla <Gramatica>");

            getComponente("SELECT");
            Campos();
            getComponente("FROM");
            Tablas();

            if ("WHERE".Equals(componente.Categoria) || "ORDER".Equals(componente.Categoria))
            {
                Opcionales();
            }

            depurarGramatica("Finalizando evaluación regla <Gramatica>");
        }

        // <Opcionales> := WHERE <Condiciones> | ORDER BY <Ordenadores> | WHERE <Condiciones> ORDER BY <Ordenadores>
        private void Opcionales()
        {
            depurarGramatica("Iniciando evaluación regla <Opcionales>");

            if ("WHERE".Equals(componente.Categoria))
            {
                getComponente("WHERE");
                Condiciones();
                if ("ORDER".Equals(componente.Categoria))
                {
                    getComponente("ORDER");
                    getComponente("BY");
                    Ordenadores();
                }
            }
            else if ("ORDER".Equals(componente.Categoria))
            {
                getComponente("ORDER");
                getComponente("BY");
                Ordenadores();
            }

            depurarGramatica("Finalizando evaluación regla <Opcionales>");
        }

        // <Campos> := CAMPO | CAMPO SEPARADOR <Campos>
        private void Campos()
        {
            depurarGramatica("Iniciando evaluación regla <Campos>");

            getComponente("CAMPO");
            if ("DELIMITADOR".Equals(componente.Categoria))
            {
                getComponente("DELIMITADOR");
                Campos();
            }

            depurarGramatica("Finalizando evaluación regla <Campos>");
        }

        // <Tablas> := TABLA | TABLA SEPARADOR <Tablas>
        private void Tablas()
        {
            depurarGramatica("Iniciando evaluación regla <Tablas>");

            getComponente("TABLA");
            if ("DELIMITADOR".Equals(componente.Categoria))
            {
                getComponente("DELIMITADOR");
                Tablas();
            }

            depurarGramatica("Finalizando evaluación regla <Tablas>");
        }

        // <Condiciones> := <Operando> <Operador> <Operando> | <Operando> <Operador> <Operando> <Conector> <Condiciones>
        private void Condiciones()
        {
            depurarGramatica("Iniciando evaluación regla <Condiciones>");

            Operando();
            Operador();
            Operando();

            if ("AND".Equals(componente.Categoria) || "OR".Equals(componente.Categoria))
            {
                Conector();
                Condiciones();
            }

            depurarGramatica("Finalizando evaluación regla <Condiciones>");
        }

        // <Operando> := CAMPO | LITERAL | <Numero>
        private void Operando()
        {
            depurarGramatica("Iniciando evaluación regla <Operando>");
            if ("CAMPO".Equals(componente.Categoria))
            {
                getComponente("CAMPO");
            }
            else if ("LITERAL".Equals(componente.Categoria))
            {
                getComponente("LITERAL");
            }
            else
            {
                Numero();
            }
            depurarGramatica("Finalizando evaluación regla <Operando>");
        }

        // <Numero> := NUMERO ENTERO | NUMERO DECIMAL
        private void Numero()
        {
            depurarGramatica("Iniciando evaluación regla <Numero>");
            if ("NUMERO ENTERO".Equals(componente.Categoria))
            {
                getComponente("NUMERO ENTERO");
            }
            else if ("NUMERO DECIMAL".Equals(componente.Categoria))
            {
                getComponente("NUMERO DECIMAL");
            }

            depurarGramatica("Finalizando evaluación regla <Numero>");
        }

        // <Operador> := MAYOR QUE | MENOR QUE | IGUAL QUE | MAYOR O IGUAL QUE | MENOR O IGUAL QUE | DIFERENTE QUE
        private void Operador()
        {
            depurarGramatica("Iniciando evaluación regla <Operador>");

            if ("MAYOR QUE".Equals(componente.Categoria))
            {
                getComponente("MAYOR QUE");
            }
            else if ("MENOR QUE".Equals(componente.Categoria))
            {
                getComponente("MENOR QUE");
            }
            else if ("IGUAL QUE".Equals(componente.Categoria))
            {
                getComponente("IGUAL QUE");
            }
            else if ("MAYOR O IGUAL QUE".Equals(componente.Categoria))
            {
                getComponente("MAYOR O IGUAL QUE");
            }
            else if ("MENOR O IGUAL QUE".Equals(componente.Categoria))
            {
                getComponente("MENOR O IGUAL QUE");
            }
            else if ("DIFERENTE QUE".Equals(componente.Categoria))
            {
                getComponente("DIFERENTE QUE");
            }

            depurarGramatica("Finalizando evaluación regla <Operador>");
        }

        // <Conector> := CONECTOR Y | CONECTOR O
        private void Conector()
        {
            depurarGramatica("Iniciando evaluación regla <Conector>");

            if ("AND".Equals(componente.Categoria))
            {
                getComponente("AND");
            }
            else if ("OR".Equals(componente.Categoria))
            {
                getComponente("OR");
            }

            depurarGramatica("Finalizando evaluación regla <Conector>");
        }

        // <Ordenadores> := <Campos> | <Campos> <Criterio> | <Indices> | <Indices> <Criterio>
        private void Ordenadores()
        {
            depurarGramatica("Iniciando evaluación regla <Ordenadores>");

            if ("CAMPO".Equals(componente.Categoria))
            {
                getComponente("CAMPO");
                if ("ASC".Equals(componente.Categoria) || "DESC".Equals(componente.Categoria))
                {
                    Criterio();
                }
            }
            else if ("NUMERO ENTERO".Equals(componente.Categoria))
            {
                Indices();
                if ("ASC".Equals(componente.Categoria) || "DESC".Equals(componente.Categoria))
                {
                    Criterio();
                }
            }

            depurarGramatica("Finalizando evaluación regla <Ordenadores>");
        }

        // <Indices> := NUMERO ENTERO | NUMERO ENTERO SEPARADOR <Indices>
        private void Indices()
        {
            depurarGramatica("Iniciando evaluación regla <Indices>");

            getComponente("NUMERO ENTERO");

            if ("DELIMITADOR".Equals(componente.Categoria))
            {
                getComponente("DELIMITADOR");
                Indices();
            }

            depurarGramatica("Finalizando evaluación regla <Indices>");
        }

        // <Criterio> := ASCENDENTE | DESCENDENTE | ASCENDENTE SEPARADOR <Ordenadores> | DESCENDENTE SEPARADOR <Ordenadores>
        private void Criterio()
        {
            depurarGramatica("Iniciando evaluación regla <Criterio>");

            if ("ASC".Equals(componente.Categoria))
            {
                getComponente("ASC");
                if ("DELIMITADOR".Equals(componente.Categoria))
                {
                    getComponente("DELIMITADOR");
                    Ordenadores();
                }
            }
            else if ("DESC".Equals(componente.Categoria))
            {
                getComponente("DESC");
                if ("DELIMITADOR".Equals(componente.Categoria))
                {
                    getComponente("DELIMITADOR");
                    Ordenadores();
                }
            }

            depurarGramatica("Finalizando evaluación regla <Criterio>");
        }

        private void depurarGramatica(String mensaje)
        {
            if (depurar)
            {
                MessageBox.Show(mensaje);
            }
        }

        private void imprimirDerivacion()
        {
            cadenaCategorias = cadenaCategorias + "->" + componente.Categoria;
            cadenaLemexas = cadenaLemexas + "->" + componente.Lexema;
            depurarGramatica(cadenaCategorias + "\n" + cadenaLemexas);
        }

        private void getComponente(String categoriaValida)
        {
            if (componente.Categoria.Equals(categoriaValida))
            {
                imprimirDerivacion();
                componente = analisisLexico.analizar();
            }
            else
            {
                String causa = "Se esperaba " + categoriaValida + " y recibí " + componente.Categoria;
                String falla = "Problemas en la validacion de la gramatica que no la hace valida";
                String solucion = "Asegure que se tenga " + categoriaValida + " en el lugar donde se ha presentado el problema";
                ManejadorErrores.obtenerManejadorErrores().agregarError(formarError(componente.Lexema, causa, falla, solucion));
            }
        }

        private Error formarError(String Lexema, String Causa, String Falla, String Solucion)
        {
            return Error.Crear(Lexema, "Error", componente.numeroLinea, componente.posicionInicial,
                componente.posicionFinal, Causa, Falla, Solucion, TipoError.SINTACTICO);
        }
    }
}