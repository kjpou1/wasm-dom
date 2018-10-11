using System;
using System.Collections.Generic;
using WebAssembly;

namespace WebAssembly.Browser.DOM.Events
{


    [Export("KeyboardEvent", typeof(JSObject))]
    public sealed class KeyboardEvent : UIEvent
    {
        internal KeyboardEvent(JSObject handle) : base(handle) { }

        //public KeyboardEvent(string typeArg, KeyboardEventInit eventInitDict) { }
        [Export("DOM_KEY_LOCATION_JOYSTICK")]
        public double DomKeyLocationJoystick { get; internal set; }
        [Export("DOM_KEY_LOCATION_LEFT")]
        public double DomKeyLocationLeft { get; internal set; }
        [Export("DOM_KEY_LOCATION_MOBILE")]
        public double DomKeyLocationMobile { get; internal set; }
        [Export("DOM_KEY_LOCATION_NUMPAD")]
        public double DomKeyLocationNumpad { get; internal set; }
        [Export("DOM_KEY_LOCATION_RIGHT")]
        public double DomKeyLocationRight { get; internal set; }
        [Export("DOM_KEY_LOCATION_STANDARD")]
        public double DomKeyLocationStandard { get; internal set; }
        [Export("altKey")]
        public bool AltKey { get; internal set; }
        [Export("char")]
        public string Char { get; internal set; }
        [Export("charCode")]
        public double CharCode { get; internal set; }
        [Export("ctrlKey")]
        public bool CtrlKey { get; internal set; }
        [Export("key")]
        public string Key { get; internal set; }
        [Export("keyCode")]
        public double KeyCode { get; internal set; }
        [Export("locale")]
        public string Locale { get; internal set; }
        [Export("location")]
        public double Location { get; internal set; }
        [Export("metaKey")]
        public bool MetaKey { get; internal set; }
        [Export("repeat")]
        public bool Repeat { get; internal set; }
        [Export("shiftKey")]
        public bool ShiftKey { get; internal set; }
        [Export("which")]
        public double Which { get; internal set; }
        [Export("code")]
        public string Code { get; internal set; }
        [Export("getModifierState")]
        public bool GetModifierState(string keyArg)
        {
            return InvokeMethod<bool>("getModifierState", keyArg);
        }
        //[Export("initKeyboardEvent")]
        //public void InitKeyboardEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, string keyArg, double locationArg, string modifiersListArg, bool repeat, string locale)
        //{
        //    InvokeMethod<object>("initKeyboardEvent", typeArg, canBubbleArg, cancelableArg, viewArg, keyArg, locationArg, modifiersListArg, repeat, locale);
        //}

        internal override void InitEvent(Dictionary<string, string> eventInfoDic)
        {
            base.InitEvent(eventInfoDic);
            string value = null;

            if (eventInfoDic.TryGetValue("altKey", out value))
            {
                AltKey = Convert.ToBoolean(value);
            }

            if (eventInfoDic.TryGetValue("char", out value))
            {
                Char = Convert.ToString(value);
            }


            if (eventInfoDic.TryGetValue("charCode", out value))
            {
                CharCode = Convert.ToInt32(value);
            }

            if (eventInfoDic.TryGetValue("ctrlKey", out value))
            {
                CtrlKey = Convert.ToBoolean(value);
            }


            if (eventInfoDic.TryGetValue("key", out value))
            {
                Key = Convert.ToString(value);
            }

            if (eventInfoDic.TryGetValue("keyCode", out value))
            {
                KeyCode = Convert.ToInt32(value);
            }

            if (eventInfoDic.TryGetValue("locale", out value))
            {
                Locale = Convert.ToString(value);
            }

            if (eventInfoDic.TryGetValue("location", out value))
            {
                Location = Convert.ToInt32(value);
            }

            if (eventInfoDic.TryGetValue("metaKey", out value))
            {
                MetaKey = Convert.ToBoolean(value);
            }

            if (eventInfoDic.TryGetValue("repeat", out value))
            {
                Repeat = Convert.ToBoolean(value);
            }

            if (eventInfoDic.TryGetValue("shiftKey", out value))
            {
                ShiftKey = Convert.ToBoolean(value);
            }

            if (eventInfoDic.TryGetValue("which", out value))
            {
                Which = Convert.ToInt32(value);
            }

            if (eventInfoDic.TryGetValue("code", out value))
            {
                Code = Convert.ToString(value);
            }

            if (eventInfoDic.TryGetValue("DOM_KEY_LOCATION_JOYSTICK", out value))
            {
                DomKeyLocationJoystick = Convert.ToInt32(value);
            }

            if (eventInfoDic.TryGetValue("DOM_KEY_LOCATION_LEFT", out value))
            {
                DomKeyLocationLeft = Convert.ToInt32(value);
            }

            if (eventInfoDic.TryGetValue("DOM_KEY_LOCATION_MOBILE", out value))
            {
                DomKeyLocationMobile = Convert.ToInt32(value);
            }

            if (eventInfoDic.TryGetValue("DOM_KEY_LOCATION_NUMPAD", out value))
            {
                DomKeyLocationNumpad = Convert.ToInt32(value);
            }

            if (eventInfoDic.TryGetValue("DOM_KEY_LOCATION_RIGHT", out value))
            {
                DomKeyLocationRight = Convert.ToInt32(value);
            }

            if (eventInfoDic.TryGetValue("DOM_KEY_LOCATION_STANDARD", out value))
            {
                DomKeyLocationStandard = Convert.ToInt32(value);
            }
        }

    }
}