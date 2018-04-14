using System;
using Mono.WebAssembly;

namespace Mono.WebAssembly.DOM
{

    [Export("HTMLTemplateElement", typeof(Mono.WebAssembly.JSObject))]
    public sealed class HTMLTemplateElement : HTMLElement
    {
        internal HTMLTemplateElement(int handle) : base(handle) { }

        //public HTMLTemplateElement() { }
        [Export("content")]
        public DocumentFragment Content => GetProperty<DocumentFragment>("content");
    }
}