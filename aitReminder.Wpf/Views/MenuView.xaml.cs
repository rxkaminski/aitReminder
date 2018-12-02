using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using aitReminder.Wpf.Commands;

namespace aitReminder.Wpf.Views
{
    /// <summary>
    /// Interaction logic for MenuView.xaml
    /// </summary>
    public partial class MenuView : UserControl, IMenuView
    {
        public MenuView()
        {
            InitializeComponent();
        }

        public void SetMenuCommands(IMenuCommand[] menuCommands)
        {
            menu.Items.Clear();

            foreach(var mC in menuCommands)
            {
                var item = SetMenuCommand(mC);
                menu.Items.Add(item);
            }

        }

        private MenuItem SetMenuCommand(IMenuCommand menuCommand)
        {
            var item = new MenuItem();
            item.Header = menuCommand.Header;
            item.Icon = menuCommand.Icon;
            item.IsEnabled = menuCommand.IsEnabled;
            

            menuCommand.PropertyChanged += (s, o) => {
                item.IsEnabled = menuCommand.IsEnabled;
            };

            item.Click += (s, o) => menuCommand.Execute();

            if(menuCommand.SubCommands == null)
            {
                return item;
            }

            foreach(var c in menuCommand.SubCommands)
            {
                item.Items.Add(SetMenuCommand(c));
            }

            return item;
        }

    }
}
