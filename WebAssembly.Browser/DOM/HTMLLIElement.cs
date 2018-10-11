using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM
{

    [Export("HTMLLIElement", typeof(JSObject))]
    public sealed class HTMLLIElement : HTMLElement, IHTMLLIElement
    {
        internal HTMLLIElement(JSObject handle) : base(handle) { }

        //public HTMLLIElement () { }
        [Export("type")]
        public string Type { get => GetProperty<string>("type"); set => SetProperty<string>("type", value); }
        [Export("value")]
        public double Value { get => GetProperty<double>("value"); set => SetProperty<double>("value", value); }
    }
}