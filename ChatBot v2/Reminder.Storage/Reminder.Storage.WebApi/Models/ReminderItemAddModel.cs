using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reminder.Storage.Core;
using System.ComponentModel.DataAnnotations;

namespace Reminder.Storage.WebApi.Models
{
    public class ReminderItemAddModel
    {
        [Required]
        public DateTimeOffset Date { get; set; }

        [Required]
        public string ContactId { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public ReminderItemStatus Status { get; set; }


    }
}
