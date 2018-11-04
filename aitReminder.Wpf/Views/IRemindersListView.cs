using System.Collections.Generic;
using aitReminder.Wpf.Models;

namespace aitReminder.Wpf.Views
{
    public interface IRemindersListView
    {
        void SetReminders(IEnumerable<Reminder> reminders);
    }
}