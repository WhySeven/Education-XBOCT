using System;
using System.Collections.Generic;

namespace ObjectOrientedProgram.ProjectClasses
{
    class Menu
    {
        private readonly List<string> menuItems;
        // Введение полей, необходимых для описания фигуры и буферных переменных, необходимых для предотвращения ошибок при вводе данных
        private Point p1 = new Point();
        private Point p2 = new Point();
        private Point buf_p1 = new Point();
        private Point buf_p2 = new Point();
        private double g = 0;
        private double buf;
        public Menu()
        {
            List<string> menuItems = new List<string>() // Создание пунктов меню
            {
                "Set Input Data",
                "Set Example of Data",
                "Show Current Data",
                "Calculate",
                "Exit"
            };
            this.menuItems = menuItems;
            this.menuItems.Add("");  
        }
        // Основной метод класса запускающий цикл, обеспечивающий работу меню
        public void Draw()
        {
            Console.CursorVisible = false;
            while (true)
            {
                string SelectedMenuItem = DrawMenu(menuItems);

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
                        buf_p1.x = CheckedReadLine();
                        Console.Write("\nSet Y:");
                        buf_p1.y = CheckedReadLine();
                        Console.Clear();

                        Console.WriteLine("Set coordinates for 2nd point on diagonal of your Rectangle\n\n");
                        Console.Write("Set X:");
                        buf_p2.x = CheckedReadLine();
                        Console.Write("\nSet Y:");
                        buf_p2.y = CheckedReadLine();
                        Console.Clear();
                    }

                    while (buf_p1.x == buf_p2.x || buf_p1.y == buf_p2.y) // Вывод ошибки о том, что по таким точкам можно построить только линию и просьба ввести данные заного
                    {
                        Console.WriteLine("Error: You got a line, not a Rectangle\n\nPlease, enter correct data");
                        PressAnyKeyToContinue();
                        SetRectangle();
                    }
                    while (buf_p1.x == buf_p2.x && buf_p1.y == buf_p2.y) // Вывод ошибки о том, что по таким точкам можно построить только точку
                    {
                        Console.WriteLine("Error: You got a point, not a Rectangle\n\nPlease, enter correct data");
                        PressAnyKeyToContinue();
                        SetRectangle();
                    }
                    while (Math.Abs(buf_p1.x - buf_p2.x) == Math.Abs(buf_p1.y - buf_p2.y)) // Вывод ошибки о том, что по таким точкам можно построить только квадрат
                    {
                        Console.WriteLine("Error: You got a quadrate, not a Rectangle\n\nPlease, enter correct data");
                        PressAnyKeyToContinue();
                        SetRectangle();
                    }


                    //Если пользователь не правильно расположил прямоугольник программа сама исправит это поменяв координаты X и Y
                    if ((buf_p1.x > buf_p2.x) && (buf_p1.y > buf_p2.y)) { SwapValues(ref buf_p1.x, ref buf_p2.x); SwapValues(ref buf_p1.y, ref buf_p2.y); }
                    else if ((buf_p1.x < buf_p2.x) && (buf_p1.y > buf_p2.y)) { SwapValues(ref buf_p1.y, ref buf_p2.y); }
                    else if ((buf_p1.x > buf_p2.x) && (buf_p1.y < buf_p2.y)) { SwapValues(ref buf_p1.x, ref buf_p2.x); }
                    if (Math.Abs(buf_p1.x - buf_p2.x) <= Math.Abs(buf_p1.y - buf_p2.y))
                    {
                        SwapValues(ref buf_p1.x, ref buf_p1.y);
                        SwapValues(ref buf_p2.x, ref buf_p2.y);
                        Console.WriteLine("I'm swap X and Y axis");
                        PressAnyKeyToContinue();
                    }


                    // Просьба ввести расстояние от точки g до точки a
                    Console.Write("Set indent for point 'g' relative to point 'a': ");
                    buf = CheckedReadLine();
                    // Проверка того, что расстояние от точки g до точки не больше, чем сторона ab
                    while (buf >= Math.Abs(buf_p2.y - buf_p1.y) || buf <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Error: indent more then side AB or less then/equal 0");
                        Console.Write("Please, set indent for point 'g' relative to point 'a' again: ");
                        buf = CheckedReadLine();
                    }
                    p1.x = buf_p1.x;
                    p2.x = buf_p2.x;
                    p1.y = buf_p1.y;
                    p2.y = buf_p2.y;
                    g = buf;
                    Console.Clear();
                    Console.WriteLine("Your Rectangle was set\nP1: X={0}, Y={1};\nP2: X={2}, Y={3}\nIndent for point 'g': {4}.", p1.x, p1.y, p2.x, p2.y, g);
                    PressAnyKeyToContinue();
                }

                // 2.
                // Пункт меню с помощью которого мы можем задать пример данных для построения фигуры
                else if (SelectedMenuItem == "Set Example of Data")
                {
                    p1.x = 0;
                    p1.y = 0;
                    p2.x = 15;
                    p2.y = 5;
                    g = 3;
                    Console.Clear();
                    Console.Write("You set Example of Data\nP1: X={0}, Y={1};\nP2: X={2}, Y={3}\nIndent for point 'g': {4}.", p1.x, p1.y, p2.x, p2.y, g);
                    PressAnyKeyToContinue();
                }

                // 3.
                // Пункт меню, показывающий текущие данные для построения фигуры
                else if (SelectedMenuItem == "Show Current Data")
                {
                    Console.Clear();
                    Console.WriteLine("Your Rectangale current data\nP1: X={0}, Y={1};\nP2: X={2}, Y={3}\nIndent for point 'g': {4}.", p1.x, p1.y, p2.x, p2.y, g);
                    PressAnyKeyToContinue();
                }

                // 4.
                // Пункт меню запускающий вычисления
                else if (SelectedMenuItem == "Calculate")
                {
                    Console.Clear();
                    // Проверка на то были ли введены данные
                    if ((p1.x == p2.x) || (p1.y == p2.y))
                    {
                        Console.WriteLine("You don't set data / Your data is incorrect");
                        PressAnyKeyToContinue();
                    }
                    else
                    {
                        for (int N = 1000; N <= Math.Pow(10, 7); N *= 10)
                        {
                            MonteCarloCalculator calc = new MonteCarloCalculator(p1, p2, g, N);
                            calc.DrawTable();
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
        // Метод меняющий значения переменных местами
        private static void SwapValues(ref double a, ref double b)
        {
            a += b;
            b = a - b;
            a -= b;
        }
        // Метод DrawMenu. С помощью него и происходит отрисовка меню.
        private static int index = 0;
        private static string DrawMenu(List<string> items)
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
        private static double CheckedReadLine()
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
        private void PressAnyKeyToContinue()
        {
            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

