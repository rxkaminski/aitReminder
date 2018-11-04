using System.Collections.Generic;
using aitReminder.Wpf.Models;

namespace aitReminder.Wpf.BusinessLogic
{
    interface IRemindersManager
    {
        IEnumerable<Reminder> Reminders { get; }

        void AddReminder(Reminder reminder);
        void LoadReminders(string filePath);
        void RemoveReminder(Reminder reminder);
        void SaveAsReminder(string filePath);
        void SaveReminders();
    }
}