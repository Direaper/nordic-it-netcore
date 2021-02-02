using System;
using System.Collections.Generic;


namespace Reminder.Storage.Core
{
    public interface IReminderStorage
    {
        //ADD 
        void Add(ReminderItem reminderItem);


        //UPDATE 
        void Update(ReminderItem reminderItem);

        //get
        ReminderItem Get(Guid id);

        //GetLiS
        List<ReminderItem> GetList(
            IEnumerable<ReminderItemStatus> statuses,
            int count = -1,
            int startPosition = 0);

    }
}
