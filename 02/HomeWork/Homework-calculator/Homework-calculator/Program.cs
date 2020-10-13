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
                double pervoeChislo = Convert.ToDouble(Console.ReadLine());                          
                Console.WriteLine();                                  
                Console.WriteLine($"Введите второе число");
                double vtoroeChislo = Convert.ToDouble(Console.ReadLine());                         
                Console.WriteLine();                                 
                Console.WriteLine($"Отлично! Вы ввели {pervoeChislo} и {vtoroeChislo}. Выберете операцию: 1 = плюс, 2 = минус, 3 = деление, 4 = умножение, 5 = остаток от деления, 6 = возведение в степень."); 
                int operacia = Convert.ToInt32(Console.ReadLine());            
                                                                        
                if (operacia == 1)                                             
                {
                    Console.WriteLine(pervoeChislo + vtoroeChislo);
                }
                if (operacia == 2)                                            
                {
                    Console.WriteLine(pervoeChislo - vtoroeChislo);                           
                }

                if (operacia == 3)                                             
                {
                    Console.WriteLine(pervoeChislo / vtoroeChislo);
                }
                if (operacia == 4)                                            
                {
                    Console.WriteLine(pervoeChislo * vtoroeChislo);
                }

                if (operacia == 5)                                           
                {
                    double ostatok = pervoeChislo % vtoroeChislo;
                    Console.WriteLine($"{ostatok}");
                }

                if (operacia == 6)                                         
                {

                    double stepen = Math.Pow(pervoeChislo, vtoroeChislo);
                    Console.WriteLine(stepen);
                }

           
            Console.ReadKey();
            }
        }
	}
}
