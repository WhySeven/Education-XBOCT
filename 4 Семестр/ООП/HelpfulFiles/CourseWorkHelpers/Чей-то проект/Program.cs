using System;

namespace ObjectOriented
{
    class Program
    {
        static void Manual()
        {
            input: Console.WriteLine("Введите координаты точки d:");
            Console.Write("x = ");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.Write("y = ");
            double y = Convert.ToDouble(Console.ReadLine());
            Point d = new Point(x, y);
            Console.WriteLine("Введите координаты точки b:");
            Console.Write("x = ");
            x = Convert.ToDouble(Console.ReadLine());
            Console.Write("y = ");
            y = Convert.ToDouble(Console.ReadLine());
            Point b = new Point(x, y), e = new Point(d.X - b.Y + d.Y, b.Y), o = new Point(e.X, d.Y);
            if (d.X <= b.X || b.Y <= d.Y || e.X < b.X)
            {
                Console.WriteLine("Ошибка! Недопустимое расположение точек b и d!");
                goto input;
            }
            Console.WriteLine($"Координаты точки d:\nx = {d.X}\ny = {d.Y}");
            Console.WriteLine($"Координаты точки e:\nx = {e.X}\ny = {e.Y}");
            Console.WriteLine($"Координаты точки b:\nx = {b.X}\ny = {b.Y}");
            Console.WriteLine($"Координаты точки o:\nx = {o.X}\ny = {o.Y}");
            Figure f = new Figure(d, e, b, o);
            f.MonteCarlo();
        }
        static void Test()
        {
            Point d = new Point(10, 1), e = new Point(8, 3), b = new Point(1, 3), o = new Point(8, 1);
            Console.WriteLine($"Координаты точки d:\nx = {d.X}\ny = {d.Y}");
            Console.WriteLine($"Координаты точки e:\nx = {e.X}\ny = {e.Y}");
            Console.WriteLine($"Координаты точки b:\nx = {b.X}\ny = {b.Y}");
            Console.WriteLine($"Координаты точки o:\nx = {o.X}\ny = {o.Y}");
            Figure f = new Figure(d, e, b, o);
            f.MonteCarlo();
        }
        static void Main()
        {
            string action = "";
            while (action != "выход")
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("[Ввод] - Ручной ввод координат\t[Тест] - Выполнить контрольный пример\t[Выход] - Выйти");
                Console.Write("> ");
                input: action = Console.ReadLine().ToLower();
                switch (action)
                {
                    case "ввод": Manual(); break;
                    case "тест": Test(); break;
                    case "выход": break;
                    default: Console.Write("Действие не найдено. Повторите ввод:\n> "); goto input;
                }
            }
        }
    }
}
