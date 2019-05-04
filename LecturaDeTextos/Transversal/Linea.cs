using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaDeTextos.Transversal
{
    public class Linea
    {
        public int Numero { get; }
        public String Contenido { get; }

        public Linea(int numero, String contenido) {
            this.Numero = numero;
            this.Contenido = contenido;
        }
    }
}
