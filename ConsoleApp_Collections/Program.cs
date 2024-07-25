////Colecciones
//Arreglos
#region Arreglos
//Definicion de Arreglos
int[] arregloEnteros = new int[5]; //Arreglo de 5 elementos de tipo entero, sin inicializar
int[] arregloEnteros2 = new int[] { 1, 2, 3, 4, 5 }; //Arreglo de 5 elementos de tipo entero, inicializado
int[] arregloEnteros3 = { 1, 2, 3, 4, 5 }; //Arreglo de 5 elementos de tipo entero, inicializado
//Acceso a elementos de un arreglo
Console.WriteLine(arregloEnteros2[0]); //Imprime el primer elemento del arreglo
//Modificacion de elementos de un arreglo
arregloEnteros2[0] = 10; //Modifica el primer elemento del arreglo
//Iteración de un arreglo usando for
for (int i = 0; i < arregloEnteros2.Length; i++)
{
    Console.WriteLine(arregloEnteros2[i]);
}

//Iteracion de un arreglo usando foreach
foreach (var item in arregloEnteros2)
{
    Console.WriteLine(item);
}

//Arreglos multidimensionales
int[,] arregloMultidimensional = new int[2, 2]; //Arreglo de 2x2
int[,] arregloMultidimensional2 = new int[,] { { 1, 2 }, { 3, 4 } }; //Arreglo de 2x2 inicializado
int[,] arregloMultidimensional3 = { { 1, 2 }, { 3, 4 } }; //Arreglo de 2x2 inicializado
//Acceso a elementos de un arreglo multidimensional
Console.WriteLine(arregloMultidimensional2[0, 0]); //Imprime el primer elemento del arreglo
//Modificacion de elementos de un arreglo multidimensional
arregloMultidimensional2[0, 0] = 10; //Modifica el primer elemento del arreglo
//Iteración de un arreglo multidimensional usando for
for (int i = 0; i < arregloMultidimensional2.GetLength(0); i++)
{
    for (int j = 0; j < arregloMultidimensional2.GetLength(1); j++)
    {
        Console.WriteLine($"Índices: {i}, {j} ");
        Console.WriteLine(arregloMultidimensional2[i, j]);
    }
}

//Iteracion de un arreglo multidimensional usando foreach
foreach (var item in arregloMultidimensional2)
{
    Console.WriteLine(item);
}

//Arreglos de arreglos
int[][] arregloDeArreglos = new int[2][]; //Arreglo de 2 arreglos
arregloDeArreglos[0] = new int[] { 1, 2, 3 }; //Inicializa el primer arreglo
arregloDeArreglos[1] = new int[] { 4, 5, 6 }; //Inicializa el segundo arreglo
//Acceso a elementos de un arreglo de arreglos
Console.WriteLine(arregloDeArreglos[0][0]); //Imprime el primer elemento del primer arreglo
//Modificacion de elementos de un arreglo de arreglos
arregloDeArreglos[0][0] = 10; //Modifica el primer elemento del primer arreglo
//Iteración de un arreglo de arreglos usando for
for (int i = 0; i < arregloDeArreglos.Length; i++)
{
    for (int j = 0; j < arregloDeArreglos[i].Length; j++)
    {
        Console.WriteLine($"Índices: {i}, {j} ");
        Console.WriteLine(arregloDeArreglos[i][j]);
    }
}
//Iteracion de un arreglo de arreglos usando foreach
foreach (var item in arregloDeArreglos)
{
    foreach (var subItem in item)
    {
        Console.WriteLine(subItem);
    }
}
#endregion

//Listas
#region Listas
//Definicion de Listas
List<int> listaEnteros = new List<int>(); //Lista de enteros vacía
List<int> listaEnteros2 = new List<int>() { 1, 2, 3, 4, 5 }; //Lista de enteros inicializada
//Acceso a elementos de una lista
Console.WriteLine(listaEnteros2[0]); //Imprime el primer elemento de la lista
//Modificacion de elementos de una lista
listaEnteros2[0] = 10; //Modifica el primer elemento de la lista
//Iteración de una lista usando for
for (int i = 0; i < listaEnteros2.Count; i++)
{
    Console.WriteLine(listaEnteros2[i]);
}
//Iteracion de una lista usando foreach
foreach (var item in listaEnteros2)
{
    Console.WriteLine(item);
}
//Agregar elementos a una lista
listaEnteros2.Add(6); //Agrega un elemento al final de la lista
listaEnteros2.Insert(0, 0); //Agrega un elemento en la posición 0
//Eliminar elementos de una lista
listaEnteros2.Remove(0); //Elimina el primer elemento con valor 0
listaEnteros2.RemoveAt(0); //Elimina el elemento en la posición 0
//Verificar si un elemento está en la lista
Console.WriteLine(listaEnteros2.Contains(1)); //Imprime true si el elemento 1 está en la lista

