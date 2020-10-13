using System;

class Program
{
	static void Main()
	{
		// operator == 
		Console.WriteLine(10 == 15);		// False
		Console.WriteLine(10.0 == 10);		// True
		Console.WriteLine("abc" == "abc");	// True
		Console.WriteLine(true == true);	// True
		Console.WriteLine(true == false);	// False

		// operator !=
		Console.WriteLine(10 != 15);		// True
		Console.WriteLine(10.0 != 10);		// False
		Console.WriteLine("abc" != "abc");	// False
		Console.WriteLine(true != true);	// False
		Console.WriteLine(true != false);	// True
	}
}