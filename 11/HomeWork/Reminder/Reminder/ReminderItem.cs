using System;

namespace Reminder
{
    class ReminderItem
    {
        public DateTimeOffset AlarmDate { get; set; }
        public string AlarmMessage { get; set; }
        public TimeSpan TimeToAlarm
        {
            get { return DateTimeOffset.Now - AlarmDate; }
        }

        public bool IsOutdated
        {
            get { return DateTime.Now > AlarmDate; }
        }
        public ReminderItem(DateTimeOffset alarmDate, string alarmMessage)
        {
            AlarmDate = alarmDate;
            AlarmMessage = alarmMessage;
        }

        public void WriteProperties()
        {
            Console.WriteLine($"Alarm Date: {AlarmDate} \nAlarm Message: {AlarmMessage} \nTime to Alarm: {TimeToAlarm} \nIs out Date {IsOutdated} \n");
        }
    }
}
