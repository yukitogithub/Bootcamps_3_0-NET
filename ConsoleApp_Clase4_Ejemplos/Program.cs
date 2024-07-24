using ConsoleApp_Clase4_Ejemplos; //Veremos esto más adelante

//Definiremos primero las funciones que usaremos en el programa en la siguiente región
//Para ejemplo de sobrecarga, ver en el archivo MiLibreria.cs
#region Funciones
////Función simple
int Sumar(int param1, int param2 = 0)
{
    param1++;
    return param1 + param2;
}

////Parámetros
//Por valor
void IncrementarPorValor(int numero)
{
    numero++;
}

//Por referencia
void IncrementarPorReferencia(ref int numero)
{
    numero++;
}

//Por salida
void ObtenerValores(out int x, out int y)
{
    x = 5;
    y = 10;
}

//Parámetros opcionales
void MostrarMensaje(string mensaje = "Hola")
{
    Console.WriteLine(mensaje);
}

//Función con retorno
int Multiplicar(int a, int b)
{
    return a * b;
}

//Función sin retorno
void Saludar()
{
    Console.WriteLine("Hola!");
}

//Uso de return cortando ejecución en función sin retorno
void VerificarEdad(int edad)
{
    if (edad < 18)
    {
        Console.WriteLine("Menor de edad.");
        return; // Sale de la función si la condición se cumple
    }

    Console.WriteLine("Mayor de edad.");
}

//Asincronismo simple
async Task DescargarArchivoAsync(string url)
{
    var client = new HttpClient();
    var contenido = await client.GetStringAsync(url);
    Console.WriteLine(contenido);
}

//Comparación entre sincronismo y asincronismo
void MetodoSincronico()
{
    Thread.Sleep(3000); // Bloquea el hilo
    Console.WriteLine("Método sincrónico terminado");
}

async Task MetodoAsincronico()
{
    await Task.Delay(4000); // No bloquea el hilo
    Console.WriteLine("Metodo asincrónico terminado");
}

#endregion

//Definiremos algunas variables que usaremos en el programa en la siguiente región
#region Variables
int a = 5;
int b, c;
#endregion

//Definiremos el código principal del programa en la siguiente región, con las llamadas a las funciones definidas anteriormente
#region Main

//Llamada a la función con parámetros por valor
Console.WriteLine("Valor de variable a (antes): " + a);
IncrementarPorValor(a);
Console.WriteLine("Valor de variable a (después): " + a);
// a sigue siendo 5

//Llamada a la función con parámetros por referencia
Console.WriteLine("Valor de variable a (antes): " + a);
IncrementarPorReferencia(ref a);
Console.WriteLine("Valor de variable a (después): " + a);
// a ahora es 6

//Llamada a la función con parámetros por salida
//imprimir b y c por consola antes de llamar a la función
ObtenerValores(out b, out c);
Console.WriteLine($"Valor de variable b y c: {b} y {c} ");
// b es 5, c es 10

//Llamada a la función con parámetros opcionales
MostrarMensaje(); // Imprime "Hola"
MostrarMensaje("Adiós"); // Imprime "Adiós"

//A partir de aquí podemos llamar a nuestra función mensaje con cualquier otra función como parámetro
//Siempre y cuando la función que se pase como parámetro retorne un string
//Teniendo la salvedad también que la función que se pase como parámetro no puede ser una función que no retorne nada
//Y a su vez, hay que prestar atención a que la función debe ser llamada con () al final para que se ejecute
//Lo siguiente no es válido
//MostrarMensaje(Sumar); // Error, no se puede pasar una función como parámetro
//Lo siguiente es válido, pero hay que castear sumar para que retorne un string
//En este caso, como retorna un int, se puede hacer uso de la función ToString() para convertirlo a string
MostrarMensaje(Sumar(a, b).ToString()); // Imprime "Hola!" y luego "Hola"

//Llamada a la función sobrecargada Sumar, con int
Console.WriteLine(MiLibreria.Sumar(5, 6)); // Imprime 12
//Llamada a la función sobrecargada Sumar, con double
Console.WriteLine(MiLibreria.Sumar(5.5, 6.6));

//Comparación entre sincronismo y asincronismo
Console.WriteLine("Inicio de comparación entre sincronismo y asincronismo");
MetodoSincronico();
await MetodoAsincronico();
Console.WriteLine("Fin de comparación entre sincronismo y asincronismo");
//Cuál crees que se imprimirá primero?
//Puedes jugar con los números en las funciones para ver qué pasa si cambias los tiempos de espera

#endregion