using System;
using System.Collections.Generic;
using System.Linq;
using Reminder.Storage.Core;

namespace Reminder.Storage.InMemory
{
	public class InMemoryReminderStorage : IReminderStorage
	{
		private readonly Dictionary<Guid, ReminderItem> _dictionary =
			new Dictionary<Guid, ReminderItem>();

		public void Add(ReminderItem reminderItem)
		{
			_dictionary.Add(reminderItem.Id, reminderItem);
		}

		public void Update(ReminderItem reminderItem)
		{
			var item = Get(reminderItem.Id);
			if (item == null)
				throw new KeyNotFoundException();

			item.Date = reminderItem.Date;
			item.Message = reminderItem.Message;
			item.ContactId = reminderItem.ContactId;
			item.Status = reminderItem.Status;
		}

		public ReminderItem Get(Guid id)
		{
			return _dictionary.ContainsKey(id)
				? _dictionary[id]
				: null;
		}

		public List<ReminderItem> GetList(
			IEnumerable<ReminderItemStatus> statuses,
			int count = -1,
			int startPosition = 0)
		{
			var result = _dictionary
				.Values
				.Where(x => statuses.Contains(x.Status))
				.Skip(startPosition);

			if (count > 0)
			{
				result = result.Take(count);
			}

			return result.ToList();
		}
	}
}
