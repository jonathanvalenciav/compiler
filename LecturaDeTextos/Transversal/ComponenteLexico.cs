using System;
using System.Text;

namespace LecturaDeTextos.Transversal
{
    public class ComponenteLexico
    {
        public String Lexema { get; }
        public String Categoria { get; }
        public int numeroLinea { get; }
        public int posicionInicial { get; }
        public int posicionFinal { get; }

        public ComponenteLexico(String Lexema, String Categoria, int numeroLinea, int posicionInicial, int posicionFinal) {
            this.Lexema = Lexema;
            this.Categoria = Categoria;
            this.numeroLinea = numeroLinea;
            this.posicionInicial = posicionInicial;
            this.posicionFinal = posicionFinal;
        }

        public String Imprimir()
        {
            StringBuilder impresion = new StringBuilder();
            impresion.Append("Categoria --> " + Categoria + "\n");
            impresion.Append("Lexema --> " + Lexema + "\n");
            impresion.Append("Numero linea --> " + numeroLinea + "\n");
            impresion.Append("Posicion Inicial --> " + posicionInicial + "\n");
            impresion.Append("Posicion Final --> " + posicionFinal + "\n");
            return impresion.ToString();
        }
    }
}
