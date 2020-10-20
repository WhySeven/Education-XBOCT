using System;
using System.Collections.Generic;
using System.Diagnostics;
namespace ProcedureOrientedProgram {
    class Program {
        // Начало кода основного метода, осуществляющего все рассчёты и отрисовку таблицы, конечно, используюя в том числе и внешние методы
        public static void MonteCarlo(double ax, double ay, double ex, double ey, double gx, double gy) {
            // Площадь прямоугольника в котором находятся фигуры
            double rectangle_Square = (ex + (ey - ay) - ax) * (ey - ay);
            // Задаём координаты недостаяющих точек dego
            double ox = ex;
            double oy = ay;
            double dx = ex + (ey - ay);
            double dy = ay;
            /* monte_carlo_Square - Площадь фигуры, вычисленная с помощью метода Монте-Карло:
            Точная площадь прямоугольника умножить на кол-во попаданий и поделить на кол-во бросков */
            List<double> monte_carlo_Square = new List<double>();
            List<double> relError = new List<double>();
            List<long> ms = new List<long>();
            int step = 0;
            double dego_Square = 0;
            for (int N = Convert.ToInt32(Math.Pow(10, 3)); N <= Math.Pow(10, 7); N *= 10) {
                // Объявляем таймер
                Stopwatch sw = new Stopwatch();
                // Старт таймера
                sw.Start();
                dego_Square = GetSquare(dx, dy, ex, ey, gx, gy, ox, oy);
                monte_carlo_Square.Add(MonteCarloSquare(ax, ay, dx, dy, ex, ey, gx, gy, ox, oy, rectangle_Square, N));
                relError.Add(Math.Abs((dego_Square - monte_carlo_Square[step]) / dego_Square) * 100);
                // Стоп таймера
                sw.Stop();
                // Подсчёт милисекунд
                ms.Add(sw.ElapsedMilliseconds);
                step++;
            }
            // Вывод таблицы в консоль
            DrawTable(step, dego_Square, monte_carlo_Square, relError, ms);
        }
        static double GetSquare(double dx, double dy, double ex, double ey, double gx, double gy, double ox, double oy) {
            return TriangleSquare(ex,ey,gx,gy,ox,oy) + QuadrantSquare(ox, oy, dx, dy);
        }
        static double MonteCarloSquare(double ax, double ay, double dx, double dy, double ex, double ey, double gx, double gy, double ox, double oy, double rectangle_Square, int N) {
            Random random = new Random();
            int count = 0;
            for (int i = 0; i < N; i++) {
                double x = random.NextDouble() * (dx-ax) + ax;
                double y = random.NextDouble() * (ey-ay) + ay;
                if (CheckPointInTriangle(x, y, ex,ey,gx,gy,ox,oy) || CheckPointInQuadrant(x, y, ox, oy, dx, dy)) {count++;}
            }
            return rectangle_Square * count / N;
        }
        // Проверка наличия точки в треугольнике
        static bool CheckPointInTriangle(double x0, double y0, double x1, double y1, double x2, double y2, double x3, double y3) {
            double buf1 = (x1 - x0) * (y2 - y1) - (x2 - x1) * (y1 - y0);
            double buf2 = (x2 - x0) * (y3 - y2) - (x3 - x2) * (y2 - y0);
            double buf3 = (x3 - x0) * (y1 - y3) - (x1 - x3) * (y3 - y0);
            if ((buf1 >= 0 && buf2 >= 0 && buf3 >= 0) || (buf1 <= 0 && buf2 <= 0 && buf3 <= 0)) {
                return true;
            } else return false;
        }
        // Проверка наличия точки в квадранте
        static bool CheckPointInQuadrant(double x, double y, double center_of_circle_x, double center_of_circle_y, double point_on_radius_x, double point_on_radius_y) {
            double R = Length(center_of_circle_x, center_of_circle_y, point_on_radius_x, point_on_radius_y);
            if ((Math.Pow(x - center_of_circle_x, 2) + Math.Pow(y - center_of_circle_y, 2) <= Math.Pow(R, 2)) && (x >= center_of_circle_x) && (y >= center_of_circle_y)) {
                return true;
            } else return false;
        }
        // Вычисление точной площади квадранта
        static double QuadrantSquare(double x1, double y1, double x2, double y2) {
            return Math.Pow(Length(x1, y1, x2, y2), 2) * 0.25 * Math.PI;
        }
        // Вычисление точной площади треугольника
        static double TriangleSquare(double x1, double y1, double x2, double y2, double x3, double y3) {
            double p = (Length(x1, y1, x2, y2) + Length(x2, y2, x3, y3) + Length(x3, y3, x1, y1)) / 2;
            return Math.Sqrt(p * (p - Length(x1, y1, x2, y2)) * (p - Length(x2, y2, x3, y3)) * (p - Length(x3, y3, x1, y1)));
        }
        // Вычисление длины отрезка
        static double Length(double x1, double y1, double x2, double y2) {
            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }
        // Методы для таблицы
        static void DrawTable(int step, double dego_Square, List<double> monte_carlo_Square, List<double> relError, List<long> ms) {
            int[] tableCellSizes = new int[] { 14, 24, 30, 26, 12 };
            for (int i = 0; i < step; i++) {
                DrawHorizontalLine("╔", "╦", "╗", tableCellSizes);
                Console.WriteLine("║ N = {0,-8} ║ dego Square = {1,-8} ║ MonteCarlo Square = {2,-8} ║ Relative Error = {3,-6}% ║ ms = {4,-5} ║", Math.Pow(10, 3 + Convert.ToDouble(i)), Math.Round(dego_Square, 3), Math.Round(monte_carlo_Square[i], 3), Math.Round(relError[i], 3), ms[i]);
                DrawHorizontalLine("╚", "╩", "╝", tableCellSizes);
            }
        }
        static void DrawHorizontalLine(string a, string b, string c, int[] tableCellSizes) {
            Console.Write(a);
            for (int j = 0; j < tableCellSizes.Length; j++) {
                for (int i = 0; i < tableCellSizes[j]; i++) {
                    Console.Write("═");
                }
                if (j != tableCellSizes.Length - 1) {
                    Console.Write(b);
                }
            }
            Console.WriteLine(c);
        }
        // Отсюда начинается Меню
        static void Main() {
            double ax = 0;
            double ay = 0;
            double ex = 0;
            double ey = 0;
            double gx = 0;
            double gy = 0;
            // Введение полей, необходимых для описания фигуры

            /* Объявление цикла, обновляющий меню при нажатии клавиш управления,
             * а также содержащий алгоритмы действий при выборе того или иного пункта меню*/
            while (true) {
                DrawMenu();
                //Switch, содержащий алгоритмы действий
                switch (ReadInputCommand()) {
                    // 1.
                    // Пункт меню, запускающий ввод данных вручную
                    case "Set Input Data":
                        Console.Clear();
                        // Метод для инициализации координат точек a,e,g, содержащий проверку на ошибки.
                        SetPoints(ref ax, ref ay, ref ex, ref ey, ref gx, ref gy);                 
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
                        // Вызов нашего основного метода MonteCarlo, используюя пример данных
                        MonteCarlo(ax, ay, ex, ey, gx, gy);
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
                        if (ax == ex) {
                            Console.WriteLine("You don't set data");
                            PressAnyKeyToContinue();
                        } 
                        else 
                        {
                            /* Вызов нашего основного метода MonteCarlo,
                             * используюя ранее введённые пользователем данные*/
                            MonteCarlo(ax, ay, ex, ey, gx, gy);
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
            static void SetPoints(ref double ax, ref double ay, ref double ex, ref double ey, ref double gx, ref double gy) {
                SetPoint("a", ref ax, ref ay);
                SetPoint("e", ref ex, ref ey);
                SetPoint("g", ref gx, ref gy);
                List<string> error_List = ErrorList(ax, ay, ex, ey, gx, gy);
                if (error_List.Count == 0)
                    return;
                Console.WriteLine("Number of errors = " + error_List.Count + ";\n");
                foreach (string error in error_List)
                    Console.WriteLine(error);
                Console.WriteLine("\nPlease enter correct data");
                PressAnyKeyToContinue();
                SetPoints(ref ax, ref ay, ref ex, ref ey, ref gx, ref gy);
            }
            static List<string> ErrorList(double ax, double ay, double ex, double ey, double gx, double gy) {
                List<string> errorMessages = new List<string>();
                if (gy - ay <= 0) {
                    errorMessages.Add("Error: AG length equal 0 or point G below point A");
                }
                if (ey - ay <= 0) {
                    errorMessages.Add("Error: AB length equal 0 or point E below point A");
                }
                if (ex - ax <= 0) {
                    errorMessages.Add("Error: AO length equal 0 or point E is to the left of point A");
                }
                if (ax != gx) {
                    errorMessages.Add("Error: AG are not parallel to the axis Y");
                }
                if (Math.Abs(gy - ay) >= Math.Abs(ey - ay)) {
                    errorMessages.Add("Error: AG length more than length AB");
                }
                return errorMessages;
            }
            // Метод для инициализации точки
            static void SetPoint(string point_name, ref double x, ref double y) {
                Console.WriteLine("Set coordinates for point '" + point_name + "'\n");
                Console.Write("\nSet x:");
                x = CheckedReadLine();
                Console.Write("\nSet y:");
                y = CheckedReadLine();
                Console.Clear();
            }
            // Метод, проверяющий является ли строка числом
            static double CheckedReadLine() {
                if (double.TryParse(Console.ReadLine(), out double digit)) {
                    return digit;
                } else {
                    Console.Write("Incorrect data format, please enter data again: ");
                    return CheckedReadLine();
                }
            }
            // Метод показывающий текущие данные фигуры
            static void ShowCurrentData(double ax, double ay, double ex, double ey, double gx, double gy) {
                Console.Clear();
                Console.WriteLine("Your figure data:\n\nd({0}, {1}), e({2}, {3}), g({4}, {5}), o({6}, {7});", ex + (ey - ay), ay, ex, ey, gx, gy, ex, ay);
                PressAnyKeyToContinue();
            }
            // Метод сообщающий, что нужно нажать на клавишу для того, чтобы продолжить
            static void PressAnyKeyToContinue() {
                Console.WriteLine("\n\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        /* Метод DrawMenu. 
         * Он принимает список пунктов меню и в зависимости от текущего значения index при нажатии enter возвращает строку выбранного пункта меню.
         * А с помощью стрелочек вверх и вниз он увеличивает или уменьшает значение переменной index в пределах, от 0 до размера, переданного
         * в метод списка -1, также метод выделяет пункт меню, соответствующий по номеру текущему значению index.
         */
        // Создание списка пунктов меню
        static List<string> menuItems = new List<string>()
        {
                "Set Input Data",
                "Show an Example",
                "Show Current Data",
                "Calculate",
                "Exit"
            };
        static int currentMenuIndex = 0;
        static void DrawMenu() {
            Console.CursorVisible = false;
            for (int i = 0; i < menuItems.Count; i++) {
                if (i == currentMenuIndex) {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(menuItems[i]);
                } else {
                    Console.WriteLine(menuItems[i]);
                }
                Console.ResetColor();
            }
        }
        static string ReadInputCommand() {
            ConsoleKeyInfo ckey = Console.ReadKey();
            if (ckey.Key == ConsoleKey.DownArrow && currentMenuIndex < menuItems.Count - 1) {
                currentMenuIndex++;
            } else if (ckey.Key == ConsoleKey.UpArrow && currentMenuIndex > 0) {
                currentMenuIndex--;
            } else if (ckey.Key == ConsoleKey.Enter) {
                Console.Clear();
                return menuItems[currentMenuIndex];
            } else if (ckey.Key == ConsoleKey.Escape) {
                Environment.Exit(0);
            }
            Console.Clear();
            return "";
        }
    }
}