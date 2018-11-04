using aitReminder.Wpf.Models;
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

        public void SetReminders(IEnumerable<Reminder> reminders)
        {
            remindersListView.ItemsSource = reminders;
        }
    }
}
