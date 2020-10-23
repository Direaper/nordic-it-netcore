using System;

namespace Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                try
                {
                    Console.WriteLine("Введите положительное число от 1 до 2 миллиардов");
                    int input = int.Parse(Console.ReadLine());
                    int i = 0;

                    if (input <= 2000000000)
                    {
                        while (input != 0)
                        {
                            if ((input % 10) % 2 == 0)
                            {
                                i++;
                            }
                            input = input / 10;
                        }
                        Console.WriteLine($"Кол-во четных цифр {i}");
                    }
                    else if (input < 2000000000)
                    {
                        Console.WriteLine($"Ошибка! Вы ввели значение больше двух миллиардов!");
                    }

                    Console.ReadKey();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка! Вы ввели неверное значение");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Ошибка! Вы ввели значение больше 2 миллиардов");
                }

            }
        }
    }
}
