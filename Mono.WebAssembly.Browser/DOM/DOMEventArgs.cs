using System;
using System.Collections.Generic;
using Mono.WebAssembly.Browser.DOM.Events;

namespace Mono.WebAssembly.Browser.DOM
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
            else if (typeOfEvent == "FocusEvent")
            {
                EventObject = new FocusEvent(Convert.ToInt32(eventHandle));
            }
            else 
            {
                EventObject = new Event(Convert.ToInt32(eventHandle));
            }


            if (eventInfo != null)
            {
                
                var eventInfoDic = Runtime.DeserializeJSON(eventInfo) as Dictionary<string, object>;

                //foreach(var key in eventInfoDic.Keys)
                //{
                //    Console.WriteLine($"Key: {key} - Value: {eventInfoDic[key]}");
                //}

                object value = null;

                if (eventInfoDic.TryGetValue("clientX", out value))
                {
                    ClientX = Convert.ToInt32(value);
                }

                if (eventInfoDic.TryGetValue("clientY", out value))
                {
                    ClientY = Convert.ToInt32(value);
                }

                if (eventInfoDic.TryGetValue("offsetX", out value))
                {
                    OffsetX = Convert.ToInt32(value);
                }
                if (eventInfoDic.TryGetValue("offsetY", out value))
                {
                    OffsetY = Convert.ToInt32(value);
                }

                if (eventInfoDic.TryGetValue("screenX", out value))
                {
                    ScreenX = Convert.ToInt32(value);
                }
                if (eventInfoDic.TryGetValue("screenY", out value))
                {
                    ScreenY = Convert.ToInt32(value);
                }

                if (eventInfoDic.TryGetValue("altKey", out value))
                {
                    AltKey = Convert.ToBoolean(value);
                }

                if (eventInfoDic.TryGetValue("ctrlKey", out value))
                {
                    CtrlKey = Convert.ToBoolean(value);
                }
                if (eventInfoDic.TryGetValue("shiftKey", out value))
                {
                    ShiftKey = Convert.ToBoolean(value);
                }

                if (eventInfoDic.TryGetValue("keyCode", out value))
                {
                    KeyCode = Convert.ToInt32(value);
                }

                if (eventInfoDic.TryGetValue("charCode", out value))
                {
                    CharCode = Convert.ToInt32(value);
                }

                if (eventInfoDic != null)
                {
                    EventObject.InitEvent(eventInfoDic);
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
