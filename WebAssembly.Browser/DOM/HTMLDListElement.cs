using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM 
{

[Export("HTMLDListElement", typeof(JSObject))]
public sealed class HTMLDListElement : HTMLElement, IHTMLDListElement {
    internal HTMLDListElement  (JSObject handle) : base (handle) {}

    //public HTMLDListElement () { }
    [Export("compact")]
    public bool Compact { get => GetProperty<bool>("compact"); set => SetProperty<bool>("compact", value); }
}

}