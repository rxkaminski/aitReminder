using System;
using System.Windows;
using aitReminder.Wpf.Commands;
using aitReminder.Wpf.BusinessLogic;
using aitReminder.Wpf.Views;
using aitReminder.Wpf.Models;
using Microsoft.Win32;


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

            var aitReminder = new AitReminderPresenter(mainWindow);

            App.Current.DispatcherUnhandledException += (s, e) =>
            {
                //TODO: Change unhandled exception
                MessageBox.Show("Unhandled Error");

                e.Handled = true;
            };
        }

        public IMenuView MenuView => menuView; 

        public IRemindersListView RemindersListView => remindersListView;

        public IRemindersStatusBarView RemindersStatusBarView => statusBarView;

        public void About()
        {
            var form = new About();
            form.Owner = this;
            form.ShowDialog();
        }

        public void CloseApplication()
        {
            Close();
        }

        public void EditReminder(IRemindersManager _remindersManager, Reminder reminder)
        {
            var form = new AddEditReminderForm(_remindersManager, reminder);
            form.Owner = this;
            form.ShowDialog();
        }

        public void MakeNewReminder(IRemindersManager _remindersManager)
        {
            var form = new AddEditReminderForm(_remindersManager);
            form.Owner = this;
            form.ShowDialog();
        }

        public void ReminderNotification(IRemindersManager remindersManager, Reminder reminder)
        {
            Application.Current.Dispatcher.Invoke((Action)delegate {
                var form = new ReminderNotification(remindersManager, reminder);
                form.Owner = this;
                form.Show();
            });
        }

        public string ShowOpenDialogGetFilePath(IOpenDialogProperty openDialogProperty)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = openDialogProperty.Multiselect;
            openFileDialog.Filter = openDialogProperty.Filter;
            Nullable<bool> result = openFileDialog.ShowDialog();

            if(result == true)
            {
                 return openFileDialog.FileName;
            }

            return "";
        }

        public string ShowSaveAsDialogGetFilePath(ISaveAsDialogProperty saveAsDialogProperty)
        {
            var saveAsFileDialog = new SaveFileDialog();
            saveAsFileDialog.Filter = saveAsDialogProperty.Filter;
            Nullable<bool> result = saveAsFileDialog.ShowDialog();

            if (result == true)
            {
                return saveAsFileDialog.FileName;
            }

            return "";
        }
    }
}
