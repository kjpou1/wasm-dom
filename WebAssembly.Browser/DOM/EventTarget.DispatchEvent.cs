using System;
namespace WebAssembly.Browser.DOM
{
    public partial class EventTarget
    {

        public int DispatchDOMEvent(string eventType, string typeOfEvent, JSObject eventTarget, JSObject eventHandle,
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
                                      string eventInfo = null)
        {

#if DEBUG
            //Console.WriteLine($"EventType: {eventType} TypeOfEvent: {typeOfEvent}, Event target: {eventTarget}, Event Handle: {eventHandle}, Event Info: {eventInfo}");
#endif

            var eventArgs = new DOMEventArgs(this, eventType, typeOfEvent, eventTarget, eventHandle,
                                      evAltKey,
                                      evBubbles,
                                      evCancelable,
                                      evCtrlKey,
                                      evDetail,
                                      evEventPhase,
                                      evMetaKey,
                                      evShiftKey,
                                      evKeyCode,
                                      evPointerId,
                                      evPointerType,
                                      evScreenX,
                                      evScreenY,
                                      timeStamp,
                                      evIsTrusted,
                                      evScoped,
                                      evClientX,
                                      evClientY,
                                      evButton,
                                             eventInfo);


            lock (eventHandlers)
            {
                if (eventHandlers.TryGetValue(eventType, out DOMEventHandler eventHandler))
                {
                    eventHandler?.Invoke(this, eventArgs);
                }
            }

            eventArgs.EventObject?.Dispose();
            eventArgs.EventObject = null;
            eventArgs.Source = null;
            eventArgs = null;
            return 0;
        }
    }
}
