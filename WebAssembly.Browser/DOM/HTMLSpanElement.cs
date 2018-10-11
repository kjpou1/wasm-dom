using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM
{

    [Export("HTMLSpanElement", typeof(JSObject))]
    public sealed class HTMLSpanElement : HTMLElement, IHTMLSpanElement
    {
        internal HTMLSpanElement(JSObject handle) : base(handle) { }

        //public HTMLSpanElement () { }
    }
}