using System;
using System.Collections.Generic;
using WebAssembly;

namespace WebAssembly.Browser.DOM.Events
{

    [Export("FocusEvent", typeof(JSObject))]
    public sealed class FocusEvent : UIEvent
    {
        internal FocusEvent(JSObject handle) : base(handle) { }

        //public FocusEvent (string typeArg, FocusEventInit eventInitDict) { }
        [Export("relatedTarget")]
        public EventTarget RelatedTarget => GetProperty<EventTarget>("relatedTarget");
        //[Export("initFocusEvent")]
        //public void InitFocusEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, double detailArg, EventTarget relatedTargetArg)
        //{
        //	InvokeMethod<object>("initFocusEvent", typeArg, canBubbleArg, cancelableArg, viewArg, detailArg, relatedTargetArg);
        //}
        internal override void InitEvent(string eventTypeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, int detailArg,
                                         double screenXArg, double screenYArg, double clientXArg, double clientYArg,
                                         bool ctrlKeyArg, bool altKeyArg, bool shiftKeyArg, bool metaKeyArg, int buttonArg,
                                        int eventPhaseArg, bool scopedArg, double timeStampArg,
                                         Dictionary<string, string> eventInfoDic)
        {
            base.InitEvent(eventTypeArg, canBubbleArg, cancelableArg, viewArg, detailArg, screenXArg, screenYArg, clientXArg, clientYArg,
                           ctrlKeyArg, altKeyArg, shiftKeyArg, metaKeyArg, buttonArg, eventPhaseArg, scopedArg, timeStampArg, eventInfoDic);
        }
    }


}