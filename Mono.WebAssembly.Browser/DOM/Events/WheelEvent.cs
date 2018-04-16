using System;
namespace Mono.WebAssembly.Browser.DOM.Events
{

    [Export("WheelEvent", typeof(Mono.WebAssembly.JSObject))]
    public sealed class WheelEvent : MouseEvent
    {
        internal WheelEvent(int handle) : base(handle) { }

        //public WheelEvent(string typeArg, IWheelEventInit eventInitDict) { }
        [Export("DOM_DELTA_LINE")]
        public double DomDeltaLine => GetProperty<double>("DOM_DELTA_LINE");
        [Export("DOM_DELTA_PAGE")]
        public double DomDeltaPage => GetProperty<double>("DOM_DELTA_PAGE");
        [Export("DOM_DELTA_PIXEL")]
        public double DomDeltaPixel => GetProperty<double>("DOM_DELTA_PIXEL");
        [Export("deltaMode")]
        public double DeltaMode => GetProperty<double>("deltaMode");
        [Export("deltaX")]
        public double DeltaX => GetProperty<double>("deltaX");
        [Export("deltaY")]
        public double DeltaY => GetProperty<double>("deltaY");
        [Export("deltaZ")]
        public double DeltaZ => GetProperty<double>("deltaZ");
        [Export("wheelDelta")]
        public double WheelDelta => GetProperty<double>("wheelDelta");
        [Export("wheelDeltaX")]
        public double WheelDeltaX => GetProperty<double>("wheelDeltaX");
        [Export("wheelDeltaY")]
        public double WheelDeltaY => GetProperty<double>("wheelDeltaY");
        [Export("getCurrentPoint")]
        public void GetCurrentPoint(Element element)
        {
            InvokeMethod<object>("getCurrentPoint", element);
        }
        //[Export("initWheelEvent")]
        //public void InitWheelEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, double detailArg, double screenXArg, double screenYArg, double clientXArg, double clientYArg, double buttonArg, EventTarget relatedTargetArg, string modifiersListArg, double deltaXArg, double deltaYArg, double deltaZArg, double deltaMode)
        //{
        //    InvokeMethod<object>("initWheelEvent", typeArg, canBubbleArg, cancelableArg, viewArg, detailArg, screenXArg, screenYArg, clientXArg, clientYArg, buttonArg, relatedTargetArg, modifiersListArg, deltaXArg, deltaYArg, deltaZArg, deltaMode);
        //}
    }

}
