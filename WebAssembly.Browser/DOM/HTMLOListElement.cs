using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM
{

    [Export("HTMLOListElement", typeof(JSObject))]
    public sealed class HTMLOListElement : HTMLElement, IHTMLOListElement
    {
        internal HTMLOListElement(JSObject handle) : base(handle) { }

        //public HTMLOListElement() { }
        [Export("compact")]
        public bool Compact { get => GetProperty<bool>("compact"); set => SetProperty<bool>("compact", value); }
        [Export("start")]
        public double Start { get => GetProperty<double>("start"); set => SetProperty<double>("start", value); }
        [Export("type")]
        public string Type { get => GetProperty<string>("type"); set => SetProperty<string>("type", value); }
    }
}