using System;
namespace Mono.WebAssembly.Browser.DOM.Events
{
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

}
