namespace aitReminder.Wpf.Commands
{
    public interface IOpenDialogProperty
    {
        string Filter { get; }
        bool Multiselect { get; }
    }
}
