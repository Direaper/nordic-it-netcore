using System;
using System.Globalization;
using System.Linq;

namespace ReWritingApp
{

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать! Пожалуйста, введите более двух слов для проверки");

                var words = Console.ReadLine();
                ChekingForA.ChekingA(words);
                RewriteWords.RewritingWords(words);
                Console.ReadKey();
            }
        }
    }
}
