namespace Clase7_Ejemplos_POO_Parte2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ahora el constructor de Auto recibe un enum para el color, en lugar de string
            Auto auto1 = new Auto("Ford", "Fiesta", ColorVehiculo.Rojo, "ABC123", 0, 4, false);

            Moto moto = new Moto();
            moto.Color = 0; //Se asigna un valor para Color basado en enum ColorVehiculo
            Console.WriteLine($"Color de la moto: {moto.Color}"); //Cuando se imprime por pantalla, se muestra el "label"
            Console.ReadLine();
            Auto auto2 = new Auto();
            //Vehiculo vehiculo = new Vehiculo(); //No se puede instanciar una clase abstracta
            Vehiculo moto2 = new Moto(); //Se instancia una moto pero se guarda en una variable de tipo Vehiculo. Es aceptado porque Moto es un Vehiculo
            Vehiculo auto3 = new Auto(); //Se instancia un auto pero se guarda en una variable de tipo Vehiculo. Es aceptado porque Auto es un Vehiculo
            if (auto3 is Moto)
            {
                Console.WriteLine("Objeto en auto3 Es una moto");
            }
            else
            {
                Console.WriteLine("Objeto en auto3 No es una moto");
            }

            //Si quiero ver los métodos de Auto en auto3, no puedo, porque está guardado como Vehiculo
            //auto3.Acelerar(10); //Tira error porque Acelerar es un método de Auto, no de Vehiculo
            //Si quisiera acceder a los métodos de Auto en auto3 debería hacer un cast
            ((Auto)auto3).Acelerar(10); //Esto es un cast. Se convierte auto3 de Vehiculo a Auto para poder acceder a los métodos de Auto
            //o también podría usar la palabra reservada as para el casteo
            (auto3 as Auto).Acelerar(10); //Esto es un cast. Se convierte auto3 de Vehiculo a Auto para poder acceder a los métodos de Auto

            var aceleracion = Calculo.CalcularAceleracion(0, auto1.Velocidad, 10); //Uso de un método estático

            IVolador volador = new Avion(); //Se instancia un avión pero se guarda en una variable de tipo IVolador. Es aceptado porque Avion implementa la interfaz IVolador

            var otroAuto = new Auto(); //Se instancia Auto pero del otro namespace VER archivo ArchivoContenedorDeClases.cs
        
            //Instancio servicio
            VehiculoService servicio = new VehiculoService();
            servicio.RealizarServicio(auto1);

            //Instancio servicio con Servicio
            ServicioConServicio servicio2 = new ServicioConServicio(servicio);
        }
    }
}
