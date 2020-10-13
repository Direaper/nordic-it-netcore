using System;

namespace Litres_Counter
{
    class Program
    {
        enum Box : int
        {
            None = 0,
            BigBox = 20,
            MidBox = 5,
            SmallBox = 1
        }


        static void Main(string[] args)

        {
            try
            {
                Console.WriteLine("Введите количество литров, которые нужно упаковать:");
                var volume = Math.Ceiling(Convert.ToDouble(Console.ReadLine()));
                var bigCont = Math.Ceiling(Convert.ToDouble(Box.BigBox));
                var bigOst = volume % (double)Box.BigBox;
                var midCont = Math.Ceiling(Convert.ToDouble(Box.MidBox));
                var midOst = bigOst % (double)Box.MidBox;
                var smallCont = Math.Ceiling(Convert.ToDouble(Box.SmallBox));

                Console.WriteLine($"Вы ввели {volume}");



                if (volume >= bigCont)
                {
                    Console.WriteLine($"Вам необходимо {Math.Floor(volume / bigCont)} , 20 литровых контейнеров");
                }

                if (bigOst >= midCont)
                {
                    Console.WriteLine($"Вам необходимо {Math.Floor(bigOst / midCont)} , 5 литровых контейнеров");
                }

                if (midOst >= smallCont)
                {
                    Console.WriteLine($"Вам небходимо {Math.Ceiling(midOst / smallCont)} , 1 литровых контейнеров");
                }
            }

            catch (FormatException)
            {
                Console.WriteLine($"Не верный формат введеного значения!");
            }


            Console.ReadKey();
        }
    }
}