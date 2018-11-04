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
    abstract class MenuCommand : IMenuCommand
    {
        public MenuCommand(IEnumerable<IMenuCommand> subCommands)
        {
            SubCommands = subCommands;
        }

        bool isEnabled = true;
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsEnabled
        {
            get => isEnabled;
            set
            {
                isEnabled = value;
                OnPropertyChanged("IsEnabled");
            }
        }

        public Image Icon { get; set; }

        public Key ShortcutKey { get; set; }
        public string Header { get; set; }
        public IEnumerable<IMenuCommand> SubCommands { get; set; }

        public abstract void Execute();
    }
}
