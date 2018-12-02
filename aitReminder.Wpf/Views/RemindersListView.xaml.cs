using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using aitReminder.Wpf.BusinessLogic;
using aitReminder.Wpf.Models;

namespace aitReminder.Wpf.Views
{
    /// <summary>
    /// Interaction logic for RemindersListView.xaml
    /// </summary>
    public partial class RemindersListView : UserControl, IRemindersListView
    {
        public RemindersListView()
        {
            InitializeComponent();
        }

        public event EventHandler<ReminderEventArgs> SelectionChanged;

        public virtual void OnSelectionChanged(Reminder reminder)
        {
            SelectionChanged?.Invoke(this, new ReminderEventArgs(reminder));
        }

        public Reminder Selected()
        {
            return (Reminder)reminderDataGrid.SelectedItem;
        }


        public void SetReminders(IEnumerable<Reminder> reminders)
        {
            reminderDataGrid.ItemsSource = reminders;
        }

        private void reminderDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Reminder reminder = null;
               
            if(e.AddedItems.Count > 0)
                reminder = e.AddedItems[0] as Reminder;

            OnSelectionChanged(reminder);
        }
    }
}
