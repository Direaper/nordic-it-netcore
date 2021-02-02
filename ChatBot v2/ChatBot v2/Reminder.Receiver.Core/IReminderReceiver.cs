using System;
using Reminder.Receiver;

namespace Reminder.Receiver.Core
{
    public interface IReminderReceiver
    {
        event EventHandler<MessageReceivedEventArgs> MessageReceived;
        void StartReceiving();

    }
}
