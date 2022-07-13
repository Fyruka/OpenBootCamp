//Escribe un programa que realice estos pasos:

//Reciba 3 datos:
//  - ancho
//  - alto
//  - relleno o no

//Dibuje en consola con un mismo caracter, por ejemplo *, un rectángulo de las dimensiones introducidas y use el tercer dato para discernir si el rectángulo está relleno (tiene más * dentro) o no.
//En caso de recibir el mismo número n dos veces debe dibujar un cuadrado de lado n.

//Reto: Extiende el programa anterior para recibir otro número que sea el número de cuadrados o rectángulos que se deben dibujar en la pantalla.Ejemplos:

//  - Input: 2,2,2, relleno = true

//      Output:
//      ** **
//      ** **

//  - Input: 3, 4, 1, relleno = false

//      Output:
//      ***
//      * *
//      * *
//      ***

Console.WriteLine("Escribe un numero para definir el ancho: ");
int ancho = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Escribe un numero para definir el alto: ");
int alto = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Escribe un numero para definir cuantas copias quieres: ");
int copias = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Escribe true o false, para definir si quieres que tenga relleno: ");
bool relleno = Convert.ToBoolean(Console.ReadLine());

int modAlto = alto;
while (modAlto > 0)
{
    int modCopias = copias;
    while (modCopias >= 1)
    {
        int modAncho = ancho;
        while (modAncho > 0)
        {
            if (relleno)
            {
                Console.Write("*");
                modAncho--;
            }
            else
            {
                if ((modAlto == alto || modAncho == ancho) || (modAlto == 1 || modAncho == 1))
                {
                    Console.Write("*");
                    modAncho--;
                }
                else if (modAlto != alto && modAlto != 1)
                {
                    Console.Write(" ");
                    modAncho--;
                }
            }
        }
        modAncho = ancho;
        if (modCopias > 1)
        {
            Console.Write("  ");
        }
        modCopias--;
    }
    Console.Write("\n");
    modAlto--;
}

