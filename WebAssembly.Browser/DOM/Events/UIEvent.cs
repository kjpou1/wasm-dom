using System;
using System.Collections.Generic;
using WebAssembly;

namespace WebAssembly.Browser.DOM.Events
{

    [Export("UIEvent", typeof(JSObject))]
    public class UIEvent : Event
    {
        internal UIEvent(JSObject handle) : base(handle) { }

        //        public UIEvent(string typeArg, IUIEventInit eventInitDict) { }
        [Export("detail")]
        public double Detail { get; internal set; }
        [Export("view")]
        public Window View => GetProperty<Window>("view");
        //[Export("initUIEvent")]
        //public void InitUiEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, double detailArg)
        //{
        //    InvokeMethod<object>("initUIEvent", typeArg, canBubbleArg, cancelableArg, viewArg, detailArg);
        //}

        internal override void InitEvent(string eventTypeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, int detailArg,
                                         double screenXArg, double screenYArg, double clientXArg, double clientYArg,
                                         bool ctrlKeyArg, bool altKeyArg, bool shiftKeyArg, bool metaKeyArg, int buttonArg,
                                        int eventPhaseArg, bool scopedArg, double timeStampArg,
                                         Dictionary<string, string> eventInfoDic)
        {
            base.InitEvent(eventTypeArg, canBubbleArg, cancelableArg, viewArg, detailArg, screenXArg, screenYArg, clientXArg, clientYArg,
                           ctrlKeyArg, altKeyArg, shiftKeyArg, metaKeyArg, buttonArg, eventPhaseArg, scopedArg, timeStampArg,
                           eventInfoDic);

            Detail = detailArg;

        }

    }

}
