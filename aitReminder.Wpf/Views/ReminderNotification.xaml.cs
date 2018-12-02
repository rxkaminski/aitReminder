using aitReminder.Wpf.BusinessLogic;
using aitReminder.Wpf.Models;
using System.Windows;

namespace aitReminder.Wpf.Views
{
    /// <summary>
    /// Interaction logic for ReminderNotification.xaml
    /// </summary>
    public partial class ReminderNotification : Window
    {
        private readonly IRemindersManager _remindersManager;
        private Reminder _reminder;
        bool _repeat = false;

        public ReminderNotification(IRemindersManager remindersManager, Reminder reminder)
        {
            InitializeComponent();

            _remindersManager = remindersManager;
            _reminder = reminder;

            viewReminder.DataContext = _reminder;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource reminderViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("reminderViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            //reminderViewSource.Source = [generic data source]
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            _remindersManager.RemoveReminder(_reminder);
            this.Close();
        }

        private void btnRepeat_Click(object sender, RoutedEventArgs e)
        {
            _reminder.CalculateNextStartDate();
            _repeat = true;
            this.Close();
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            if (!_repeat)
                _remindersManager.RemoveReminder(_reminder);
        }
    }
}
