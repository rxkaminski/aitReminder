using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aitReminder.Wpf.Commands
{
    class CloseMenuCommand : MenuCommand
    {
        public CloseMenuCommand() : this(null) { }

        public CloseMenuCommand(IEnumerable<IMenuCommand> subCommands) : base(subCommands)
        {
            Header = "Close";
        }
        
        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
