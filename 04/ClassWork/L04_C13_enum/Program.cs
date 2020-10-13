using System;

class Program
{
	enum Day
	{
		Sunday = 1,
		Monday,
		Tuesday,
		Wednesday,
		Thursday,
		Friday1,
		Saturday
	};
	enum Month : byte { Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec };

	public static void Main()
	{
		var a = Day.Monday;
		var b = (Day)(((double)a) + 4);
		Console.WriteLine(b);

		Day today = Day.Friday1;
		int dayNumber = (int)today;
		Console.WriteLine("{0} is day number #{1}.", today, dayNumber);
		Console.WriteLine($"{today} is day number #{dayNumber}.");

		Month thisMonth = Month.Dec;
		byte monthNumber = (byte)thisMonth;
		Console.WriteLine("{0} is month number #{1}.", thisMonth, monthNumber);
		Console.ReadKey();

		// Monday is day number #1.
		// Dec is month number #11.
	}
}
