using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM
{

    [Export("TimeRanges", typeof(JSObject))]
    public sealed class TimeRanges : DOMObject
    {
        internal TimeRanges(JSObject handle) : base(handle) { }

        //public TimeRanges() { }
        [Export("length")]
        public double Length => GetProperty<double>("length");
        [Export("end")]
        public double End(double index)
        {
            return InvokeMethod<double>("end", index);
        }
        [Export("start")]
        public double Start(double index)
        {
            return InvokeMethod<double>("start", index);
        }
    }
}