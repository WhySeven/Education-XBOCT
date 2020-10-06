using System;
using System.Collections.Generic;
using System.Diagnostics;
namespace ProcedureOrientedProgram
{
    class Program
    {
        // Начало кода основного метода, осуществляющего все рассчёты и отрисовку таблицы, конечно, используюя в том числе и внешние методы
        public static void Solution(double x1, double y1, double x2, double y2, double g, int N)
        {

            double S = (x2 - x1) * (y2 - y1); // Площадь прямоугольника в котором находятся фигуры

            // Задаём координаты точек dego
            double dx = x2;
            double dy = y1;
            double ex = x2 - (y2 - y1);
            double ey = y2;
            double gx = x1;
            double gy = y1 + g;
            double ox = x2 - (y2 - y1);
            double oy = y1;


            double figure_S = TS(ex, ey, gx, gy, ox, oy) + QS(ox, oy, dx, dy); // Площадь фигуры dego вычисленная с помощью правил геометрии

            Stopwatch st = new Stopwatch();// объявляем таймер
            st.Start();// старт таймера
            Random r = new Random();
            int count = 0;
            for (int i = 0; i < N; i++)
            {
                double x = r.NextDouble() * (x2 - x1) + x1; // Случайная координата x ограниченная размерами прямоугольника
                double y = r.NextDouble() * (y2 - y1) + y1; // Случайная координата y ограниченная размерами прямоугольника

                if (CheckPinT(x, y, ex, ey, gx, gy, ox, oy) || CheckPinQ(x, y, ox, oy, dx, dy)) //Если точка попала в треугольник или квадрант(нашу фигуру dego), то счётчик увеличивается на 1
                {
                    count++;
                }

            }
            double mc_S = S * count / N;
            /* MK_S - Площадь фигуры, вычисленная с помощью метода Монте-Карло
            Площадь прямоугольника(ограниченного пространства куда мы будем кидать точки) умножить на кол-во попаданий и поделить на кол-во бросков */

            double relError = Math.Abs((figure_S - mc_S) / figure_S)*100; // Вычисление погрешности вычислений (relative error)

            st.Stop();// стоп таймера
            long tc = st.ElapsedTicks;// подсчёт тиков

            // Вывод таблицы в консоль
            int[] tableCellSizes = new int[] { 14, 24, 30, 26, 18 };
            static void DrawHorizontal(string a, string b, string c, int[] tableCellSizes)
            {
                Console.Write(a);
                for (int j = 0; j < tableCellSizes.Length; j++)
                {
                    for (int i = 0; i < tableCellSizes[j]; i++)
                    {
                        Console.Write("═");
                    }
                    if (j != tableCellSizes.Length - 1)
                    {
                        Console.Write(b);
                    }
                }
                Console.WriteLine(c);
            }
            void DrawCellLine(int[] tableCellSizes)
            {
                DrawHorizontal("╔", "╦", "╗", tableCellSizes);
                Console.WriteLine("║ N = {0,-8} ║ dego Square = {1,-8} ║ MonteCarlo Square = {2,-8} ║ Relative Error = {3,-6}% ║ tiks = {4,-9} ║", N, Math.Round(figure_S, 3), Math.Round(mc_S, 3), Math.Round(relError, 3), tc);
                DrawHorizontal ("╚", "╩", "╝", tableCellSizes);
            }
            DrawCellLine(tableCellSizes);                     
        }


        // Далее идут различные методы, использованные в коде выше

        // Проверка наличия точки в Треугольнике
        public static bool CheckPinT(double x0, double y0, double x1, double y1, double x2, double y2, double x3, double y3)
        {
            double buf1 = (x1 - x0) * (y2 - y1) - (x2 - x1) * (y1 - y0);
            double buf2 = (x2 - x0) * (y3 - y2) - (x3 - x2) * (y2 - y0);
            double buf3 = (x3 - x0) * (y1 - y3) - (x1 - x3) * (y3 - y0);
            if ((buf1 >= 0 && buf2 >= 0 && buf3 >= 0) || (buf1 <= 0 && buf2 <= 0 && buf3 <= 0))
            {
                return true;
            }
            else return false;
        }

        // Проверка наличия точки в квадранте
        public static bool CheckPinQ(double x, double y, double cntrX, double cntrY, double Px, double Py)
        {
            double R = Len(cntrX, cntrY, Px, Py);

            if ((Math.Pow(x - cntrX, 2) + Math.Pow(y - cntrY, 2) <= Math.Pow(R, 2)) && (x >= cntrX) && (y >= cntrY))
            {
                return true;
            }
            else return false;
        }

