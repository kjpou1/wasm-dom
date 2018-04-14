using System;
using Mono.WebAssembly;

namespace Mono.WebAssembly.DOM
{

    [Export("HTMLDivElement", typeof(Mono.WebAssembly.JSObject))]
    public sealed class HTMLDivElement : HTMLElement
    {
        internal HTMLDivElement(int handle) : base(handle) { }

        //public HTMLDivElement() { }
        [Export("align")]
        public string Align { get => GetProperty<string>("align"); set => SetProperty<string>("align", value); }
        [Export("noWrap")]
        public bool NoWrap { get => GetProperty<bool>("noWrap"); set => SetProperty<bool>("noWrap", value); }
    }
}