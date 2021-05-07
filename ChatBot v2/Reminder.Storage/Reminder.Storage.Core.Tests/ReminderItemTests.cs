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
				null,
				ReminderItemStatus.Awaiting);

			// checking the results

			Assert.AreNotEqual(Guid.Empty, testItem.Id);
		}

		[TestMethod]
		[DataRow(ReminderItemStatus.Awaiting)]
		[DataRow(ReminderItemStatus.Failed)]
		[DataRow(ReminderItemStatus.ReadyToSend)]
		[DataRow(ReminderItemStatus.SuccessfullySent)]
		public void Constructor_Initializes_Status_With_Status_From_Parameter(
			ReminderItemStatus status)
		{
			// preparing data
			// test run

			var item = new ReminderItem(
				DateTimeOffset.MinValue,
				null,
				null,
				status);

			// checking the results

			Assert.AreEqual(status, item.Status);
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

			var item = new ReminderItem(
				id,
				date,
				message,
				contactId,
				ReminderItemStatus.Awaiting);

			// checking the results

			Assert.AreEqual(id, item.Id);
			Assert.AreEqual(date, item.Date);
			Assert.AreEqual(message, item.Message);
			Assert.AreEqual(contactId, item.ContactId);
			Assert.AreEqual(ReminderItemStatus.Awaiting, item.Status);
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

			var item = new ReminderItem(date, null, null, ReminderItemStatus.Awaiting);

			// checking the results
			
			int actual = Math.Sign(item.TimeToAlarm.TotalDays);
			Assert.AreEqual(expected, actual);
		}
	}
}
