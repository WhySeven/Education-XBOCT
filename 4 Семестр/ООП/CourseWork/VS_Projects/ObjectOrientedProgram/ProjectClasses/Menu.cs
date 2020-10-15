using System;
using System.Collections.Generic;

namespace ObjectOrientedProgram.ProjectClasses
{
    class Menu
    {
        // Поле которое будет заполнено списком пунктов меню
        private readonly List<string> menuItems;
        /* Введение полей, необходимых для описания фигуры и буферных переменных, 
         * которые будут использоваться для предотвращения ошибок при вводе данных*/
        private Point a = new Point();
        private Point e = new Point();
        private Point g = new Point();
        private Point buf_a = new Point();
        private Point buf_e = new Point();
        private Point buf_g = new Point();
        public Menu()// Конструктор по умолчанию в котором мы заполняем список пунтов меню
        {
            menuItems = new List<string>()
            {
                "Set Input Data",
                "Show an Example",
                "Show Current Data",
                "Calculate",
                "Exit"
            };
        }
        /* Основной метод класса запускающий цикл, обновляющий меню при нажатии клавиш управления,
         * а также содержащий алгоритмы действий при выборе того или иного пункта меню*/
        public void Draw()
        {
            // Объявление цикла
            while (true)
            {
                // Switch, содержащий алгоритмы действий
                switch (DrawMenu(menuItems))
                {
                    // 1.
                    // Пункт меню, запускающий ввод данных вручную
                    case "Set Input Data":
                        Console.Clear();
                        SetPointsForDego();
                        // Метод для инициализации координат точек a,e,g
                        void SetPointsForDego() 
                        {
                            SetPoint("a", ref buf_a);
                            SetPoint("e", ref buf_e);
                            SetPoint("g", ref buf_g);
                            // Проверка на ошибки
                            PointInitializationErrorsCheck();
                        }
                        /* Метод включающий все возможные ошибки инициализации точек и если ошибки присутствуют,
                         * то метод снова вызывает метод для инициализации координат точек*/
                        void PointInitializationErrorsCheck()
                        {
                            int number_of_errors = 0;
                            PointInitializationCheck(buf_g.y - buf_a.y <= 0, "AG length equal 0 or point G below point A", ref number_of_errors);
                            PointInitializationCheck(buf_e.y - buf_a.y <= 0, "AB length equal 0 or point E below point A", ref number_of_errors);
                            PointInitializationCheck(buf_e.x - buf_a.x <= 0, "AO length equal 0 or point E is to the left of point A", ref number_of_errors);
                            PointInitializationCheck(buf_a.x != buf_g.x, "AG are not parallel to the axis Y", ref number_of_errors);
                            PointInitializationCheck(Math.Abs(buf_g.y - buf_a.y) >= Math.Abs(buf_e.y - buf_a.y), "AG length more than length AB", ref number_of_errors);
                            // Возвращение к методу инициализации координат, если кол-во ошибок != 0
                            if (number_of_errors != 0)
                            {
                                Console.Write("\nNumber of errors = " + number_of_errors + ";\n\nPlease, enter correct data");
                                number_of_errors = 0;
                                PressAnyKeyToContinue();    
                                SetPointsForDego();
                            }
                        }
                        // Заполнение  'чистовых' полей
                        a = buf_a;
                        e = buf_e;
                        g = buf_g;
                        ShowCurrentData(a, e, g);
                        break;
                    // 2.
                    /* Пункт меню с помощью которого мы можем посмотреть, как работает программа,
                     * используя готовый пример исходных данных*/
                    case "Show an Example":
                        // Задаются исходные данные
                        a = new Point(0, 0);
                        e = new Point(10, 5);
                        g = new Point(0, 3);
                        ShowCurrentData(a, e, g);
                        for (int N = 1000; N <= Math.Pow(10, 7); N *= 10)
                        {
                            /* Создание экземпляра класса MonteCarloCalculator, используя пример данных
                             * который преобразует исходные данные в точки фигуры dego,
                             * создаёт экземляры классов triangle и quadrand и использует их методы для
                             * подсчёта площади методом Монте-Карло, а затем идёт вызов метода Calculate и DrawTable,
                             * обеспечивающие все рассчёты и вывод таблицы с необходимыми данными в консоль*/
                            MonteCarloCalculator calc = new MonteCarloCalculator(a, e, g, N);
                            calc.Calculate();
                            calc.DrawTable();
                        }
                        PressAnyKeyToContinue();
                        break;
                    // 3.
                    // Пункт меню, выводящий в консоль текущие данные нашей фигуры
                    case "Show Current Data":
                        ShowCurrentData(a, e, g);
                        break;
                    // 4.
                    // Пункт меню запускающий вычисления
                    case "Calculate":
                        Console.Clear();
                        // Проверка на то были ли введены данные
                        if (a.x == e.x)
                        {
                            Console.WriteLine("You don't set data");
                            PressAnyKeyToContinue();
                        }
                        else
                        {
                            for (int N = 1000; N <= Math.Pow(10, 7); N *= 10)
                            {
                                /* Создание экземпляра класса MonteCarloCalculator, ранее введённые пользователем данные
                                 * который преобразует исходные данные в точки фигуры dego,
                                 * создаёт экземляры классов triangle и quadrand и использует их методы для
                                 * подсчёта площади методом Монте-Карло, а затем идёт вызов метода Calculate и DrawTable,
                                 * обеспечивающие все рассчёты и вывод таблицы с необходимыми данными в консоль*/
                                MonteCarloCalculator calc = new MonteCarloCalculator(a, e, g, N);
                                calc.Calculate();
                                calc.DrawTable();
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
        private static void SetPoint(string point_name, ref Point p)
        {
            Console.WriteLine("Set coordinates for point '" + point_name + "'\n\n");
            Console.Write("Set X:");
            p.x = CheckedReadLine();
            Console.Write("\nSet Y:");
            p.y = CheckedReadLine();
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
        private static void ShowCurrentData(Point a, Point e, Point g)
        {
            Console.Clear();
            Console.WriteLine("Your figure data:\n\nd({0}, {1}), e({2}, {3}), g({4}, {5}), o({6}, {7});", e.x + (e.y - a.y), a.y, e.x, e.y, g.x, g.y, e.x, a.y);
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

