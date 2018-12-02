using aitReminder.Wpf.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace aitReminder.Wpf.BusinessLogic
{
    class RemindersManager : IRemindersManager
    {
        private ObservableCollection<Reminder> _reminders = new ObservableCollection<Reminder>();
        private string _filePath = $"";

        private Task _remindersChecker;

        public event EventHandler RemindersChanged;
        public event EventHandler<ReminderEventArgs> ReminderActivated;

        public RemindersManager()
        {

            _remindersChecker = Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    foreach (var reminder in _reminders)
                    {
                        if (reminder.IsExpired && !reminder.Showned)
                        {
                            reminder.Showned = true;
                            OnReminderActivated(reminder);
                        }
                    }

                    Thread.Sleep(1000);
                }

            });

        }

        public virtual void OnReminderActivated(Reminder reminder)
        {
            ReminderActivated?.Invoke(this, new ReminderEventArgs(reminder));
        }

        public virtual void OnRemindersChanged()
        {
            RemindersChanged?.Invoke(this, new EventArgs());
        }

        public void NewReminders()
        {
            _reminders.Clear();
            _filePath = "";

            EventAggregator.Instance.Publish(new RemindersManagerIsChangedEventAggregator(false, RemidersFileIsSet));

            OnRemindersChanged();
        }

        public void LoadReminders(string filePath)
        {
            _filePath = filePath;
            if (File.Exists(_filePath))
            {
                _reminders.Clear();
                try
                {
                    var serializer = new XmlSerializer(typeof(ObservableCollection<Reminder>));
                    using (var s = File.OpenRead(_filePath))
                    {
                        _reminders = (ObservableCollection<Reminder>)serializer.Deserialize(s);
                    }
                }
                catch (Exception ex)
                {
                    //TODO: Exception when load reminders
                    throw new Exception($"Error on LoadReminders from file: '{filePath}'", ex);
                }


                OnRemindersChanged();
            }
            else
            {
                _reminders.Clear();

                AddReminder(new Reminder() { Name = "Zdarzenie 1a", Description = "Opis zdarzenie 1", StartDate = new DateTime(2019, 11, 9, 19, 30, 10, DateTimeKind.Local) });
                AddReminder(new Reminder() { Name = "Zdarzenie 2a", Description = "Opis zdarzenie 2", StartDate = new DateTime(2019, 11, 11, 10, 20, 10, DateTimeKind.Local), Repeated = true, RepeatInterval = new TimeSpan(0, 10, 0) });
                AddReminder(new Reminder() { Name = "Zdarzenie 3s", Description = "Opis zdarzenie 3", StartDate = new DateTime(2019, 11, 12, 10, 20, 10, DateTimeKind.Local) });
                AddReminder(new Reminder() { Name = "Zdarzenie 4s", Description = "Opis zdarzenie 4", StartDate = new DateTime(2019, 11, 13, 10, 20, 10, DateTimeKind.Local) });

            }
        }

        public void SaveReminders()
        {
            SaveAsReminder(_filePath);
        }
    

        public bool SaveAsReminder(string filePath)
        {
            if (!RemidersFileIsSet)
                return false;

            _filePath = filePath;

            try
            {
                var serializer = new XmlSerializer(typeof(ObservableCollection<Reminder>));
                using (var s = File.Create(_filePath))
                {
                    serializer.Serialize(s, _reminders);
                }
            }
            catch (Exception ex)
            {
                //TODO: Exception when save reminders
                throw new Exception($"Error on SaveAsReminder in file: '{filePath}'", ex);
            }

            return true;
        }

        public void AddReminder(Reminder reminder)
        {
            if(reminder is Reminder)
            {
                _reminders.Add(reminder);

                EventAggregator.Instance.Publish(new RemindersManagerIsChangedEventAggregator(true, RemidersFileIsSet));

                OnRemindersChanged();
            }
        }

        public void RemoveReminder(Reminder reminder)
        {
            if (reminder is Reminder)
            {
                _reminders.Remove(reminder);

                EventAggregator.Instance.Publish(new RemindersManagerIsChangedEventAggregator(true, RemidersFileIsSet));

                OnRemindersChanged();
            }
        }

        public IEnumerable<Reminder> Reminders { get => _reminders; }

        public bool RemidersFileIsSet { get => _filePath.Length > 0; }
    }
}
