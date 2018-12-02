using aitReminder.Wpf.BusinessLogic;
using aitReminder.Wpf.Views;
using System.Collections.Generic;

namespace aitReminder.Wpf.Commands
{
    class RemoveReminderMenuCommand : MenuCommand
    {
        private readonly IRemindersManager _remindersManager;
        private readonly IRemindersListView _remindersListView;

        public RemoveReminderMenuCommand(IRemindersManager remindersManager, IRemindersListView remindersListView) : this(remindersManager, remindersListView, null) { }

        public RemoveReminderMenuCommand(IRemindersManager remindersManager, IRemindersListView remindersListView, IEnumerable<IMenuCommand> subCommands) : base(subCommands)
        {
            _remindersManager = remindersManager;
            _remindersListView = remindersListView;
            Header = "Remove";

            IsEnabled = false;

            EventAggregator.Instance.Subscribe<ReminderIsSelectedEventAggregator>(r => IsEnabled = r.IsSelected);

        }

        public override void Execute()
        {
            var reminder = _remindersListView.Selected();
            _remindersManager.RemoveReminder(reminder);
        }
    }
}

