using System;

namespace Figures
{
    class Program
    {
        enum Figures
        {
            Rectangle = 1,
            Triagle, 
            Circle
        }
        static void Main(string[] args)
        {
            var figureArray = (Figures[])Enum.GetValues(typeof(Figures));
            Console.Write($"Please, choose figure:  ");

            for (var i = 0; i < figureArray.Length; i++)
            {
                Console.Write($"{figureArray[i]}, ");
            }
            Console.WriteLine($"\n");
            try
            {
                var input = Console.ReadLine();
                var getValue = (Figures)Enum.Parse(typeof(Figures), input);
                Console.WriteLine($"you choose:  {getValue}");

                switch (Convert.ToInt32(input))
                {
                    case 1:
                        Console.WriteLine("Please, enter the height of the rectangle: ");
                        double height = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Please, enter the width of the rectangle: ");
                        double width = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine($"The area of the rectangle: {height * width}");
                        Console.WriteLine($"The perimeter of the rectangle: {2 * (height + width)}");
                        break;
                    case 2:
                        Console.WriteLine("Please, enter the side of the triangle: ");
                        double side = Convert.ToDouble(Console.ReadLine());
                        double sqrt = Math.Sqrt(3);
                        double squareSide = Math.Round((sqrt / 4) * (side * side), 2);
                        Console.WriteLine($"The area of the triangle: {squareSide}");
                        Console.WriteLine($"The perimetr of the triangle: {side * 3}");
                        break;
                    case 3:
                        Console.WriteLine("Please, enter the diametr of the circle: ");
                        double P = Math.Round(Math.PI, 2);
                        double Diametr = Convert.ToDouble(Console.ReadLine());
                        double area = (P / 4) * (Diametr * Diametr);
                        Console.WriteLine($"The area of the circle: {area}");
                        Console.WriteLine($"The perimetr of the circle: {P * Diametr}");
                        break;
                   default:
                        Console.WriteLine($"Sorry, you enter the wrong value of the figure!");
                        break;

                }

             }
            catch (System.ArgumentException)
            {
                Console.WriteLine($"You enter wrong value!");
            }
            catch (System.FormatException)
            {
                Console.WriteLine($"You enter wrong format!");
            }
            Console.ReadKey();
        }
    }
}
