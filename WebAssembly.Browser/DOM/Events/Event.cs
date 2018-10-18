using System;
using System.Collections.Generic;
using WebAssembly;

namespace WebAssembly.Browser.DOM.Events
{
    [Export("Event", typeof(JSObject))]
    public class Event : DOMObject
    {
        internal Event(JSObject handle) : base(handle) { }

        //public Event(string typeArg, IEventInit eventInitDict) { }
        [Export("AT_TARGET")]
        public double AtTarget => GetProperty<double>("AT_TARGET");
        [Export("BUBBLING_PHASE")]
        public double BubblingPhase => GetProperty<double>("BUBBLING_PHASE");
        [Export("CAPTURING_PHASE")]
        public double CapturingPhase => GetProperty<double>("CAPTURING_PHASE");
        [Export("bubbles")]
        public bool Bubbles { get; internal set; }
        [Export("cancelable")]
        public bool Cancelable { get; internal set; }
        [Export("cancelBubble")]
        public bool CancelBubble { get => GetProperty<bool>("cancelBubble"); set => SetProperty<bool>("cancelBubble", value); }
        [Export("currentTarget")]
        public EventTarget CurrentTarget => GetProperty<EventTarget>("currentTarget");
        [Export("defaultPrevented")]
        public bool DefaultPrevented => GetProperty<bool>("defaultPrevented");
        [Export("eventPhase")]
        public double EventPhase { get; internal set; }
        [Export("isTrusted")]
        public bool IsTrusted { get; internal set; }
        [Export("returnValue")]
        public bool ReturnValue { get => GetProperty<bool>("returnValue"); set => SetProperty<bool>("returnValue", value); }
        [Export("srcElement")]
        public Element SrcElement => GetProperty<Element>("srcElement");
        [Export("target")]
        public EventTarget Target => GetProperty<EventTarget>("target");
        [Export("timeStamp")]
        public double TimeStamp { get; internal set; }
        [Export("type")]
        public string Type { get; internal set; }
        [Export("scoped")]
        public bool Scoped { get; internal set; }
        //[Export("initEvent")]
        //public void InitEvent(string eventTypeArg, bool canBubbleArg, bool cancelableArg)
        //{
        //    InvokeMethod<object>("initEvent", eventTypeArg, canBubbleArg, cancelableArg);
        //}
        [Export("preventDefault")]
        public void PreventDefault()
        {
            InvokeMethod<object>("preventDefault");
        }
        [Export("stopImmediatePropagation")]
        public void StopImmediatePropagation()
        {
            InvokeMethod<object>("stopImmediatePropagation");
        }
        [Export("stopPropagation")]
        public void StopPropagation()
        {
            InvokeMethod<object>("stopPropagation");
        }
        [Export("deepPath")]
        public EventTarget[] DeepPath()
        {
            return InvokeMethod<EventTarget[]>("deepPath");
        }


        internal virtual void InitEvent(string eventTypeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, int detailArg,
                                         double screenXArg, double screenYArg, double clientXArg, double clientYArg,
                                         bool ctrlKeyArg, bool altKeyArg, bool shiftKeyArg, bool metaKeyArg, int buttonArg,
                                        int eventPhaseArg, bool scopedArg, double timeStampArg, 
            Dictionary<string, string> eventInfoDic)
        {

            Bubbles = canBubbleArg;
            Cancelable = cancelableArg;
            TimeStamp = timeStampArg;
            Scoped = scopedArg;
            Type = eventTypeArg;
            EventPhase = eventPhaseArg;

        }

    }
}
