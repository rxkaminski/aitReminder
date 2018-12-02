using aitReminder.Wpf.BusinessLogic;
using System.Collections.Generic;

namespace aitReminder.Wpf.Commands
{
    class SaveMenuCommand : MenuCommand
    {
        private readonly IRemindersManager _remindersManager;

        public SaveMenuCommand(IRemindersManager remindersManager) : this(remindersManager, null) { }

        public SaveMenuCommand(IRemindersManager remindersManager, IEnumerable<IMenuCommand> subCommands) : base(subCommands)
        {
            _remindersManager = remindersManager;

            Header = "Save";

            IsEnabled = false;

            EventAggregator.Instance.Subscribe<RemindersManagerIsChangedEventAggregator>(e => { IsEnabled = e.IsChanged && e.RemindersFileIsSet; });
        }

        public override void Execute()
        {
            _remindersManager.SaveReminders();

            EventAggregator.Instance.Publish(new RemindersManagerIsChangedEventAggregator(false, _remindersManager.RemidersFileIsSet));
        }
    }
}
