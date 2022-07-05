
Console.WriteLine("Hola, mundo!");

string nombre = "Samuel";
Console.WriteLine("Hola, " + nombre);


Console.WriteLine("Introduce tu nombre:");
string nombre_consola = Console.ReadLine();
Console.WriteLine("Hola, " + nombre_consola);

DateTime dateTime = DateTime.UtcNow.Date;
Console.WriteLine(dateTime.ToString("dd/MM/yyyy"));