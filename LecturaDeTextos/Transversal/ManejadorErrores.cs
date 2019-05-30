using System;
using System.Collections.Generic;
using System.Linq;

namespace LecturaDeTextos.Transversal
{
    public class ManejadorErrores
    {
        private static ManejadorErrores Instancia = new ManejadorErrores();
        private Dictionary<TipoError, List<Error>> mapaErrores = new Dictionary<TipoError, List<Error>>();

        public ManejadorErrores()
        {

        }

        public static ManejadorErrores obtenerManejadorErrores()
        {
            return Instancia;
        }

        private List<Error> obtenerListaErrores(TipoError Tipo)
        {
            if (!mapaErrores.ContainsKey(Tipo))
            {
                mapaErrores.Add(Tipo, new List<Error>());
            }

            return mapaErrores[Tipo];
        }

        public void agregarError(Error Error)
        {
            if (Error != null)
            {
                obtenerListaErrores(Error.Tipo).Add(Error);
            }
        }

        public bool hayErrores(TipoError Tipo)
        {
            return obtenerListaErrores(Tipo).Count > 0;
        }

        public bool hayErrores()
        {
            bool existenErrores = false;
            foreach (TipoError Tipo in Enum.GetValues(typeof(TipoError)))
            {
                existenErrores = hayErrores(Tipo);
                if (existenErrores)
                {
                    break;
                }
            }

            return existenErrores;
        }

        public List<Error> ObtenerErroresTotales()
        {
            return mapaErrores.Values.SelectMany(simbolo => simbolo).ToList();
        }

    }
}
