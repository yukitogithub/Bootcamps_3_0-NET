using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase8_ClassLibrary
{
    public class Persona
    {
        //Atributos de la clase Persona
        //private como modificador de acceso
        //private permite el acceso a los atributos solo desde la misma clase
        private string _nombre;
        public string Nombre 
        {
            get { return _nombre; }
            set { _nombre = value; } 
        }

        private int _edad;
        public int Edad 
        {
            get => _edad;
            //Agregar validación en edad para que value sea siempre mayor a cero
            set
            {
                if (value <= 0)
                {
                    throw new Exception("La edad debe ser mayor a cero");
                }
                _edad = value;
            }
        }

        private string _genero;
        //property de solo lectura
        public string Genero 
        { 
            get { return _genero; }
        }

        private int _dni;
        //property de solo escritura
        public int DNI 
        {
            set { _dni = value; }
        }

        //Añadir campo publico
        public string direccion;
        //Añadir campo privado
        private string _telefono;

        //Constructor de la clase Persona
        //public como modificador de acceso
        //public permite el acceso a la clase Persona desde cualquier parte del programa
        public Persona(string nombre, int edad, string genero)
        {
            //Inicialización de los atributos de la clase Persona
            this._nombre = nombre;
            this._edad = edad;
            this._genero = genero;
        }

        public Persona()
        {
            
        }

        //Método que imprime los datos de la persona
        //public como modificador de acceso
        //public permite el acceso al método ImprimirDatos desde cualquier parte del programa
        public void ImprimirDatos()
        {
            Console.WriteLine("Nombre: " + _nombre);
            Console.WriteLine("Edad: " + _edad);
            Console.WriteLine("Género: " + _genero);
        }

        //Método que imprime el mensaje de saludo
        //public como modificador de acceso
        //public permite el acceso al método Saludar desde cualquier parte del programa
        public void Saludar()
        {
            Console.WriteLine("Hola, soy " + _nombre);
        }

        //Calcular edad para jubilarse
        //public como modificador de acceso
        //public permite el acceso al método CalcularEdadJubilacion desde cualquier parte del programa
        public int CalcularEdadJubilacion()
        {
            int edadJubilacion = 65;
            int añosParaJubilarse = edadJubilacion - _edad;
            return añosParaJubilarse;
        }

        //Agregar métodos para GetTelefono y SetTelefono
        public string GetTelefono()
        {
            return _telefono;
        }

        public void SetTelefono(string telefono)
        {
            _telefono = telefono;
        }
    }
}
