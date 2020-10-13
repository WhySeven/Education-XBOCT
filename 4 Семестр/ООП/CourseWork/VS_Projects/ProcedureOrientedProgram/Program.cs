using System;
using System.Collections.Generic;
using System.Diagnostics;
namespace ProcedureOrientedProgram
{
    class Program
    {
        // Начало кода основного метода, осуществляющего все рассчёты и отрисовку таблицы, конечно, используюя в том числе и внешние методы
        public static void MonteCarlo(double ax, double ay, double ex, double ey, double gx, double gy, int N)
        {
            // Площадь прямоугольника в котором находятся фигуры
            double S = (ex + (ey - ay) - ax) * (ey - ay);

            // Задаём координаты недостаяющих точек dego
            double ox = ex;
            double oy = ay;
            double dx = ex+(ey-ay);
            double dy = ay;

            // Точная площадь фигуры dego
            double figure_Square = TriangleSquare(ex, ey, gx, gy, ox, oy) + QuadrantSquare(ox, oy, dx, dy);

            // Объявляем таймер
            Stopwatch st = new Stopwatch();

            // Старт таймера
            st.Start();

            Random random = new Random();
            int count = 0;
            for (int i = 0; i < N; i++)
            {
                // Случайная координата x ограниченная размерами прямоугольника
                double x = random.NextDouble() * (ex + (ey - ay) - ax) + ax;

                // Случайная координата y ограниченная размерами прямоугольника
                double y = random.NextDouble() * (ey - ay) + ay;

                //Если точка попала в треугольник или квадрант(нашу фигуру dego), то счётчик увеличивается на 1
                if (CheckPointInTriangle(x,y,ex, ey, gx, gy, ox, oy) || CheckPointInQuadrant(ox, oy, dx, dy,x,y)) { count++; }                    
            }

            /* monte_carlo_Square - Площадь фигуры, вычисленная с помощью метода Монте-Карло:
            Точная площадь прямоугольника умножить на кол-во попаданий и поделить на кол-во бросков */
            double monte_carlo_Square = S * count / N;
            
            // Вычисление погрешности вычислений (relative error)
            double relError = Math.Abs((figure_Square - monte_carlo_Square) / figure_Square) * 100; 

            // Стоп таймера
            st.Stop();

            // Подсчёт милисекунд
            long tc = st.ElapsedMilliseconds;

            // Вывод таблицы в консоль
            int[] tableCellSizes = new int[] { 14, 24, 30, 26, 18 };
            DrawCellLine(tableCellSizes);
            void DrawCellLine(int[] tableCellSizes)
            {
                DrawHorizontalLine("╔", "╦", "╗", tableCellSizes);
                Console.WriteLine("║ N = {0,-8} ║ dego Square = {1,-8} ║ MonteCarlo Square = {2,-8} ║ Relative Error = {3,-6}% ║ tiks = {4,-9} ║", N, Math.Round(figure_Square, 3), Math.Round(monte_carlo_Square, 3), Math.Round(relError, 3), tc);
                DrawHorizontalLine("╚", "╩", "╝", tableCellSizes);
            }
            void DrawHorizontalLine(string a, string b, string c, int[] tableCellSizes)
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
        }
        // Отсюда и до меню идут методы, использующиеся в методе MonteCarlo 

        // Проверка наличия точки в треугольнике
        public static bool CheckPointInTriangle(double x0, double y0, double x1, double y1, double x2, double y2, double x3, double y3)
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
        public static bool CheckPointInQuadrant(double center_of_circle_x, double center_of_circle_y, double point_on_radius_x, double point_on_radius_y, double x, double y)
        {
            double R = Length(center_of_circle_x, center_of_circle_y,point_on_radius_x,point_on_radius_y);

            if ((Math.Pow(x - center_of_circle_x, 2) + Math.Pow(y - center_of_circle_y, 2) <= Math.Pow(R, 2)) && (x >= center_of_circle_x) && (y >= center_of_circle_y))
            {
                return true;
            }
            else return false;
        }

        // Вычисление точной площади квадранта
        public static double QuadrantSquare(double x1, double y1, double x2, double y2)
        {
            return Math.Pow(Length(x1, y1, x2, y2), 2) * 0.25 * Math.PI;
        }

        // Вычисление точной площади треугольника
        public static double TriangleSquare(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            double p = (Length(x1, y1, x2, y2) + Length(x2, y2, x3, y3) + Length(x3, y3, x1, y1)) / 2;
            return Math.Sqrt(p * (p - Length(x1, y1, x2, y2)) * (p - Length(x2, y2, x3, y3)) * (p - Length(x3, y3, x1, y1)));
        }

        // Вычисление длины отрезка
        public static double Length(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }

