using System;

namespace Reminder
{
   public class ReminderItem
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

        public virtual void WriteProperties()
        {
            Console.WriteLine($"TypeMessage: {GetType().Name} \nAlarm Date: {AlarmDate} \nAlarm Message: {AlarmMessage} \nTime to Alarm: {TimeToAlarm} \nIs out Date {IsOutdated} \n");
        }
    }
}
