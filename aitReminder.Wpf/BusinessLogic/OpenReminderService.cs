using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aitReminder.Wpf.BusinessLogic
{
    class OpenReminderService
    {
        public string GetPathToReminderConfig()
        {
            var dialog = new OpenFileDialog();
            return dialog.ShowDialog() == true ? dialog.OpenFile().ToString() : null;
        }
    }
}
