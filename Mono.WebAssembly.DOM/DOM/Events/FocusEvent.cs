using System;
using Mono.WebAssembly;

namespace Mono.WebAssembly.DOM.Events
{

    [Export("FocusEvent", typeof(Mono.WebAssembly.JSObject))]
    public sealed class FocusEvent : UIEvent
    {
        internal FocusEvent(int handle) : base(handle) { }

        //public FocusEvent (string typeArg, FocusEventInit eventInitDict) { }
        [Export("relatedTarget")]
        public EventTarget RelatedTarget => GetProperty<EventTarget>("relatedTarget");
        //[Export("initFocusEvent")]
        //public void InitFocusEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, double detailArg, EventTarget relatedTargetArg)
        //{
        //	InvokeMethod<object>("initFocusEvent", typeArg, canBubbleArg, cancelableArg, viewArg, detailArg, relatedTargetArg);
        //}
    }
}