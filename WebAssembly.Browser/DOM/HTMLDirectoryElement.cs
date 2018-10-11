using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM 
{

[Export("HTMLDirectoryElement", typeof(JSObject))]
    public sealed class HTMLDirectoryElement : HTMLElement, IHTMLDirectoryElement {
    internal HTMLDirectoryElement  (JSObject handle) : base (handle) {}

    //public HTMLDirectoryElement () { }
    [Export("compact")]
    public bool Compact { get => GetProperty<bool>("compact"); set => SetProperty<bool>("compact", value); }
}

}