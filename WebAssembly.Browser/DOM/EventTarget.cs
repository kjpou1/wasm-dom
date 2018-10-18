using System;
using System.Collections.Generic;
using WebAssembly;
using WebAssembly.Browser.DOM.Events;


namespace WebAssembly.Browser.DOM
{


    [Export("EventTarget", typeof(JSObject))]
    public partial class EventTarget : DOMObject, IEventTarget
    {

        static int nextEventId = 0;
        static int NextEventId => nextEventId++;

        public EventTarget(JSObject handle) : base(handle) { }

        protected EventTarget(string globalName) : base(globalName)
        {

        }

        internal Dictionary<string, DOMEventHandler> eventHandlers = new Dictionary<string, DOMEventHandler>();


        [Export("addEventListener")]
        public void AddEventListener(string type, DOMEventHandler listener, object options)
        {

            bool addNativeEventListener = false;
            lock (eventHandlers)
            {
                if (!eventHandlers.ContainsKey(type))
                {
                    eventHandlers.Add(type, null);
                    addNativeEventListener = true;
                }
                eventHandlers[type] += listener;
            }

            if (addNativeEventListener)
            {

                var UID = NextEventId;
                AddJSEventListener(type, dispather(), UID);

            }


        }

        public delegate int DOMEventDelegate(string eventType, string typeOfEvent, JSObject eventTarget, JSObject eventHandle,
                      bool evAltKey,
                      bool evBubbles,
                      bool evCancelable,
                      bool evCtrlKey,
                      int evDetail,
                      int evEventPhase,
                      bool evMetaKey,
                      bool evShitKey,
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

                      string eventInfo = null);


        DOMEventDelegate dispather()
        {
            return new DOMEventDelegate(DispatchDOMEvent);
        }

        [Export("dispatchEvent")]
        public bool DispatchEvent(Event evt)
        {
            return InvokeMethod<bool>("dispatchEvent", evt);
        }

        [Export("removeEventListener")]
        public void RemoveEventListener(string type, DOMEventHandler listener, object options)
        {

        }

    }

}