using aitReminder.Wpf.Commands;

namespace aitReminder.Wpf.Views
{
    public interface IMenuView
    {
        void SetMenuCommands(IMenuCommand[] menuCommands);
    }
}
