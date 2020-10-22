using System;

namespace Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            { 
            Console.WriteLine("Введите положительное число от 1 до 2 миллиардов");
            int input = int.Parse(Console.ReadLine());
            int i = 0;

           while (input != 0 )
            {
                if ((input % 10) % 2 == 0)
                {
                    i++;
                }
                input = input / 10;
            }


            Console.WriteLine($"Кол-во четных цифр {i}");
            Console.ReadKey();
            }
            catch (FormatException)
            {
                Console.WriteLine("Вы ввели неверное значение");
            }
        }
    }
}
