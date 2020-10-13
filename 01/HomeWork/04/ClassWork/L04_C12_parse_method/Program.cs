using System;

class Program
{
	static void Main()
	{
		//string strInt = "12";
		//int i = Int32.Parse(strInt);
		//Console.WriteLine(i * i); // 144

		string strFloat = "3.kjsdfkjlsdf14159265";
		//float f = Single.Parse(strFloat);
		var result = Single.TryParse(strFloat, out var f1);
		Console.WriteLine(result);
		Console.WriteLine(f1);
		Console.ReadKey();

		//string strBool = "true";
		//bool b = Boolean.Parse(strBool);
		//Console.WriteLine(b.ToString()); // True
	}
}