using System;

class Program
{
	static void Main()
	{
		double a = 10 * 10.0 + 5f;
		double b = a;
		Console.WriteLine(b);

		double g = 9.8;
		int c = g; // compiler gives an error for this line!
		Console.WriteLine(g);
	}
}