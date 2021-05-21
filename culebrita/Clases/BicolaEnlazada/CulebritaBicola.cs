using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;

namespace culebrita.Clases.BicolaEnlazada
{
    class CulebritaBicola
    {
        //convertirlo en un programa orietado a objetos
        //emitir beep cuando coma la comida
        //incrementar la velocidad conforme vaya avanzando
        //modificar el uso de queue y reemplazarlo con cada una de las estructuras de de cola vista en clase
        //Elaborar Video explicando el funcionamiento del código y del programa.

        internal enum Direction
        {
            Abajo, Izquierda, Derecha, Arriba
        }

        private static void DibujaPantalla(Size size)
        {
            Console.Title = "Culebrita Con BiCola";
            Console.WindowHeight = size.Height + 2;
            Console.WindowWidth = size.Width + 2;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();

            Console.BackgroundColor = ConsoleColor.Black;
            for (int row = 0; row < size.Height; row++)
            {
                for (int col = 0; col < size.Width; col++)
                {
                    Console.SetCursorPosition(col + 1, row + 1);
                    Console.Write(" ");
                }
            }
        }

        private static void MuestraPunteo(int punteo)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(1, 0);
            Console.Write($"Puntuación: {punteo.ToString("00000000")}");
        }

        private static Direction ObtieneDireccion(Direction direccionAcutal)
        {
            if (!Console.KeyAvailable) return direccionAcutal;

            var tecla = Console.ReadKey(true).Key;
            switch (tecla)
            {
                case ConsoleKey.DownArrow:
                    if (direccionAcutal != Direction.Arriba)
                        direccionAcutal = Direction.Abajo;
                    break;
                case ConsoleKey.LeftArrow:
                    if (direccionAcutal != Direction.Derecha)
                        direccionAcutal = Direction.Izquierda;
                    break;
                case ConsoleKey.RightArrow:
                    if (direccionAcutal != Direction.Izquierda)
                        direccionAcutal = Direction.Derecha;
                    break;
                case ConsoleKey.UpArrow:
                    if (direccionAcutal != Direction.Abajo)
                        direccionAcutal = Direction.Arriba;
                    break;
            }
            return direccionAcutal;
        }

        private static Point ObtieneSiguienteDireccion(Direction direction, Point currentPosition)
        {
            Point siguienteDireccion = new Point(currentPosition.X, currentPosition.Y);
            switch (direction)
            {
                case Direction.Arriba:
                    siguienteDireccion.Y--;
                    break;
                case Direction.Izquierda:
                    siguienteDireccion.X--;
                    break;
                case Direction.Abajo:
                    siguienteDireccion.Y++;
                    break;
                case Direction.Derecha:
                    siguienteDireccion.X++;
                    break;
            }
            return siguienteDireccion;
        }

