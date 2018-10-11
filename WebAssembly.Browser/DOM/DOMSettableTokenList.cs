using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM
{

    [Export("DOMSettableTokenList", typeof(JSObject))]
    public sealed class DOMSettableTokenList : DOMTokenList, IDOMSettableTokenList
    {
        internal DOMSettableTokenList(JSObject handle) : base(handle) { }

        //public DOMSettableTokenList() { }
        [Export("value")]
        public string Value { get => GetProperty<string>("value"); set => SetProperty<string>("value", value); }
    }
}