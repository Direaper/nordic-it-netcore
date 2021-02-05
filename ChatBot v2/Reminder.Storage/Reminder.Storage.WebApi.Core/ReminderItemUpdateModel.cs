using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reminder.Storage.Core;
using System.ComponentModel.DataAnnotations;

namespace Reminder.Storage.WebApi.Core
{
    public class ReminderItemUpdateModel
    {
        [Required]
        public DateTimeOffset Date { get; set; }

        [Required]
        public string ContactId { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public ReminderItemStatus Status { get; set; }


        public ReminderItemUpdateModel()
        {

        }
        public ReminderItemUpdateModel(ReminderItem reminderItem)
        {
            ContactId = reminderItem.ContactId;
            Message = reminderItem.Message;
            Date = reminderItem.Date;
            Status = reminderItem.Status;
        }

        public void UpdateRemiderItem(ReminderItem reminderItem)
        {
            reminderItem.ContactId = ContactId;
            reminderItem.Date = Date;
            reminderItem.Message = Message;
            reminderItem.Status = Status;
        }
    }
}
