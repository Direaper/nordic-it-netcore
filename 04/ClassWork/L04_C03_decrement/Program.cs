using System;

class Program
{
	static void Main()
	{
		// decrement

		// --i
		int a = 0;
		int b = 0;
		b = --a; // first decrement "a", then assign its value to "b"
		Console.WriteLine(a);	// -1
		Console.WriteLine(b);	// -1

		// i--
		int c = 0;
		int d = 0;
		d = c--; // first assign value of "c" to "d", then decrement "c"
		Console.WriteLine(c);	// -1
		Console.WriteLine(d);	// 0
	}
}