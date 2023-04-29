using System.Data;

int[,] CrearTablero(int filas, int columnas)
{
    int[,] tablero = new int[filas, columnas];

    for (int i = 0; i < filas; i++)
    {
        for (int j = 0; j < columnas; j++)
        {
            tablero[i, j] = 0;
        }
    }

    return tablero;
}

int[,] tablero1 = CrearTablero(5, 5);
int[,] tablero2 = CrearTablero(5, 5);

void paso2_colocar_barcos(int[,] tablero3)
{
    Random rand = new Random();
    HashSet<string> coordenadas = new HashSet<string>(); // usamos un HashSet para almacenar las coordenadas

    while (coordenadas.Count < 5) // generamos coordenadas hasta que tengamos 5 únicas
    {
        int x = rand.Next(0, 5);
        int y = rand.Next(0, 5);
        string coord = $"{x},{y}"; // concatenamos x e y en una cadena

        if (!coordenadas.Contains(coord)) // verificamos si la coordenada ya está en el conjunto
        {
            coordenadas.Add(coord); // si no está, la agregamos al conjunto
            tablero3[x, y] = 1; //guardamos las coordenadas de los barcos de damos el valor de 1 
        }
    }

}
string nombre1 = "";
string nombre2 = "";
int a3, a4;
a3 = a4 = 0;
void inicio()
{
    paso2_colocar_barcos(tablero1);
    paso2_colocar_barcos(tablero2);
    direccion(tablero1, nombre2, a3);
    Console.WriteLine();
    Console.WriteLine("Presione una tecla para que el siguiente jugador empiece..");
    Console.ReadKey();
    direccion(tablero2, nombre1, a4);
}
void paso3_imprimir_tablero(int[,] tablero4)

{

    string caracter_imprimir = "|";

    for (int f = 0; f < tablero4.GetLength(0); f++)

    {

        for (int c = 0; c < tablero4.GetLength(1); c++)

        {
            switch (tablero4[f, c])

            {

                case 0:

                    caracter_imprimir = "~";

                    break;

                case 1:

                    caracter_imprimir = "-";

                    break;

                case -1:

                    caracter_imprimir = "*";

                    break;

                case -2:

                    caracter_imprimir = "X";

                    break;

            }

            Console.Write(caracter_imprimir + "| ");

        }

        Console.WriteLine();

    }
}
void direccion(int[,] tablero5, string nombreusuario, int a2)
{

    int fila = 0, columna = 0;
    int final = 0;
    int a11 = 0;
    Console.Clear();
    do

    {
        a11++;
        try
        {
            Console.Write("Ingrese la fila de 0 a 4: ");

            fila = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese la columna de 0 a 4: ");

            columna = Convert.ToInt32(Console.ReadLine());

            if (fila > 4 || columna > 4)
            {
                throw new Exception("Las coordenadas ingresadas estan fuera del rango de la matriz ");
                Console.WriteLine();
            }




            if (tablero5[fila, columna] == 1)
            {

                Console.Beep();

                tablero5[fila, columna] = -1;
                final++;
                Console.WriteLine($"llevas {final} barcos derivados");
            }
            else

            {

                tablero5[fila, columna] = -2;

            }
            Console.Clear();
            paso3_imprimir_tablero(tablero5);
            Console.WriteLine($"Es turno de {nombreusuario}");
            Console.WriteLine($"Barcos derivados :{final}");
            Console.WriteLine($"numero de intentos :{a11}");

        }
        catch (FormatException ex)
        {
            Console.WriteLine("error de formato: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("----ERROR------" + ex.Message);
            Console.WriteLine();
        }
        Console.WriteLine();

    } while (final < 5);
}

void principal()
{
    Console.Clear();
    Console.WriteLine("-----------------------------------------");
    Console.WriteLine("        BIENVENIDO A LA BATALLA NAVAL     ");
    Console.WriteLine("-----------------------------------------\n");
    Console.WriteLine("           INSTRUCCIONES DEL JUEGO\n");
    Console.WriteLine("Cada jugador tiene un tablero de 5x5 en el que se colocan 5 barcos.");
    Console.WriteLine("Cada jugador deberá adivinar las coordenadas de los barcos del otro.");
    Console.WriteLine("Gana el jugador que derive en menos intentos los barcos del otro.\n");

    Console.Write("Ingrese el nombre del jugador 1: ");
    nombre1 = Console.ReadLine();

    Console.Write("Ingrese el nombre del jugador 2: ");
    nombre2 = Console.ReadLine();

    inicio();
    if (a3 < a4)
    {
        Console.WriteLine($"-----------------FELICIDADES----------------------");
        Console.WriteLine($"El ganador es {nombre2} por menos intentos realizados");
        Console.WriteLine(); Console.WriteLine($"!!!!! {nombre1} mas suerte la proxima...");
    }
    else
    {
        Console.WriteLine($"-----------------FELICIDADES----------------------");
        Console.WriteLine($"El ganador es {nombre1} por menos intentos realizados");
        Console.WriteLine(); Console.WriteLine($"!!!!! {nombre2} mas suerte la proxima...");
    }
}
principal();

