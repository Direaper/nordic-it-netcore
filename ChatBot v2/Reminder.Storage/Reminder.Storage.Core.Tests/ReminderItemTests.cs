using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Reminder.Storage.Core.Tests
{
	[TestClass]
	public class ReminderItemTests
	{
		private ReminderItem testItem;

		[TestInitialize]
		public void TestInitialize()
		{
			// 
		}

		[TestMethod]
		public void Constructor_Initializes_Id_With_Not_Empty_Guid()
		{
			// preparing data
			// test run
			
			testItem = new ReminderItem(
				DateTimeOffset.MinValue,
				null,
				null);

			// checking the results

			Assert.AreNotEqual(Guid.Empty, testItem.Id);
		}

		[TestMethod]
		public void Constructor_Initializes_Status_With_Awaiting()
		{
			// preparing data
			// test run

			var item = new ReminderItem(
				DateTimeOffset.MinValue,
				null,
				null);

			// checking the results

			Assert.AreEqual(ReminderItemStatus.Awaiting, item.Status);
		}

		[TestMethod]
		public void Constructor_Initializes_Explicit_Parameters()
		{
			// preparing data
			Guid id = Guid.NewGuid();
			DateTimeOffset date = DateTimeOffset.Parse("2020-01-01 12:00");
			const string message = "msg";
			const string contactId = "id";

			// test run

			var item = new ReminderItem(id, date,message,contactId);

			// checking the results

			Assert.AreEqual(id, item.Id);
			Assert.AreEqual(date, item.Date);
			Assert.AreEqual(message, item.Message);
			Assert.AreEqual(contactId, item.ContactId);
		}

		[DataTestMethod]
		[DataRow("1000-01-01 00:00")]
		[DataRow("3000-01-01 00:00")]
		public void TimeToAlarm_Positive_For_Future_Event_And_Vise_Versa(
			string stringDate)
		{
			// preparing data
			DateTimeOffset date = DateTimeOffset.Parse(stringDate);
			int expected = Math.Sign(date.Subtract(DateTimeOffset.Now).TotalDays);

			// test run

			var item = new ReminderItem(date, null, null);

			// checking the results
			
			int actual = Math.Sign(item.TimeToAlarm.TotalDays);
			Assert.AreEqual(expected, actual);
		}
	}
}
