using System;

class Program
{
	static void Main()
	{
		var d1 = 7.03m;
		var d2 = 7.64m;
		var d3 = 0.12m;
		var d4 = -0.12m;
		var d5 = -7.1m;
		var d6 = -7.6m;
		Console.WriteLine("{0}, {1}", Math.Ceiling(d1), Math.Floor(d1)); // 8, 7
		Console.WriteLine("{0}, {1}", Math.Ceiling(d2), Math.Floor(d2)); // 8, 7
		Console.WriteLine("{0}, {1}", Math.Ceiling(d3), Math.Floor(d3)); // 1, 0
		Console.WriteLine("{0}, {1}", Math.Ceiling(d4), Math.Floor(d4)); // 0, -1
		Console.WriteLine("{0}, {1}", Math.Ceiling(d5), Math.Floor(d5)); // -7, -8
		Console.WriteLine("{0}, {1}", Math.Ceiling(d6), Math.Floor(d6)); // -7, -8

		var c = Math.Max(10.0, 11);
	}
}