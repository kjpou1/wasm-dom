using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM
{

    [Export("HTMLDataElement", typeof(JSObject))]
    public sealed class HTMLDataElement : HTMLElement, IHTMLDataElement
    {
        internal HTMLDataElement(JSObject handle) : base(handle) { }

        //public HTMLDataElement() { }
        [Export("value")]
        public string Value { get => GetProperty<string>("value"); set => SetProperty<string>("value", value); }
    }

}