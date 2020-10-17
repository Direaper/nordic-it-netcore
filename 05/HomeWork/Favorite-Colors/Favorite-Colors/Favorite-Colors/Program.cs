using System;

namespace Favorite_Colors
{
    class Program
    {
        [Flags]
        enum Colors : byte
        {
            None = 0x0,                 
            Red = 0x1,                  
            Orange = 0x1 << 1,         
            Yellow = 0x1 << 2,          
            Green = 0x1 << 3,           
            Blue = 0x1 << 4,           
            Violet = 0x1 << 5,          
            Black = 0x1 << 6,          
            White = 0x1 << 7           
        }
        static void Main(string[] args)
        {
            var Pallet = Colors.Red | Colors.Orange | Colors.Yellow | Colors.Green | Colors.Blue | Colors.Violet | Colors.Black | Colors.White;
            var colorArray = (Colors[])Enum.GetValues(typeof(Colors));
            Console.WriteLine($"Please, enter you favorite colors: ");
       
            for (var i = 1; i < colorArray.Length; i++)
            {
                Console.WriteLine($"{colorArray[i]}  ");
            }
        

            Console.Write($"\n");

            var favColors = Colors.None;
            var unFavColors = Colors.None;
          
                for (var i = 1; i < 5; i++)
                {
                try
                {
                    Console.WriteLine($"\nChoose {i} color");
                    var input = Console.ReadLine();
                    var getValue = (Colors)Enum.Parse(typeof(Colors), input);
                    favColors = favColors | getValue;
                }

                catch (System.ArgumentException)
                {
                    Console.WriteLine($"You enter wrong value!");
                }

            }
            
         
            unFavColors = favColors ^ Pallet;
            Console.WriteLine($"You favorite colors: {favColors}  ");
            Console.WriteLine($"You don't like this colors: {unFavColors}  ");
            Console.ReadKey();
        }

        }
    }

