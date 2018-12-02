using aitReminder.Wpf.BusinessLogic;

namespace aitReminder.Wpf.Views
{
    public interface IRemindersStatusBarView
    {
        void SetNumberOfReminders(IRemindersManager remindersManager);
    }
}