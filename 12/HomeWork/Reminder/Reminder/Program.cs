using System;
using System.Threading.Tasks.Dataflow;
using System.Collections.Generic;

namespace Reminder
{

    class Program
    {
        static void Main(string[] args)
        {
            DateTimeOffset datetime = DateTimeOffset.Parse("2020-11-07 13:41");

            DateTimeOffset datetime2 = DateTimeOffset.Parse("2020-11-07 19:32");

            DateTimeOffset datetime3 = DateTimeOffset.Parse("2020-11-20 12:00");

            List<ReminderItem> reminders = new List<ReminderItem>(3);
            reminders.Add(new PhoneReminderItem(datetime, "Time to wake up with PHONE", "89292934842"));
            reminders.Add(new ChatReminderItem(datetime2, "Time to wake up with CHAT", "Чат с Василием", "Сергей"));
            reminders.Add(new ReminderItem(datetime3, "ALARM"));

            foreach (ReminderItem p in reminders)
            {
                p.WriteProperties();
            }
        }
    }
}
