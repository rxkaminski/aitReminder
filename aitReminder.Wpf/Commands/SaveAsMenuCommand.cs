using aitReminder.Wpf.BusinessLogic;
using System.Collections.Generic;

namespace aitReminder.Wpf.Commands
{
    class SaveAsMenuCommand : MenuCommand, ISaveAsDialogProperty
    {
        private readonly IMainWindow _mainWindow;
        private readonly IRemindersManager _remindersManager;

        public SaveAsMenuCommand(IMainWindow mainWindow, IRemindersManager remindersManager) : 
            this(mainWindow, remindersManager, null) { }

        public SaveAsMenuCommand(IMainWindow mainWindow, IRemindersManager remindersManager, IEnumerable<IMenuCommand> subCommands) 
            : base(subCommands)
        {
            _mainWindow = mainWindow;
            _remindersManager = remindersManager;

            Header = "Save As";

            IsEnabled = false;

            Filter = "XML (*.xml)|*.xml";

            EventAggregator.Instance.Subscribe<RemindersManagerIsChangedEventAggregator>(e => IsEnabled = e.IsChanged);
        }

        public string Filter { get; private set; }

        public override void Execute()
        {
            var filePath = _mainWindow.ShowSaveAsDialogGetFilePath(this);
            
            if(_remindersManager.SaveAsReminder(filePath))
            {
               EventAggregator.Instance.Publish(new RemindersManagerIsChangedEventAggregator(false, _remindersManager.RemidersFileIsSet));

            }
        }
    }
}
