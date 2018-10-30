using System;
namespace WebAssembly.Browser.DOM
{
    [Export("HTMLCanvasElement", typeof(JSObject))]
    public sealed class HTMLCanvasElement : HTMLElement
    {
        internal HTMLCanvasElement(JSObject handle) : base(handle) { }

        //public HTMLCanvasElement() { }
        [Export("height")]
        public double Height { get => GetProperty<double>("height"); set => SetProperty<double>("height", value); }
        [Export("width")]
        public double Width { get => GetProperty<double>("width"); set => SetProperty<double>("width", value); }
        //[Export("dataset")]
        //public DOMStringMap Dataset => GetProperty<DOMStringMap>("dataset");
        //[Export("style")]
        //public CSSStyleDeclaration Style => GetProperty<CSSStyleDeclaration>("style");
        //[Export("getContext")]
        //public CanvasRenderingContext2D GetContext(string contextId, Canvas2DContextAttributes contextAttributes)
        //{
        //    return InvokeMethod<CanvasRenderingContext2D>("getContext", contextId, contextAttributes);
        //}
        [Export("getContext")]
        public CanvasRenderingContext2D GetContext2D()//Canvas2DContextAttributes contextAttributes)
        {
            return InvokeMethod<CanvasRenderingContext2D>("getContext", "2d");//, contextAttributes);
        }
        //[Export("msToBlob")]
        //public Blob MsToBlob()
        //{
        //    return InvokeMethod<Blob>("msToBlob");
        //}
        [Export("toBlob")]
        public void ToBlob(Action callback, string type, params Object[] arguments)
        {
            InvokeMethod<object>("toBlob", callback, type, arguments);
        }
        [Export("toDataURL")]
        public string ToDataUrl(string type, params Object[] args)
        {
            return InvokeMethod<string>("toDataURL", type, args);
        }
        //[Export("msGetInputContext")]
        //public MSInputMethodContext MsGetInputContext()
        //{
        //    return InvokeMethod<MSInputMethodContext>("msGetInputContext");
        //}
    }
}
