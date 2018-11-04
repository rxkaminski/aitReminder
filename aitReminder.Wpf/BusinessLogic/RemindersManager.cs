using aitReminder.Wpf.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aitReminder.Wpf.BusinessLogic
{
    class RemindersManager : IRemindersManager
    {
        private ObservableCollection<Reminder> _reminders = new ObservableCollection<Reminder>();
        private string _filePath = "";

        public void LoadReminders(string filePath)
        {
            _filePath = filePath;

            _reminders = new ObservableCollection<Reminder>()
            {
                new Reminder() { Name ="Zdarzenie 1", Description = "Opis zdarzenie 1", StartDate = new DateTime(2018,11,10, 10,20,10, DateTimeKind.Local) },
                new Reminder() { Name ="Zdarzenie 2", Description = "Opis zdarzenie 2", StartDate = new DateTime(2018,11,11, 10,20,10, DateTimeKind.Local) },
                new Reminder() { Name ="Zdarzenie 3", Description = "Opis zdarzenie 3", StartDate = new DateTime(2018,11,12, 10,20,10, DateTimeKind.Local) },
                new Reminder() { Name ="Zdarzenie 4", Description = "Opis zdarzenie 4", StartDate = new DateTime(2018,11,13, 10,20,10, DateTimeKind.Local) },
            };

        }

        public void SaveReminders()
        {
            throw new NotImplementedException();
        }

        public void SaveAsReminder(string filePath)
        {
            throw new NotImplementedException();
        }

        public void AddReminder(Reminder reminder)
        {
            _reminders.Add(reminder);
        }

        public void RemoveReminder(Reminder reminder)
        {
            _reminders.Remove(reminder);
        }

        public IEnumerable<Reminder> Reminders { get => _reminders; }
    }
}
