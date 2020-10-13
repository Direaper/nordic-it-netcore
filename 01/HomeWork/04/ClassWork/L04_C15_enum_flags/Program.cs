using System;

namespace L04_C15_enum_flags
{
	class Program
	{
		[Flags]
		enum Days: byte
		{
			None = 0x0,            // 00000000
			Sunday = 0x1,          // 00000001
			Monday = 0x1 << 1,     // 00000010
			Tuesday = 0x1 << 2,    // 00000100
			Wednesday = 0x1 << 3,  // 00001000
			Thursday = 0x1 << 4,   // 00010000
			Friday = 0x1 << 5,     // 00100000
			Saturday = 0x1 << 6    // 01000000
		}

		static void Main(string[] args)
		{
			var input = Console.ReadLine();
			var inputByte = Byte.Parse(input); // 1, 2, 4, 8, 16, 32, 64
			var inputDate = (Days)inputByte;
			var favorites = Days.None | inputDate;

			Days nonWorkingDays = Days.Saturday | Days.Sunday; // 01000001
			WriteByteValueWithBits((byte)Days.Saturday);
			WriteByteValueWithBits((byte)Days.Sunday);
			WriteByteValueWithBits((byte)nonWorkingDays);

			Console.WriteLine("\nAdding Friday:");

			// add Friday to the list of non-working days
			nonWorkingDays = nonWorkingDays | Days.Friday;
			WriteByteValueWithBits((byte)Days.Friday);
			WriteByteValueWithBits((byte)nonWorkingDays);

			Console.WriteLine("\nRemove Sunday:");

			// remove Sunday from the list of non-working days
			WriteByteValueWithBits((byte)nonWorkingDays);
			WriteByteValueWithBits((byte)Days.Sunday);
			nonWorkingDays = nonWorkingDays ^ Days.Sunday;
			WriteByteValueWithBits((byte)nonWorkingDays);

			Console.WriteLine("\nCheck Thursday:");
			WriteByteValueWithBits((byte)nonWorkingDays);
			WriteByteValueWithBits((byte)Days.Thursday);
			WriteByteValueWithBits((byte)(nonWorkingDays & Days.Thursday));
			bool isThursdayNonWirking = (nonWorkingDays &Days.Thursday) == Days.Thursday;
			Console.WriteLine(isThursdayNonWirking);

			Console.WriteLine("\nCheck Friday:");
			WriteByteValueWithBits((byte)nonWorkingDays);
			WriteByteValueWithBits((byte)Days.Friday);
			WriteByteValueWithBits((byte)(nonWorkingDays & Days.Friday));
			bool isFridayNonWirking = (nonWorkingDays & Days.Friday) == Days.Friday;
			Console.WriteLine(isFridayNonWirking);
			Console.ReadKey();
		}

		static void WriteByteValueWithBits(byte value)
		{
			Console.WriteLine(
				"0x{0}\t({1})\t{2}",
				value.ToString("X").PadLeft(2, '0'),
				Convert.ToString(value, 2).PadLeft(8, '0'),
				value.ToString().PadLeft(3, '0'));
		}
	}
}
