using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM
{

    [Export("HTMLPictureElement", typeof(JSObject))]
    public sealed class HTMLPictureElement : HTMLElement
    {
        internal HTMLPictureElement(JSObject handle) : base(handle) { }

        //public HTMLPictureElement() { }
    }
}