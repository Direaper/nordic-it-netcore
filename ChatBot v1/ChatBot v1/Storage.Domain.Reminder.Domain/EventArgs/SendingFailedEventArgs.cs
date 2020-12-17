﻿using Reminder.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Domain.EventArgs
{
   public class SendingFailedEventArgs: System.EventArgs
    {
        public SendReminderModel Reminder { get; set; }
        public Exception RaisedException { get; set; }

        public SendingFailedEventArgs(SendReminderModel reminder, Exception exception)
        {
            Reminder = reminder;
            RaisedException = exception;
        }
    }
}
