using System;
using System.Collections.Generic;

namespace ObjectOrientedProgram {
    class Menu {
        // Поле которое будет заполнено списком пунктов меню
        readonly List<string> menuItems;
        int currentMenuIndex = 0;
        /* Введение полей, необходимых для описания фигуры и буферных переменных, 
         * которые будут использоваться для предотвращения ошибок при вводе данных*/
        Point a;
        Point e;
        Point g;
        // Конструктор по умолчанию в котором мы заполняем список пунтов меню
        public Menu() {
            a = new Point();
            e = new Point();
            g = new Point();
            menuItems = new List<string>()
            {
                "Set Input Data",
                "Show an Example",
                "Show Current Data",
                "Calculate",
                "Exit"
            };
        }
        /* Основной метод класса запускающий рекурсию, обеспечивающую работу меню
         * а также содержащий алгоритмы действий при выборе того или иного пункта меню*/
        public void Draw() {
            // Объявление цикла
            // Switch, содержащий алгоритмы действий
            DrawMenu();
            switch (ReadInputCommand()) {
                // 1.
                // Пункт меню, запускающий ввод данных вручную
                case "Set Input Data":
                    SetPoints();
                    ShowCurrentData();
                    PressAnyKeyToContinue();
                    break;
                // 2.
                /* Пункт меню с помощью которого мы можем посмотреть, как работает программа,
                 * используя готовый пример исходных данных*/
                case "Show an Example":
                    // Задаются исходные данные
                    a = new Point(0, 0);
                    e = new Point(10, 5);
                    g = new Point(0, 3);
                    ShowCurrentData();
                    PressAnyKeyToContinue();
                    new MonteCarloCalculator(a, e, g).Calculate();
                    PressAnyKeyToContinue();
                    break;
                // 3.
                // Пункт меню, выводящий в консоль текущие данные нашей фигуры
                case "Show Current Data":
                    ShowCurrentData();
                    PressAnyKeyToContinue();
                    break;
                // 4.
                // Пункт меню запускающий вычисления
                case "Calculate":
                    Console.Clear();
                    // Проверка на то были ли введены данные
                    if (a.X == e.X)
                        Console.WriteLine("You didn't set the data");  
                    else 
                        new MonteCarloCalculator(a, e, g).Calculate();
                    PressAnyKeyToContinue();
                    break;
                // 5.
                // Пункт меню, обеспечивающий выход из программы
                case "Exit":
                    Environment.Exit(0);
                    break;
            }
            Draw();
        }
        // Метод для инициализации координат точек a,e,g
        void SetPoints() {
            a = PointInitialization("a");
            e = PointInitialization("e");
            g = PointInitialization("g");
            // Проверка на ошибки
            List<string> errorList = new PointValidator(a, e, g).ValidatePoints();
            if (errorList.Count == 0)
                return;
            Console.WriteLine("Number of errors = " + errorList.Count + ";\n");
            foreach (var error in errorList)
                Console.WriteLine(error);
            Console.WriteLine("\nPlease enter correct data");
            PressAnyKeyToContinue();
            SetPoints();
        }
        Point PointInitialization(string pointName) {
            Point point = new Point();
            Console.WriteLine("Set coordinates for point '" + pointName + "'");
            Console.Write("\nSet x:");
            point.X = CheckedReadLine();
            Console.Write("\nSet y:");
            point.Y = CheckedReadLine();
            Console.Clear();
            return point;
        }
        double CheckedReadLine() {
            if (double.TryParse(Console.ReadLine(), out double result))
                return result;
            Console.Write("\nError: Incorrect data format. You need to enter 'double' data type\nPlease enter the correct data: ");
            return CheckedReadLine();
        }
        void ShowCurrentData() {
            Console.Clear();
            Console.WriteLine("Your figure data:\n\nd({0}, {1}), e({2}, {3}), g({4}, {5}), o({6}, {7});", e.X + (e.Y - a.Y), a.Y, e.X, e.Y, g.X, g.Y, e.X, a.Y);
        }
        // Метод сообщающий, что нужно нажать на клавишу для того, чтобы продолжить
        void PressAnyKeyToContinue() {
            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        void DrawMenu() {
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
        string ReadInputCommand() {
            switch (Console.ReadKey().Key) {
                case ConsoleKey.DownArrow:
                    if(currentMenuIndex < menuItems.Count - 1)
                        currentMenuIndex++;
                    break;
                case ConsoleKey.UpArrow:
                    if(currentMenuIndex > 0)
                        currentMenuIndex--;
                    break;
                case ConsoleKey.Enter:
                    Console.Clear();
                    return menuItems[currentMenuIndex];
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
            }
            Console.Clear();
            return "";
        }
    }
}

