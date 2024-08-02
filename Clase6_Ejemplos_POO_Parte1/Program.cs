namespace Clase6_Ejemplos_POO_Parte1
{
    //Clase Program que contiene el método Main 
    //Contiene internal como modificador de acceso
    //internal permite el acceso a la clase Program desde el mismo ensamblado
    internal class Program 
    {
        //Método Main que es el punto de entrada de la aplicación
        //Contiene private como modificador de acceso por default
        //Si no se especifica un modificador de acceso, private es el modificador de acceso por default
        //Contiene args como parámetro de tipo string[]
        //args es un arreglo de cadenas que contiene los argumentos de la línea de comandos
        static void Main(string[] args)
        {
            Console.WriteLine("Programa de Consola de ejemplo de uso de Clases y Objetos");
            Console.WriteLine("-----------------------------------------------------------");
            Console.ReadLine();
            //Creación de un objeto de la clase Persona
            Console.WriteLine("Creación de un objeto de la clase Persona");
            Console.WriteLine("  ");
            //Se instancia la clase Persona con el constructor que recibe tres parámetros
            //Se asigna el objeto a la variable persona1
            Persona persona1 = new Persona("Juan", 25, "Masculino");
            persona1.direccion = "Calle 123";
            //Acceso a los atributos de la clase Persona
            Console.WriteLine("Acceso a los atributos de la clase Persona");
            Console.WriteLine("  ");
            //Se accede a los atributos de la clase Persona a través de la variable persona1 usando el .
            //Se accede a los atributos de la clase Persona a través de los métodos de la clase Persona
            Console.WriteLine("Nombre de persona1: " + persona1.Nombre);
            Console.WriteLine("Edad de persona1: " + persona1.Edad);
            //persona1.Genero = "Masculino"; //TIRA ERROR "Genero" is read-only
            Console.WriteLine("Género de persona1: " + persona1.Genero);

            Console.WriteLine("  ");
            Console.WriteLine("Se accede a los campos llamando al método ImprimirDatos de la clase Persona");
            persona1.ImprimirDatos();

            Console.WriteLine("  ");
            Console.WriteLine("Años para jubilarse de persona1: " + persona1.CalcularEdadJubilacion());
            Console.WriteLine("Dirección de Persona1: " + persona1.direccion);
            //Agrega DNI a persona1
            persona1.DNI = 12345678;
            //Console.WriteLine(persona1.DNI); //TIRA ERROR "DNI" is write-only

            Console.WriteLine("---------------------------------------------");
            Console.ReadLine();
            //Creación de un objeto de la clase Auto
            Console.WriteLine("Creación de un objeto de la clase Auto");
            //Se instancia la clase Auto con el constructor que recibe siete parámetros
            //Se asigna el objeto a la variable auto1
            Auto auto1 = new Auto("Ford", "Fiesta", "Rojo", "ABC123", 0, 4, false);
            Console.WriteLine("  ");
            Console.WriteLine("Vamos a subir a persona1 al auto1, como conductor");
            Console.ReadLine();
            Console.WriteLine("Teléfono de persona1 antes de 'Subirse al auto como conductor': " + persona1.GetTelefono()); //Telefono de Persona 1 antes de subir al auto
            //"Subir conductor al auto": Se asigna persona1 como conductor de auto1. 
            Console.WriteLine("  ");
            Console.ReadLine();
            Console.WriteLine("Subiendo conductor al auto (El método subir conductor al auto 'setea' el valor del teléfono del conductor, en este caso persona1)");
            auto1.SubirConductor(persona1); //Metodo para subir conductor setea telefono en conductor
            Console.WriteLine("  ");
            Console.ReadLine();
            Console.WriteLine("Teléfono de persona1 después de 'Subirse al auto como conductor': " + persona1.GetTelefono()); //Telefono de Persona 1 despues de subir al auto
            Console.WriteLine(auto1.Conductor.GetTelefono()); //Telefono de Conductor osea, persona1 despues de subir al auto
            Console.WriteLine("  ");
            Console.ReadLine();
            Console.WriteLine("El cambio de la propiedad teléfono de persona1 se cambia desde auto, porque es un reference type, y tanto conductor como persona1 hacen referencia al mismo espacio de memoria, por ende, el mismo objeto");
            Console.WriteLine("  ");
            Console.WriteLine("FIN DEL PROGRAMA EJEMPLO");
            Console.ReadLine();
        }
    }
}
