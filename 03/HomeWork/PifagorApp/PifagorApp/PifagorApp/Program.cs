using System;

namespace PifagorApp
{


    class Program
    {
        static void Main(string[] args)
        {
            int[] mass = new int[10];
            int[,] mass2 = new int[10, 10];


            int value = 1;
            int val2 = 0;
            int v = 0;

            while (true)
            {
                Console.WriteLine($"Наберите: 1 чтобы отобразить таблицу \nНаберите: 2 чтобы отобразить изменяему таблицу \nНаберите: 3 для выхода из приложения");
                var work = Convert.ToInt32(Console.ReadLine());

                if (work == 1)
                {
                    for (int i = 0; i < mass.Length; i++)
                    {
                        mass[i] = value++;
                    }

                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < mass.Length; j++)
                        {

                            val2 = mass[j] * mass[i];
                            mass2[i, j] = val2;
                        }
                    }

                    for (int a = 0; a < mass.Length; a++)
                    {
                        Console.Write($"{mass[a]} | ");
                        if (a == 9)
                        {
                            Console.WriteLine();
                        }
                    }

                    for (int b = 0; b < 10; b++)
                    {
                        if (b == 0)
                        {
                            continue;
                        }

                        Console.WriteLine($"{mass[b]} | {mass2[v + 1, b]} | {mass2[v + 2, b]} | {mass2[v + 3, b]} | {mass2[v + 4, b]}| {mass2[v + 5, b]}| {mass2[v + 6, b]}| {mass2[v + 7, b]}| {mass2[v + 8, b]}|  {mass2[v + 9, b]}| ");

                        if (v > 10)
                        {
                            break;
                        }
                    }
                }

                if (work == 2)
                {
                    Console.WriteLine($"Введите число больше 10 и меньше 1000, чтобы увидеть таблицу умножения");
                    var work2 = Convert.ToInt32(Console.ReadLine());
                    if (work2 < 10)
                    {
                        Console.WriteLine($"Ошибка! Вы ввели слишком маленькое число!");
                        Console.ReadKey();
                        break;
                    }
                    else if (work2 > 1000)
                    {
                        Console.WriteLine($"Ошибка! Вы ввели слишком большое число!");
                        Console.ReadKey();
                        break;
                    }
                    int[] massVar2 = new int[work2];
                    for (int i = 0; i < massVar2.Length; i++)
                    {
                        massVar2[i] = value++;
                    }

                    for (int i = 0; i < massVar2.Length; i++)
                    {
                        for (int j = 0; j < massVar2.Length; j++)
                        {

                            val2 = massVar2[j] * massVar2[i];
                            Console.WriteLine($"{val2} ");
                        }
                    }
                }
                if(work == 3)
                {
                    break; 
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
