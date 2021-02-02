using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Storage.Core;
using System;

namespace Reminder.Storage.InMemory.Tests
{
    [TestClass]
    public class InMemoryReminderStorageTests
    {
        [TestMethod]
        public void In_Memory_Reminder_Add_Get_Method()   //Добавляем запись и получаем из dictionary
        {
            //preparing data
            InMemoryReminderStorage inmemory = new InMemoryReminderStorage();

            ReminderItem item1 = new ReminderItem(DateTimeOffset.Now, "Hello World", "testContact007");
            ReminderItem item2 = new ReminderItem(DateTimeOffset.Parse("2020-01-01 12:00"), "Hello World", "testContact007");

            //test run
            //вводим данные в Dictionary
            inmemory.Add(item1);
            inmemory.Add(item2);

            //получаем данные из Dictionary по ID
            ReminderItem getMemory = inmemory.Get(item1.Id);
            ReminderItem getMemory2 = inmemory.Get(item2.Id);

            //checking the results

            //Сравниваем заданные параметры item1 с параметрами в хранилище dictionary 
            //логика: item1 заносит данные в хранилище, потом через get мы извлекаем их в переменнную типа ReminderItem и сравниваем, 
            //не изменились ли параметры на этапе внесения данных через объект класса InMemoryRimendirStorage

            Assert.AreEqual(item1.Id, getMemory.Id);
            Assert.AreEqual(item1.Chat, getMemory.Chat);
            Assert.AreEqual(item1.ContactId, getMemory.ContactId);
            Assert.AreEqual(item1.Date, getMemory.Date);
            Assert.AreEqual(item1.Message, getMemory.Message);
            //Assert.AreEqual(item1.TimeToAlarm, getMemory.TimeToAlarm); Нужно ли это тестировать? параметр изменяемый
            Assert.AreEqual(item1.IsTimeToSend, getMemory.IsTimeToSend);
            Assert.AreEqual(item1.Status, getMemory.Status);

            //Сравниваем заданные параметры item2 с параметрами в dictionary
            Assert.AreEqual(item2.Id, getMemory2.Id);
            Assert.AreEqual(item2.Chat, getMemory2.Chat);
            Assert.AreEqual(item2.ContactId, getMemory2.ContactId);
            Assert.AreEqual(item2.Date, getMemory2.Date);
            Assert.AreEqual(item2.Message, getMemory2.Message);
            //Assert.AreEqual(item2.TimeToAlarm, getMemory2.TimeToAlarm); Нужно ли это тестировать? параметр изменяемый
            Assert.AreEqual(item2.IsTimeToSend, getMemory2.IsTimeToSend);
            Assert.AreEqual(item2.Status, getMemory2.Status);

            //ID item1 и item2 не равны?
            Assert.AreNotEqual(getMemory.Id, getMemory2.Id);
        }

        [TestMethod]
        public void In_Memory_Reminder_Add_Get_Update_Get_Method()
        {
            //preparing data
            ReminderItem getInMemory;

            string getContactId;
            string getMessage;
            ReminderItemStatus getStatus;
            DateTimeOffset getDate;

            InMemoryReminderStorage inmemory = new InMemoryReminderStorage();

            ReminderItem item1 = new ReminderItem(DateTimeOffset.Now, "world hello", "testContact001");
            ReminderItem item2 = new ReminderItem(DateTimeOffset.Parse("2020-01-01 12:00"), "Hello World111", "002contacttest");

            //test run
            //вводим данные в Dictionary
            inmemory.Add(item1);
            inmemory.Add(item2);

            //получаем данные в getmemory из в Dictionary
            getInMemory = inmemory.Get(item1.Id);
            getContactId = getInMemory.ContactId;
            getMessage = getInMemory.Message;
            getStatus = getInMemory.Status;
            getDate = getInMemory.Date;

            //first checking the results.  
            Assert.AreEqual(item1.Id, getInMemory.Id);
            Assert.AreEqual(getContactId, item1.ContactId);
            Assert.AreEqual(getMessage, item1.Message);
            Assert.AreEqual(getStatus, item1.Status);
            Assert.AreEqual(getDate, item1.Date);

            //Update params
            item1.ContactId = item2.ContactId;
            item1.Message = item2.Message;
            item1.Date = item2.Date;

            //положили в dictionary
            inmemory.Update(item1); 

            //get params (извлекаем из dictionary)
            getInMemory = inmemory.Get(item1.Id);

            //final cheking. Проверяем есть ли изменения данных item1 в dictionary
            Assert.AreEqual(item1.Id, getInMemory.Id);                            //ID обязательно должен быть одним и тем же, по скольку мы меняем все в одном событии
            Assert.AreNotEqual(getContactId, item1.ContactId);                    //Contact, Message, date изменяемые параметры, не должны быть равны
            Assert.AreNotEqual(getMessage, item1.Message);
            Assert.AreEqual(getStatus, item1.Status);                            //статусы должны быть равны. Хотя это не обязательный параметр, решил оставить
            Assert.AreNotEqual(getDate, item1.Date);

        }

    }
}
