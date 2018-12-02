using aitReminder.Wpf.BusinessLogic;

namespace aitReminder.Wpf.BusinessLogic
{
    class RemindersManagerIsChangedEventAggregator : ITypeEventAggregator
    {
        public RemindersManagerIsChangedEventAggregator(bool isChanged, bool remindersFileIsSet)
        {
            IsChanged = isChanged;
            RemindersFileIsSet = remindersFileIsSet;
        }

        public bool IsChanged { get; set; } = false;
        public bool RemindersFileIsSet { get; set; } = false;
    }
}
