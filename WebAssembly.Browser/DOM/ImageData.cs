using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM
{

    [Export("ImageData", typeof(JSObject))]
    public sealed class ImageData : DOMObject, IImageData
    {
        internal ImageData(JSObject handle) : base(handle) { }

        //public ImageData(double width, double height) { }
        //public ImageData(byte[] array, double width, double height) { }
        [Export("data")]
        public byte[] Data => GetProperty<byte[]>("data");
        [Export("height")]
        public double Height => GetProperty<double>("height");
        [Export("width")]
        public double Width => GetProperty<double>("width");
    }
}