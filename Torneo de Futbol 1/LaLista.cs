using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Torneo_de_Futbol_1
{
    
    internal class LaLista
    {
        //Atributos
        private Equipo[] Milista; //aqui guardare los equipos
        private int auxiliar;
        private int NumeroEquipos;


        //Constructores

        
        public LaLista()
        {
            auxiliar = 0;
            NumeroEquipos = 0;
            Milista = new Equipo[10]; //tiene maximo 10, no importa si quedan posiciones sobrando :c
        }

        //Metodos

        public Array getMilista()
        {
            return Milista;
        }


        //Validacion
        public void establecernumeroequipos()
        {
            do
            {
                try
                {
                    Console.WriteLine("Ingrese el numero de equipos que participaran en el Campeonato Los Sufridos:");
                    NumeroEquipos = int.Parse(Console.ReadLine());

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "\n");
                }

            } while (NumeroEquipos != 6 && NumeroEquipos != 8 && NumeroEquipos != 10);
        }

        //aqui voy a agregar el nombre y grupo de cada equipo
        public void PreguntarNombres()
        {
            establecernumeroequipos();
            string aux;
            int aux2 = 1;
            int contA = 0;
            int contB = 0;

            do
            {
                Console.WriteLine("\nInserte el nombre del equipo " + aux2 + ":\n");
                aux = Console.ReadLine();
                Equipo Gatitos = new Equipo(aux);
                string grupo;

                do
                {
                    Console.WriteLine("\n¿A qué grupo desea asignar el equipo " + Gatitos.getNombre() + "? (A/B):");
                    grupo = Console.ReadLine().ToUpper(); //cosa que me funciona para transformar las letras de minuscula a mayuscula, nuevo descubrimiento waos
                } while (grupo != "A" && grupo != "B");

                if (grupo == "A" && contA < NumeroEquipos / 2) //Aqui comienzo a validar los grupos
                {
                    Gatitos.setGrupo("A");
                    contA++;
                }
                else if (grupo == "B" && contB < NumeroEquipos / 2)
                {
                    Gatitos.setGrupo("B");
                    contB++;
                }
                else
                {
                    Console.WriteLine("¡El grupo " + grupo + " está lleno! Lo agregaremos al grupo que se encuentra libre.");
                    if (grupo == "A")
                    {
                        Gatitos.setGrupo("B");
                        contB++;
                    }
                    else
                    {
                        Gatitos.setGrupo("A");
                        contA++;
                    }
                }

                Console.WriteLine("\nEl nombre del equipo " + aux2 + " es: " + Gatitos.getNombre() + " ; Y el grupo al que pertenece es el: " + Gatitos.getGrupo() + "\n");
                Agregarequipos(Gatitos);
                aux2++; //nomas por estetica pero aja
            } while (aux2 < NumeroEquipos + 1);
            Console.Clear();
        }

        //Para guardar mis objetos de tipo Equipo aqui
        private void Agregarequipos(Equipo Gatitos)
        {
            this.Milista[auxiliar] = Gatitos;
            auxiliar++;
        }

        //para ver el arreglo en pantalla
        public void Consultarequipos()
        {
            int aux3 = 1;

            for (int i = 0; i < NumeroEquipos; i++)
            {
                Console.WriteLine("\n*************************************************************");
                Console.WriteLine("\n*El nombre del equipo " + aux3 + " es: " + Milista[i].getNombre());
                Console.WriteLine("\n*El grupo al que pertenece es: " + Milista[i].getGrupo());
                Console.WriteLine("\n*************************************************************");
                aux3++;
            }

        }

        //Buscando equipos por nombre

        public Equipo BuscarEquipoPorNombreYMostrarGrupo(string nombreEquipo)
        {
            Equipo equipoEncontrado = null;

            // Buscar el equipo por nombre
            foreach (Equipo equipo in Milista)
            {
                if (equipo != null)
                {
                    if (equipo.getNombre().Equals(nombreEquipo, StringComparison.OrdinalIgnoreCase))
                    {
                        equipoEncontrado = equipo;
                        break;
                    }
                }
            }

            // Si se encontró el equipo, mostrar su información
            if (equipoEncontrado != null)
            {
                Console.WriteLine($"El equipo {equipoEncontrado.getNombre()} pertenece al grupo {equipoEncontrado.getGrupo()} y su posición en la tabla es: {equipoEncontrado.getPosicionTabla()}");
            }
            else
            {
                Console.WriteLine($"No se encontró un equipo con el nombre {nombreEquipo}");
            }
            return equipoEncontrado;
        }
       

        public void MostrarPartidos(Equipo[] milista)
        {
            // Separar los equipos en dos grupos
            Equipo[] grupoA = new Equipo[milista.Length / 2];
            Equipo[] grupoB = new Equipo[milista.Length / 2];

            int indiceA = 0, indiceB = 0;
            for (int i = 0; i < milista.Length; i++)
            {
                if (milista[i] != null)
                {
                    if (milista[i].getGrupo() == "A")
                    {
                        grupoA[indiceA++] = milista[i];
                    }
                    else
                    {
                        grupoB[indiceB++] = milista[i];
                    }
                }
            }

            // **Aquí se agrega el segmento de código para generar y guardar los partidos**

            List<Equipo> partidos = new List<Equipo>();

            for (int i = 0; i < grupoA.Length; i++)
            {
                for (int j = i + 1; j < grupoA.Length; j++)
                {
                    if (i + 1 < grupoA.Length)
                    {
                        string nombreEquipo1 = grupoA[i].getNombre();
                        string nombreEquipo2 = grupoA[j].getNombre();

                        Partido partido = new Partido(nombreEquipo1, nombreEquipo2);
                        partidos.Add(partido);
                    }
                }
            }

            for (int i = 0; i < grupoB.Length; i++)
            {
                for (int j = i + 1; j < grupoB.Length; j++)
                {
                    if (grupoB[i] != null && grupoB[j] != null)
                    {
                        string nombreEquipo1 = grupoB[i].getNombre();
                        string nombreEquipo2 = grupoB[j].getNombre();

                        Partido partido = new Partido(nombreEquipo1, nombreEquipo2);
                        partidos.Add(partido);                       
                    }
                }
            }
            
        }

        public void MostrarPartidosGrupo(Equipo[] equipos)
        {
            for (int i = 0; i < equipos.Length; i++)
            {
                for (int j = i + 1; j < equipos.Length; j++)
                {
                    if (equipos[i] != null && equipos[j] != null)
                    {
                        Console.WriteLine($"{equipos[i].getNombre()} vs {equipos[j].getNombre()}");
                    }
                }
            }
        }


        public Equipo[] ObtenerEquipos()
        {
            Equipo[] milistaCopia = new Equipo[NumeroEquipos];
            Array.Copy(Milista, milistaCopia, NumeroEquipos);
            return milistaCopia;
        }

        public Equipo[] ObtenerGrupoA()
        {
            Equipo[] grupoA = new Equipo[NumeroEquipos / 2];
            Array.Copy(Milista, 0, grupoA, 0, NumeroEquipos / 2);
            return grupoA;
        }

        public Equipo[] ObtenerGrupoB()
        {
            Equipo[] grupoB = new Equipo[NumeroEquipos / 2];
            Array.Copy(Milista, NumeroEquipos / 2, grupoB, 0, NumeroEquipos / 2);
            return grupoB;
        }


        public void IngresarMarcadores(List<Partido> partidos)
        {
            // Recorrer los partidos
            foreach (Partido partido in partidos)
            {
                // Mostrar información del partido
                Console.WriteLine("**Partido:**");
                Console.WriteLine($"{partido.getequipo1()} vs {partido.getequipo2}");

                // Solicitar goles al usuario
                Console.Write("Ingrese el marcador (Ej: 1-2): ");
                string input = Console.ReadLine();

                // Validar y procesar el marcador
                if (string.IsNullOrEmpty(input) || !Regex.IsMatch(input, @"^\d+-\d+$"))
                {
                    Console.WriteLine("Marcador no válido. Intente nuevamente.");
                    continue;
                }

                // Separar los goles
                string[] goles = input.Split('-');
                int golesEquipo1 = int.Parse(goles[0]);
                int golesEquipo2 = int.Parse(goles[1]);

                // Actualizar los goles del partido
                partido.SetScores(golesEquipo1, golesEquipo2);

                // Mostrar mensaje de confirmación
                Console.WriteLine("Marcador ingresado correctamente.");
            }
        }

        public void MostrarPartidos2(List<Partido> partidos)
        {
            // Mostrar la información de los partidos
            foreach (Partido partido in partidos)
            {
                Console.WriteLine("**Partido:**");
                Console.WriteLine($"{partido.getequipo1()} vs {partido.getequipo2()}");
                Console.WriteLine("Goles: {0} - {1}", partido.getgolesEquipo1(), partido.getgolesEquipo2());
            }
        }

    }
}