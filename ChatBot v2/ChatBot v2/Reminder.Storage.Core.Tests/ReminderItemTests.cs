using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Reminder.Storage.Core.Tests
{
    [TestClass]
    public class ReminderItemTests
    {

        [TestMethod]
        public void Constructor_Initializes_Id_With_Not_Empty_Guid()
        {
            //preparing data
            //test run
            ReminderItem item = new ReminderItem(
                DateTimeOffset.MinValue,
                null,
                null);

            //checking the results
            Assert.AreNotEqual(Guid.Empty, item.Id);
        }

        [TestMethod]
        public void Constructor_Initializes_Status_With_Not_Empty_Awaiting()
        {
            //preparing data


            //test run
            ReminderItem item = new ReminderItem(
                DateTimeOffset.MinValue,
                null,
                null);

            //checking the results
            Assert.AreEqual(ReminderItemStatus.Awaiting, item.Status);
        }

        [TestMethod]
        public void Constructor_Initializes_Explicit_Parameters()
        {
            //preparing data
            Guid id = Guid.NewGuid();
            DateTimeOffset date = DateTimeOffset.Parse("2020-01-01 12:00");
            const string message = "msg";
            const string contactId = "id";
            //test run
            ReminderItem item = new ReminderItem(id, date, message, contactId);

            //checking the results
            Assert.AreEqual(id, item.Id);
            Assert.AreEqual(date, item.Date);
            Assert.AreEqual(message, item.Message);
            Assert.AreEqual(contactId, item.ContactId);
        }


        [DataTestMethod]
        [DataRow("1000-01-01 00:00")]
        [DataRow("3000-01-01 00:00")]
        public void TimeToAlarm_Positive_Futurer_Event_and_vise_Versa(
            string stringDate)
        {

            //preparing data
            Guid id = Guid.NewGuid();
            DateTimeOffset date = DateTimeOffset.Parse(stringDate);
            int expected = Math.Sign(date.Subtract(DateTimeOffset.Now).TotalDays);

            //test run
            var item = new ReminderItem(date, null, null);

            //checking the results
            
            int actual = Math.Sign(item.TimeToAlarm.TotalDays);

            Assert.AreEqual(expected, actual);
 
        }

    }
}
