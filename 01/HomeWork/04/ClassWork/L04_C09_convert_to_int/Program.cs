using System;

class Program
{
	static void Main()
	{
		double i = 9.49;
		double j = 9.5;
		double k = 10.49;
		double l = 10.5; // it will be just 10!
		double m = 10.51;
		Console.WriteLine(Convert.ToInt32(i)); // 9
		Console.WriteLine(Convert.ToInt32(j)); // 10
		Console.WriteLine(Convert.ToInt32(k)); // 10
		Console.WriteLine(Convert.ToInt32(l)); // 10
		Console.WriteLine(Convert.ToInt32(m)); // 11
	}
}