using System;
using System.Collections.Generic;
using WebAssembly.Browser.DOM.Events;
using WebAssembly;

namespace WebAssembly.Browser.DOM
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
        public DOMObject Source { get; internal set; }
        public Event EventObject { get; internal set; }


        internal DOMEventArgs(DOMObject source, string type, string typeOfEvent, JSObject eventObject, string eventInfo)
        {
            Source = source;
            EventType = type;

            //Console.WriteLine($"EventHandle: {eventHandle}");

            if (typeOfEvent == "MouseEvent")
            {
                EventObject = new MouseEvent(eventObject);
            }
            else if (typeOfEvent == "DragEvent")
            {
                EventObject = new DragEvent(eventObject);
            }
            else if (typeOfEvent == "FocusEvent")
            {
                EventObject = new FocusEvent(eventObject);
            }
            else if (typeOfEvent == "WheelEvent")
            {
                EventObject = new WheelEvent(eventObject);
            }
            else if (typeOfEvent == "KeyboardEvent")
            {
                EventObject = new KeyboardEvent(eventObject);
            }
            else if (typeOfEvent == "ClipboardEvent")
            {
                EventObject = new ClipboardEvent(eventObject);
            }
            else 
            {
                EventObject = new Event(eventObject);
            }


            if (eventInfo != null)
            {
                var ei = eventInfo.Substring(1, eventInfo.Length - 2).Split(',');
                var eventInfoDic = new Dictionary<string, string>();
                string value = null;
                foreach (var eip in ei)
                {
                    //Console.WriteLine(eip);
                    var kvp = eip.Split(':');
                    var key = kvp[0].Substring(1, kvp[0].Length - 2);
                    value = kvp[1];
                    if (value.StartsWith("\"", StringComparison.InvariantCulture))
                        eventInfoDic.Add(key, value.Substring(1, value.Length - 2));
                    else
                        eventInfoDic.Add(key, value);

                }
                //Console.WriteLine(eventInfo.Substring(1, eventInfo.Length - 2));

                //var eventInfoDic = Runtime.DeserializeJSON(eventInfo) as Dictionary<string, object>;

                //foreach(var key in eventInfoDic.Keys)
                //{
                //    Console.WriteLine($"Key: {key} - Value: {eventInfoDic[key]}");
                //}

                value = null;

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
