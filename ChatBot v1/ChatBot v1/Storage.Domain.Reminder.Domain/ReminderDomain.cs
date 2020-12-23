using Reminder.Domain.Model;
using Reminder.Storage.Core;
using Reminder.Domain.EventArgs;
using System;
using System.Linq;
using System.Threading;
using System.Net.Http;
using Reminder.Sender.Core;
using Reminder.Receiver.Core;
using Reminder.Parsing;

namespace Reminder.Domain
{
    public class ReminderDomain : IDisposable
    {
        private readonly IReminderStorage _storage;
        private readonly IReminderSender _sender;
        private readonly IReminderReceiver _receiver;

        private readonly TimeSpan _awaitingRemindersCheckPeriod;
        private readonly TimeSpan _readyRemindersSendPeriod;


        private Timer _awaitingRemindersCheckTimer;
        private Timer _readyRemindersSendTimer;

        public event EventHandler<SendingSucceededEventArgs> SendingSucceeded;
        public event EventHandler<SendingFailedEventArgs> SendingFailed;

        public event EventHandler<ParsingFailedEventArgs> ParsingFailed;

        public event EventHandler<AddingSucceededEventArgs> AddingSucceeded;
        public event EventHandler<AddingFailedEventArgs> AddingFailed;

        public ReminderDomain(
            IReminderStorage storage,
            IReminderReceiver receiver,
            IReminderSender sender)
            : this(
                  storage,
                  receiver,
                  sender,
                  TimeSpan.FromMinutes(1),
                  TimeSpan.FromMinutes(1))
        { }
        public ReminderDomain(
            IReminderStorage storage,
            IReminderReceiver receiver,
            IReminderSender sender,
            TimeSpan awaitingRemindersCheckingPeriod,
            TimeSpan readyRemindersSendPeriod)
        {
            _storage = storage;
            _receiver = receiver;
            _sender = sender;
            _awaitingRemindersCheckPeriod = awaitingRemindersCheckingPeriod;
            _readyRemindersSendPeriod = readyRemindersSendPeriod;
        }
        //public void AddReminder(AddReminderModel addReminderModel)
        //{
        //    _storage.Add(addReminderModel.ToRemiderItem());
        //}



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

            _receiver.MessageReceived += ReceiverOnMessageReceived;

            _receiver.StartReceiving();
        }

        private void ReceiverOnMessageReceived(
             object sender, MessageReceivedEventArgs e)
        {
            var o = MessageParser.Parse(e.Message);
            if (o == null)
            {
                ParsingFailed?.Invoke(
                    this,
                    new ParsingFailedEventArgs(e.ContactId, e.Message));
                return;
            }

            var item = new ReminderItem(o.Date, o.Message, e.ContactId);

            try
            {
                _storage.Add(item);

                AddingSucceeded?.Invoke(
                    this,
                    new AddingSucceededEventArgs(new AddReminderModel(item)));
            }
            catch (Exception exception)
            {
                AddingFailed?.Invoke(
                    this,
                    new AddingFailedEventArgs(new AddReminderModel(item), exception));  
            }
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

                    //SendReminder?.Invoke(sendingModel);
                    _sender.Send(
                        sendingModel.ContactId,
                        sendingModel.Message);

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
