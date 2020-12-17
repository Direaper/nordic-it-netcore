using Reminder.Domain.Model;
using Reminder.Storage.Core;
using Reminder.Domain.EventArgs;
using System;
using System.Linq;
using System.Threading;
using System.Net.Http;

namespace Reminder.Domain
{
    public class ReminderDomain : IDisposable
    {
        private readonly IReminderStorage _storage;
        private readonly TimeSpan _awaitingRemindersCheckPeriod;
        private readonly TimeSpan _readyRemindersSendPeriod;

        private Timer _awaitingRemindersCheckTimer;
        private Timer _readyRemindersSendTimer;

        public event EventHandler<SendingSucceededEventArgs> SendingSucceeded;
        public event EventHandler<SendingFailedEventArgs> SendingFailed;

        public Action<SendReminderModel> SendReminder { get; set; }

        public ReminderDomain(IReminderStorage storage)
            : this(storage,
                  TimeSpan.FromMinutes(1),
                  TimeSpan.FromMinutes(1))
        { }
        public ReminderDomain(
            IReminderStorage storage,
            TimeSpan awaitingRemindersCheckingPeriod,
            TimeSpan readyRemindersSendPeriod)
        {
            _storage = storage;
            _awaitingRemindersCheckPeriod = awaitingRemindersCheckingPeriod;
            _readyRemindersSendPeriod = readyRemindersSendPeriod;
        }
        public void AddReminder(AddReminderModel addReminderModel)
        {
            _storage.Add(addReminderModel.ToRemiderItem());
        }

        public void Run()
        {
            _awaitingRemindersCheckTimer = new Timer(
                CheckAwaitingReminders,
                null,
                TimeSpan.Zero,
                _awaitingRemindersCheckPeriod);

            _readyRemindersSendTimer = new Timer(
             SendReadyReminders,
             null,
             TimeSpan.Zero,
             _readyRemindersSendPeriod);
        }

        private void CheckAwaitingReminders(object _)
        {
            var readyItems = _storage.GetList(
                new[] { ReminderItemStatus.Awaiting })
                .Where(i => i.IsTimeToSend);

            foreach (var readyItem in readyItems)
            {
                readyItem.Status = ReminderItemStatus.ReadyToSent;
                _storage.Update(readyItem);
            }
        }

        private void SendReadyReminders(object _)
        {
            var readyItems = _storage.GetList(
                new[] { ReminderItemStatus.ReadyToSent })
                .Where(i => i.IsTimeToSend);

            foreach (var readyItem in readyItems)
            {
                var sendingModel = new SendReminderModel(readyItem);

                try
                {
                    //попытка послать уведомление

                    SendReminder?.Invoke(sendingModel);

                    readyItem.Status = ReminderItemStatus.SuccessfullySent;

                    SendingSucceeded?.Invoke(this, new SendingSucceededEventArgs(sendingModel));

                    //if succesfull send message 

                }
                catch (Exception exception)
                {
                    readyItem.Status = ReminderItemStatus.Failed;

                    SendingFailed?.Invoke(this, new SendingFailedEventArgs(sendingModel, exception));
                }

                _storage.Update(readyItem);
            }
        }

        public void Dispose()
        {
            _awaitingRemindersCheckTimer?.Dispose();
            _readyRemindersSendTimer?.Dispose();

        }
    }
}
