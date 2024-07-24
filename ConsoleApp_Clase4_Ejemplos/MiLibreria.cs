using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Clase4_Ejemplos
{
    //Definiremos esta clase para ejemplificar la sobrecarga de métodos
    //Por ahora no prestaremos atención a cualquier otro detalle de la clase
    public static class MiLibreria
    {
        //Estas funciones son lo que podrían llamarse también métodos
        public static int Sumar(int param1, int param2 = 0)
        {
            param1++;
            return param1 + param2;
        }

        //Sobrecarga de la función Sumar
        public static double Sumar(double param1, double param2)
        {
            var suma = param1 + param2;
            return suma;
        }

        /*
        Puedes sobrecargar la función Sumar las veces que quieras
        siempre y cuando los parámetros sean diferentes.
        En C#, la sobrecarga de métodos se basa en los parámetros que toma un método, 
        no en el tipo de valor que devuelve. 
        Dos métodos pueden tener el mismo nombre 
        pero deben diferir en el número o tipo de parámetros que toman. 
        El tipo de valor devuelto no puede ser utilizado 
        para distinguir entre dos métodos con el mismo nombre y parámetros. 
        Por lo tanto, puedes tener dos métodos con el mismo nombre 
        y el mismo tipo de valor devuelto, 
        siempre y cuando tengan diferentes parámetros.
         */
    }
}
