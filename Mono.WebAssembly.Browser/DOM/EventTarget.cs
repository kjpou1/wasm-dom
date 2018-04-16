using System;
using System.Collections.Generic;
using Mono.WebAssembly;
using Mono.WebAssembly.Browser.DOM.Events;

namespace Mono.WebAssembly.Browser.DOM
{


    [Export("EventTarget", typeof(Mono.WebAssembly.JSObject))]
    public class EventTarget : JSObject, IEventTarget
    {
        public EventTarget(int handle) : base(handle) { }

        protected EventTarget(string globalName) : this(GetGlobal(globalName))
        {

        }

        public EventTarget() { }

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

                double UID = RuntimeUtilities.NextUID;

                RuntimeEventManager.RegisterEventTarget(UID, this);

                var addEventListerFor = "MonoDOMRuntime.mono_wasm_addEventListener(" + Handle + ",\"" + type + "\"," + UID + ")";
                var res = Runtime.ExecuteJavaScript(addEventListerFor);
            }
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

		protected internal override object ConvertTo(Type targetType)
		{

            if (targetType.IsAssignableFrom(base.GetType()))
            {
                return this;
            }
            else if (targetType.IsSubclassOf(this.GetType()))
            {
                return CreateJSObjectFrom(targetType, this);
            }

            return base.ConvertTo(targetType);
		}

        public void DispatchDOMEvent(string type, string typeOfEvent, string UID, string eventHandle, string eventInfo = null)
        {

//#if DEBUG
            //Console.WriteLine($"EventType: {type} TypeOfEvent: {typeOfEvent}, Event Id: {UID}, Event Handle: {eventHandle}, Event Info: {eventInfo}");
//#endif

            var eventArgs = new DOMEventArgs(this, type, typeOfEvent, eventHandle, eventInfo);


            lock (eventHandlers)
            {
                DOMEventHandler eventHandler;
                if (eventHandlers.TryGetValue(type, out eventHandler))
                {
                    eventHandler?.Invoke(this, eventArgs);
                }
            }
        }

    }

}