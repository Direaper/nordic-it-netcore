using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            for (; ; )
            {
                Console.WriteLine($"Добро пожаловать в программу Калькулятор. Введите первое число");
                double firstNumber = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine($"Введите второе число");
                double secondNubmer = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine($"Отлично! Вы ввели {firstNumber} и {secondNubmer}. Выберете операцию: 1 = плюс, 2 = минус, 3 = деление, 4 = умножение, 5 = остаток от деления, 6 = возведение в степень.");
                int operation = Convert.ToInt32(Console.ReadLine());

                if (operation == 1)
                {
                    Console.WriteLine(firstNumber + secondNubmer);
                }
                if (operation == 2)
                {
                    Console.WriteLine(firstNumber - secondNubmer);
                }

                if (operation == 3)
                {
                    Console.WriteLine(firstNumber / secondNubmer);
                }
                if (operation == 4)
                {
                    Console.WriteLine(firstNumber * secondNubmer);
                }

                if (operation == 5)
                {
                    double last = firstNumber % secondNubmer;
                    Console.WriteLine($"{last}");
                }

                if (operation == 6)
                {

                    double extent = Math.Pow(firstNumber, secondNubmer);
                    Console.WriteLine(extent);
                }


                Console.ReadKey();
            }
        }
    }
}
