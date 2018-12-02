using aitReminder.Wpf.BusinessLogic;
using aitReminder.Wpf.Models;
using System.Windows;
using System.Windows.Controls;

namespace aitReminder.Wpf.Views
{
    /// <summary>
    /// Interaction logic for AddEditReminderForm.xaml
    /// </summary>
    public partial class AddEditReminderForm : Window
    {
        private readonly IRemindersManager _remindersManager;

        Reminder _reminder;
        Reminder _reminderToEdit;
        bool _isNew = false;

        public AddEditReminderForm(IRemindersManager remindersManager) : this(remindersManager, null)
        { }

        public AddEditReminderForm(IRemindersManager remindersManager, Reminder reminder)
        {
            _remindersManager = remindersManager;

            InitializeComponent();

            if (reminder == null)
            {
                _reminder = new Reminder();
                _isNew = true;
                btnOk.Content = "Add";
            }
            else
            {
                _reminderToEdit = reminder;
                _reminder = new Reminder();

                Reminder.Copy(reminder, _reminder);
            }

            grid1.DataContext = _reminder;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            nameTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            descriptionTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            startDateTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            repeatedCheckBox.GetBindingExpression(CheckBox.IsCheckedProperty).UpdateSource();
            repeatIntervalTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();

            if (!_reminder.HasError())
            {

                if (_isNew)
                {
                    _remindersManager.AddReminder(_reminder);
                }
                else
                {
                    Reminder.Copy(_reminder, _reminderToEdit);
                }

                this.Close();
            }           
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
