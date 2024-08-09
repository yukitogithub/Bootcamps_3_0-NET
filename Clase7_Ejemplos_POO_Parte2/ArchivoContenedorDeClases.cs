using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase7_Ejemplos_POO_Parte2
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

        public string Apellido { get; set; }

        public List<Vehiculo> Vehiculos { get; set; } //Puedo añadir una moto o un auto

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

    //Clase abstracta
    public abstract class Vehiculo
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public ColorVehiculo Color { get; set; } //0,1,2,3,4,5 //Rojo, Azul, Verde, Amarillo, Blanco, NoColorFound //Enum
        public string Patente { get; set; }
        public int Velocidad { get; set; }
        public bool Encendido { get; set; }
        public Persona Conductor { get; set; }

        //Método para encender el auto (abstracto)
        public abstract void Encender();
        //{
        //Encendido = true;
        //}

        //Método para apagar el auto
        public void Apagar()
        {
            Encendido = false;
        }
    }

    //Clase que hereda de Vehiculo
    public class Auto : Vehiculo
    {
        public int CantPuertas { get; set; }
        public int CantPasajeros { get; set; } //5

        #region Constructores
        public Auto()
        {

        }
        //Constructor de la clase Auto. Si defino un constructor propio customizado, se pierde el constructor por defecto, y si lo quisiera usar, debería declararlo nuevamente
        public Auto(string marca, string modelo, ColorVehiculo color, string patente, int velocidad, int cantPuertas, bool encendido)
        {
            Marca = marca;
            Modelo = modelo;
            Color = color;
            Patente = patente;
            Velocidad = velocidad;
            CantPuertas = cantPuertas;
            Encendido = encendido;
        }
        #endregion

        #region Métodos
        //Métodos de la clase Auto

        //Método para encender el auto (override) porque es un método abstracto de la clase padre
        public override void Encender()
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
        #endregion

    } 

    //Clase que hereda de Vehiculo
    public class Moto : Vehiculo
    {
        public override void Encender()
        {
            Encendido = true;
        }
    }

    //Clase que hereda de Vehiculo y que luego es sellada
    public sealed class Camion : Vehiculo
    {
        public override void Encender()
        {
            Encendido = true;
        }
    }

    //public class CamionGrande: Camion
    //{
    //    public override void Encender()
    //    {
    //        Encendido = true;
    //    }
    //}

    //Interfaz
    //El nombre comienza con I
    public interface ITransporte
    {
        bool Encendido { get; set; } //Properties igual que clases
        void Apagar(); //Métodos NO igual porque no tiene implementación
        void Transportar();
    }

    public interface IVolador
    {
        void Volar();
    }

    //Clase que hereda de Vehiculo e implementa varias interfaces
    public class Avion : Vehiculo, ITransporte, IVolador //Pseudo-multiherencia
    {
        public bool Encendido { get; set; }

        public override void Encender()
        {
            Encendido = true;
        }
        public void Apagar()
        {
            Encendido = false;
        }

        //Los métodos de las interfaces se deben implementar. La interfaz nos obliga a implementar los métodos
        public void Transportar()
        {
            Console.WriteLine("Transportando");
        }

        public void Volar()
        {
            Console.WriteLine("Volando");
        }
    }

    //Clase estática
    public static class Calculo
    {
        //Método estático. No se necesita instanciar la clase para usarlo
        public static int CalcularAceleracion(int velocidadInicial, int velocidadFinal, int tiempo)
        {
            return (velocidadFinal - velocidadInicial) / tiempo;
        }
    }

    //Servicios
    public class VehiculoService
    {
        public void RealizarServicio(Vehiculo vehiculo)
        {
            vehiculo.Apagar();
        }
    }

    //Otro servicio que depende de VehiculoService
    public class ServicioConServicio
    {
        private VehiculoService _vehiculoService;

        public ServicioConServicio(VehiculoService vehiculoService)
        {
            _vehiculoService = vehiculoService;
        }

        public void RealizarServicioConServicio(Vehiculo vehiculo)
        {
            _vehiculoService.RealizarServicio(vehiculo);
        }
    }

    //ValueType Enum
    public enum ColorVehiculo
    {
        Rojo, //0,1,2,3,4,5
        Azul,
        Verde,
        Amarillo,
        Blanco,
        NoColorFound
    }

    //ValueType Struct
    //Similar a class peeeeero en ValueType
    public struct Point //Punto
    {
        public int x;
        public int y;

        int CalcularDistancia(Point otroPunto)
        {
            return Math.Abs(x - otroPunto.x) + Math.Abs(y - otroPunto.y);
        }
    }
}

namespace OtroEspacio
{
    public class Auto
    {
        public Auto()
        { }
    }
}

//OtroEspacio.Auto
//Clase7_Ejemplos_POO_Parte2.Auto