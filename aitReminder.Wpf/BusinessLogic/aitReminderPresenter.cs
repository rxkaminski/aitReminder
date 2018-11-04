using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aitReminder.Wpf.Commands;

namespace aitReminder.Wpf.BusinessLogic
{
    class AitReminderPresenter
    {
        public AitReminderPresenter(IMainWindow mainWindow, 
                                    IMenuCommand[] menuCommands
,
                                    IRemindersManager remindersManager)
        {

            mainWindow.MenuView.SetMenuCommands(menuCommands);

     
            mainWindow.RemindersListView.SetReminders(remindersManager.Reminders);
        }
    }
}
