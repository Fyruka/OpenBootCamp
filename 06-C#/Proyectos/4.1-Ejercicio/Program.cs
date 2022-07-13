//Ejercicio 1 - While

//Escribe una tabla de multiplicar del 1 al 10 para un número entero que recibe por consola. Es decir, un programa que presente para el 1:

//1 x 1 = 1
//1 x 2 = 2
//…
//1 x 10 = 10

int num1 = 1;
int num2 = 1;
while (num1 < 11)
{
    while (num2 < 11)
    {
        int resultado = num1 * num2;
        Console.WriteLine($"{num1} x {num2} = {resultado}");
        num2++;
    }
    num2 = 1;
    num1++;
    Console.WriteLine(" ");
}


//for (int num1 = 1; num1 < 11; num1++)
//{
//    for (int num2 = 1; num2 < 11; num2++)
//    {
//        int resultado = num1 * num2;
//        Console.WriteLine($"{num1} x {num2} = {resultado}");
//    }
//    Console.WriteLine(" ");
//}