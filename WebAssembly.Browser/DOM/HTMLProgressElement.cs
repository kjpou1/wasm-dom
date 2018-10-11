using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM
{

    [Export("HTMLProgressElement", typeof(JSObject))]
    public sealed class HTMLProgressElement : HTMLElement, IHTMLProgressElement
    {
        internal HTMLProgressElement(JSObject handle) : base(handle) { }

        //public HTMLProgressElement () { }
        [Export("form")]
        public HTMLFormElement Form => GetProperty<HTMLFormElement>("form");
        [Export("max")]
        public double Max { get => GetProperty<double>("max"); set => SetProperty<double>("max", value); }
        [Export("position")]
        public double Position => GetProperty<double>("position");
        [Export("value")]
        public double Value { get => GetProperty<double>("value"); set => SetProperty<double>("value", value); }
    }

}