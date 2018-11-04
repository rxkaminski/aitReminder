using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aitReminder.Wpf.Commands
{
    class FileMenuCommmand : MenuCommand
    {
        public FileMenuCommmand() : this(null) { }

        public FileMenuCommmand(IEnumerable<IMenuCommand> subCommands) : base(subCommands)
        {
            Header = "File";
        }

        public override void Execute()
        {
            //throw new NotImplementedException();
        }
    }
}
