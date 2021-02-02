using Reminder.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Domain.EventArgs
{
   public class SendingSucceededEventArgs: System.EventArgs
    {
        public SendReminderModel Reminder { get; set; }

        public SendingSucceededEventArgs(SendReminderModel reminder)
        {
            Reminder = reminder;
        }
    }
}
