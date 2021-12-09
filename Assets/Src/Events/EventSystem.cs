using System;
using System.Collections.Generic;

namespace Src.Events
{
    public static class EventsWithoutData
    {
        public delegate void EventHandler();
        private static Dictionary<EventTypes, EventHandler> EventHandlers;

        static EventsWithoutData()
        {
            EventHandlers = new Dictionary<EventTypes, EventHandler>();

            foreach (EventTypes type in (EventTypes[]) Enum.GetValues(typeof(EventTypes)))
            {
                EventHandlers.Add(type, null);
            }
        }

        public static void Clear()
        {
            EventHandlers.Clear();
        }

        public static void FireEvent(EventTypes eventType)
        {

            EventHandlers[eventType]?.Invoke();
        }

        public static void Sub(EventTypes eventType, EventHandler @delegate)
        {
            if (@delegate != null)
            {
                EventHandlers[eventType] += @delegate;
            }
        }

        public static void Unsub(EventTypes eventType, EventHandler @delegate)
        {
            if (@delegate != null)
            {
                EventHandlers[eventType] -= @delegate;
            }
        }
    }

    public static class EventsWithData<T> where T : EventDataTransferObject
    {
        public delegate void EventHandler(T dto);

        private static Dictionary<DTOEventTypes, EventHandler> EventHandlers;

        static EventsWithData()
        {
            EventHandlers = new Dictionary<DTOEventTypes, EventHandler>();

            foreach (DTOEventTypes type in (DTOEventTypes[])Enum.GetValues(typeof(DTOEventTypes)))
            {
                EventHandlers.Add(type, null);
            }
        }

        public static void Clear()
        {
            EventHandlers.Clear();
        }

        public static void FireEvent(DTOEventTypes eventType, T message)
        {

            EventHandlers[eventType]?.Invoke(message);
        }

        public static void Sub(DTOEventTypes eventType, EventHandler handler)
        {
            if (handler != null)
            {
                EventHandlers[eventType] += handler;
            }
        }

        public static void Unsub(DTOEventTypes eventType, EventHandler handler)
        {
            if (handler != null)
            {
                EventHandlers[eventType] -= handler;
            }
        }
    }
}
