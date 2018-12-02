using System.Collections.Generic;

namespace aitReminder.Wpf.Commands
{
    class CloseMenuCommand : MenuCommand
    {
        private readonly IMainWindow _mainWindow;

        public CloseMenuCommand(IMainWindow mainWindow) : this(mainWindow, null) { }

        public CloseMenuCommand(IMainWindow mainWindow, IEnumerable<IMenuCommand> subCommands) : base(subCommands)
        {
            _mainWindow = mainWindow;

            Header = "Close";
        }

        public override void Execute()
        {
            _mainWindow.CloseApplication();
        }
    }
}
