using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM
{

    [Export("HTMLQuoteElement", typeof(JSObject))]
    public sealed class HTMLQuoteElement : HTMLElement, IHTMLQuoteElement
    {
        internal HTMLQuoteElement(JSObject handle) : base(handle) { }

        //public HTMLQuoteElement() { }
        [Export("cite")]
        public string Cite { get => GetProperty<string>("cite"); set => SetProperty<string>("cite", value); }
    }
}