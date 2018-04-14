using System;
using Mono.WebAssembly;

namespace Mono.WebAssembly.DOM
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


    [Export("UIEvent", typeof(Mono.WebAssembly.JSObject))]
    public class UIEvent : Event
    {
        internal UIEvent(int handle) : base(handle) { }

//        public UIEvent(string typeArg, IUIEventInit eventInitDict) { }
        [Export("detail")]
        public double Detail => GetProperty<double>("detail");
        [Export("view")]
        public Window View => GetProperty<Window>("view");
        [Export("initUIEvent")]
        public void InitUiEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, double detailArg)
        {
            InvokeMethod<object>("initUIEvent", typeArg, canBubbleArg, cancelableArg, viewArg, detailArg);
        }
    }


    [Export("MouseEvent", typeof(Mono.WebAssembly.JSObject))]
    public class MouseEvent : UIEvent
    {
        internal MouseEvent(int handle) : base(handle) { }

        //public MouseEvent(string typeArg, IMouseEventInit eventInitDict) { }
        [Export("altKey")]
        public bool AltKey => GetProperty<bool>("altKey");
        [Export("button")]
        public double Button => GetProperty<double>("button");
        [Export("buttons")]
        public double Buttons => GetProperty<double>("buttons");
        [Export("clientX")]
        public double ClientX => GetProperty<double>("clientX");
        [Export("clientY")]
        public double ClientY => GetProperty<double>("clientY");
        [Export("ctrlKey")]
        public bool CtrlKey => GetProperty<bool>("ctrlKey");
        [Export("fromElement")]
        public Element FromElement => GetProperty<Element>("fromElement");
        [Export("layerX")]
        public double LayerX => GetProperty<double>("layerX");
        [Export("layerY")]
        public double LayerY => GetProperty<double>("layerY");
        [Export("metaKey")]
        public bool MetaKey => GetProperty<bool>("metaKey");
        [Export("movementX")]
        public double MovementX => GetProperty<double>("movementX");
        [Export("movementY")]
        public double MovementY => GetProperty<double>("movementY");
        [Export("offsetX")]
        public double OffsetX => GetProperty<double>("offsetX");
        [Export("offsetY")]
        public double OffsetY => GetProperty<double>("offsetY");
        [Export("pageX")]
        public double PageX => GetProperty<double>("pageX");
        [Export("pageY")]
        public double PageY => GetProperty<double>("pageY");
        [Export("relatedTarget")]
        public EventTarget RelatedTarget => GetProperty<EventTarget>("relatedTarget");
        [Export("screenX")]
        public double ScreenX => GetProperty<double>("screenX");
        [Export("screenY")]
        public double ScreenY => GetProperty<double>("screenY");
        [Export("shiftKey")]
        public bool ShiftKey => GetProperty<bool>("shiftKey");
        [Export("toElement")]
        public Element ToElement => GetProperty<Element>("toElement");
        [Export("which")]
        public double Which => GetProperty<double>("which");
        [Export("x")]
        public double X => GetProperty<double>("x");
        [Export("y")]
        public double Y => GetProperty<double>("y");
        [Export("getModifierState")]
        public bool GetModifierState(string keyArg)
        {
            return InvokeMethod<bool>("getModifierState", keyArg);
        }
        [Export("initMouseEvent")]
        public void InitMouseEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, double detailArg, double screenXArg, double screenYArg, double clientXArg, double clientYArg, bool ctrlKeyArg, bool altKeyArg, bool shiftKeyArg, bool metaKeyArg, double buttonArg, EventTarget relatedTargetArg)
        {
            InvokeMethod<object>("initMouseEvent", typeArg, canBubbleArg, cancelableArg, viewArg, detailArg, screenXArg, screenYArg, clientXArg, clientYArg, ctrlKeyArg, altKeyArg, shiftKeyArg, metaKeyArg, buttonArg, relatedTargetArg);
        }
    }


    [Export("PointerEvent", typeof(Mono.WebAssembly.JSObject))]
    public sealed class PointerEvent : MouseEvent
    {
        internal PointerEvent(int handle) : base(handle) { }

        //public PointerEvent(string typeArg, IPointerEventInit eventInitDict) { }
        [Export("currentPoint")]
        public Object CurrentPoint => GetProperty<Object>("currentPoint");
        [Export("height")]
        public double Height => GetProperty<double>("height");
        [Export("hwTimestamp")]
        public double HwTimestamp => GetProperty<double>("hwTimestamp");
        [Export("intermediatePoints")]
        public Object IntermediatePoints => GetProperty<Object>("intermediatePoints");
        [Export("isPrimary")]
        public bool IsPrimary => GetProperty<bool>("isPrimary");
        [Export("pointerId")]
        public double PointerId => GetProperty<double>("pointerId");
        [Export("pointerType")]
        public Object PointerType => GetProperty<Object>("pointerType");
        [Export("pressure")]
        public double Pressure => GetProperty<double>("pressure");
        [Export("rotation")]
        public double Rotation => GetProperty<double>("rotation");
        [Export("tiltX")]
        public double TiltX => GetProperty<double>("tiltX");
        [Export("tiltY")]
        public double TiltY => GetProperty<double>("tiltY");
        [Export("width")]
        public double Width => GetProperty<double>("width");
        [Export("getCurrentPoint")]
        public void GetCurrentPoint(Element element)
        {
            InvokeMethod<object>("getCurrentPoint", element);
        }
        [Export("getIntermediatePoints")]
        public void GetIntermediatePoints(Element element)
        {
            InvokeMethod<object>("getIntermediatePoints", element);
        }
        [Export("initPointerEvent")]
        public void InitPointerEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, double detailArg, double screenXArg, double screenYArg, double clientXArg, double clientYArg, bool ctrlKeyArg, bool altKeyArg, bool shiftKeyArg, bool metaKeyArg, double buttonArg, EventTarget relatedTargetArg, double offsetXArg, double offsetYArg, double widthArg, double heightArg, double pressure, double rotation, double tiltX, double tiltY, double pointerIdArg, Object pointerType, double hwTimestampArg, bool isPrimary)
        {
            InvokeMethod<object>("initPointerEvent", typeArg, canBubbleArg, cancelableArg, viewArg, detailArg, screenXArg, screenYArg, clientXArg, clientYArg, ctrlKeyArg, altKeyArg, shiftKeyArg, metaKeyArg, buttonArg, relatedTargetArg, offsetXArg, offsetYArg, widthArg, heightArg, pressure, rotation, tiltX, tiltY, pointerIdArg, pointerType, hwTimestampArg, isPrimary);
        }
    }



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