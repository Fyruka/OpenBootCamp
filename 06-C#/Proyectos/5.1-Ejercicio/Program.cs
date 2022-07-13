//Ejercicio 1 - If

//Escribe un programa que:
//  - Pida datos a un cliente: Nombre, email, cupón
//  - Determine si un cliente tiene un cupon descuento
//  - Muestre un precio rebajado en función del descuento
//  - Muestre el precio de un producto sin descuento si no hay cupón

//Nota: puedes poner un precio fijo de un producto o uno variable.

Console.WriteLine("Escribe tu nombre: ");
string name = Console.ReadLine();

Console.WriteLine("Escribe tu email: ");
string email = Console.ReadLine();

Console.WriteLine("Escribe tu descuento: ");
string? cupon = Console.ReadLine();


int price = 1000;
int finalprice = price;

Console.WriteLine(cupon);
if (!string.IsNullOrEmpty(cupon))
{
    finalprice = price - (price * Convert.ToInt32(cupon)) / 100;
}

Console.WriteLine($"Nombre cliente: {name} \nEmail: {email} \nEl precio que ha solicitado es: ${finalprice}");