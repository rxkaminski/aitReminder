using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aitReminder.Wpf.Commands
{
    class SaveMenuCommand : MenuCommand
    {
        public SaveMenuCommand() : this(null) { }

        public SaveMenuCommand(IEnumerable<IMenuCommand> subCommands) : base(subCommands)
        {
            Header = "Save";
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
