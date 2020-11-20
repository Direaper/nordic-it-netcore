using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder
{
    public class ChatReminderItem : ReminderItem
    {
        public string ChatName { get; set; }
        public string AccountName { get; set; }

       public ChatReminderItem(DateTimeOffset alarmDate, string alarmMessage, string chatName, string accountName) : base(alarmDate, alarmMessage)
        {
            AlarmDate = alarmDate;
            AlarmMessage = alarmMessage;
            ChatName = chatName;
            AccountName = accountName;
        }

        public override void WriteProperties()
        {
            Console.WriteLine($"TypeMessage: {GetType().Name} \nAlarm Date: {AlarmDate} \nChatName: {ChatName} \nAccountName: {AccountName} \nAlarm Message: {AlarmMessage} \nTime to Alarm: {TimeToAlarm} \nIs out Date {IsOutdated} \n");
        }

    }
}
