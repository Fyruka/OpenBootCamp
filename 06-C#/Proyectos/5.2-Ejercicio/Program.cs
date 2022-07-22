////Ejercicio 2 - Switch

////Haz una lista de lenguajes de programación, por ejemplo: C#, Java, C++. Presenta la lista en consola y pide que el usuario seleccione el lenguaje mediante 1, 2, 3 o a, b, c. Presenta el resultado en consola.

////Nota: puedes añadir al resultado el “Hola, mundo” para el caso de C#.

//var lenguages = new List<string> { "C#", "Java", "C++", "JavaScript", "Python"};

//foreach (var (lenguage, index) in lenguages.Select((value, i) => (value, i)))
//{
//    Console.WriteLine($"{index}: {lenguage}");
//}

//Console.WriteLine("Selecciona un lenguaje con el num: ");
//int select = Convert.ToInt32(Console.ReadLine());

//if (select == 0)
//{
//    Console.WriteLine($"Has seleccionado: {lenguages[select]}");
//    Console.WriteLine($"Hola mundo! ^^");
//}
//else
//{
//    Console.WriteLine($"Has seleccionado: {lenguages[select]}");
//}

var apple = new { Item = "apples", Price = 1.35 };
var onSale = apple with { Price = 0.79 };
Console.WriteLine(apple);
Console.WriteLine(onSale);