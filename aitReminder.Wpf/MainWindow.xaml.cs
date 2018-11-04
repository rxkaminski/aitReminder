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
using aitReminder.Wpf.BusinessLogic;
using aitReminder.Wpf.Views;

namespace aitReminder.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindow
    {

        public static IMainWindow AppWindow;


        public MainWindow()
        {
            InitializeComponent();

            IMainWindow mainWindow = this;

            IRemindersManager remindersManager = new RemindersManager();
            IRemindersListView remindersListView = mainWindow.RemindersListView;

            var menuCommands = new IMenuCommand[]
            {
                new FileMenuCommmand(
                    new IMenuCommand[]
                    {
                        new OpenMenuCommand(remindersManager, remindersListView),
                        new SaveMenuCommand(),
                        new CloseMenuCommand(),
                    }),
                new EditMenuCommand(
                    new IMenuCommand[]
                    {
                        new AddNewReminderMenuCommand(remindersManager),
                        new EditMenuCommand(),

                        new FileMenuCommmand(
                            new IMenuCommand[]
                            {
                                
                                new SaveMenuCommand(),
                                new CloseMenuCommand(),
                            }),
                    })

            };


            var aitReminder = new AitReminderPresenter(mainWindow,
                                                            menuCommands,
                                                            remindersManager
                );



        }

        public IMenuView MenuView => menuView; 

        public IRemindersListView RemindersListView => remindersListView;
    }




    public interface IMainWindow
    {
        IMenuView MenuView { get; }
        IRemindersListView RemindersListView { get; }
    }
}
