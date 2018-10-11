using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM
{



    [Export("DocumentFragment", typeof(JSObject))]
    public sealed class DocumentFragment : Node
    {
        internal DocumentFragment(JSObject handle) : base(handle) { }

        //public DocumentFragment() { }
        [Export("children")]
        public HTMLCollection Children => GetProperty<HTMLCollection>("children");
        [Export("firstElementChild")]
        public Element FirstElementChild => GetProperty<Element>("firstElementChild");
        [Export("lastElementChild")]
        public Element LastElementChild => GetProperty<Element>("lastElementChild");
        [Export("childElementCount")]
        public double ChildElementCount => GetProperty<double>("childElementCount");
        [Export("getElementById")]
        public HTMLElement GetElementById(string elementId)
        {
            return InvokeMethod<HTMLElement>("getElementById", elementId);
        }
    }
}