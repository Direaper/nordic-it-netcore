using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder
{
    class PhoneReminderItem : ReminderItem
    {
        public string PhoneNumber { get; set; }

        public PhoneReminderItem(DateTimeOffset alarmDate, string alarmMessage, string phoneNumber) : base(alarmDate, alarmMessage)
        {
            AlarmDate = alarmDate;
            AlarmMessage = alarmMessage;
            PhoneNumber = phoneNumber;
        }

        public override void WriteProperties()
        {
            Console.WriteLine($"TypeMessage: {GetType().Name} \nPhoneNumber: {PhoneNumber} \nAlarm Date: {AlarmDate} \nAlarm Message: {AlarmMessage} \nTime to Alarm: {TimeToAlarm} \nIs out Date {IsOutdated} \n");
        }
    }
}
