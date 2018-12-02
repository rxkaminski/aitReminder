using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aitReminder.Wpf.Commands
{
    class AboutMenuCommand : MenuCommand
    {
        private readonly IMainWindow _mainWindow;

        public AboutMenuCommand(IMainWindow mainWindow) : this(mainWindow, null) { }

        public AboutMenuCommand(IMainWindow mainWindow, IEnumerable<IMenuCommand> subCommands) : base(subCommands)
        {
            _mainWindow = mainWindow;
            Header = "About";
        }
        
        public override void Execute()
        {
            _mainWindow.About();
        }
    }
}
