using System;
using Reminder.Storage.Core;
using Reminder.Storage.InMemory;

namespace Reminder.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var storage = new InMemoryReminderStorage();
            var item = new ReminderItem(
                DateTimeOffset.Now,
                "Hello World",
                "testContact007");

            storage.Add(item);
            var ItemFromStorage = storage.Get(item.Id);
            Console.WriteLine(ItemFromStorage.Message);
        }
    }
}
