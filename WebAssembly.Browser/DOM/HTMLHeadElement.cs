using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM
{

    [Export("HTMLHeadElement", typeof(JSObject))]
    public sealed class HTMLHeadElement : HTMLElement
    {
        internal HTMLHeadElement(JSObject handle) : base(handle) { }

        //public HTMLHeadElement() { }
        [Export("profile")]
        public string Profile { get => GetProperty<string>("profile"); set => SetProperty<string>("profile", value); }
    }
}