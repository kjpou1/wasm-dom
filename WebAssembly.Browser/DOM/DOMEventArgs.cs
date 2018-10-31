using System;
using System.Collections.Generic;
using WebAssembly.Browser.DOM.Events;
using WebAssembly;

namespace WebAssembly.Browser.DOM
{
    public class DOMEventArgs : EventArgs
    {

        public double ClientX { get; internal set; }
        public double ClientY { get; internal set;  }
        public double OffsetX { get; internal set;  }
        public double OffsetY { get; internal set; }
        public double ScreenX { get; internal set; }
        public double ScreenY { get; internal set; }
        public bool AltKey { get; internal set; }
        public bool CtrlKey { get; internal set; }
        public bool ShiftKey { get; internal set; }
        public int KeyCode { get; internal set; }
        public string EventType { get; internal set; }
        public DOMObject Source { get; internal set; }
        public Event EventObject { get; internal set; }


        public DOMEventArgs(DOMObject source, string eventType, string typeOfEvent, JSObject eventTarget, JSObject eventObject,
                                      bool evAltKey,
                                      bool evBubbles,
                                      bool evCancelable,
                                      bool evCtrlKey,
                                      int evDetail,
                                      int evEventPhase,
                                      bool evMetaKey,
                                      bool evShiftKey,
                                      int evKeyCode,
                                      int evPointerId,
                                      string evPointerType,
                                      double evScreenX,
                                      double evScreenY,
                                      double timeStamp,
                                      bool evIsTrusted,
                                      bool evScoped,
                                      double evClientX,
                                      double evClientY,
                                      int evButton,
                              string eventInfo)
        {


            Source = source;
            EventType = typeOfEvent;

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

            ScreenX = evScreenX;
            ScreenY = evScreenY;
            AltKey = evAltKey;
            CtrlKey = evCtrlKey;
            ShiftKey = evShiftKey;
            KeyCode = evKeyCode;
            ClientX = evClientX;
            ClientY = evClientY;

            var eventInfoDic = new Dictionary<string, string>();

            // an empty json string still has a length of two "{}"
            if (!string.IsNullOrEmpty(eventInfo) && eventInfo.Length > 2)
            {
                var ei = eventInfo.Substring(1, eventInfo.Length - 2).Split(',');
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


                if (eventInfoDic.TryGetValue("offsetX", out value))
                {
                    OffsetX = Convert.ToInt32(value);
                }
                if (eventInfoDic.TryGetValue("offsetY", out value))
                {
                    OffsetY = Convert.ToInt32(value);
                }

            }

            EventObject.InitEvent(eventType, evBubbles, evCancelable, null, evDetail, evScreenX, evScreenY, evClientX, evClientY,
            evCtrlKey, evAltKey, evShiftKey, evMetaKey, evButton, evEventPhase, evScoped, timeStamp,
                  eventInfoDic);

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
