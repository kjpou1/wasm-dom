using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM 
{

    [Export("DocumentType", typeof(JSObject))]
    public sealed class DocumentType : Node, IDocumentType
    {
        internal DocumentType(JSObject handle) : base(handle) { }

        //public DocumentType() { }
        [Export("entities")]
        public NamedNodeMap Entities => GetProperty<NamedNodeMap>("entities");
        [Export("internalSubset")]
        public string InternalSubset => GetProperty<string>("internalSubset");
        [Export("name")]
        public string Name => GetProperty<string>("name");
        [Export("notations")]
        public NamedNodeMap Notations => GetProperty<NamedNodeMap>("notations");
        [Export("publicId")]
        public string PublicId => GetProperty<string>("publicId");
        [Export("systemId")]
        public string SystemId => GetProperty<string>("systemId");
        [Export("remove")]
        public void Remove()
        {
            InvokeMethod<object>("remove");
        }
    }
}