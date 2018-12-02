using aitReminder.Wpf.BusinessLogic;

namespace aitReminder.Wpf.BusinessLogic
{
    class ReminderIsSelectedEventAggregator : ITypeEventAggregator
    {
        public ReminderIsSelectedEventAggregator(bool isSelected)
        {
            IsSelected = isSelected;
        }

        public bool IsSelected { get; set; }
    }
}
