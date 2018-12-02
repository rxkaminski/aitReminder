using System;
using System.Collections.Generic;

namespace aitReminder.Wpf.BusinessLogic
{
    public class EventAggregator : IDisposable
    {
        public static EventAggregator Instance { get; } = new EventAggregator();

        private Dictionary<Type, List<object>> subscriptions = new Dictionary<Type, List<object>>();

        public void Subscribe<T>(Action<T> action) where T : ITypeEventAggregator
        {
            if (!subscriptions.TryGetValue(typeof(T), out List<object> subscribers))
            {
                subscribers = new List<object>
                {
                    action
                };
                subscriptions.Add(typeof(T), subscribers);
            }
            else
            {
                subscribers.Add(action);
                subscriptions[typeof(T)] = subscribers;
            }
        }

        public void Unsubscribe<T>(Action<T> action) where T : ITypeEventAggregator
        {
            if (subscriptions.TryGetValue(typeof(T), out List<object> subscribers))
                subscribers.Remove(action);
        }

        public void Publish<T>(T message) where T : ITypeEventAggregator
        {
            if (subscriptions.TryGetValue(typeof(T), out List<object> subscribers))
                foreach (var subscriber in subscribers)
                    ((Action<T>)subscriber)(message);
        }

        public void Dispose() => subscriptions.Clear();
    }
}
