using System;

namespace Reminder.Storage.Core
{
    public class ReminderItem
    {
        public Guid Id { get; }
        public ReminderChat Chat { get; }
        public string ContactId { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Message { get; set; }
        public TimeSpan TimeToAlarm => Date.Subtract(DateTimeOffset.UtcNow);
        public bool IsTimeToSend => TimeToAlarm <= TimeSpan.Zero;
        public ReminderItemStatus Status { get; set; }
        public ReminderItem(
               DateTimeOffset date,
               string message,
               string contactId)
               : this( Guid.NewGuid(), date, message, contactId) 
        { }

        public ReminderItem(
            Guid id,
            DateTimeOffset date,
            string message,
            string contactId)
        {
            Id = id;
            Date = date;
            Message = message;
            ContactId = contactId;
            Chat = ReminderChat.Telegram;
            Status = ReminderItemStatus.Awaiting;
        }


    }
}