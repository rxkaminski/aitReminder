using System;
using System.Collections.Generic;
using aitReminder.Wpf.Models;

namespace aitReminder.Wpf.BusinessLogic
{
    public interface IRemindersManager
    {
        IEnumerable<Reminder> Reminders { get; }
        bool RemidersFileIsSet { get; }

        void AddReminder(Reminder reminder);
        void NewReminders();
        void LoadReminders(string filePath);
        void RemoveReminder(Reminder reminder);
        bool SaveAsReminder(string filePath);
        void SaveReminders();
        

        event EventHandler RemindersChanged;
        event EventHandler<ReminderEventArgs> ReminderActivated;
    }
}