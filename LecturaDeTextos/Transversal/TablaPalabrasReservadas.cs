﻿using System;
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
            tablaInicial.Add("SELECT",ComponenteLexico.Crear("SELECT", "SELECT"));
            tablaInicial.Add("FROM",ComponenteLexico.Crear("FROM", "FROM"));
            tablaInicial.Add("WHERE",ComponenteLexico.Crear("WHERE", "WHERE"));
            tablaInicial.Add("ORDER",ComponenteLexico.Crear("ORDER", "ORDER"));
            tablaInicial.Add("BY",ComponenteLexico.Crear("BY", "BY"));
            tablaInicial.Add("INNER",ComponenteLexico.Crear("INNER", "INNER"));
            tablaInicial.Add("AND",ComponenteLexico.Crear("AND", "AND"));
            tablaInicial.Add("OR",ComponenteLexico.Crear("OR", "OR"));
            tablaInicial.Add("JOIN",ComponenteLexico.Crear("JOIN", "JOIN"));
            tablaInicial.Add("ASC",ComponenteLexico.Crear("ASC", "ASC"));
            tablaInicial.Add("DESC",ComponenteLexico.Crear("DESC", "DESC"));
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
