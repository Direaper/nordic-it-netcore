using System;
using Reminder.Domain.Model;

namespace Reminder.Domain.EventArgs
{
	public class ParsingFailedEventArgs
	{
		public string ContactId { get; set; }

		public string InputText { get; set; }

		public ParsingFailedEventArgs(string contactId, string inputText)
		{
			ContactId = contactId;
			InputText = inputText;
		}
	}
}
