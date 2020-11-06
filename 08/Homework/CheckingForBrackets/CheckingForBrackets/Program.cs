using System;
using System.Collections.Generic;

namespace CheckingForBrackets
{
    public static class CheckingForBrackets
    {


    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                static int BracketCheck(string s)
                {
                    string t = "[{(]})";
                    Stack<char> st = new Stack<char>();

                    for (int i = 0; i < s.Length; i++)
                    {
                        int f = t.IndexOf(s[i]);

                        if (f >= 0 && f <= 2)
                            st.Push(s[i]);

                        if (f > 2)
                        {
                            if (st.Count == 0 || st.Pop() != t[f - 3])
                                return i;
                        }
                    }

                    if (st.Count != 0)
                        return s.LastIndexOf(st.Pop());

                    return -1;
                }

                var s = Console.ReadLine();
                Console.WriteLine(BracketCheck(s) == -1 ? "Success" : BracketCheck(s).ToString());
            }
        }
    }
}
