using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM
{

    [Export("HTMLLegendElement", typeof(JSObject))]
    public sealed class HTMLLegendElement : HTMLElement, IHTMLLegendElement
    {
        internal HTMLLegendElement(JSObject handle) : base(handle) { }

        //public HTMLLegendElement () { }
        [Export("align")]
        public string Align { get => GetProperty<string>("align"); set => SetProperty<string>("align", value); }
        [Export("form")]
        public HTMLFormElement Form => GetProperty<HTMLFormElement>("form");
    }
}