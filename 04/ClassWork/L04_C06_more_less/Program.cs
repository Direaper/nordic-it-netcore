using System;

class Program
{
	static void Main()
	{
		// operator >
		Console.WriteLine(10 > 15);				// False
		//Console.WriteLine(true > false);		// Compiler error!
		//Console.WriteLine("abc" > "def");		// Compiler error!

		// operator <
		Console.WriteLine(10 < 15);				// True
		Console.WriteLine(15 < 10);				// False

		// operator >=
		Console.WriteLine(10 >= 15);			// False
		Console.WriteLine(15 >= 15);			// True

		// operator <=
		Console.WriteLine(10 <= 15);			// True
		Console.WriteLine(15 <= 15);			// True
	}
}