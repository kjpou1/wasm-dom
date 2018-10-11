using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM
{

    [Export("HTMLDataListElement", typeof(JSObject))]
    public sealed class HTMLDataListElement : HTMLElement, IHTMLDataListElement
    {
        internal HTMLDataListElement(JSObject handle) : base(handle) { }

        //public HTMLDataListElement () { }
        [Export("options")]
        public HTMLCollectionOf<HTMLOptionElement> Options { get => GetProperty<HTMLCollectionOf<HTMLOptionElement>>("options"); set => SetProperty<HTMLCollectionOf<HTMLOptionElement>>("options", value); }
    }

}