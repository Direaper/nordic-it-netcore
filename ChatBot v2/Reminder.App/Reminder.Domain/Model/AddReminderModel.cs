using System;
using System.Collections.Generic;
using System.Text;
using Reminder.Storage.Core;

namespace Reminder.Domain.Model
{
	public class AddReminderModel
	{
		public string ContactId { get; set; }

		public DateTimeOffset Date { get; set; }

		public string Message { get; set; }

		public AddReminderModel()
		{
		}

		public AddReminderModel(ReminderItem reminderItem)
		{
			Date = reminderItem.Date;
			Message = reminderItem.Message;
			ContactId = reminderItem.ContactId;
		}

		public AddReminderModel(DateTimeOffset date, string message, string contactId)
		{
			Date = date;
			Message = message;
			ContactId = contactId;
		}

		public ReminderItem ToReminderItem()
		{
			return new ReminderItem(
				Date,
				Message,
				ContactId);
		}
	}
}
