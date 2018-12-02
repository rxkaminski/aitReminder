using aitReminder.Wpf.Models;
using System;

namespace aitReminder.Wpf.BusinessLogic
{
    public class ReminderEventArgs : EventArgs
    {
        public Reminder Reminder { get; private set; }

        public ReminderEventArgs(Reminder reminder)
        {
            Reminder = reminder;
        }
    }
}
