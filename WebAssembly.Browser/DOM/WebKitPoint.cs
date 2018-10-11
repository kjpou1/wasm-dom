using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM
{

    [Export("WebKitPoint", typeof(JSObject))]
    public sealed class WebKitPoint : DOMObject
    {
        public WebKitPoint(JSObject handle) : base(handle) { }

        //public WebKitPoint(double x, double y) { }
        [Export("x")]
        public double X { get => GetProperty<double>("x"); set => SetProperty<double>("x", value); }
        [Export("y")]
        public double Y { get => GetProperty<double>("y"); set => SetProperty<double>("y", value); }
    }
}