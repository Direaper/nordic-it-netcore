using System;

namespace L04_C14_bin_operators
{
	class Program
	{
		static void Main(string[] args)
		{
			byte a = 0x03;                  // 00000011
			byte b = 0x05;                  // 00000101

			//WriteByteValueWithBits(a);
			//WriteByteValueWithBits(b);

			// | OR
			// 1 | 1 = 1
			// 1 | 0 = 1
			// 0 | 1 = 1
			// 0 | 0 = 0

			byte orResult = (byte)(a | b);  // 00000111
			WriteByteValueWithBits(orResult);

			// & AND
			// 1 & 1 = 1
			// 0 & 1 = 0
			// 1 & 0 = 0
			// 0 & 0 = 0

			byte andResult = (byte)(a & b); // 00000001
			WriteByteValueWithBits(andResult);

			// ^ XOR
			// 0 ^ 0 = 0
			// 0 ^ 1 = 1
			// 1 ^ 0 = 1
			// 1 ^ 1 = 0

			//byte a = 0x03;                // 00000011
			//byte b = 0x05;                // 00000101
			byte xorResult = (byte)(a ^ b); // 00000110
			WriteByteValueWithBits(xorResult);

			// ~ NOT
			byte notResultA = (byte)~a;           // 11111001
			byte notResultB = (byte)~b;           // 11111100

			WriteByteValueWithBits(a);
			Console.WriteLine("~ NOT =");
			WriteByteValueWithBits(notResultA);
			Console.WriteLine();

			WriteByteValueWithBits(b);
			Console.WriteLine("~ NOT =");
			WriteByteValueWithBits(notResultB);
			Console.WriteLine();

			// << left-shift
			byte leftShiftResultA = (byte)(a << 2); // 00000011
													// 00001100
			byte leftShiftResultB = (byte)(b << 6);

			WriteByteValueWithBits(a);
			Console.WriteLine("<< 1 left-shift by 1");
			WriteByteValueWithBits(leftShiftResultA);
			Console.WriteLine();

			WriteByteValueWithBits(b);
			Console.WriteLine("<< 6 left-shift by 6");
			WriteByteValueWithBits(leftShiftResultB);
			Console.WriteLine();

			// >> right-shift
			byte rightShiftResultA = (byte)(a >> 1); // 00000011
													 // 00000000
			byte rightShiftResultB = (byte)(b >> 2);

			WriteByteValueWithBits(a);
			Console.WriteLine(">> 1 right-shift by 1");
			WriteByteValueWithBits(rightShiftResultA);
			Console.WriteLine();

			WriteByteValueWithBits(b);
			Console.WriteLine(">> 2 right-shift by 2");
			WriteByteValueWithBits(rightShiftResultB);
			Console.WriteLine();
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
