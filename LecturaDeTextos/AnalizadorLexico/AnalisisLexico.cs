using LecturaDeTextos.Transversal;
using System;

namespace LecturaDeTextos.AnalizadorLexico
{
    public class AnalisisLexico
    {
        private int puntero;
        private int numeroLineaActual = 0;
        private String contenidoLineaActual;
        private String caracterActual;
        private String causa;
        private String falla;
        private String solucion;

        public AnalisisLexico()
        {
            cargarNuevaLinea();
        }

        private void cargarNuevaLinea()
        {
            if (!"@EOF@".Equals(contenidoLineaActual))
            {
                numeroLineaActual++;
                puntero = 1;
                contenidoLineaActual = Cache.obtenerCache().obtenerLinea(numeroLineaActual).Contenido;
            }
        }

        private void leerSiguienteCaracter()
        {
            if ("@EOF@".Equals(contenidoLineaActual))
            {
                caracterActual = "@EOF@";
            }
            else if (puntero > contenidoLineaActual.Length)
            {
                caracterActual = "@FL@";
                puntero++;
            }
            else
            {
                caracterActual = contenidoLineaActual.Substring(puntero - 1, 1).ToUpper().ToString();
                puntero++;
            }
        }

        private void devolverPuntero()
        {
            puntero--;
        }

