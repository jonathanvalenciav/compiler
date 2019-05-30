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
    public class AnalisisSintacticoSQL
    {
        private bool depurar = false;
        private bool depurarOperacion = false;
        private AnalisisLexico analex = new AnalizadorLexico.AnalisisLexico();
        private ComponenteLexico componente;
        private String cadenaCategorias;
        private String cadenaLexemas;
        private String causa;
        private String falla;
        private String solucion;
        private Stack<double> pila = new Stack<double>();

        public void analizar()
        {

            try
            {
                depurar = false;
                depurarOperacion = true;
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
                    if ("FIN DE ARCHIVO".Equals(componente.Categoria))
                    {
                        if (pila.Count == 1)
                        {
                            MessageBox.Show("El programa esta bien escrito y el resultado de la operación es: " + pila.Pop());
                        }
                        else
                        {
                            MessageBox.Show("aunque esta bien escrito, faltaron componentes por evaluar.");
                        }
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

                if (!ManejadorErrores.obtenerManejadorErrores().hayErrores())
                {
                    Double derecho = pila.Pop();
                    Double izquierdo = pila.Pop();
                    Double resultado = izquierdo + derecho;
                    pila.Push(resultado);
                    depurarOperaciones(izquierdo + " + " + derecho + " = " + resultado);
                }
            }
            else if ("RESTA".Equals(componente.Categoria))
            {
                obtenerComponente("RESTA");
                expresion();

                if (!ManejadorErrores.obtenerManejadorErrores().hayErrores())
                {
                    Double derecho = pila.Pop();
                    Double izquierdo = pila.Pop();
                    Double resultado = izquierdo - derecho;
                    pila.Push(resultado);
                    depurarOperaciones(izquierdo + " - " + derecho + " = " + resultado);
                }
            }

            depurarGramatica("finalizando  evaluacion  de regla <expresionPrima>");

        }

        //<Factor> := NUMERO ENTERO|NUMERO DECIMAL|PARENTESIS ABRE<Expresion>PARENTESIS CIERRA
        private void factor()
        {
            depurarGramatica("Iniciando evaluacion  de regla <factor>");

            if ("NUMERO ENTERO".Equals(componente.Categoria))
            {
                pila.Push(Convert.ToDouble(componente.Lexema));
                obtenerComponente("NUMERO ENTERO");

            }
            else if ("NUMERO DECIMAL".Equals(componente.Categoria))
            {
                pila.Push(Convert.ToDouble(componente.Lexema));
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

                if (!ManejadorErrores.obtenerManejadorErrores().hayErrores()) {
                    Double derecho = pila.Pop();
                    Double izquierdo = pila.Pop();
                    Double resultado = izquierdo * derecho;
                    pila.Push(resultado);
                    depurarOperaciones(izquierdo + " * " + derecho + " = " + resultado);
                }
            }
            else if ("DIVISION".Equals(componente.Categoria))
            {
                obtenerComponente("DIVISION");
                termino();

                if (!ManejadorErrores.obtenerManejadorErrores().hayErrores())
                {
                    Double derecho = pila.Pop();
                    Double izquierdo = pila.Pop();
                    if (derecho == 0)
                    {
                        causa = "División por cero";
                        falla = "Problemas en las operaciones diviendo por cero";
                        solucion = "Asegure que que el divisor no sea cero.";
                        ManejadorErrores.obtenerManejadorErrores().agregarError(formarErrorSemantico(componente.Lexema, causa, falla, solucion));
                    }
                    else
                    {
                        Double resultado = izquierdo / derecho;
                        pila.Push(resultado);
                        depurarOperaciones(izquierdo + " / " + derecho + " = " + resultado);
                    }                   
                }
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

        private void depurarOperaciones(String mensage)
        {
            if (depurarOperacion)
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
            if (componente.Categoria.Equals(categoriaValida))
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

        private Error formarErrorSemantico(String lexema, String causa, String falla, String solucion)
        {
            return Error.Crear(lexema, "Error", componente.numeroLinea, componente.posicionInicial, componente.posicionFinal,
                causa, falla, solucion, TipoError.SEMANTICO);
        }
    }
}
