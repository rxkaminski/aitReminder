using aitReminder.Wpf.BusinessLogic;
using aitReminder.Wpf.Models;
using aitReminder.Wpf.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aitReminder.Wpf.Commands
{
    class AddNewReminderMenuCommand : MenuCommand
    {
        private readonly IMainWindow _mainWindow;
        private readonly IRemindersManager _remindersManager;
        
        public AddNewReminderMenuCommand(IMainWindow mainWindow, IRemindersManager remindersManager) : this(mainWindow, remindersManager, null) { }

        public AddNewReminderMenuCommand(IMainWindow mainWindow, IRemindersManager remindersManager, IEnumerable<IMenuCommand> subCommands) : base(subCommands)
        {
            _mainWindow = mainWindow;
            _remindersManager = remindersManager;
            Header = "Add";
        }

        public override void Execute()
        {
            _mainWindow.MakeNewReminder(_remindersManager);
       }
    }
}

