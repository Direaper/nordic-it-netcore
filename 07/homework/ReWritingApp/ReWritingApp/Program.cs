using System;
using System.Globalization;
using System.Linq;

namespace ReWritingApp
{
    class ChekingForA
    {
        public string words { get; set; }

        public void ChekingA(string words)
        {
            string checkWords;
            int indexOfA = 0;
            string rewrite = words.ToLower();
            checkWords = words;

            string[] wordsCheck = words.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (wordsCheck.Length >= 2)
            {
                for (int i = 0; i < wordsCheck.Length; i++)
                {

                    if (wordsCheck[i].StartsWith('a') || wordsCheck[i].StartsWith('A') || wordsCheck[i].StartsWith('А') || wordsCheck[i].StartsWith('а'))
                    {
                        indexOfA = indexOfA + 1;
                    }
                }
                Console.WriteLine($"Вы ввели {wordsCheck.Length} слов(а).\n" +
                $"Из них {indexOfA} слов начинались на символы А и а \n");
            }

            if (wordsCheck.Length < 2)
            {
                Console.WriteLine("Ошибка! Вы ввели меньше двух слов");
            }

        }

        public void RewriteWords(string words)
        {
            string[] values = new string[words.Length];
            string[] values2 = new string[words.Length];

            for (int i = 0; i < words.Length; i++)
            {

                values[i] = Convert.ToString(words[i]);
                values2[i] = Convert.ToString(words[i]);
            }

            for (int i = 0, j = values.Length - 1; j >= 0; j--, i++)
            {
                values[i] = values2[j];
            }
            for (int i = 0; i < values.Length; i++)
            {
                Console.Write($"{values[i].ToLower()}");

            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать! Пожалуйста, введите более двух слов для проверки");

                var word = Console.ReadLine();

                ChekingForA check = new ChekingForA();
                check.ChekingA(word);
                check.RewriteWords(word);

                Console.ReadKey();
            }
        }
    }
}
