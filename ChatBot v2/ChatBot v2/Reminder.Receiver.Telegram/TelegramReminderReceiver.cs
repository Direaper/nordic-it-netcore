using Reminder.Receiver.Core;
using System;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace Reminder.Receiver.Telegram
{
    public class TelegramReminderReceiver : IReminderReceiver
    {
        private readonly TelegramBotClient _botClient;

        public TelegramReminderReceiver(string token)
        {
            _botClient = new TelegramBotClient(token);

        }

        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        public void StartReceiving()
        {
            _botClient.OnMessage += (sender, sourceArgs) =>
            {
                if (sourceArgs.Message.Type != MessageType.Text) //если юзер отправил не текст, то такое сообщение будет игнорироваться
                    return;

                var ourArgs = new MessageReceivedEventArgs(
                    sourceArgs.Message.Chat.Id.ToString(),
                    sourceArgs.Message.Text);

                OnMessageReceived(this, ourArgs);
                
            };

            _botClient.StartReceiving();
        }

        protected virtual void OnMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            MessageReceived?.Invoke(sender, e);
        }
    }
}
