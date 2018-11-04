using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aitReminder.Wpf.Commands
{
    class EditReminderMenuCommand : MenuCommand
    {
        public EditReminderMenuCommand() : this(null) { }

        public EditReminderMenuCommand(IEnumerable<IMenuCommand> subCommands) : base(subCommands)
        {
            Header = "Edit";
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
