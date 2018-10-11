using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM
{

    [Export("HTMLUListElement", typeof(JSObject))]
    public sealed class HTMLUListElement : HTMLElement, IHTMLUListElement
    {
        internal HTMLUListElement(JSObject handle) : base(handle) { }

        //public HTMLUListElement() { }
        [Export("compact")]
        public bool Compact { get => GetProperty<bool>("compact"); set => SetProperty<bool>("compact", value); }
        [Export("type")]
        public string Type { get => GetProperty<string>("type"); set => SetProperty<string>("type", value); }
    }

}