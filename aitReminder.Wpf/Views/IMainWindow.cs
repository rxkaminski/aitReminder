using aitReminder.Wpf.Commands;
using aitReminder.Wpf.BusinessLogic;
using aitReminder.Wpf.Views;
using aitReminder.Wpf.Models;


namespace aitReminder.Wpf
{
    public interface IMainWindow
    {
        IMenuView MenuView { get; }
        IRemindersListView RemindersListView { get; }
        IRemindersStatusBarView RemindersStatusBarView { get; }

        void ReminderNotification(IRemindersManager remindersManager, Reminder reminder);
        void MakeNewReminder(IRemindersManager remindersManager);
        void EditReminder(IRemindersManager remindersManager, Reminder reminder);
        void About();
        string ShowOpenDialogGetFilePath(IOpenDialogProperty openDialogProperty);
        string ShowSaveAsDialogGetFilePath(ISaveAsDialogProperty saveAsDialogProperty);

        void CloseApplication();
    }
}
