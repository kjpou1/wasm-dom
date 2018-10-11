using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM
{

    [Export("HTMLPreElement", typeof(JSObject))]
    public sealed class HTMLPreElement : HTMLElement, IHTMLPreElement
    {
        internal HTMLPreElement(JSObject handle) : base(handle) { }

        //public HTMLPreElement () { }
        [Export("width")]
        public double Width { get => GetProperty<double>("width"); set => SetProperty<double>("width", value); }
    }
}