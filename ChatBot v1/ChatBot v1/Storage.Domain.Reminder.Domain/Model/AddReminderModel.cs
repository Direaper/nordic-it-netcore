using Reminder.Storage.Core;
using System;
using System.Collections.Generic;
using System.Text;

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
        public AddReminderModel(DateTimeOffset date, string message, string contactId)
        {
            Date = date;
            Message = message;
            ContactId = contactId;
        }


        public ReminderItem ToRemiderItem()
        {
            return  new ReminderItem(
            Date,
            Message,
            ContactId);
        }
    }
}
