using System;

class Program
{
	static void Main()
	{
		int number = 12;
		Console.WriteLine(number.ToString());	// 12
		Console.WriteLine(number);

		bool boolean = true;
		Console.WriteLine(boolean.ToString());	// True

		DateTime now = DateTime.Now;
		Console.WriteLine(now.ToString());		// 1/1/2019 2:15:00 PM

		System.Object me = new object();
		object obj1 = 4;
		object obj2 = true;
		Console.WriteLine(obj1);
		Console.WriteLine(obj2);
		Console.WriteLine(me.ToString());       // System.Object

		var dyn = 4;
		Console.WriteLine(dyn.ToString());

		string str = "abc";
		Console.WriteLine(str.ToString());      // abc :)
		Console.ReadKey();
	}
}