        private static bool MoverLaCulebrita(Bicola culebra, Point posiciónObjetivo,
            int longitudCulebra, Size screenSize)
        {

            var lastPoint = (Point)culebra.finalBicola();


            try
            {

                if (lastPoint.Equals(posiciónObjetivo))
                    return true;


                if (culebra.frente.elemento.Equals(posiciónObjetivo))
                    return false;


                if (posiciónObjetivo.X < 0 || posiciónObjetivo.X >= screenSize.Width
                        || posiciónObjetivo.Y < 0 || posiciónObjetivo.Y >= screenSize.Height)

                {
                    return false;
                }

                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(lastPoint.X + 1, lastPoint.Y + 1);
                Console.WriteLine(" ");

                culebra.ponerFinalbi(posiciónObjetivo);
                //culebra.ponerFrentebi(posiciónObjetivo);

                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(posiciónObjetivo.X + 1, posiciónObjetivo.Y + 1);
                Console.Write(":");

                // Quitar cola
                if (culebra.numElementosBicola() > (longitudCulebra))
                {
                    var removePoint = (Point)culebra.quitarFrentebi();
                    //var removeP = (Point)culebra.quitarFinalbi();

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(removePoint.X + 1, removePoint.Y + 1);
                    //Console.SetCursorPosition(removeP.X+1, removeP.Y+1);
                    Console.Write(" ");
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error=" + e.Message);
                return false;
            }

        }

        private static Point MostrarComida(Size screenSize, Bicola culebra)
        {
            var lugarComida = Point.Empty;
            var cabezaCulebra = (Point)culebra.finalBicola();
            var rnd = new Random();
            Point point = (Point)culebra.frente.elemento;

            do
            {
                var x = rnd.Next(0, screenSize.Width - 1);
                var y = rnd.Next(0, screenSize.Height - 1);

                if ((point.X != x || point.Y != y)
                    && Math.Abs(x - cabezaCulebra.X) + Math.Abs(y - cabezaCulebra.Y) > 8)
                {
                    lugarComida = new Point(x, y);
                }

            } while (lugarComida == Point.Empty);

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(lugarComida.X + 1, lugarComida.Y + 1);
            Console.Write(" ");


            return lugarComida;
        }
        public void biColaCulebrita()
        {
            try
            {
                int opcion;
                do
                {
                    Random rnd = new Random();
                    var punteo = 0;
                    var punteo2 = 50;
                    var velocidad = 150; //modificar estos valores y ver qué pasa
                    var velocidad2 = 100;
                    var posiciónComida = Point.Empty;
                    var tamañoPantalla = new Size(60, 20);

                    var culebrita = new Bicola();
                    var longitudCulebra = 3; //modificar estos valores y ver qué pasa

                    int aparicioncule1 = rnd.Next(0, 50);
                    int aparicioncule2 = rnd.Next(0, 20);

                    var posiciónActual = new Point(aparicioncule1, aparicioncule2); //modificar estos valores y ver qué pasa
                    culebrita.insertar(posiciónActual);
                    var dirección = Direction.Izquierda; //modificar estos valores y ver qué pasa

                    DibujaPantalla(tamañoPantalla);
                    MuestraPunteo(punteo);

                    while (MoverLaCulebrita(culebrita, posiciónActual, longitudCulebra, tamañoPantalla))
                    {
                        Thread.Sleep(velocidad);
                        dirección = ObtieneDireccion(dirección);
                        posiciónActual = ObtieneSiguienteDireccion(dirección, posiciónActual);

                        if (posiciónActual.Equals(posiciónComida))
                        {
                            posiciónComida = Point.Empty;
                            longitudCulebra++; //modificar estos valores y ver qué pasa
                            punteo += 10; //modificar estos valores y ver qué pasa
                            MuestraPunteo(punteo);
                            Console.Beep();
                        }
                        if (punteo >= punteo2)
                        {
                            velocidad2 -= 30;
                            velocidad = velocidad2;
                            punteo2 += 60;
                        }

                        if (posiciónComida == Point.Empty) //entender qué hace esta linea
                        {
                            posiciónComida = MostrarComida(tamañoPantalla, culebrita);
                        }
                    }

                    Console.ResetColor();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(tamañoPantalla.Width / 2 - 4, tamañoPantalla.Height / 2);
                    Console.WriteLine("Has Perdido :( ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(tamañoPantalla.Width / 2 - 4, (tamañoPantalla.Height + 2) / 2);
                    Console.Write("1.Jugar De Nuevo :) ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(tamañoPantalla.Width / 2 - 4, (tamañoPantalla.Height + 4) / 2);
                    Console.Write("2.Salir ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(tamañoPantalla.Width / 2 - 4, (tamañoPantalla.Height + 6) / 2);
                    Console.Write("Opcion: ");
                    opcion = Convert.ToInt32(Console.ReadLine());
                    Thread.Sleep(2000);


                } while (opcion != 2);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error= " + e.Message);
            }

        }
    }
}
