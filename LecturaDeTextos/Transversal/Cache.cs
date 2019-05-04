using System.Collections.Generic;
using System.Linq;

namespace LecturaDeTextos.Transversal
{
    public class Cache
    {
        private static Cache INSTANCIA = new Cache();
        private List<Linea> lineas = new List<Linea>();

        private Cache() { }

        public static Cache obtenerCache() {
            return INSTANCIA;
        }

        public void agregarLinea(Linea linea) {
            if (linea != null) {
                lineas.Add(linea);
            }
        }

        public Linea obtenerLinea(int numeroLinea) {
            if (numeroLinea >= 0 && (numeroLinea - 1) < lineas.Count)
            {
                return lineas.ElementAt(numeroLinea - 1);
            }

            else {
                return new Linea(numeroLinea, "@EOF@");
            }
        }

        public List<Linea> obtenerLineas(){
            return lineas;
        }

        public void limpiar(){
            lineas.Clear();
        }
    }
}
