using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaDeTextos.Transversal
{
     public class TablaPalabrasReservadas
    {
        private Dictionary<String, List<ComponenteLexico>> tablaPalabrasReservadas = new Dictionary<String, List<ComponenteLexico>>();
        private Dictionary<String, ComponenteLexico> tablaInicial = new Dictionary<String, ComponenteLexico>();

        private static TablaPalabrasReservadas Instancia = new TablaPalabrasReservadas();
        public TablaPalabrasReservadas()
        {
            //Asi con todas 
            tablaInicial.Add("SELECT",ComponenteLexico.Crear("SELECT","select"));
            tablaInicial.Add("FROM",ComponenteLexico.Crear("FROM","from"));
            tablaInicial.Add("WHERE",ComponenteLexico.Crear("WHERE","where"));
            tablaInicial.Add("ORDER",ComponenteLexico.Crear("ORDER","order"));
            tablaInicial.Add("BY",ComponenteLexico.Crear("BY","by"));
            tablaInicial.Add("INNER",ComponenteLexico.Crear("INNER","Inner"));
            tablaInicial.Add("AND",ComponenteLexico.Crear("AND","And"));
            tablaInicial.Add("OR",ComponenteLexico.Crear("OR","Or"));
            tablaInicial.Add("JOIN",ComponenteLexico.Crear("JOIN", "Join"));
            tablaInicial.Add("ASC",ComponenteLexico.Crear("ASC", "Asc"));
            tablaInicial.Add("DESC",ComponenteLexico.Crear("DESC", "Desc"));
        }
        public static TablaPalabrasReservadas obtenerTablaPalabrasReservadas()
        {
            return Instancia;
        }

        public void agregarPalabrasReservadas(ComponenteLexico componenteLexico)
        {
            if (componenteLexico != null && componenteLexico.tipo.Equals(TipoComponenteLexico.PALABRA_RESERVADA))
            {
                obtenerPalabrasReservadas(componenteLexico.Lexema).Add(componenteLexico);
            }
        }

        private Boolean existePalabrasReservadas(String lexema)
        {
            return tablaPalabrasReservadas.ContainsKey(lexema);
        }

        private List<ComponenteLexico> obtenerPalabrasReservadas(String lexema)
        {
            if (!existePalabrasReservadas(lexema))
            {
                tablaPalabrasReservadas.Add(lexema, new List<ComponenteLexico>());
            }
            return tablaPalabrasReservadas[lexema];
        }

        public Dictionary<String, List<ComponenteLexico>> obtenerPalabrasReservadas()
        {
            return tablaPalabrasReservadas;
        }

        public void comprobarPalabraReservada(ComponenteLexico componenteLexico) {
            if (componenteLexico != null && tablaInicial.ContainsKey(componenteLexico.Lexema.ToUpper())) {
                componenteLexico.tipo = TipoComponenteLexico.PALABRA_RESERVADA;
                componenteLexico.Categoria = tablaInicial[componenteLexico.Lexema.ToUpper()].Categoria;
            }
        }

  
    }
}
