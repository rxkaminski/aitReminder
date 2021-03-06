﻿using aitReminder.Wpf.BusinessLogic;
using aitReminder.Wpf.Views;
using System.Collections.Generic;

namespace aitReminder.Wpf.Commands
{
    class OpenMenuCommand : MenuCommand, IOpenDialogProperty
    {
        private readonly IMainWindow _mainWindow;
        private readonly IRemindersManager _remindersManager;

        public OpenMenuCommand(IMainWindow mainWindow,
                                IRemindersManager remindersManager)
                            : this(mainWindow,
                                     remindersManager,
                                     null)
        { }

        public OpenMenuCommand(IMainWindow mainWindow,
                                IRemindersManager remindersManager,
                                IEnumerable<IMenuCommand> subCommands) : base(subCommands)
        {
            _mainWindow = mainWindow;
            _remindersManager = remindersManager;

            Header = "Open";
            ShortcutKey = System.Windows.Input.Key.O;

            Filter = "XML (*.xml)|*.xml";
            Multiselect = false;
        }

        public string Filter { get; private set; }
        public bool Multiselect { get; private set; }

        public override void Execute()
        {
            var filePath = _mainWindow.ShowOpenDialogGetFilePath(this);
            _remindersManager.LoadReminders(filePath);
            _mainWindow.RemindersListView.SetReminders(_remindersManager.Reminders);

            EventAggregator.Instance.Publish(new RemindersManagerIsChangedEventAggregator(false, _remindersManager.RemidersFileIsSet));
        }
    }
}