        // Отсюда начинается Меню
        static void Main()
        {
            // Введение переменных, необходимых для описания фигуры и буферных переменных, необходимых для предотвращения ошибок при вводе данных
            double ax = 0;
            double ay = 0;
            double ex = 0;
            double ey = 0;
            double gx = 0;
            double gy = 0;
            double buf_ax = 0;
            double buf_ay = 0;
            double buf_ex = 0;
            double buf_ey = 0;
            double buf_gx = 0;
            double buf_gy = 0;

            // Создание списка пунктов меню
            List<string> menuItem = new List<string>() 
            {
                "Set Input Data",
                "Set Example of Data",
                "Show Current Data",
                "Calculate",
                "Exit"               
            };

            // Цикл, вызывающий в зависимости от выбранного пункта меню
            while (true)
            {
                switch (DrawMenu(menuItem))
                {
                    // 1.
                    // Пункт меню, запускающий ввод данных вручную
                    case "Set Input Data":
                        Console.Clear();
                        SetPointsForDego();
                        void SetPointsForDego() // Метод для введения введения исходных данных(координат точек a,e,g)
                        {
                            SetPoint("a", ref buf_ax, ref buf_ay);
                            SetPoint("e", ref buf_ex, ref buf_ey);
                            SetPoint("g", ref buf_gx, ref buf_gy);
                            PointInitializationErrorStackCheck();
                        }
                        void SetPoint(string point_name, ref double x, ref double y)
                        {
                            Console.WriteLine("Set coordinates for point '" + point_name + "'\n\n");
                            Console.Write("Set X:");
                            x = CheckedReadLine();
                            Console.Write("\nSet Y:");
                            y = CheckedReadLine();
                            Console.Clear();
                        }
                        void PointInitializationErrorStackCheck()
                        {
                            int number_of_errors = 0;
                            PointInitializationCheck(buf_gy - buf_ay <= 0, "AG length equal 0 or point G below point A", ref number_of_errors);
                            PointInitializationCheck(buf_ey - buf_ay <= 0, "AB length equal 0 or point E below point A",ref number_of_errors);
                            PointInitializationCheck(buf_ex - buf_ax <= 0, "AO length equal 0 or point E is to the left of point A",ref number_of_errors);
                            PointInitializationCheck(buf_ax != buf_gx, "AG are not parallel to the axis Y",ref number_of_errors);
                            PointInitializationCheck(Math.Abs(buf_gy - buf_ay) >= Math.Abs(buf_ey - buf_ay), "AG length more than length AB",ref number_of_errors);
                            if (number_of_errors != 0)
                            {
                                Console.Write("\nNumber of errors = "+ number_of_errors+";\n\nPlease, enter correct data");
                                number_of_errors = 0;
                                PressAnyKeyToContinue();
                                SetPointsForDego();
                            }  
                        }
                        ax = buf_ax;
                        ay = buf_ay;
                        ex = buf_ex;
                        ey = buf_ey;
                        gx = buf_gx;
                        gy = buf_gy;
                        ShowCurrentData(ax, ay, ex, ey, gx, gy);
                        break;
                    // 2.
                    // Пункт меню с помощью которого мы можем задать пример данных для построения фигуры
                    case "Set Example of Data":
                        ax = 0;
                        ay = 0;
                        ex = 10;
                        ey = 5;
                        gx = 0;
                        gy = 3;
                        ShowCurrentData(ax, ay, ex, ey, gx, gy);
                        break;
                    // 3.
                    // Пункт меню, показывающий текущие данные для построения фигуры
                    case "Show Current Data":
                        ShowCurrentData(ax, ay, ex, ey, gx, gy);
                        break;
                    // 4.
                    // Пункт меню запускающий вычисления
                    case "Calculate":
                        Console.Clear();
                        // Проверка на то были ли введены данные
                        if (ax == ex)
                        {
                            Console.WriteLine("You don't set data");
                            PressAnyKeyToContinue();
                        }
                        else
                        {
                            for (int N = 1000; N <= Math.Pow(10, 7); N *= 10)
                            {
                                MonteCarlo(ax, ay, ex, ey, gx, gy, N); // Вызов нашего основного метода Solution, используюя ранее введённые данные
                            }
                            PressAnyKeyToContinue();
                        }
                        break;
                    // 5.
                    // Пункт меню, обеспечивающий выход из программы
                    case "Exit":
                        Environment.Exit(0);
                        break;
                }
            }         
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
                Console.Write("Incorrect data format, please enter data again: ");
                return CheckedReadLine();
            }
        }

        // Метод для создания сообщения об ошибке
        static void PointInitializationCheck(bool condition, string error_message, ref int number_of_errors)
        {
            if (condition)
            {
                Console.WriteLine("Error: " + error_message+";\n");
                number_of_errors++;
            }
        }

        // Метод показывающий текущие данные фигуры
        static void ShowCurrentData(double ax, double ay, double ex, double ey, double gx, double gy)
        {
            Console.Clear();
            Console.WriteLine("Your figure data:\n\nd({0}, {1}), e({2}, {3}), g({4}, {5}), o({6}, {7});", ex + (ey - ay), ay, ex, ey, gx, gy, ex, ay);
            PressAnyKeyToContinue();
        }

        // Метод сообщающий, что нужно нажать на клавишу для того, чтобы продолжить
        static void PressAnyKeyToContinue()
        {
            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        // Метод DrawMenu. С помощью него и работает меню.
        private static int index = 0;
        public static string DrawMenu(List<string> items)
        {
            Console.CursorVisible = false;
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
            if (ckey.Key == ConsoleKey.DownArrow && index < items.Count - 1)
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
            return"";
        }
    }
}