using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM
{

    [Export("PerformanceNavigation", typeof(JSObject))]
    public sealed class PerformanceNavigation : DOMObject
    {
        internal PerformanceNavigation(JSObject handle) : base(handle) { }

        //public PerformanceNavigation() { }
        [Export("TYPE_BACK_FORWARD")]
        public double TypeBackForward => GetProperty<double>("TYPE_BACK_FORWARD");
        [Export("TYPE_NAVIGATE")]
        public double TypeNavigate => GetProperty<double>("TYPE_NAVIGATE");
        [Export("TYPE_RELOAD")]
        public double TypeReload => GetProperty<double>("TYPE_RELOAD");
        [Export("TYPE_RESERVED")]
        public double TypeReserved => GetProperty<double>("TYPE_RESERVED");
        [Export("redirectCount")]
        public double RedirectCount => GetProperty<double>("redirectCount");
        [Export("type")]
        public double Type => GetProperty<double>("type");
        [Export("toJSON")]
        public string ToJson()
        {
            return InvokeMethod<string>("toJSON");
        }
    }
}