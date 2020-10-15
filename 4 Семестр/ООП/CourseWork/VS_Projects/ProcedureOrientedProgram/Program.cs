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
            // Объявляем таймер
            Stopwatch sw = new Stopwatch();
            // Старт таймера
            sw.Start();
            // Площадь прямоугольника в котором находятся фигуры
            double rectangle_Square = (ex + (ey - ay) - ax) * (ey - ay);
            // Задаём координаты недостаяющих точек dego
            double ox = ex;
            double oy = ay;
            double dx = ex+(ey-ay);
            double dy = ay;
            // Координаты точки, которую мы будем бросать в прямоугольник
            double x;
            double y;
            // Точная площадь фигуры dego
            double dego_Square = TriangleSquare(ex, ey, gx, gy, ox, oy) + QuadrantSquare(ox, oy, dx, dy);
            Random random = new Random();
            int count = 0;
            for (int i = 0; i < N; i++)
            {
                // Случайные координаты x и y ограниченные размерами прямоугольника
                 x = random.NextDouble() * (ex + (ey - ay) - ax) + ax;
                 y = random.NextDouble() * (ey - ay) + ay;
                //Если точка попала в треугольник или квадрант(нашу фигуру dego), то счётчик увеличивается на 1
                if (CheckPointInTriangle(x, y, ex, ey, gx, gy, ox, oy) || CheckPointInQuadrant(x, y, ox, oy, dx, dy)) { count++; }                    
            }
            /* monte_carlo_Square - Площадь фигуры, вычисленная с помощью метода Монте-Карло:
            Точная площадь прямоугольника умножить на кол-во попаданий и поделить на кол-во бросков */
            double monte_carlo_Square = rectangle_Square * count / N;
            // Вычисление погрешности вычислений (relative error)
            double relError = Math.Abs((dego_Square - monte_carlo_Square) / dego_Square) * 100; 
            // Стоп таймера
            sw.Stop();
            // Подсчёт милисекунд
            long ms = sw.ElapsedMilliseconds;
            // Вывод таблицы в консоль
            int[] tableCellSizes = new int[] { 14, 24, 30, 26, 12 };
            DrawCells(tableCellSizes);
            void DrawCells(int[] tableCellSizes)
            {
                DrawHorizontalLine("╔", "╦", "╗", tableCellSizes);
                Console.WriteLine("║ N = {0,-8} ║ dego Square = {1,-8} ║ MonteCarlo Square = {2,-8} ║ Relative Error = {3,-6}% ║ ms = {4,-5} ║", N, Math.Round(dego_Square, 3), Math.Round(monte_carlo_Square, 3), Math.Round(relError, 3), ms);
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
        private static bool CheckPointInTriangle(double x0, double y0, double x1, double y1, double x2, double y2, double x3, double y3)
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
        private static bool CheckPointInQuadrant(double x, double y, double center_of_circle_x, double center_of_circle_y, double point_on_radius_x, double point_on_radius_y)
        {
            double R = Length(center_of_circle_x, center_of_circle_y,point_on_radius_x,point_on_radius_y);

            if ((Math.Pow(x - center_of_circle_x, 2) + Math.Pow(y - center_of_circle_y, 2) <= Math.Pow(R, 2)) && (x >= center_of_circle_x) && (y >= center_of_circle_y))
            {
                return true;
            }
            else return false;
        }
        // Вычисление точной площади квадранта
        private static double QuadrantSquare(double x1, double y1, double x2, double y2)
        {
            return Math.Pow(Length(x1, y1, x2, y2), 2) * 0.25 * Math.PI;
        }
        // Вычисление точной площади треугольника
        private static double TriangleSquare(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            double p = (Length(x1, y1, x2, y2) + Length(x2, y2, x3, y3) + Length(x3, y3, x1, y1)) / 2;
            return Math.Sqrt(p * (p - Length(x1, y1, x2, y2)) * (p - Length(x2, y2, x3, y3)) * (p - Length(x3, y3, x1, y1)));
        }
        // Вычисление длины отрезка
        private static double Length(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }
        // Отсюда начинается Меню
        static void Main()
        {
            /* Введение полей, необходимых для описания фигуры и буферных переменных, 
             * которые будут использоваться для предотвращения ошибок при вводе данных*/
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
                "Show an Example",
                "Show Current Data",
                "Calculate",
                "Exit"               
            };
            /* Объявление цикла, обновляющий меню при нажатии клавиш управления,
             * а также содержащий алгоритмы действий при выборе того или иного пункта меню*/
            while (true)
            {
                //Switch, содержащий алгоритмы действий
                switch (DrawMenu(menuItem))
                {
                    // 1.
                    // Пункт меню, запускающий ввод данных вручную
                    case "Set Input Data":
                        Console.Clear();
                        SetPointsForDego();
                        // Метод для инициализации координат точек a,e,g
                        void SetPointsForDego() 
                        {
                            SetPoint("a", ref buf_ax, ref buf_ay);
                            SetPoint("e", ref buf_ex, ref buf_ey);
                            SetPoint("g", ref buf_gx, ref buf_gy);
                            // Проверка на ошибки
                            PointInitializationErrorsCheck();
                        }
                        /* Метод включающий все возможные ошибки инициализации точек и если ошибки присутствуют,
                         * то метод снова вызывает метод для инициализации координат точек*/
                        void PointInitializationErrorsCheck()
                        {
                            int number_of_errors = 0;
                            PointInitializationCheck(buf_gy - buf_ay <= 0, "AG length equal 0 or point G below point A", ref number_of_errors);
                            PointInitializationCheck(buf_ey - buf_ay <= 0, "AB length equal 0 or point E below point A",ref number_of_errors);
                            PointInitializationCheck(buf_ex - buf_ax <= 0, "AO length equal 0 or point E is to the left of point A",ref number_of_errors);
                            PointInitializationCheck(buf_ax != buf_gx, "AG are not parallel to the axis Y",ref number_of_errors);
                            PointInitializationCheck(Math.Abs(buf_gy - buf_ay) >= Math.Abs(buf_ey - buf_ay), "AG length more than length AB",ref number_of_errors);
                            // Возвращение к методу инициализации координат, если кол-во ошибок != 0
                            if (number_of_errors != 0)
                            {
                                Console.Write("\nNumber of errors = "+ number_of_errors+";\n\nPlease, enter correct data");
                                number_of_errors = 0;
                                PressAnyKeyToContinue();
                                SetPointsForDego();
                            }  
                        }
                        // Заполнение  'чистовых' полей
                        ax = buf_ax;
                        ay = buf_ay;
                        ex = buf_ex;
                        ey = buf_ey;
                        gx = buf_gx;
                        gy = buf_gy;
                        ShowCurrentData(ax, ay, ex, ey, gx, gy);
                        break;
                    // 2.
                    /* Пункт меню с помощью которого мы можем посмотреть, как работает программа,
                     * используя готовый пример исходных данных*/
                    case "Show an Example":
                        // Задаются исходные данные
                        ax = 0;
                        ay = 0;
                        ex = 10;
                        ey = 5;
                        gx = 0;
                        gy = 3;
                        ShowCurrentData(ax, ay, ex, ey, gx, gy);
                        for (int N = 1000; N <= Math.Pow(10, 7); N *= 10)
                        {
                            // Вызов нашего основного метода MonteCarlo, используюя пример данных
                            MonteCarlo(ax, ay, ex, ey, gx, gy, N); 
                        }
                        PressAnyKeyToContinue();
                        break;
                    // 3.
                    // Пункт меню, выводящий в консоль текущие данные нашей фигуры
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
                                /* Вызов нашего основного метода MonteCarlo,
                                 * используюя ранее введённые пользователем данные*/
                                MonteCarlo(ax, ay, ex, ey, gx, gy, N); 
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
        // Метод для инициализации точки
        private static void SetPoint(string point_name, ref double x, ref double y)
        {
            Console.WriteLine("Set coordinates for point '" + point_name + "'\n\n");
            Console.Write("Set X:");
            x = CheckedReadLine();
            Console.Write("\nSet Y:");
            y = CheckedReadLine();
            Console.Clear();
        }
        // Метод для создания сообщения об ошибке
        private static void PointInitializationCheck(bool condition, string error_message, ref int number_of_errors)
        {
            if (condition)
            {
                Console.WriteLine("Error: " + error_message + ";\n");
                number_of_errors++;
            }
        }
        // Метод, проверяющий является ли строка числом
        private static double CheckedReadLine()
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
        // Метод показывающий текущие данные фигуры
        private static void ShowCurrentData(double ax, double ay, double ex, double ey, double gx, double gy)
        {
            Console.Clear();
            Console.WriteLine("Your figure data:\n\nd({0}, {1}), e({2}, {3}), g({4}, {5}), o({6}, {7});", ex + (ey - ay), ay, ex, ey, gx, gy, ex, ay);
            PressAnyKeyToContinue();
        }
        // Метод сообщающий, что нужно нажать на клавишу для того, чтобы продолжить
        private static void PressAnyKeyToContinue()
        {
            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        /* Метод DrawMenu. 
         * Он принимает список пунктов меню и в зависимости от текущего значения index при нажатии enter возвращает строку выбранного пункта меню.
         * А с помощью стрелочек вверх и вниз он увеличивает или уменьшает значение переменной index в пределах, от 0 до размера, переданного
         * в метод списка -1, также метод выделяет пункт меню, соответствующий по номеру текущему значению index.
         */
        private static int index = 0;
        private static string DrawMenu(List<string> items)
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
            return "";
        }
    }
}