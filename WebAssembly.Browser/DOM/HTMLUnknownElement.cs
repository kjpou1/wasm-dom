using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM
{

    [Export("HTMLUnknownElement", typeof(JSObject))]
    public sealed class HTMLUnknownElement : HTMLElement
    {
        internal HTMLUnknownElement(JSObject handle) : base(handle) { }

        //public HTMLUnknownElement () { }
    }
}