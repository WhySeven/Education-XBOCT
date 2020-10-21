using System;
using System.Collections.Generic;

namespace ObjectOrientedProgram {
    class Menu {
        // Поле которое будет заполнено списком пунктов меню
        readonly List<string> menuItems;
        private int currentMenuIndex = 0;
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
        /* Основной метод класса запускающий цикл, обновляющий меню при нажатии клавиш управления,
         * а также содержащий алгоритмы действий при выборе того или иного пункта меню*/
        public void Draw() {
            // Объявление цикла
            // Switch, содержащий алгоритмы действий
            DrawMenu();
            switch (ReadInputCommand()) {
                // 1.
                // Пункт меню, запускающий ввод данных вручную
                case "Set Input Data":
                    //Console.Clear();
                    SetPoints();
                    // Заполнение  'чистовых' полей
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
                    /* Создание экземпляра класса MonteCarloCalculator, используя пример данных
                    * который преобразует исходные данные в точки фигуры dego,
                    * создаёт экземляры классов triangle и quadrand и использует их методы для
                    * подсчёта площади методом Монте-Карло, а затем идёт вызов метода Calculate и DrawTable,
                    * обеспечивающие все рассчёты и вывод таблицы с необходимыми данными в консоль*/
                    MonteCarloCalculator calc_example = new MonteCarloCalculator(a, e, g);
                    calc_example.Calculate();
                    Table table_example = new Table(calc_example);
                    table_example.DrawTable();
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
                    if (a.x == e.x) {
                        Console.WriteLine("You didn't set the data");
                        PressAnyKeyToContinue();
                    } 
                    else 
                    {
                        /* Создание экземпляра класса MonteCarloCalculator, ранее введённые пользователем данные
                         * который преобразует исходные данные в точки фигуры dego,
                         * создаёт экземляры классов triangle и quadrand и использует их методы для
                         * подсчёта площади методом Монте-Карло, а затем идёт вызов метода Calculate и DrawTable,
                         * обеспечивающие все рассчёты и вывод таблицы с необходимыми данными в консоль*/
                        MonteCarloCalculator calc = new MonteCarloCalculator(a, e, g);
                        calc.Calculate();
                        Table table = new Table(calc);
                        table.DrawTable();
                        PressAnyKeyToContinue();
                    }
                    break;
                // 5.
                // Пункт меню, обеспечивающий выход из программы
                case "Exit":
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
            Draw();
        }
        // Метод для инициализации координат точек a,e,g
        void SetPoints() {
            a = SetPoint("a");
            e = SetPoint("e");
            g = SetPoint("g");
            // Проверка на ошибки
            // Метод для создания сообщения об ошибке
            /* Метод включающий все возможные ошибки инициализации точек и если ошибки присутствуют,
            * то метод снова вызывает метод для инициализации координат точек*/
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
        // Метод для инициализации точки
        Point SetPoint(string point_name) {
            var point = new Point();
            Console.WriteLine("Set coordinates for point '" + point_name + "'\n");
            Console.Write("\nSet x:");
            point.x = CheckedReadLine();
            Console.Write("\nSet y:");
            point.y = CheckedReadLine();
            Console.Clear();
            return point;
        }
        // Метод, проверяющий является ли строка числом
        double CheckedReadLine() {
            if (double.TryParse(Console.ReadLine(), out double digit))
                return digit;
            Console.Write("Incorrect data format, please enter data again: ");
            return CheckedReadLine();
        }
        // Метод показывающий текущие данные фигуры
        void ShowCurrentData(Point a, Point e, Point g) {
            Console.Clear();
            Console.WriteLine("Your figure data:\n\nd({0}, {1}), e({2}, {3}), g({4}, {5}), o({6}, {7});", e.x + (e.y - a.y), a.y, e.x, e.y, g.x, g.y, e.x, a.y);
            PressAnyKeyToContinue();
        }
        // Метод сообщающий, что нужно нажать на клавишу для того, чтобы продолжить
        void PressAnyKeyToContinue() {
            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        /* Метод DrawMenu. 
        * Он принимает список пунктов меню и в зависимости от текущего значения index при нажатии enter возвращает строку выбранного пункта меню.
        * А с помощью стрелочек вверх и вниз он увеличивает или уменьшает значение переменной index в пределах, от 0 до размера, переданного
        * в метод списка -1, также метод выделяет пункт меню, соответствующий по номеру текущему значению index.
        */
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

