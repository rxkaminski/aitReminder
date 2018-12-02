using System;

namespace aitReminder.Wpf.Models
{
    public interface IReminder
    {
        string Description { get; set; }
        string Name { get; set; }
        bool Repeated { get; set; }
        TimeSpan RepeatInterval { get; set; }
        long RepeatIntervalTick { get; set; }
        DateTime StartDate { get; set; }
    }
}