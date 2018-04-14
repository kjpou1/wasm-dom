using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Mono.WebAssembly
{

	public sealed class RuntimeEventManager {
		

        // The event handling may be a little simple but works for now
        // Will need to be looked at in the future.
        static Dictionary<double, DOM.IEventTarget> eventManager = new Dictionary<double, DOM.IEventTarget>();
        internal static void RegisterEventTarget(double uid, DOM.IEventTarget listener)
        {
            if (!eventManager.ContainsKey(uid))
                eventManager.Add(uid, listener);
        }

        internal static void UnRegisterEventTarget(double uid)
        {
            if (eventManager.ContainsKey(uid))
                eventManager.Remove(uid);
        }

        internal static void EventWrangler(string eventType, string typeOfEvent, string eventId, string eventHandle, string eventInfo)
        {

            var uidKey = Convert.ToDouble(eventId);
            DOM.IEventTarget eventTarget;
            if (eventManager.TryGetValue(uidKey, out eventTarget))
            {
                eventTarget.DispatchDOMEvent(eventType, typeOfEvent, eventId, eventHandle, eventInfo);
            }
            
        }
		
	}


}
