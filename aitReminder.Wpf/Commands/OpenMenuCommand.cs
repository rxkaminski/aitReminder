using aitReminder.Wpf.BusinessLogic;
using aitReminder.Wpf.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aitReminder.Wpf.Commands
{
    class OpenMenuCommand : MenuCommand
    {
        private readonly IRemindersManager _remindersManager;
        private readonly IRemindersListView _remindersListView;

        public OpenMenuCommand(IRemindersManager remindersManager,
                                IRemindersListView remindersListView)
                            : this(remindersManager,
                                     remindersListView,
                                     null)
        { }

        public OpenMenuCommand(IRemindersManager remindersManager,
                                IRemindersListView remindersListView,
                                IEnumerable<IMenuCommand> subCommands) : base(subCommands)
        {
            _remindersManager = remindersManager;
            _remindersListView = remindersListView;

            Header = "Open";
            ShortcutKey = System.Windows.Input.Key.O;
        }

        public override void Execute()
        {
            _remindersManager.LoadReminders("ToDo");
            _remindersListView.SetReminders(_remindersManager.Reminders);
        }
    }
}
