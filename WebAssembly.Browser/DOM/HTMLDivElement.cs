using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM
{

    [Export("HTMLDivElement", typeof(JSObject))]
    public sealed class HTMLDivElement : HTMLElement, IHTMLDivElement
    {
        //internal HTMLDivElement(JSObject handle) : base(handle) { }
        internal HTMLDivElement(JSObject jsObject) : base(jsObject) { }
        //public HTMLDivElement() { }
        [Export("align")]
        public string Align { get => GetProperty<string>("align"); set => SetProperty<string>("align", value); }
        [Export("noWrap")]
        public bool NoWrap { get => GetProperty<bool>("noWrap"); set => SetProperty<bool>("noWrap", value); }
    }
}