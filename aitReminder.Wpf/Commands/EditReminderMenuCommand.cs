using aitReminder.Wpf.BusinessLogic;
using aitReminder.Wpf.Views;
using System.Collections.Generic;

namespace aitReminder.Wpf.Commands
{
    class EditReminderMenuCommand : MenuCommand
    {
        private readonly IMainWindow _mainWindow;
        private readonly IRemindersManager _remindersManager;
        private readonly IRemindersListView _reminderListView;

        public EditReminderMenuCommand(IMainWindow mainWindow, 
                                        IRemindersManager remindersManager, 
                                        IRemindersListView reminderListView) : 
            this(mainWindow, remindersManager, reminderListView, null) { }

        public EditReminderMenuCommand(IMainWindow mainWindow, 
            IRemindersManager remindersManager, 
            IRemindersListView reminderListView, 
            IEnumerable<IMenuCommand> subCommands) : 
            base(subCommands)
        {
            _mainWindow = mainWindow;
            _remindersManager = remindersManager;
            _reminderListView = reminderListView;
            Header = "Edit";

            IsEnabled = false;

            EventAggregator.Instance.Subscribe<ReminderIsSelectedEventAggregator>(r => IsEnabled = r.IsSelected);

        }

        public override void Execute()
        {
            var reminder = _reminderListView.Selected();
            if(reminder != null)
            {
                _mainWindow.EditReminder(_remindersManager, reminder);

                EventAggregator.Instance.Publish(new RemindersManagerIsChangedEventAggregator(true, _remindersManager.RemidersFileIsSet));
            }
        }
    }
}
