using System;
namespace Mono.WebAssembly.Browser.DOM.Events
{
    [Export("Event", typeof(Mono.WebAssembly.JSObject))]
    public class Event : JSObject
    {
        internal Event(int handle) : base(handle) { }

        public Event(string typeArg, IEventInit eventInitDict) { }
        [Export("AT_TARGET")]
        public double AtTarget => GetProperty<double>("AT_TARGET");
        [Export("BUBBLING_PHASE")]
        public double BubblingPhase => GetProperty<double>("BUBBLING_PHASE");
        [Export("CAPTURING_PHASE")]
        public double CapturingPhase => GetProperty<double>("CAPTURING_PHASE");
        [Export("bubbles")]
        public bool Bubbles => GetProperty<bool>("bubbles");
        [Export("cancelable")]
        public bool Cancelable => GetProperty<bool>("cancelable");
        [Export("cancelBubble")]
        public bool CancelBubble { get => GetProperty<bool>("cancelBubble"); set => SetProperty<bool>("cancelBubble", value); }
        [Export("currentTarget")]
        public EventTarget CurrentTarget => GetProperty<EventTarget>("currentTarget");
        [Export("defaultPrevented")]
        public bool DefaultPrevented => GetProperty<bool>("defaultPrevented");
        [Export("eventPhase")]
        public double EventPhase => GetProperty<double>("eventPhase");
        [Export("isTrusted")]
        public bool IsTrusted => GetProperty<bool>("isTrusted");
        [Export("returnValue")]
        public bool ReturnValue { get => GetProperty<bool>("returnValue"); set => SetProperty<bool>("returnValue", value); }
        [Export("srcElement")]
        public Element SrcElement => GetProperty<Element>("srcElement");
        [Export("target")]
        public EventTarget Target => GetProperty<EventTarget>("target");
        [Export("timeStamp")]
        public double TimeStamp => GetProperty<double>("timeStamp");
        [Export("type")]
        public string Type => GetProperty<string>("type");
        [Export("scoped")]
        public bool Scoped => GetProperty<bool>("scoped");
        [Export("initEvent")]
        public void InitEvent(string eventTypeArg, bool canBubbleArg, bool cancelableArg)
        {
            InvokeMethod<object>("initEvent", eventTypeArg, canBubbleArg, cancelableArg);
        }
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
    }
}
