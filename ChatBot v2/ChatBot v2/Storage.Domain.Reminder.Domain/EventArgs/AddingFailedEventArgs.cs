using System;
using Reminder.Domain.Model;

namespace Reminder.Domain.EventArgs
{
	public class AddingFailedEventArgs : System.EventArgs
	{
		public AddReminderModel Reminder { get; set; }

		public Exception Exception { get; set; }

		public AddingFailedEventArgs(
			AddReminderModel reminder,
			Exception exception)
		{
			Reminder = reminder;
			Exception = exception;
		}
	}
}
