using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM
{

    [Export("HTMLHtmlElement", typeof(JSObject))]
    public sealed class HTMLHtmlElement : HTMLElement, IHTMLHtmlElement
    {
        internal HTMLHtmlElement(JSObject handle) : base(handle) { }

        //public HTMLHtmlElement() { }
        [Export("version")]
        public string Version { get => GetProperty<string>("version"); set => SetProperty<string>("version", value); }
    }
}