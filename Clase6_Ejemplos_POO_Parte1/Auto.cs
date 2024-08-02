using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase6_Ejemplos_POO_Parte1
{
    public class Auto
    {
        //Properties de la clase Auto
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public string Patente { get; set; }
        public int Velocidad { get; set; }
        public int CantPuertas { get; set; }
        public int CantPasajeros { get ; set; } //5
        public bool Encendido { get; set; }
        public Persona Conductor { get; set; } //Relaciones entre clases u objetos

        //Constructor de la clase Auto
        public Auto(string marca, string modelo, string color, string patente, int velocidad, int cantPuertas, bool encendido)
        {
            Marca = marca;
            Modelo = modelo;
            Color = color;
            Patente = patente;
            Velocidad = velocidad;
            CantPuertas = cantPuertas;
            Encendido = encendido;
        }

        //Métodos de la clase Auto

        //Método para encender el auto
        public void Encender()
        {
            Encendido = true;
        }

        //Método para apagar el auto
        public void Apagar()
        {
            Encendido = false;
        }

        //Método para acelerar el auto
        public void Acelerar(int incremento)
        {
            Velocidad += incremento;
        }

        //Método para frenar el auto
        public void Frenar(int decremento)
        {
            Velocidad -= decremento;
        }

        //Agregar conductor
        public void SubirConductor(Persona conductor)
        {
            Conductor = conductor;
            conductor.SetTelefono("123456789");
        }

        //Sacar conductor
        public void BajarConductor()
        {
            Conductor = null;
        }
    }
}
