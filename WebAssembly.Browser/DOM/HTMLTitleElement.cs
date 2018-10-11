using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM
{

    [Export("HTMLTitleElement", typeof(JSObject))]
    public sealed class HTMLTitleElement : HTMLElement, IHTMLSpanElement
    {
        internal HTMLTitleElement(JSObject handle) : base(handle) { }

        //public HTMLTitleElement() { }
        [Export("text")]
        public string Text { get => GetProperty<string>("text"); set => SetProperty<string>("text", value); }
    }
}