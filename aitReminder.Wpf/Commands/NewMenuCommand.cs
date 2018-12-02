using aitReminder.Wpf.BusinessLogic;
using aitReminder.Wpf.Views;
using System.Collections.Generic;

namespace aitReminder.Wpf.Commands
{
    class NewMenuCommand : MenuCommand
    {
        private readonly IMainWindow _mainWindow;
        private readonly IRemindersManager _remindersManager;

        public NewMenuCommand(IMainWindow mainWindow,
                                IRemindersManager remindersManager)
                            : this(mainWindow,
                                     remindersManager,
                                     null)
        { }

        public NewMenuCommand(IMainWindow mainWindow,
                                IRemindersManager remindersManager,
                                IEnumerable<IMenuCommand> subCommands) : base(subCommands)
        {
            _mainWindow = mainWindow;
            _remindersManager = remindersManager;

            Header = "New";
            ShortcutKey = System.Windows.Input.Key.N;
        }

        public override void Execute()
        {
            _remindersManager.NewReminders();
        }
    }
}
