//Ejercicio 3

//Operadores Determina los operadores para verificar las siguientes condiciones:
//  - Un número es mayor o igual a 18
//  - Un char es ‘a’
//  - Se cumplen dos conciones a la vez (ambas verdaderas)
//  - Se cumple una de dos condiciones a la vez (una true y otra false)

//Nota: puedes escribir estos datos por consola si prefieres verlos. La idea del ejercicio es almacenar los datos en los tipos más adecuados.

int num1 = 20;
bool mayor = (num1 >= 18);


char a = 'a';
Type char1 = a.GetType();
Type char2 = typeof(char);
bool isa = (char2 == char1);


int numCon1 = 20;
int numCon2 = 40;
bool condicion = (numCon1 >= 10 && numCon2 >= 30);


bool condicion2 = (numCon2 >= 10 || numCon2 >= 50);
















Console.WriteLine("Es mayor? " + mayor);
Console.WriteLine("Es un char? " + isa);
Console.WriteLine("La condicion es: " + condicion);
Console.WriteLine("La condicion2 es: " + condicion);