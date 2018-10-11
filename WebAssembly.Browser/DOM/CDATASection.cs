using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM
{

    [Export("CDATASection", typeof(JSObject))]
    public sealed class CDATASection : Text
    {
        internal CDATASection(JSObject handle) : base(handle) { }

        //public CDATASection() { }
    }
}