using System;

namespace bank
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            while (i == 0)
            { 
            try { 
            Console.WriteLine("Введите сумму первоначального взноса в рублях: ");
            double sumInp = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Вы ввели {sumInp} рублей");
             if (sumInp<=0)
                    {
                    Console.WriteLine($"Ошибка! Вы ввели отрицательное или нулевое значение. Нажмите любую клавишу, чтобы начать заново!");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }

            Console.WriteLine("Введите ежедневный процент дохода в виде десятичной дроби (1% = 0,01):");
            double procInp = Convert.ToDouble(Console.ReadLine());
                    if (procInp <= 0)
                    {
                        Console.WriteLine($"Ошибка! Вы ввели отрицательное или нулевое значение. Нажмите любую клавишу, чтобы начать заново!");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }

            double procValue = procInp * sumInp;
            int day = 0;
            Console.WriteLine($"Ваш доход будет увеличиваться на {procValue} ежедневно");
            Console.WriteLine("Введите желаемую сумму накопления в рублях:");
            double capInp = Convert.ToDouble(Console.ReadLine());
                    if (capInp <= 0)
                    {
                        Console.WriteLine($"Ошибка! Вы ввели отрицательное или нулевое значение. Нажмите любую клавишу, чтобы начать заново!");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }
                    Console.WriteLine($"Желаемая сумма накопления: {capInp} ");

            while (sumInp < capInp)
            {
                sumInp=sumInp + procValue;
                day=day + 1;

            }
            Console.WriteLine($"Через {day} дней, ваш доход будет: {capInp} ");
            }
            catch (FormatException)
            {
                Console.WriteLine($"Вы ввели не верное значение!");
            }
            catch (System.OverflowException)
            {
                Console.WriteLine($"Введенное число превышает допустимое значение");
            }

            Console.ReadKey();
            Console.Clear();
            }
        }
    }
}
