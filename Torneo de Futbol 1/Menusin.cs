/*/using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torneo_de_Futbol_1
{
    internal class Menusin
    {
        public Menusin()
        {
        }
        LaLista listica = new LaLista();
        //metodo menu

        public void menusin()
        {
            Console.Clear();          

            Console.WriteLine(@" 
              ********************************************MENU DE OPCIONES********************************************

                              A: Buscar un equipo por su nombre, ver su grupo y posicion en la tabla.
                              B: Ver los diferentes encuentros entre los equipos de cada grupo(A/B).
                              C: Ingresar los marcadores de cada encuentro.
                              D: Ver la lista de los equipos del grupo A o B.
                              E: Ver los resultados de un grupo en particular (A/B).
                              F: Ver la lista de todos los equipos con sus atributos y puntos totales.

              ********************************************************************************************************
                              ");

            ConsoleKeyInfo teclas = new ConsoleKeyInfo();

            teclas = Console.ReadKey(true);
            if (teclas.Key == ConsoleKey.A)               
            Console.WriteLine("Introduzca el nombre del equipo que desea buscar:");
            string nombreEquipo = Console.ReadLine();
            listica.Consultarequipos();
            listica.BuscarEquipoPorNombreYMostrarGrupo(nombreEquipo);
            menusin();

            if (teclas.Key == ConsoleKey.B)
                Console.WriteLine("\nA continuacion la lista de partidos del torneo: \n");
            listica.SepararGrupos();
            Console.ReadKey();
            Console.Clear();
            menusin();

            if (teclas.Key == ConsoleKey.C)
               //Ingresar marcadores

            if (teclas.Key == ConsoleKey.D)
                    //listar los equipos por grupo


                if (teclas.Key == ConsoleKey.E)
                        //Mostrar la tabla con los resusltados de un determinado grupo, consultar al usuario


                    if (teclas.Key == ConsoleKey.F)
                            //Mostrar todos los equipos ordenados por puntos y sus atributos.


                        Console.ReadKey();
        }

    }
}*/
