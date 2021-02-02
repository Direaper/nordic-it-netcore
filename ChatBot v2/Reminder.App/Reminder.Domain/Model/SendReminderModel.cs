using System;
using System.Collections.Generic;
using System.Text;
using Reminder.Storage.Core;

namespace Reminder.Domain.Model
{
	public class SendReminderModel
	{
		public string ContactId { get; set; }

		public DateTimeOffset Date { get; set; }

		public string Message { get; set; }

		public SendReminderModel()
		{
		}

		public SendReminderModel(ReminderItem reminderItem)
		{
			ContactId = reminderItem.ContactId;
			Message = reminderItem.Message;
			Date = reminderItem.Date;
		}
	}
}
