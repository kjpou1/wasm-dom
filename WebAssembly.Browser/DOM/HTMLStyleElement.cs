using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM
{

    [Export("HTMLStyleElement", typeof(JSObject))]
    public sealed class HTMLStyleElement : HTMLElement, IHTMLStyleElement
    {
        internal HTMLStyleElement(JSObject handle) : base(handle) { }

        //public HTMLStyleElement() { }
        [Export("disabled")]
        public bool Disabled { get => GetProperty<bool>("disabled"); set => SetProperty<bool>("disabled", value); }
        [Export("media")]
        public string Media { get => GetProperty<string>("media"); set => SetProperty<string>("media", value); }
        [Export("type")]
        public string Type { get => GetProperty<string>("type"); set => SetProperty<string>("type", value); }
        [Export("sheet")]
        public StyleSheet Sheet => GetProperty<StyleSheet>("sheet");
    }
}