using System;
using System.Collections.Generic;
using Mono.WebAssembly.DOM.Events;

namespace Mono.WebAssembly.DOM
{
    public class DOMEventArgs : EventArgs
    {

        public int ClientX { get; internal set; }
        public int ClientY { get; internal set;  }
        public int OffsetX { get; internal set;  }
        public int OffsetY { get; internal set; }
        public int ScreenX { get; internal set; }
        public int ScreenY { get; internal set; }
        public bool AltKey { get; internal set; }
        public bool CtrlKey { get; internal set; }
        public bool ShiftKey { get; internal set; }
        public int KeyCode { get; internal set; }
        public int CharCode { get; internal set; }
        public string EventType { get; internal set; }
        public JSObject Source { get; internal set; }
        public Event EventObject { get; internal set; }


        internal DOMEventArgs(JSObject source, string type, string typeOfEvent, string eventHandle, string eventInfo)
        {
            Source = source;
            EventType = type;

            //Console.WriteLine($"EventHandle: {eventHandle}");

            if (typeOfEvent == "MouseEvent")
            {
                EventObject = new MouseEvent(Convert.ToInt32(eventHandle));
            }
            else if (typeOfEvent == "DragEvent")
            {
                EventObject = new DragEvent(Convert.ToInt32(eventHandle));
            }
            else 
            {
                EventObject = new Event(Convert.ToInt32(eventHandle));
            }


            if (eventInfo != null)
            {
                
                var dict = Runtime.DeserializeJSON(eventInfo) as Dictionary<string, object>;

                //foreach(var key in dict.Keys)
                //{
                //    Console.WriteLine($"Key: {key} - Value: {dict[key]}");
                //}

                object value = null;

                if (dict.TryGetValue("clientX", out value))
                {
                    ClientX = Convert.ToInt32(value);
                }

                if (dict.TryGetValue("clientY", out value))
                {
                    ClientY = Convert.ToInt32(value);
                }

                if (dict.TryGetValue("offsetX", out value))
                {
                    OffsetX = Convert.ToInt32(value);
                }
                if (dict.TryGetValue("offsetY", out value))
                {
                    OffsetY = Convert.ToInt32(value);
                }

                if (dict.TryGetValue("screenX", out value))
                {
                    ScreenX = Convert.ToInt32(value);
                }
                if (dict.TryGetValue("screenY", out value))
                {
                    ScreenY = Convert.ToInt32(value);
                }

                if (dict.TryGetValue("altKey", out value))
                {
                    AltKey = Convert.ToBoolean(value);
                }

                if (dict.TryGetValue("ctrlKey", out value))
                {
                    CtrlKey = Convert.ToBoolean(value);
                }
                if (dict.TryGetValue("shiftKey", out value))
                {
                    ShiftKey = Convert.ToBoolean(value);
                }

                if (dict.TryGetValue("keyCode", out value))
                {
                    KeyCode = Convert.ToInt32(value);
                }

                if (dict.TryGetValue("charCode", out value))
                {
                    CharCode = Convert.ToInt32(value);
                }

            }

        }

        public void PreventDefault()
        {
            if (EventObject != null)
                EventObject.PreventDefault();
        }

        public void StopPropagation()
        {
            if (EventObject != null)
                EventObject.StopPropagation();
        }

    }
}