        // Вычисление точной площади квадранта
        public static double QS(double X1, double Y1, double X2, double Y2)
        {
            return Math.Pow(Len(X1, Y1, X2, Y2), 2) * 0.25 * Math.PI;
        }

        // Вычисление точной площади треугольника
        public static double TS(double X1, double Y1, double X2, double Y2, double X3, double Y3)
        {
            double P = (Len(X1, Y1, X2, Y2) + Len(X2, Y2, X3, Y3) + Len(X3, Y3, X1, Y1)) / 2;
            return Math.Sqrt(P * (P - Len(X1, Y1, X2, Y2)) * (P - Len(X2, Y2, X3, Y3)) * (P - Len(X3, Y3, X1, Y1)));
        }

        // Вычисление длины отрезка
        public static double Len(double X1, double Y1, double X2, double Y2)
        {
            return Math.Sqrt(Math.Pow(X1 - X2, 2) + Math.Pow(Y1 - Y2, 2));
        }

        // Метод меняющий значения переменных местами
        public static void SwapValues(ref double a, ref double b)
        {
            a += b;
            b = a - b;
            a -= b;
        }

        

        // Отсюда начинается Меню
        static void Main()
        {
            // Введение переменных, необходимых для описания фигуры и буферных переменных, необходимых для предотвращения ошибок при вводе данных
            double x1 = 0;
            double x2 = 0;
            double y1 = 0;
            double y2 = 0;
            double g = 0;
            double bx1, by1, bx2, by2, buf;

            Console.CursorVisible = false;

            List<string> menuItem = new List<string>() // Создание пунктов меню
            {
                "Set Input Data",
                "Set Example of Data",
                "Show Current Data",
                "Calculate",
                "Exit",
                ""
            };

            // Цикл вызывающий определённные действия в зависимости от выбранного пункта меню
            while (true)
            {
                string SelectedMenuItem = DrawMenu(menuItem);

                // 1.
                // Пункт меню, запускающий ввод данных вручную
                if (SelectedMenuItem == "Set Input Data")
                {
                    Console.Clear();
                    SetRectangle();
                    void SetRectangle() // Метод для введения введения координат прямоугольника, содержащего нашу фигуру, с помощью 2-ух точек, лежащих на его диагонали
                    {
                        Console.WriteLine("Set coordinates for 1st point on diagonal of your Rectangle\n\n");
                        Console.Write("Set X:");
                        bx1 = CheckedReadLine();
                        Console.Write("\nSet Y:");
                        by1 = CheckedReadLine();
                        Console.Clear();

                        Console.WriteLine("Set coordinates for 2nd point on diagonal of your Rectangle\n\n");
                        Console.Write("Set X:");
                        bx2 = CheckedReadLine();
                        Console.Write("\nSet Y:");
                        by2 = CheckedReadLine();
                        Console.Clear();
                    }

                    while (bx1 == bx2 || by1 == by2) // Вывод ошибки о том, что по таким точкам можно построить только линию и просьба ввести данные заного
                    {
                        Console.WriteLine("Error: You got a line, not a Rectangle\n\nPlease, enter correct data");
                        PressAnyKeyToContinue();
                        SetRectangle();
                    }
                    while (bx1 == bx2 && by1 == by2) // Вывод ошибки о том, что по таким точкам можно построить только точку
                    {
                        Console.WriteLine("Error: You got a point, not a Rectangle\n\nPlease, enter correct data");
                        PressAnyKeyToContinue();
                        SetRectangle();
                    }
                    while (Math.Abs(bx1 - bx2) == Math.Abs(by1 - by2)) // Вывод ошибки о том, что по таким точкам можно построить только квадрат
                    {
                        Console.WriteLine("Error: You got a quadrate, not a Rectangle\n\nPlease, enter correct data");
                        PressAnyKeyToContinue();
                        SetRectangle();
                    }


                    // Если пользователь не правильно расположил прямоугольник программа сама исправит это поменяв координаты X и Y
                    if ((bx1 > bx2) && (by1 > by2)) { SwapValues(ref bx1, ref bx2); SwapValues(ref by1, ref by2); }
                    else if ((bx1 < bx2) && (by1 > by2)) { SwapValues(ref by1, ref by2); }
                    else if ((bx1 > bx2) && (by1 < by2)) { SwapValues(ref bx1, ref bx2); }
                    if (Math.Abs(bx1 - bx2) <= Math.Abs(by1 - by2))
                    {
                        SwapValues(ref bx1, ref by1);
                        SwapValues(ref bx2, ref by2);
                        Console.WriteLine("I'm swap X and Y axis");
                        PressAnyKeyToContinue();
                    }


                    // Просьба ввести расстояние от точки g до точки a
                    Console.Write("Set indent for point 'g' relative to point 'a': ");
                    buf = CheckedReadLine();
                    // Проверка того, что расстояние от точки g до точки не больше, чем сторона ab
                    while (buf >= Math.Abs(by2 - by1) || buf <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Error: indent more then side AB or less then/equal 0");
                        Console.Write("Please, set indent for point 'g' relative to point 'a' again: ");
                        buf = CheckedReadLine();
                    }
                    x1 = bx1;
                    x2 = bx2;
                    y1 = by1;
                    y2 = by2;
                    g = buf;
                    Console.Clear();
                    Console.WriteLine("Your Rectangle was set\nP1: X={0}, Y={1};\nP2: X={2}, Y={3}\nIndent for point 'g': {4}.", x1, y1, x2, y2, g);
                    PressAnyKeyToContinue();
                }

                // 2.
                // Пункт меню с помощью которого мы можем задать пример данных для построения фигуры
                else if (SelectedMenuItem == "Set Example of Data")
                {
                    x1 = 0;
                    y1 = 0;
                    x2 = 15;
                    y2 = 5;
                    g = 3;
                    Console.Clear();
                    Console.Write("You set Example of Data\nP1: X={0}, Y={1};\nP2: X={2}, Y={3}\nIndent for point 'g': {4}.", x1, y1, x2, y2, g);
                    PressAnyKeyToContinue();
                }

                // 3.
                // Пункт меню, показывающий текущие данные для построения фигуры
                else if (SelectedMenuItem == "Show Current Data")
                {
                    Console.Clear();
                    Console.WriteLine("Your Rectangale current data\nP1: X={0}, Y={1};\nP2: X={2}, Y={3}\nIndent for point 'g': {4}.", x1, y1, x2, y2, g);
                    PressAnyKeyToContinue();
                }

                // 4.
                // Пункт меню запускающий вычисления
                else if (SelectedMenuItem == "Calculate")
                {
                    Console.Clear();
                    // Проверка на то были ли введены данные
                    if ((x1 == x2) || (y1 == y2))
                    {
                        Console.WriteLine("You don't set data / Your data is incorrect");
                        PressAnyKeyToContinue();
                    }
                    else
                    {
                        for (int N = 1000; N <= Math.Pow(10, 7); N *= 10)
                        {
                            Solution(x1, y1, x2, y2, g, N); // Вызов нашего основного метода Solution, используюя ранее введённые данные
                        }
                        PressAnyKeyToContinue();
                    }

                }

                // 5.
                // Пункт меню, обеспечивающий выход из программы
                else if (SelectedMenuItem == "Exit")
                {
                    Environment.Exit(0);
                }
            }
        }



        // Метод DrawMenu. С помощью него и работает меню.
        private static int index = 0;
        public static string DrawMenu(List<string> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(items[i]);
                }
                else
                {
                    Console.WriteLine(items[i]);
                }
                Console.ResetColor();
            }
            ConsoleKeyInfo ckey = Console.ReadKey();
            if (ckey.Key == ConsoleKey.DownArrow && index < items.Count - 2)
            {
                index++;
            }
            else if (ckey.Key == ConsoleKey.UpArrow && index > 0)
            {
                index--;
            }
            else if (ckey.Key == ConsoleKey.Enter)
            {
                return items[index];
            }
            else if (ckey.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            Console.Clear();
            return "";
        }

        // Метод проверяющий является ли строка числом
        public static double CheckedReadLine()
        {
            if (double.TryParse(Console.ReadLine(), out double digit))
            {
                return digit;
            }
            else
            {
                Console.Write("Incorrect data format, please enter data again:");
                return CheckedReadLine();
            }
        }

        // Метод сообщающий, что нужно нажать на клавишу для того, чтобы продолжить
        static void PressAnyKeyToContinue()
        {
            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}