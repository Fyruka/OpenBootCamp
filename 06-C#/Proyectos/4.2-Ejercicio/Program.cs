//Ejercicio 2 - Do while

//Escribe un programa que realice estos pasos:
//  - Reciba al menos un número por consola
//  - Determine si el número es positivo o negativo
//  - Presente un contador para cada tipo (positivo y negativo).

//Nota: el cero se puede abordar en una clase adicional ya que no es ni positivo ni negativo. Tienes completa libertad para elegir el formato de la salida.

Console.WriteLine("Escribe un numero: ");
int numero = Convert.ToInt32(Console.ReadLine());

if (numero < 0)
{
    Console.WriteLine($"{numero} es negativo");
    do
    {
        Console.WriteLine($" {numero} ");
        numero++;
    } while (numero != 0);
}
else if (numero > 0)
{
    Console.WriteLine($"{numero} es postivo");
    do
    {
        Console.Write($" {numero} ");
        numero--;
    } while (numero != 0);
}
else if (numero == 0)
{
    Console.WriteLine("El numero ya es 0");
}


