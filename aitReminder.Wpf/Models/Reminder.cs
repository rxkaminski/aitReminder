using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace aitReminder.Wpf.Models
{
    public class Reminder : INotifyPropertyChanged, IDataErrorInfo, IReminder
    {
        private string _name = String.Empty;
        private string _description = String.Empty;
        private DateTime _startDate = DateTime.Now;
        private bool _repeated = false;
        private TimeSpan _repeatInterval = new TimeSpan();

        public string Name
        {
            get => _name;
            set
            {
                _name = value;

                OnPropertyChanged("Name");
            }
        }
        public string Description
        {
            get => _description;
            set
            {
                _description = value;

                OnPropertyChanged("Description");
            }
        }
        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;

                OnPropertyChanged("StartDate");
            }
        }

        public bool Repeated
        {
            get => _repeated;
            set
            {
                _repeated = value;

                OnPropertyChanged("Repeated");
            }
        }

        [XmlIgnore]
        public TimeSpan RepeatInterval
        {
            get => _repeatInterval;
            set
            {
                _repeatInterval = value;

                OnPropertyChanged("RepeatInterval");
            }
        }

        [XmlElement("RepeatInterval")]
        public long RepeatIntervalTick
        {
            get => RepeatInterval.Ticks;
            set
            {
                RepeatInterval = TimeSpan.FromTicks(value);
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public bool IsExpired { get => DateTime.Now > StartDate; }

        public bool Showned { get; set; } = false;
        
        public void CalculateNextStartDate()
        {
            if (Repeated && RepeatInterval > new TimeSpan(0, 0, 0, 1, 0))
            {
                while (StartDate < DateTime.Now)
                {
                    StartDate = StartDate + RepeatInterval;
                }
            }

            Showned = false;
        }

        #region IDataErrorInfo

        [XmlIgnore]
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();

        public bool HasError()
        {
            bool hasError = false;

            foreach (var pair in ErrorCollection)
                if (pair.Value != null)
                    hasError = true;

            return hasError;
        }

        public string this[string propertyName]
        {
            get
            {
                string erroMessage = null;

                switch (propertyName)
                {
                    case "Name":
                        if (Name?.Length <= 5)
                            erroMessage = $"Field Name must by longer then 5";

                        if (string.IsNullOrWhiteSpace(Name))
                            erroMessage = $"Field Name is required";
                        break;

                    case "Description":
                        if (string.IsNullOrWhiteSpace(Description))
                            erroMessage = $"Field Description is required";

                        if (Description?.Length <= 5)
                            erroMessage = $"Field Description must by longer then 5";
                        break;

                    case "StartDate":
                        DateTime tmpDate;
                        DateTime.TryParse(StartDate.ToString(), out tmpDate);

                        if (tmpDate == null)
                            erroMessage = "Wrong format of field StartDate";
                        break;

                    case "RepeatInterval":
                        if (Repeated)
                        {
                            TimeSpan tmpTimeSpan;
                            TimeSpan.TryParse(RepeatInterval.ToString(), out tmpTimeSpan);

                            if (tmpTimeSpan == null || tmpTimeSpan < new TimeSpan(0,0,0,1))
                                erroMessage = $"If you checked Repeated you must set RepeatInterval";
                        }

                        break;
                }

                if( ErrorCollection.ContainsKey(propertyName))
                    ErrorCollection[propertyName] = erroMessage;
                else if (erroMessage != null)
                    ErrorCollection.Add(propertyName, erroMessage);

                OnPropertyChanged("ErrorCollection");

                return erroMessage;
            }

        }


        public string Error => null;

        #endregion

        #region Static Method
        public static void Copy(Reminder source, Reminder destination)
        {
            destination.Name = source.Name;
            destination.Description = source.Description;
            destination.StartDate = source.StartDate;
            destination.Repeated = source.Repeated;
            destination.RepeatInterval = source.RepeatInterval;
            destination.Showned = source.Showned;
        }
        #endregion

    }
}
