using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM
{

    // experimental technology https://developer.mozilla.org/en-US/docs/Web/API/CanvasPattern/setTransform
    // do not use for now
    [Export("SVGMatrix", typeof(JSObject))]
    public sealed class SVGMatrix : DOMObject, ISVGMatrix
    {
        internal SVGMatrix(JSObject handle) : base(handle) { }

        //public SVGMatrix() { }
        [Export("a")]
        public double A { get => GetProperty<double>("a"); set => SetProperty<double>("a", value); }
        [Export("b")]
        public double B { get => GetProperty<double>("b"); set => SetProperty<double>("b", value); }
        [Export("c")]
        public double C { get => GetProperty<double>("c"); set => SetProperty<double>("c", value); }
        [Export("d")]
        public double D { get => GetProperty<double>("d"); set => SetProperty<double>("d", value); }
        [Export("e")]
        public double E { get => GetProperty<double>("e"); set => SetProperty<double>("e", value); }
        [Export("f")]
        public double F { get => GetProperty<double>("f"); set => SetProperty<double>("f", value); }
        [Export("flipX")]
        public ISVGMatrix FlipX()
        {
            return InvokeMethod<SVGMatrix>("flipX");
        }
        [Export("flipY")]
        public ISVGMatrix FlipY()
        {
            return InvokeMethod<SVGMatrix>("flipY");
        }
        [Export("inverse")]
        public ISVGMatrix Inverse()
        {
            return InvokeMethod<SVGMatrix>("inverse");
        }
        [Export("multiply")]
        public ISVGMatrix Multiply(ISVGMatrix secondMatrix)
        {
            return InvokeMethod<SVGMatrix>("multiply", secondMatrix);
        }
        [Export("rotate")]
        public ISVGMatrix Rotate(double angle)
        {
            return InvokeMethod<SVGMatrix>("rotate", angle);
        }
        [Export("rotateFromVector")]
        public ISVGMatrix RotateFromVector(double x, double y)
        {
            return InvokeMethod<SVGMatrix>("rotateFromVector", x, y);
        }
        [Export("scale")]
        public ISVGMatrix Scale(double scaleFactor)
        {
            return InvokeMethod<SVGMatrix>("scale", scaleFactor);
        }
        [Export("scaleNonUniform")]
        public ISVGMatrix ScaleNonUniform(double scaleFactorX, double scaleFactorY)
        {
            return InvokeMethod<SVGMatrix>("scaleNonUniform", scaleFactorX, scaleFactorY);
        }
        [Export("skewX")]
        public ISVGMatrix SkewX(double angle)
        {
            return InvokeMethod<SVGMatrix>("skewX", angle);
        }
        [Export("skewY")]
        public ISVGMatrix SkewY(double angle)
        {
            return InvokeMethod<SVGMatrix>("skewY", angle);
        }
        [Export("translate")]
        public ISVGMatrix Translate(double x, double y)
        {
            return InvokeMethod<SVGMatrix>("translate", x, y);
        }
    }
}