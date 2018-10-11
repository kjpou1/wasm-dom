using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM
{

    [Export("HTMLTableDataCellElement", typeof(JSObject))]
    public sealed class HTMLTableDataCellElement : HTMLTableCellElement, IHTMLTableDataCellElement
    {
        internal HTMLTableDataCellElement(JSObject handle) : base(handle) { }

        //public HTMLTableDataCellElement () { }
    }
}