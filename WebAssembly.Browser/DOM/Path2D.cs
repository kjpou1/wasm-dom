using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM
{

    [Export("Path2D", typeof(JSObject))]
    public sealed class Path2D : DOMObject, IPath2D
    {
        internal Path2D(JSObject handle) : base(handle) { }

        //public Path2D(object d) { }
        [Export("arc")]
        public void Arc(double x, double y, double radius, double startAngle, double endAngle, bool anticlockwise)
        {
            InvokeMethod<object>("arc", x, y, radius, startAngle, endAngle, anticlockwise);
        }
        [Export("arcTo")]
        public void ArcTo(double x1, double y1, double x2, double y2, double radius)
        {
            InvokeMethod<object>("arcTo", x1, y1, x2, y2, radius);
        }
        [Export("arcTo")]
        public void ArcTo(double x1, double y1, double x2, double y2, double radiusX, double radiusY, double rotation)
        {
             InvokeMethod<object>("arcTo", x1, y1, x2, y2, radiusX, radiusY, rotation);
        }
        [Export("bezierCurveTo")]
        public void BezierCurveTo(double cp1x, double cp1y, double cp2x, double cp2y, double x, double y)
        {
            InvokeMethod<object>("bezierCurveTo", cp1x, cp1y, cp2x, cp2y, x, y);
        }
        [Export("closePath")]
        public void ClosePath()
        {
            InvokeMethod<object>("closePath");
        }
        [Export("ellipse")]
        public void Ellipse(double x, double y, double radiusX, double radiusY, double rotation, double startAngle, double endAngle, bool anticlockwise)
        {
            InvokeMethod<object>("ellipse", x, y, radiusX, radiusY, rotation, startAngle, endAngle, anticlockwise);
        }
        [Export("lineTo")]
        public void LineTo(double x, double y)
        {
            InvokeMethod<object>("lineTo", x, y);
        }
        [Export("moveTo")]
        public void MoveTo(double x, double y)
        {
            InvokeMethod<object>("moveTo", x, y);
        }
        [Export("quadraticCurveTo")]
        public void QuadraticCurveTo(double cpx, double cpy, double x, double y)
        {
            InvokeMethod<object>("quadraticCurveTo", cpx, cpy, x, y);
        }
        [Export("rect")]
        public void Rect(double x, double y, double w, double h)
        {
            InvokeMethod<object>("rect", x, y, w, h);
        }
    }

}