using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Torneo_de_Futbol_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LaLista listica = new LaLista();          
            //1
            listica.PreguntarNombres();
            //2
            Console.WriteLine("Introduzca el nombre del equipo que desea buscar:");
            string nombreEquipo = Console.ReadLine();
            listica.BuscarEquipoPorNombreYMostrarGrupo(nombreEquipo);
            //3
            Console.WriteLine("Encuentros que se daran en el torneo: \n");
            Equipo[] milista = listica.ObtenerEquipos();
            listica.MostrarPartidos(milista);

            // Mostrar los partidos del grupo A
            Console.WriteLine("**Grupo A:**");
            Equipo[] grupoA = listica.ObtenerGrupoA();
            listica.MostrarPartidosGrupo(grupoA);

            // Mostrar los partidos del grupo B
            Console.WriteLine("**Grupo B:**");
            Equipo[] grupoB = listica.ObtenerGrupoB();
            listica.MostrarPartidosGrupo(grupoB);          
            //4
            //Ingresar marcadores
            /*List<Partido> partidos = new List<Partido>();
            listica.MostrarPartidos2(partidos);
            listica.IngresarMarcadores(partidos);*/

            //5


        }
    }
}