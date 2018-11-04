using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace aitReminder.Wpf.Commands
{
    public interface IMenuCommand : INotifyPropertyChanged
    {
        void Execute();
        bool IsEnabled { get; set; }
        Image Icon { get; set; }
        Key ShortcutKey { get; set; }
        string Header { get; set; }
        IEnumerable<IMenuCommand> SubCommands { get; set; }
    }
}
