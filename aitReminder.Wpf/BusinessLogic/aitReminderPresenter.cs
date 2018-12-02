using aitReminder.Wpf.BusinessLogic;
using aitReminder.Wpf.Commands;
using aitReminder.Wpf.Views;

namespace aitReminder.Wpf.BusinessLogic
{
    class AitReminderPresenter
    {
        public AitReminderPresenter(IMainWindow mainWindow)
        {
            IRemindersManager remindersManager = new RemindersManager();
            remindersManager.ReminderActivated += (o, e) =>
            {
                var remindersMenager = o as RemindersManager;

                if (remindersManager == null)
                    return;

                mainWindow.ReminderNotification(remindersMenager, e.Reminder);
            };

            remindersManager.RemindersChanged += (o, a) =>
            {
                mainWindow.RemindersStatusBarView.SetNumberOfReminders((IRemindersManager)o);
            };

            IRemindersListView remindersListView = mainWindow.RemindersListView;
            IRemindersStatusBarView remindersStatusBarView = mainWindow.RemindersStatusBarView;

            var menuCommands = new IMenuCommand[]
            {
                new FileMenuCommmand(
                    new IMenuCommand[]
                    {
                        new NewMenuCommand(mainWindow, remindersManager),
                        new OpenMenuCommand(mainWindow, remindersManager),
                        new SaveMenuCommand(remindersManager),
                        new SaveAsMenuCommand(mainWindow, remindersManager),
                        new CloseMenuCommand(mainWindow),
                    }),
                new EditMenuCommand(
                    new IMenuCommand[]
                    {
                        new AddNewReminderMenuCommand(mainWindow, remindersManager),
                        new EditReminderMenuCommand(mainWindow, remindersManager, remindersListView),
                        new RemoveReminderMenuCommand(remindersManager, remindersListView),
                    }),
                new HelpMenuCommand(
                    new IMenuCommand[]
                    {
                        new AboutMenuCommand(mainWindow)
                    })

            };

            mainWindow.MenuView.SetMenuCommands(menuCommands);

            mainWindow.RemindersListView.SetReminders(remindersManager.Reminders);
            mainWindow.RemindersListView.SelectionChanged += (a, e) =>
            {
                EventAggregator.Instance.Publish(new ReminderIsSelectedEventAggregator(e.Reminder == null ? false : true));
            };
        }
    }
}
