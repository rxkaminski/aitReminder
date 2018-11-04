using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aitReminder.Wpf.Models
{
    public class Reminder
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan RepeatInterval { get; set; }
        public bool Repeated { get; set; }
    }
}
