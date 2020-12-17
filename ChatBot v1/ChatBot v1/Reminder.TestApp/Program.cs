using System;
using Reminder.Domain;
using Reminder.Storage.Core;
using Reminder.Storage.InMemory;
using Reminder.Domain.Model;
using Reminder.Domain.EventArgs;

namespace Reminder.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var storage = new InMemoryReminderStorage();
           using var domain = new ReminderDomain(storage, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));

            domain.SendingSucceeded += Domain_SendingSucceeded;
            domain.SendingFailed += Domaint_SendingFailed;

            domain.SendReminder += model =>
            {
                throw new Exception();
            };

            var addReminderModel = new AddReminderModel(
                DateTimeOffset.Now.AddSeconds(1),
                "Hello World",
                "Dmitriy");

            domain.AddReminder(addReminderModel);
            domain.Run();

            Console.WriteLine("Domain logic running...(press any key to exit)");
            Console.ReadKey();
        }

        private static void Domaint_SendingFailed(object sender, SendingFailedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Sending failed");
            Console.ResetColor();

            Console.Write($"Contact {e.Reminder.ContactId}could not received message at {e.Reminder.Date:f}.\n Exception: {e.RaisedException}");
        }

        private static void Domain_SendingSucceeded(object sender, Domain.EventArgs.SendingSucceededEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Sending OK");
            Console.ResetColor();

            Console.Write($"Contact {e.Reminder.ContactId} received message at {e.Reminder.Date:f}");
        }
    }
}