        public ComponenteLexico analizar()
        {
            int estadoActual = 0;
            bool continuarAnalisis = true;
            String lexema = "";
            ComponenteLexico componenteLexico = null;

            while (continuarAnalisis)
            {
                switch (estadoActual)
                {
                    case 0:
                        leerSiguienteCaracter();
                        while ("".Equals(caracterActual.Trim()))
                        {
                            leerSiguienteCaracter();
                        }
                        if ("C".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 1;
                        }
                        else if ("T".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 8;
                        }
                        else if (Char.IsLetter(caracterActual.ToCharArray()[0]) &&
                            !("C".Equals(caracterActual) || "T".Equals(caracterActual)))
                        {
                            lexema += caracterActual;
                            estadoActual = 6;
                        }
                        else if (Char.IsDigit(caracterActual.ToCharArray()[0]))
                        {
                            lexema += caracterActual;
                            estadoActual = 12;
                        }
                        else if ("+".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 16;
                        }
                        else if ("-".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 17;
                        }
                        else if ("*".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 18;
                        }
                        else if ("'".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 20;
                        }
                        else if ("=".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 24;
                        }
                        else if ("!".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 30;
                        }
                        else if ("/".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 19;
                        }
                        else if (">".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 28;
                        }
                        else if ("<".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 25;
                        }
                        else if (("@EOF@".Equals(caracterActual)))
                        {
                            lexema = caracterActual;
                            estadoActual = 32;
                        }
                        else if (("@FL@".Equals(caracterActual)))
                        {
                            estadoActual = 33;
                        }
                        else if (",".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 41;
                        }
                        else
                        {
                            estadoActual = 40;
                        }
                        break;

                    case 1:
                        leerSiguienteCaracter();

                        if (Char.IsLetter(caracterActual.ToCharArray()[0]) && !"A".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 6;
                        }
                        else if ("A".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 2;
                        }
                        break;

                    case 2:
                        leerSiguienteCaracter();

                        if ("M".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 3;
                        }
                        else if (Char.IsLetter(caracterActual.ToCharArray()[0]))
                        {
                            estadoActual = 6;
                        }
                        break;

                    case 3:
                        leerSiguienteCaracter();

                        if ("_".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 4;
                        }
                        else if (Char.IsLetter(caracterActual.ToCharArray()[0]))
                        {
                            lexema += caracterActual;
                            estadoActual = 6;
                        }
                        break;

                    case 4:
                        leerSiguienteCaracter();

                        if ("_".Equals(caracterActual) ||
                            Char.IsLetter(caracterActual.ToCharArray()[0]))
                        {
                            lexema += caracterActual;
                            estadoActual = 4;
                        }
                        else
                        {
                            estadoActual = 5;
                        }
                        break;

                    case 5:
                        devolverPuntero();
                        continuarAnalisis = false;
                        componenteLexico = ComponenteLexico.Crear(lexema, "CAMPO",
                            numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        TablaMaestro.obtenerTablaMaestro().agregarElemento(componenteLexico);
                        break;

                    case 6:
                        leerSiguienteCaracter();

                        if ("_".Equals(caracterActual) || Char.IsLetter(caracterActual.ToCharArray()[0]))
                        {
                            lexema += caracterActual;
                            estadoActual = 6;
                        }
                        else
                        {
                            estadoActual = 7;
                        }
                        break;

                    case 7:
                        continuarAnalisis = false;
                        componenteLexico = ComponenteLexico.Crear(lexema, "IDENTIFICADOR", numeroLineaActual,
                            puntero - lexema.Length, puntero - 1);
                        TablaMaestro.obtenerTablaMaestro().agregarElemento(componenteLexico);

                        break;

                    case 8:
                        leerSiguienteCaracter();

                        if ("A".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 9;
                        }
                        else if (Char.IsLetter(caracterActual.ToCharArray()[0]) && !"A".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 6;
                        }
                        break;

                    case 9:
                        leerSiguienteCaracter();

                        if ("B".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 10;
                        }
                        else if (Char.IsLetter(caracterActual.ToCharArray()[0]) && !"B".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 6;
                        }
                        break;

                    case 10:
                        leerSiguienteCaracter();

                        if ("_".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 11;
                        }
                        else if (Char.IsLetter(caracterActual.ToCharArray()[0]))
                        {
                            lexema += caracterActual;
                            estadoActual = 6;
                        }
                        break;

                    case 11:
                        leerSiguienteCaracter();

                        if ("_".Equals(caracterActual) || (Char.IsLetter(caracterActual.ToCharArray()[0])))
                        {
                            lexema += caracterActual;
                            estadoActual = 11;
                        }
                        else
                        {
                            estadoActual = 35;
                        }
                        break;

                    case 12:
                        leerSiguienteCaracter();

                        if (Char.IsDigit(caracterActual.ToCharArray()[0]))
                        {
                            lexema += caracterActual;
                            estadoActual = 12;
                        }
                        else if (".".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 13;
                        }
                        else
                        {
                            estadoActual = 21;
                        }
                        break;

                    case 13:
                        leerSiguienteCaracter();

                        if (Char.IsDigit(caracterActual.ToCharArray()[0]))
                        {
                            lexema += caracterActual;
                            estadoActual = 14;
                        }
                        else
                        {
                            estadoActual = 38;
                        }
                        break;

                    case 14:
                        leerSiguienteCaracter();

                        if (Char.IsDigit(caracterActual.ToCharArray()[0]))
                        {
                            lexema += caracterActual;
                            estadoActual = 14;
                        }
                        else
                        {
                            estadoActual = 15;
                        }
                        break;

                    case 15:
                        devolverPuntero();
                        continuarAnalisis = false;
                        componenteLexico = ComponenteLexico.Crear(lexema, "NUMERO DECIMAL", numeroLineaActual,
                            puntero - lexema.Length, puntero - 1);
                        TablaMaestro.obtenerTablaMaestro().agregarElemento(componenteLexico);
                        break;

                    case 16:
                        continuarAnalisis = false;
                        componenteLexico = ComponenteLexico.Crear(lexema, "SUMA", numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        break;

                    case 17:
                        componenteLexico = ComponenteLexico.Crear(lexema, "RESTA", numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        continuarAnalisis = false;
                        break;

                    case 18:
                        componenteLexico = ComponenteLexico.Crear(lexema, "MULTIPLICACION", numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        continuarAnalisis = false;
                        break;

                    case 19:
                        componenteLexico = ComponenteLexico.Crear(lexema, "DIVISION", numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        continuarAnalisis = false;
                        break;

                    case 20:
                        leerSiguienteCaracter();
                        if ("'".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 23;
                        }
                        else
                        {
                            lexema += caracterActual;
                            estadoActual = 22;
                        }
                        break;

                    case 21:
                        devolverPuntero();
                        continuarAnalisis = false;
                        componenteLexico = ComponenteLexico.Crear(lexema, "NUMERO ENTERO", numeroLineaActual,
                            puntero - lexema.Length, puntero - 1);
                        TablaMaestro.obtenerTablaMaestro().agregarElemento(componenteLexico);
                        break;

                    case 22:
                        leerSiguienteCaracter();
                        if ("'".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 23;
                        }
                        else if (Char.IsLetter(caracterActual.ToCharArray()[0]))
                        {
                            lexema += caracterActual;
                            estadoActual = 22;
                        }
                        break;

                    case 23:
                        continuarAnalisis = false;
                        componenteLexico = ComponenteLexico.Crear(lexema, "LITERAL", numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        TablaMaestro.obtenerTablaMaestro().agregarElemento(componenteLexico);
                        break;

                    case 24:
                        continuarAnalisis = false;
                        componenteLexico = ComponenteLexico.Crear(lexema, "IGUAL QUE", numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        TablaMaestro.obtenerTablaMaestro().agregarElemento(componenteLexico);
                        break;

                    case 25:
                        leerSiguienteCaracter();
                        if (">".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 31;
                        }
                        else if ("=".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 26;
                        }
                        else
                        {
                            lexema += caracterActual;
                            estadoActual = 27;
                        }
                        break;

                    case 26:
                        continuarAnalisis = false;
                        componenteLexico = ComponenteLexico.Crear(lexema, "MENOR O IGUAL QUE", numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        TablaMaestro.obtenerTablaMaestro().agregarElemento(componenteLexico);
                        break;

                    case 27:
                        devolverPuntero();
                        continuarAnalisis = false;
                        componenteLexico = ComponenteLexico.Crear(lexema, "MENOR QUE", numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        TablaMaestro.obtenerTablaMaestro().agregarElemento(componenteLexico);
                        break;

                    case 28:
                        leerSiguienteCaracter();
                        if ("=".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 36;
                        }
                        else
                        {
                            lexema += caracterActual;
                            estadoActual = 29;
                        }
                        break;

                    case 29:
                        devolverPuntero();
                        continuarAnalisis = false;
                        componenteLexico = ComponenteLexico.Crear(lexema, "MAYOR QUE", numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        TablaMaestro.obtenerTablaMaestro().agregarElemento(componenteLexico);
                        break;

                    case 30:
                        leerSiguienteCaracter();
                        if ("=".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 31;
                        }
                        else
                        {
                            estadoActual = 39;
                        }
                        break;

                    case 31:
                        continuarAnalisis = false;
                        componenteLexico = ComponenteLexico.Crear(lexema, "DIFERENTE QUE", numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        TablaMaestro.obtenerTablaMaestro().agregarElemento(componenteLexico);
                        break;

                    case 32:
                        //devolverPuntero();
                        //componenteLexico = new ComponenteLexico(null, "ERROR!, ASIGANCIÓN NO VALIDA", numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        componenteLexico = ComponenteLexico.Crear(lexema, "FIN DE ARCHIVO", numeroLineaActual,
                            puntero - lexema.Length, puntero - 1);
                        continuarAnalisis = false;
                        break;

                    case 33:
                        cargarNuevaLinea();
                        estadoActual = 0;
                        break;

                    case 34:
                        if ("@FL@".Equals(caracterActual))
                        {
                            estadoActual = 33;
                        }
                        else if ("*".Equals(caracterActual))
                        {
                            estadoActual = 35;
                        }
                        else
                        {
                            estadoActual = 34;
                            lexema += caracterActual;
                        }
                        break;
                    case 35:
                        continuarAnalisis = false;
                        componenteLexico = ComponenteLexico.Crear(lexema, "TABLA", numeroLineaActual,
                            puntero - lexema.Length, puntero - 1);
                        TablaMaestro.obtenerTablaMaestro().agregarElemento(componenteLexico);
                        break;

                    case 36:
                        continuarAnalisis = false;
                        componenteLexico = ComponenteLexico.Crear(lexema, "MAYOR O IGUAL QUE", numeroLineaActual,
                            puntero - lexema.Length, puntero - 1);
                        TablaMaestro.obtenerTablaMaestro().agregarElemento(componenteLexico);
                        break;

                    case 38:
                        //Estado de Error
                        continuarAnalisis = false;
                        causa = "Se esperaba un digito y recibió " + caracterActual + ".";
                        falla = "Decimal mal formado";
                        solucion = "Asegurese que luego del separador decimal exista un digito para formar un decimal";

                        //Reportando el error
                        ManejadorErrores.obtenerManejadorErrores().
                            agregarError(formarError(lexema+caracterActual, causa, falla, solucion));

                        componenteLexico = ComponenteLexico.Crear(lexema + "0", "NUMERO DECIMAL", numeroLineaActual,
                            puntero - lexema.Length, puntero - 1);

                        componenteLexico.tipo = TipoComponenteLexico.DUMMY;
                        TablaMaestro.obtenerTablaMaestro().agregarElemento(componenteLexico);
                        break;

                    case 39:
                        //Estado de Error
                        devolverPuntero();
                        continuarAnalisis = false;
                        causa = "Se esperaba un igual y recibió " + caracterActual + ".";
                        falla = "Diferente que mal formado";
                        solucion = "Asegurese que luego del ! exista un igual(=) para formar un diferente que.";

                        //Reportando el error
                        ManejadorErrores.obtenerManejadorErrores().
                            agregarError(formarError(lexema, causa, falla, solucion));

                        componenteLexico = ComponenteLexico.Crear(lexema + "=", "DIFERENTE QUE", numeroLineaActual,
                            puntero - lexema.Length, puntero - 1);

                        componenteLexico.tipo = TipoComponenteLexico.DUMMY;
                        TablaMaestro.obtenerTablaMaestro().agregarElemento(componenteLexico);

                        break;

                    case 40:
                        //Estado de Stoper
                        devolverPuntero();

                        causa = "Causa: caracter no soportado por el lenguaje:  " + caracterActual + ".\n";
                        falla = "Falla: no se reconoce el simbolo ingresado.\n";
                        solucion = "Solucion: asegurese de utilizar solo los simbolos permitidos por el lenguaje.";

                        //Reportando el error
                        ManejadorErrores.obtenerManejadorErrores().
                            agregarError(formarError(caracterActual, causa, falla, solucion));


                        throw new Exception("Se ha presentado un erro lexico tipo stopper, que impide la manejador de " +
                            "errores recuperarse, por favor verifique.\n\n" + causa + falla + solucion);
                    case 41:
                        continuarAnalisis = false;
                        componenteLexico = ComponenteLexico.Crear(lexema, "DELIMITADOR", numeroLineaActual,
                            puntero - lexema.Length, puntero - 1);
                        TablaMaestro.obtenerTablaMaestro().agregarElemento(componenteLexico);
                        break;


                }
            }
            return componenteLexico;
        }
        private Error formarError(String lexema, String causa, String falla, String solucion)
        {
            return Error.Crear(lexema, "Error", numeroLineaActual, puntero - lexema.Length, puntero - 1,
                causa, falla, solucion, TipoError.LEXICO);
        }
    }
}
