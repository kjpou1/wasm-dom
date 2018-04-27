using System;
using System.Collections.Generic;

namespace Mono.WebAssembly.Browser.DOM
{
    public sealed partial class Document
    {

        static Dictionary<Type, string> elementTypeMap = new Dictionary<Type, string>()
        {
            {typeof(HTMLAnchorElement), "a"},
            {typeof(HTMLAreaElement), "area"},
            {typeof(HTMLBaseElement), "base"},
            {typeof(HTMLDivElement), "div"},
            {typeof(HTMLButtonElement), "button"},
            {typeof(HTMLBRElement), "br"},
            {typeof(HTMLInputElement), "input"},
            {typeof(HTMLFieldSetElement), "fieldset"},
            {typeof(HTMLFormElement), "form"},
            {typeof(HTMLLabelElement), "label"},
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

            // When called on an HTML document, createElement() converts tagName to lower case before creating the element
            return InvokeMethod<T>("createElement", tagName);
        }        
    }
}
