using System;

namespace ReWritingApp
{
    static class ChekingForA
    {
        static public void ChekingA(string words)
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
    }
}
