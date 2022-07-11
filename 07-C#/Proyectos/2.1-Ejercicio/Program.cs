// Ejercicio 1 - Variables

// - Escribe un programa que reciba datos de una persona y genera un mensaje, usa una variable para cada dato y otra para el mensaje.
//      Ej: nombre, apellido, edad, sabe programar, etc.


Console.WriteLine("Escribe tu nombre: ");
string? nombre = Console.ReadLine();

Console.WriteLine("Escribe tu apellido: ");
string? apellido = Console.ReadLine();

Console.WriteLine("Escribe tu edad: ");
int? edad = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Sabes programar? (si - no) ");
string? programar = Console.ReadLine();

Console.WriteLine("Te llamas " + nombre + " " + apellido + " y tienes " + edad + " años, y " + programar + " sabes programar.");