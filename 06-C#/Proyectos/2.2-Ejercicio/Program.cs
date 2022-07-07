//Ejercicio 2 - Tipos
//
//Usando los tipos de variables más adecuados, describe los objetos siguientes:
//  - Coche: puertas, ruedas, marca, ITV vigente
//  - Mesa: peso, largo, material, color

//Nota: puedes escribir estos datos por consola si prefieres verlos. La idea del ejercicio es almacenar los datos en los tipos más adecuados.

// coche:

int puertas = 4;
int ruedas = 4;
string marca = "Mazda";
bool itv = true;

string pasada = "sin pasar";

if (itv) {
    pasada = "pasada";
}

Console.WriteLine("El coche tiene " + puertas + " puertas y " + ruedas + " ruedas, es de la marca " + marca + ", y tiene la itv " + pasada);