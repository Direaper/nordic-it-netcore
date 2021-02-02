using System;
using Reminder.Domain;
using Reminder.Domain.EventArgs;
using Reminder.Receiver.Telegram;
using Reminder.Sender.Telegram;
using Reminder.Storage.InMemory;

namespace Reminder.TestApp
{    
    class Program
    {
        static void Main(string[] args)
        {
            //var botClient = new TelegramBotClient("943556973:AAF8Kfc3bUu4nYah6d9t5S1QFHNBIjF6VNY");
            //var me = botClient.GetMeAsync().Result;
            //Console.WriteLine(
            //    $"Hello {me.Id},  my name is {me.FirstName}");

            //return;
            const string token = " ";

            var storage = new InMemoryReminderStorage();
            var sender = new TelegramReminderSender(token);
            var receiver = new TelegramReminderReceiver(token);
                    
           using var domain = new ReminderDomain(
               storage,
               receiver,
               sender,
               TimeSpan.FromSeconds(1),
               TimeSpan.FromSeconds(1));

            domain.SendingSucceeded += Domain_SendingSucceeded;
            domain.SendingFailed += DomainOnSendingFailed;
            domain.ParsingFailed += Domain_ParsingFailed;
            domain.AddingSucceeded += Domain_AddingSucceeded;
            domain.AddingFailed += Domain_AddingFailed;

            //var addReminderModel = new AddReminderModel(
            //    DateTimeOffset.Now.AddSeconds(1),
            //    "Hello World",
            //    "943556973");

            //domain.AddReminder(   addReminderModel);
            domain.Run();

            Console.WriteLine("Domain logic running...(press any key to exit)");
            Console.ReadKey();
        }

		private static void Domain_AddingFailed(object sender, AddingFailedEventArgs e)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("Adding Failed ");
			Console.ResetColor();

			Console.WriteLine(
				$"Bot couldn't save new reminder from {e.Reminder.ContactId} " +
				$"message '{e.Reminder.Message}' " +
				$"at {e.Reminder.Date:f}.\n" +
				$"Exception: {e.Exception}");
		}

		private static void Domain_AddingSucceeded(object sender, AddingSucceededEventArgs e)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("Adding OK ");
			Console.ResetColor();

			Console.WriteLine(
				$"New reminder from {e.Reminder.ContactId} received: " +
				$"message '{e.Reminder.Message}' " +
				$"at {e.Reminder.Date:f}");
		}

		private static void Domain_ParsingFailed(object sender, ParsingFailedEventArgs e)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("Parsing Failed ");
			Console.ResetColor();

			Console.WriteLine(
				$"Bot could not parse message from {e.ContactId} '{e.InputText}'");
		}

		private static void DomainOnSendingFailed(object sender, SendingFailedEventArgs e)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("Sending Failed ");
			Console.ResetColor();

			Console.WriteLine(
				$"Contact {e.Reminder.ContactId} could not receive " +
				$"message '{e.Reminder.Message}' " +
				$"at {e.Reminder.Date:f}.\n" +
				$"Exception: {e.Exception}");
		}

		private static void Domain_SendingSucceeded(object sender, Domain.EventArgs.SendingSucceededEventArgs e)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("Sending OK ");
			Console.ResetColor();

			Console.WriteLine(
				$"Contact {e.Reminder.ContactId} received " +
				$"message '{e.Reminder.Message}' " +
				$"at {e.Reminder.Date:f}");
		}
	}
}
 
