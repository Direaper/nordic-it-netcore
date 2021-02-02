using System;

namespace Reminder.Storage.Core
{
	public class ReminderItem
	{
		public Guid Id { get; }

		public ReminderItemChat Chat { get; }

		public string ContactId { get; set; }

		public DateTimeOffset Date { get; set; }

		public string Message { get; set; }

		public TimeSpan TimeToAlarm => Date.Subtract(DateTimeOffset.UtcNow);

		public bool IsTimeToSend => TimeToAlarm <= TimeSpan.Zero;

		public ReminderItemStatus Status { get; set; }

		public ReminderItem(
			DateTimeOffset date,
			string message,
			string contactId,
			ReminderItemStatus status)
			: this(Guid.NewGuid(), date, message, contactId, status)
		{ }

		public ReminderItem(
			Guid id,
			DateTimeOffset date,
			string message,
			string contactId,
			ReminderItemStatus status)
		{
			Id = id;
			Date = date;
			Message = message;
			ContactId = contactId;
			Chat = ReminderItemChat.Telegram;
			Status = status;
		}
	}
}
