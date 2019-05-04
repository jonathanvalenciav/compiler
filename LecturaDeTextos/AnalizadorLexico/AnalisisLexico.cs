using LecturaDeTextos.Transversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaDeTextos.AnalizadorLexico
{
    public class AnalisisLexico
    {
        private int puntero;
        private int numeroLineaActual = 0;
        private String contenidoLineaActual;
        private String caracterActual;

        public AnalisisLexico() {

            cargarNuevaLinea();
        }

        private void cargarNuevaLinea() {
            if (!"@EOF@".Equals(contenidoLineaActual)) {
                numeroLineaActual++;
                puntero = 1;
                contenidoLineaActual = Cache.obtenerCache().obtenerLinea(numeroLineaActual).Contenido;
            }
        }

        private void leerSiguienteCaracter() {
            if ("@EOF@".Equals(contenidoLineaActual))
            {
                caracterActual = "@EOF@";
            }
            else if (puntero > contenidoLineaActual.Length)
            {
                caracterActual = "@FL@";
                puntero++;
            }
            else {
                caracterActual = contenidoLineaActual.Substring(puntero - 1, 1);
                puntero++;
            }
        }

        private void devolverPuntero(){
            puntero--;
        }

        public ComponenteLexico analizar() {
            int estadoActual = 0;
            bool continuarAnalisis = true;
            String lexema = "";
            ComponenteLexico componenteLexico = null;

            while (continuarAnalisis) {
               // Console.WriteLine("Se queda!!!");
                switch (estadoActual){
                    case 0:
                        leerSiguienteCaracter();
                        while ("".Equals(caracterActual.Trim()))
                        {
                            leerSiguienteCaracter();
                        }
                        if ("C".Equals(caracterActual)
                            || "c".Equals(caracterActual)
                            )
                        {
                            lexema += caracterActual;
                            estadoActual = 1;

                        }
                        else if (Char.IsLetter(caracterActual.ToCharArray()[0]) && 
                            (!"C".Equals(caracterActual) | !"c".Equals(caracterActual))
                            | (!"T".Equals(caracterActual) | !"t".Equals(caracterActual)))
                        {
                            lexema += caracterActual;
                            estadoActual = 6;
                        }
                        else if ("t".Equals(caracterActual) || "T".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 8;
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
                        else if (",".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 21;
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
                            estadoActual = 32;
                        }
                        else if (("@FL@".Equals(caracterActual)))
                        {
                            estadoActual = 33;
                        }
                        else
                        {
                           // estadoActual = 18; este para simbolo inválido
                        }

                        break;

                    case 1:
                        leerSiguienteCaracter();

                        if (Char.IsLetter(caracterActual.ToCharArray()[0]) && (!"a".Equals(caracterActual) 
                            || !"A".Equals(caracterActual)))
                        {
                            lexema += caracterActual;
                            estadoActual = 6;
                        }

                        else if ("a".Equals(caracterActual)
                            || "A".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 2;
                        } 
                        
                        break;
                    case 2:
                        leerSiguienteCaracter();

                        if ("m".Equals(caracterActual)
                           || "M".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 3;
                        }

                        else if(Char.IsLetter(caracterActual.ToCharArray()[0]))
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

                        else if(Char.IsLetter(caracterActual.ToCharArray()[0]))
                        {
                            estadoActual = 6;
                        }

                        break;
                    case 4:
                        leerSiguienteCaracter();
                        
                        if ( "_".Equals(caracterActual) || 
                            Char.IsLetter(caracterActual.ToCharArray()[0]))
                        {
                            lexema += caracterActual;
                            estadoActual = 4;
                        }

                        else {
                            estadoActual = 5;
                        }


                        break;
                    case 5:

                        continuarAnalisis = false;
                        componenteLexico = new ComponenteLexico(lexema, "CAMPO", numeroLineaActual,
                            puntero - lexema.Length, puntero - 1);
                        break;
                    case 6:
                        leerSiguienteCaracter();
                        if (Char.IsLetter(caracterActual.ToCharArray()[0]))
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
                        componenteLexico = new ComponenteLexico(lexema, "IDENTIDICADOR", numeroLineaActual,
                            puntero - lexema.Length, puntero - 1);
                        break;

                    case 8:
                        leerSiguienteCaracter();

                        if ("a".Equals(caracterActual) || "A".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 9;
                        }


                        else if (Char.IsLetter(caracterActual.ToCharArray()[0]) && 
                            (!"b".Equals(caracterActual) || !"B".Equals(caracterActual))) {
                            lexema += caracterActual;
                            estadoActual = 6;
                        }
                     
                        
                        break;
                    case 9:
                        if (Char.IsLetter(caracterActual.ToCharArray()[0]) &&
                            (!"b".Equals(caracterActual) || !"B".Equals(caracterActual)))
                        {
                            lexema += caracterActual;
                            estadoActual = 6;
                        }else if (!"b".Equals(caracterActual) || !"B".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 10;
                        }
                        break;

                    case 10:
                        if ("-".Equals(caracterActual))
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
                       if ("-".Equals(caracterActual) || 
                          (Char.IsLetter(caracterActual.ToCharArray()[0])))
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
                        if (Char.IsDigit(caracterActual.ToCharArray()[0]))
                        {
                            lexema += caracterActual;
                            estadoActual = 12;
                        }
                        else if((".".Equals(caracterActual))) {
                            lexema += caracterActual;
                            estadoActual = 13;
                        }
                        else
                        {
                            estadoActual = 21;
                        }

                        break;

                    case 13:
                        if (Char.IsDigit(caracterActual.ToCharArray()[0]))
                        {
                            lexema += caracterActual;
                            estadoActual = 14;
                        }
                        break;
                    case 14:
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
                        componenteLexico = new ComponenteLexico(lexema, "NUMERO DECIMAL", numeroLineaActual,
                            puntero - lexema.Length, puntero - 1);
                        break;
                    case 16:
               
                        continuarAnalisis = false;
                        componenteLexico = new ComponenteLexico(lexema, "SUMA", numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        break;

                    case 17:
        
                        componenteLexico = new ComponenteLexico(lexema, "RESTA", numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        continuarAnalisis = false;
                        break;

                    case 18:
                   
                        componenteLexico = new ComponenteLexico(lexema, "MULTIPLICACION", numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        continuarAnalisis = false;
                        break;

                    case 19:

                        componenteLexico = new ComponenteLexico(lexema, "DIVISION", numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        continuarAnalisis = false;
                        break;
                    //VOY ACA!
                    case 20:
                        if (Char.IsLetter(caracterActual.ToCharArray()[0]))
                        {
                            lexema += caracterActual;
                            estadoActual = 23;
                        }
                        else if ("=".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 24;
                        }
                        else
                        {
                            estadoActual = 25;
                        }
                        break;
                    case 21:
                        if ("=".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 26;
                        }
                        else
                        {
                            estadoActual = 27;
                        }
                        break;

                    case 22:
                        if ("=".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 28;
                        }
                        else
                        {
                            estadoActual = 29;
                        }
                        break;

                    case 23:
                        continuarAnalisis = false;
                        componenteLexico = new ComponenteLexico(lexema, "DIFERENTE QUE", numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        break;

                    case 24:
                        continuarAnalisis = false;
                        componenteLexico = new ComponenteLexico(lexema, "MENOR O IGUAL QUE", numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        break;

                    case 25:
                        devolverPuntero();
                        continuarAnalisis = false;
                        componenteLexico = new ComponenteLexico(lexema, "MENOR QUE", numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        break;

                    case 26:
                        continuarAnalisis = false;
                        componenteLexico = new ComponenteLexico(lexema, "MAYOR O IGUAL QUE", numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        break;

                    case 27:
                        devolverPuntero();
                        continuarAnalisis = false;
                        componenteLexico = new ComponenteLexico(lexema, "MAYOR O IGUAL QUE", numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        break;

                    case 28:
                        continuarAnalisis = false;
                        componenteLexico = new ComponenteLexico(lexema, "ASIGNACIÓN", numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        break;

                    case 29:
                        devolverPuntero();
                        //componenteLexico = new ComponenteLexico(null, "ERROR!, ASIGNACIÓN NO VÁLIDA", numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        continuarAnalisis = false;
                        break;

                    case 30:
                        if ("=".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 31;
                        }
                        else
                        {
                            estadoActual = 29;
                        }
                        break;

                    case 31:
                        continuarAnalisis = false;
                        componenteLexico = new ComponenteLexico(lexema, "DIFERENTE QUE", numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        break;

                    case 32:
                        devolverPuntero();
                        //componenteLexico = new ComponenteLexico(null, "ERROR!, ASIGANCIÓN NO VALIDA", numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        continuarAnalisis = false;
                        break;

                    case 33:
                        continuarAnalisis = false;
                        componenteLexico = new ComponenteLexico(lexema, "DIVISIÓN", numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        break;

                    case 34:
                        if ("@FL@".Equals(caracterActual))
                        {
                            estadoActual = 37;
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
                        if ("*".Equals(caracterActual))
                        {
                            estadoActual = 35;
                        }

                        else if ("/".Equals(caracterActual))
                        {
                            estadoActual = 0;
                        }

                        else {
                            estadoActual = 34;
                        }
                        break;
                    case 36:
                        if ("@FL@".Equals(caracterActual)) { 
                            estadoActual = 13;
                        }
                        else{
                            estadoActual = 36;
                        }
                        break;
                    case 37:
                        cargarNuevaLinea();
                        estadoActual = 34;
                        break;
                }
            }

            return componenteLexico;
        }



    }
}
