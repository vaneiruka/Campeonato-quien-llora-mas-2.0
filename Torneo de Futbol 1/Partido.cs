using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torneo_de_Futbol_1
{
    internal class Partido : Equipo 
    {
        private string equipo1;
        private string equipo2;
        private int encuentro;
        private int golesEquipo1 = 0;
        private int golesEquipo2 = 0;


        
        public Partido()
        {

        }
        public Partido(string equipo1, string equipo2)
        {
            this.equipo1 = equipo1;
            this.equipo2 = equipo2;
        }

        public void setequipo1(string nuevoequipo1)
        { this.equipo1 = nuevoequipo1; }

        public string getequipo1()
        {return equipo1;}

        public string getequipo2() { return equipo2;}
        public void setequipo2(string nuevoequipo2)
        { this.equipo2 = nuevoequipo2; }

        public int getencuentro() {  return encuentro; }
        public void setencuentro(int encuentro)
        { this.encuentro= encuentro; }

        public int getgolesEquipo1() {  return golesEquipo1; }

        public int getgolesEquipo2() {  return golesEquipo2; }
        public void setgolesEquipo1(int golesEquipo1)
        {
            this.golesEquipo1= golesEquipo1;
        }
        public void setgolesEquipo2(int golesEquipo2)
        {
            this.golesEquipo2 = golesEquipo2;
        }



        public void SetScores(int golesEquipo1, int golesEquipo2)
        {
            this.golesEquipo1 = golesEquipo1;
            this.golesEquipo2 = golesEquipo2;
        }    




    }
}
