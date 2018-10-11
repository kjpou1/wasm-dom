using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM
{

    [Export("HTMLHeadingElement", typeof(JSObject))]
    public sealed class HTMLHeadingElement : HTMLElement, IHTMLHeadingElement
    {
        internal HTMLHeadingElement(JSObject handle) : base(handle) { }

        //public HTMLHeadingElement() { }
        [Export("align")]
        public string Align { get => GetProperty<string>("align"); set => SetProperty<string>("align", value); }
    }

}