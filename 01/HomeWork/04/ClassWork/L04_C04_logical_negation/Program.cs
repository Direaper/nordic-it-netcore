using System;

class Program
{
	static void Main()
	{
		bool a = true;
		Console.WriteLine(a);	// a is "true"

		bool b = !a;
		Console.WriteLine(b);	// a is "true", so !a is "false"

		bool c = !b;			
		Console.WriteLine(c);	// b is "false", so !b is "true"
	}
}