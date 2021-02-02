using System;
using System.Net;

namespace Reminder.Parsing
{
	public static class MessageParser
	{
		public static ParsedMessage Parse(string input)
		{
			if (string.IsNullOrWhiteSpace(input))
				return null;

			DateTimeOffset date;
			string sourceMessage = input.Trim();

			int spaceIndex = sourceMessage.IndexOf(' ');

			string potentialDate =
				sourceMessage.Substring(0, spaceIndex);

			try
			{
				date = DateTimeOffset.Parse(potentialDate);
			}
			catch (Exception exception)
			{
				// Place to extend inputs for 10s 
				return null;
			}

			return new ParsedMessage
			{
				Date = date,
				Message = sourceMessage.Substring(spaceIndex).TrimStart()
			};
		}
	}
}
