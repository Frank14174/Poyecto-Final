using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;

namespace culebrita.Clases.Cola_Arreglo
{
    class CulebritaLineal
    {
        internal enum Direction
        {
            Abajo, Izquierda, Derecha, Arriba
        }

        private static void DibujaPantalla(Size size)
        {
            Console.Title = "Culebrita comelona";
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

        private static bool MoverLaCulebrita(ColaLineal culebra, Point posiciónObjetivo,
            int longitudCulebra, Size screenSize)
        {
            try
            {
                var lastPoint = (Point)culebra.finalCola();

                if (lastPoint.Equals(posiciónObjetivo))
                    return true;


                if (culebra.Equals(posiciónObjetivo))
                    return false;


                if (posiciónObjetivo.X < 0 || posiciónObjetivo.X >= screenSize.Width
                        || posiciónObjetivo.Y < 0 || posiciónObjetivo.Y >= screenSize.Height)
                {
                    return false;
                }
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.SetCursorPosition(lastPoint.X + 1, lastPoint.Y + 1);
                Console.WriteLine(" ");

                culebra.insertar(posiciónObjetivo);

                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.SetCursorPosition(posiciónObjetivo.X + 1, posiciónObjetivo.Y + 1);
                Console.Write(":");

                // Quitar cola
                if (culebra.el() > (longitudCulebra))
                {
                    var removePoint = (Point)culebra.quitar();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(removePoint.X + 1, removePoint.Y + 1);
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

        private static Point MostrarComida(Size screenSize, ColaLineal culebra)
        {
            var lugarComida = Point.Empty;
            var cabezaCulebra = (Point)culebra.frenteCola();
            var rnd = new Random();
            Point point = (Point)culebra.finalCola();

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

            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(lugarComida.X + 1, lugarComida.Y + 1);
            Console.Write(" ");


            return lugarComida;
        }
        public void linealCulebrita()
        {
            try
            {
                var punteo = 0;
                var velocidad = 100; //modificar estos valores y ver qué pasa
                var posiciónComida = Point.Empty;
                var tamañoPantalla = new Size(60, 20);
                var culebrita = new ColaLineal();
                var longitudCulebra = 3; //modificar estos valores y ver qué pasa
                var posiciónActual = new Point(0, 9); //modificar estos valores y ver qué pasa
                culebrita.insertar(posiciónActual);
                var dirección = Direction.Derecha; //modificar estos valores y ver qué pasa
                var punteo2 = 20;

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
                    if (punteo == punteo2) {
                        velocidad = 75;
                    }

                    if (posiciónComida == Point.Empty) //entender qué hace esta linea
                    {
                        posiciónComida = MostrarComida(tamañoPantalla, culebrita);
                    }
                }

                Console.ResetColor();
                Console.SetCursorPosition(tamañoPantalla.Width / 2 - 4, tamañoPantalla.Height / 2);
                Console.Write("Fin del Juego");
                Thread.Sleep(2000);
                Console.ReadKey();
            }
            catch (Exception e)
            { 
                Console.WriteLine("Error= " + e.Message);
            }

        }
    }
}
