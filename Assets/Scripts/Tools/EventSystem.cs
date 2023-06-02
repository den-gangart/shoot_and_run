using System;
using System.Collections.Generic;

namespace RunShooter
{
    public static class EventSystem
    {
        private static readonly Dictionary<Type, Action<BaseEvent>> _eventListeners = new Dictionary<Type, Action<BaseEvent>>();
        private static readonly Dictionary<Delegate, Action<BaseEvent>> _eventLookups = new Dictionary<Delegate, Action<BaseEvent>>();

        public static void AddEventListener<T>(Action<T> callBack) where T : BaseEvent
        {
            if (!_eventLookups.ContainsKey(callBack))
            {
                Action<BaseEvent> newAction = (gameEvent) => callBack((T)gameEvent);
                _eventLookups[callBack] = newAction;

                if (_eventListeners.TryGetValue(typeof(T), out Action<BaseEvent> internalAction))
                {
                    _eventListeners[typeof(T)] = internalAction += newAction;
                }
                else
                {
                    _eventListeners[typeof(T)] = newAction;
                }
            }
        }

        public static void RemoveEventListener<T>(Action<T> callBack)
        {
            if (_eventLookups.TryGetValue(callBack, out var action))
            {
                if (_eventListeners.TryGetValue(typeof(T), out var tempAction))
                {
                    tempAction -= action;
                    if (tempAction == null)
                        _eventListeners.Remove(typeof(T));
                    else
                        _eventListeners[typeof(T)] = tempAction;
                }

                _eventLookups.Remove(callBack);
            }
        }

        public static void Broadcast(BaseEvent gameEvent)
        {
            if (_eventListeners.TryGetValue(gameEvent.GetType(), out var action))
            {
                action.Invoke(gameEvent);
            }
        }
    }
}