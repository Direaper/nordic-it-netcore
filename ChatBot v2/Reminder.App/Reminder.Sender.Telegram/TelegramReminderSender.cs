using Telegram.Bot;
using Reminder.Sender.Core;
using Telegram.Bot.Types;

namespace Reminder.Sender.Telegram
{
	public class TelegramReminderSender : IReminderSender
	{
		private readonly TelegramBotClient _botClient;

		public TelegramReminderSender(string token)
		{
			_botClient = new TelegramBotClient(token);
		}

		public void Send(string contactId, string message)
		{
			_botClient.SendTextMessageAsync(new ChatId(long.Parse(contactId)), message);
		}
	}
}
