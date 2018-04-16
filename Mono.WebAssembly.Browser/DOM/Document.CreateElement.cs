using System;
using System.Collections.Generic;

namespace Mono.WebAssembly.Browser.DOM
{
    public sealed partial class Document
    {

        static Dictionary<Type, string> elementTypeMap = new Dictionary<Type, string>()
        {
            {typeof(HTMLDivElement), "div"},
            {typeof(HTMLButtonElement), "button"},
            {typeof(HTMLLIElement), "li"},
            {typeof(HTMLLinkElement), "link"},
            {typeof(HTMLParagraphElement), "p"},
            {typeof(HTMLTemplateElement), "template"},
            {typeof(HTMLUListElement), "ul"},
        };

        [Export("createElement")]
        public T CreateElement<T>()
        {
            var tagName = string.Empty;
            if (!elementTypeMap.TryGetValue(typeof(T), out tagName))
                throw new NotSupportedException($"Element of type {typeof(T)} is not supported yet.  Please use the method CreateElement(tagName).");

            return InvokeMethod<T>("createElement", tagName);
        }        
    }
}
