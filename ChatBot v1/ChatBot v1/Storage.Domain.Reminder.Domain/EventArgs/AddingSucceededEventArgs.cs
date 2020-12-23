using Reminder.Domain.Model;

namespace Reminder.Domain.EventArgs
{
	public class AddingSucceededEventArgs
	{
		public AddReminderModel Reminder { get; set; }

		public AddingSucceededEventArgs(AddReminderModel reminder)
		{
			Reminder = reminder;
		}
	}
}