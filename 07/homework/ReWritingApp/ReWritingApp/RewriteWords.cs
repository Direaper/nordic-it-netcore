using System;
using System.Linq;

namespace ReWritingApp
{
    static class RewriteWords
    {
        static public void RewritingWords(string words)
        {
            string[] values = new string[words.Length];

            for (int i = 0, j = values.Length - 1; j >= 0; j--, i++)
            {
                values[i] = Convert.ToString(words[j]);
                Console.Write(values[i].ToLower());
            }
        }
    }
}