listaEnteros.All(x => x > 0); //Devuelve true si todos los elementos de la lista son mayores a 0
listaEnteros.Select(x => x > 10); //Devuelve una lista con los elementos de la lista que son mayores a 0

List<string> nombres = new List<string>() { "Juan", "Pedro", "María", "Ana" };

var subnombres = nombres.Where(x => x.Length == 5 ); //Devuelve una lista con los elementos que empiezan con "M"
foreach (var item in subnombres)
{
    Console.WriteLine(item);
}

var newLength = nombres.Where(x => x.Length == 5).Count(); //Devuelve la cantidad de elementos que empiezan con "M"
#endregion

//Diccionarios
#region Diccionarios
//Definicion de Diccionarios
Dictionary<string, int> diccionario = new Dictionary<string, int>(); //Diccionario vacío
Dictionary<string, int> diccionario2 = new Dictionary<string, int>() { { "uno", 1 }, { "dos", 2 } }; //Diccionario inicializado
//Acceso a elementos de un diccionario
Console.WriteLine(diccionario2["uno"]); //Imprime el valor asociado a la clave "uno"
//Modificacion de elementos de un diccionario
diccionario2["uno"] = 10; //Modifica el valor asociado a la clave "uno"
//Iteración de un diccionario
foreach (var item in diccionario2)
{
    Console.WriteLine($"Clave: {item.Key}, Valor: {item.Value}");
}
//Agregar elementos a un diccionario
diccionario2.Add("tres", 3); //Agrega un elemento al diccionario
//Eliminar elementos de un diccionario
diccionario2.Remove("uno"); //Elimina el elemento con clave "uno"
//Verificar si una clave está en el diccionario
Console.WriteLine(diccionario2.ContainsKey("uno")); //Imprime true si la clave "uno" está en el diccionario
#endregion

//Conjuntos
#region Conjuntos
//Definicion de Conjuntos
HashSet<int> conjunto = new HashSet<int>(); //Conjunto vacío
HashSet<int> conjunto2 = new HashSet<int>() { 1, 2, 3, 4, 5 }; //Conjunto inicializado
//Agregar elementos a un conjunto
conjunto2.Add(6); //Agrega un elemento al conjunto
//Eliminar elementos de un conjunto
conjunto2.Remove(1); //Elimina el elemento 1 del conjunto
//Verificar si un elemento está en el conjunto
Console.WriteLine(conjunto2.Contains(1)); //Imprime true si el elemento 1 está en el conjunto
//Iteración de un conjunto
foreach (var item in conjunto2)
{
    Console.WriteLine(item);
}
#endregion

//Colas
#region Colas
//Definicion de Colas
Queue<int> cola = new Queue<int>(); //Cola vacía
Queue<int> cola2 = new Queue<int>(new int[] { 1, 2, 3, 4, 5 }); //Cola inicializada
//Agregar elementos a una cola
cola2.Enqueue(6); //Agrega un elemento al final de la cola
//Eliminar elementos de una cola
cola2.Dequeue(); //Elimina el primer elemento de la cola
//Verificar el primer elemento de la cola
Console.WriteLine(cola2.Peek()); //Imprime el primer elemento de la cola
//Iteración de una cola
foreach (var item in cola2)
{
    Console.WriteLine(item);
}
#endregion

//Pilas
#region Pilas
//Definicion de Pilas
Stack<int> pila = new Stack<int>(); //Pila vacía
Stack<int> pila2 = new Stack<int>(new int[] { 1, 2, 3, 4, 5 }); //Pila inicializada
//Agregar elementos a una pila
pila2.Push(6); //Agrega un elemento al final de la pila
//Eliminar elementos de una pila
pila2.Pop(); //Elimina el primer elemento de la pila
//Verificar el primer elemento de la pila
Console.WriteLine(pila2.Peek()); //Imprime el primer elemento de la pila
//Iteración de una pila
foreach (var item in pila2)
{
    Console.WriteLine(item);
}
#endregion

string nombre = "Fernando";

foreach (var item in nombre)
{
    Console.WriteLine(item);
}

//String es una colección? Sí o no? y por qué?