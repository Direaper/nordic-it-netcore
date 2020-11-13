using System;
using System.Threading.Tasks.Dataflow;

namespace Reminder
{

    class Program
    {
        static void Main(string[] args)
        {
            DateTimeOffset datetime = DateTimeOffset.Parse("2020-11-07 13:41");
            ReminderItem bud1 = new ReminderItem(datetime, "ALARM");
            bud1.WriteProperties();

            DateTimeOffset datetime2 = DateTimeOffset.Parse("2020-11-07 19:32");
            ReminderItem bud2 = new ReminderItem(datetime2, "ALARM");
            bud2.WriteProperties();
        }
    }
}
