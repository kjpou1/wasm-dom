using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM
{

    [Export("HTMLMenuElement", typeof(JSObject))]
    public sealed class HTMLMenuElement : HTMLElement, IHTMLMenuElement
    {
        internal HTMLMenuElement(JSObject handle) : base(handle) { }

        //public HTMLMenuElement () { }
        [Export("compact")]
        public bool Compact { get => GetProperty<bool>("compact"); set => SetProperty<bool>("compact", value); }
        [Export("type")]
        public string Type { get => GetProperty<string>("type"); set => SetProperty<string>("type", value); }
    }
}