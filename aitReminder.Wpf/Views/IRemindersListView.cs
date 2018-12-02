using System;
using System.Collections.Generic;
using aitReminder.Wpf.BusinessLogic;
using aitReminder.Wpf.Models;

namespace aitReminder.Wpf.Views
{
    public interface IRemindersListView
    {
        void SetReminders(IEnumerable<Reminder> reminders);
        Reminder Selected();

        event EventHandler<ReminderEventArgs> SelectionChanged;
        void OnSelectionChanged(Reminder reminder);
    }
}