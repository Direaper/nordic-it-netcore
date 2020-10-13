using System;

class Program
{
	static void Main()
	{
		// var resultVariable = firstOperand operator secondOperand; // result
		float a = 7 + 0.5F;		// 7.5
		Console.WriteLine(a);

		int b = 7 - 2;          // 5
		Console.WriteLine(b);

		float c = 10.1F * 3;    // 30.3
		Console.WriteLine(c);

		int d = 11 / 3;         // 3
		Console.WriteLine(d);

		double e = 11 / 3;      // 3
		Console.WriteLine(e);

		double f = 11.0 / 3;    // 3.66666666666667
		Console.WriteLine(f);

		int g = 11 % 3;         // 2
		Console.WriteLine(g);
	}
}