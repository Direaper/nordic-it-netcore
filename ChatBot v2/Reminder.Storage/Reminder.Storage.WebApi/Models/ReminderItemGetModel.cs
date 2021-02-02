using Reminder.Storage.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reminder.Storage.WebApi.Models
{
    public class ReminderItemGetModel
    {
        public Guid Id { get; set; }

        public ReminderItemChat Chat { get; }

        public DateTimeOffset Date { get; set; }

        public string ContactId { get; set; }

        public string Message { get; set; }

        public ReminderItemStatus Status { get; set; }

        //gets time period before reminder should fire.
        // negative for dates in the past
        public TimeSpan TimeToAlarm => Date.Subtract(DateTimeOffset.UtcNow);
        
        //Gets the value indicating weither w
        public bool IsTimeToSend => TimeToAlarm <= TimeSpan.Zero;

        public ReminderItemGetModel()
        {

        }

        public ReminderItemGetModel(ReminderItem reminderItem)
        {
            Id = reminderItem.Id;
            Chat = ReminderItemChat.Telegram;
            ContactId = reminderItem.ContactId;
            Message = reminderItem.Message;
            Date = reminderItem.Date;
            Status = reminderItem.Status;
        }
    }
}
