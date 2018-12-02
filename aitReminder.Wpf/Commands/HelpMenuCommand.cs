using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aitReminder.Wpf.Commands
{
    class HelpMenuCommand : MenuCommand
    {
        public HelpMenuCommand() : this(null) { }

        public HelpMenuCommand(IEnumerable<IMenuCommand> subCommands) : base(subCommands)
        {
            Header = "Help";
        }
        
        public override void Execute()
        {
        }
    }
}
