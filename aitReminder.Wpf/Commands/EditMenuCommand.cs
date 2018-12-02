using aitReminder.Wpf.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aitReminder.Wpf.Commands
{
    class EditMenuCommand : MenuCommand
    {
        public EditMenuCommand() : this(null) { }

        public EditMenuCommand(IEnumerable<IMenuCommand> subCommands) : base(subCommands)
        {
            Header = "Edit";
        }

        public override void Execute()
        {
        }
    }
}
