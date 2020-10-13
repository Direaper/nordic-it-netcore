using System;

class Program
{
	static void Main()
	{
		double c = 9.8;
		int d = (int)c; // 'g' is 9 loosing its .8 part
		Console.WriteLine(d);

		long e = 10;
		int f = (int)e;
		Console.WriteLine($"e is {e} and f is {f}"); // e is 10 and f is 10

		e = long.MaxValue;
		f = (int)e;
		Console.WriteLine($"e is {e} and f is {f}");    // e is 9223372036854775807 and f is -1

		object obj = 10;
		int iObj = (int)obj;
	}
}