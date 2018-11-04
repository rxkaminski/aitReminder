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
        private readonly IRemindersManager _remindersManager;
        
        public AddNewReminderMenuCommand(IRemindersManager remindersManager) : this(remindersManager, null) { }

        public AddNewReminderMenuCommand(IRemindersManager remindersManager, IEnumerable<IMenuCommand> subCommands) : base(subCommands)
        {
            _remindersManager = remindersManager;
            Header = "Add";
        }

        public override void Execute()
        {
            var reminder = new Reminder()
            {
                Name = "Nowy",
                Description = "Opis dla nowego",
                StartDate = DateTime.Now
            };

            _remindersManager.AddReminder(reminder);
        }
    }
}

