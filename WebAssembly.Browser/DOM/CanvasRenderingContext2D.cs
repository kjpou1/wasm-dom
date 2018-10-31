using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM
{


    [Export("CanvasRenderingContext2D", typeof(JSObject))]
    public sealed class CanvasRenderingContext2D : DOMObject, ICanvasRenderingContext2D
    {
        internal CanvasRenderingContext2D(JSObject handle) : base(handle) { }

        //public CanvasRenderingContext2D() { }
        [Export("canvas")]
        public HTMLCanvasElement Canvas => GetProperty<HTMLCanvasElement>("canvas");
        [Export("fillStyle")]
        public object FillStyle { get => GetProperty<object>("fillStyle"); set => SetProperty<object>("fillStyle", value); }
        [Export("font")]
        public string Font { get => GetProperty<string>("font"); set => SetProperty<string>("font", value); }
        [Export("globalAlpha")]
        public double GlobalAlpha { get => GetProperty<double>("globalAlpha"); set => SetProperty<double>("globalAlpha", value); }
        [Export("globalCompositeOperation")]
        public string GlobalCompositeOperation { get => GetProperty<string>("globalCompositeOperation"); set => SetProperty<string>("globalCompositeOperation", value); }
        [Export("imageSmoothingEnabled")]
        public bool ImageSmoothingEnabled { get => GetProperty<bool>("imageSmoothingEnabled"); set => SetProperty<bool>("imageSmoothingEnabled", value); }
        [Export("lineCap")]
        public LineCap LineCap { get => GetProperty<LineCap>("lineCap"); set => SetProperty<LineCap>("lineCap", value); }
        [Export("lineDashOffset")]
        public double LineDashOffset { get => GetProperty<double>("lineDashOffset"); set => SetProperty<double>("lineDashOffset", value); }
        [Export("lineJoin")]
        public LineJoin LineJoin { get => GetProperty<LineJoin>("lineJoin"); set => SetProperty<LineJoin>("lineJoin", value); }
        [Export("lineWidth")]
        public double LineWidth { get => GetProperty<double>("lineWidth"); set => SetProperty<double>("lineWidth", value); }
        [Export("miterLimit")]
        public double MiterLimit { get => GetProperty<double>("miterLimit"); set => SetProperty<double>("miterLimit", value); }
        [Export("mozImageSmoothingEnabled")]
        public bool MozImageSmoothingEnabled { get => GetProperty<bool>("mozImageSmoothingEnabled"); set => SetProperty<bool>("mozImageSmoothingEnabled", value); }
        [Export("msFillRule")]
        public CanvasFillRule MsFillRule { get => GetProperty<CanvasFillRule>("msFillRule"); set => SetProperty<CanvasFillRule>("msFillRule", value); }
        [Export("oImageSmoothingEnabled")]
        public bool OImageSmoothingEnabled { get => GetProperty<bool>("oImageSmoothingEnabled"); set => SetProperty<bool>("oImageSmoothingEnabled", value); }
        [Export("shadowBlur")]
        public double ShadowBlur { get => GetProperty<double>("shadowBlur"); set => SetProperty<double>("shadowBlur", value); }
        [Export("shadowColor")]
        public string ShadowColor { get => GetProperty<string>("shadowColor"); set => SetProperty<string>("shadowColor", value); }
        [Export("shadowOffsetX")]
        public double ShadowOffsetX { get => GetProperty<double>("shadowOffsetX"); set => SetProperty<double>("shadowOffsetX", value); }
        [Export("shadowOffsetY")]
        public double ShadowOffsetY { get => GetProperty<double>("shadowOffsetY"); set => SetProperty<double>("shadowOffsetY", value); }
        [Export("strokeStyle")]
        public object StrokeStyle { get => GetProperty<object>("strokeStyle"); set => SetProperty<object>("strokeStyle", value); }
        [Export("textAlign")]
        public TextAlign TextAlign { get => GetProperty<TextAlign>("textAlign"); set => SetProperty<TextAlign>("textAlign", value); }
        [Export("textBaseline")]
        public TextBaseline TextBaseline { get => GetProperty<TextBaseline>("textBaseline"); set => SetProperty<TextBaseline>("textBaseline", value); }
        [Export("webkitImageSmoothingEnabled")]
        public bool WebkitImageSmoothingEnabled { get => GetProperty<bool>("webkitImageSmoothingEnabled"); set => SetProperty<bool>("webkitImageSmoothingEnabled", value); }
        [Export("beginPath")]
        public void BeginPath()
        {
            InvokeMethod<object>("beginPath");
        }
        [Export("clearRect")]
        public void ClearRect(double x, double y, double w, double h)
        {
            InvokeMethod<object>("clearRect", x, y, w, h);
        }
        [Export("clip")]
        public void Clip(CanvasFillRule fillRule = CanvasFillRule.NonZero)
        {
            InvokeMethod<object>("clip", fillRule);
        }
        [Export("clip")]
        public void Clip(Path2D path, CanvasFillRule fillRule = CanvasFillRule.NonZero)
        {
            InvokeMethod<object>("clip", path, fillRule);
        }
        [Export("createImageData")]
        public ImageData CreateImageData(object imageDataOrSw, double sh)
        {
            return InvokeMethod<ImageData>("createImageData", imageDataOrSw, sh);
        }
        [Export("createLinearGradient")]
        public CanvasGradient CreateLinearGradient(double x0, double y0, double x1, double y1)
        {
            return InvokeMethod<CanvasGradient>("createLinearGradient", x0, y0, x1, y1);
        }
        [Export("createPattern")]
        public CanvasPattern CreatePattern(object image, string repetition)
        {
            return InvokeMethod<CanvasPattern>("createPattern", image, repetition);
        }
        [Export("createRadialGradient")]
        public CanvasGradient CreateRadialGradient(double x0, double y0, double r0, double x1, double y1, double r1)
        {
            return InvokeMethod<CanvasGradient>("createRadialGradient", x0, y0, r0, x1, y1, r1);
        }
        [Export("drawFocusIfNeeded")]
        public void DrawFocusIfNeeded(Element element)
        {
            InvokeMethod<object>("drawFocusIfNeeded", element);
        }
        [Export("drawFocusIfNeeded")]
        public void DrawFocusIfNeeded(Path2D path, Element element)
        {
            InvokeMethod<object>("drawFocusIfNeeded", path, element);
        }
        [Export("drawImage")]
        public void DrawImage(object image, double dstX, double dstY)
        {
            InvokeMethod<object>("drawImage", image, dstX, dstY);
        }
        [Export("drawImage")]
        public void DrawImage(object image, double dstX, double dstY, double dstW, double dstH)
        {
            InvokeMethod<object>("drawImage", image, dstX, dstY, dstW, dstH);
        }
        [Export("drawImage")]
        public void DrawImage(object image, double srcX, double srcY, double srcW, double srcH, double dstX, double dstY, double dstW, double dstH)
        {
            InvokeMethod<object>("drawImage", image, srcX, srcY, srcW, srcH, dstX, dstY, dstW, dstH);
        }


        [Export("fill")]
        public void Fill(CanvasFillRule fillRule = CanvasFillRule.NonZero)
        {
            InvokeMethod<object>("fill", fillRule = CanvasFillRule.NonZero);
        }
        [Export("fill")]
        public void Fill(Path2D path, CanvasFillRule fillRule = CanvasFillRule.NonZero)
        {
            InvokeMethod<object>("fill", path, fillRule);
        }

        [Export("fillRect")]
        public void FillRect(double x, double y, double w, double h)
        {
            InvokeMethod<object>("fillRect", x, y, w, h);
        }
        [Export("fillText")]
        public void FillText(string text, double x, double y, double maxWidth = Double.MaxValue)
        {
            InvokeMethod<object>("fillText", text, x, y, maxWidth);
        }
        [Export("getImageData")]
        public ImageData GetImageData(double sx, double sy, double sw, double sh)
        {
            return InvokeMethod<ImageData>("getImageData", sx, sy, sw, sh);
        }
        [Export("getLineDash")]
        public double[] GetLineDash()
        {
            return InvokeMethod<double[]>("getLineDash");
        }
        [Export("isPointInPath")]
        public bool IsPointInPath(double x, double y, CanvasFillRule fillRule = CanvasFillRule.NonZero)
        {
            return InvokeMethod<bool>("isPointInPath", x, y, fillRule);
        }
        [Export("isPointInPath")]
        public bool IsPointInPath(Path2D path, double x, double y, CanvasFillRule fillRule = CanvasFillRule.NonZero)
        {
            return InvokeMethod<bool>("isPointInPath", path, x, y, fillRule);
        }
        [Export("isPointInStroke")]
        public bool IsPointInStroke(double x, double y, CanvasFillRule fillRule = CanvasFillRule.NonZero)
        {
            return InvokeMethod<bool>("isPointInStroke", x, y, fillRule);
        }
        [Export("isPointInStroke")]
        public bool IsPointInStroke(Path2D path, double x, double y, CanvasFillRule fillRule = CanvasFillRule.NonZero)
        {
            return InvokeMethod<bool>("isPointInStroke", path, x, y, fillRule);
        }
        [Export("measureText")]
        public TextMetrics MeasureText(string text)
        {
            return InvokeMethod<TextMetrics>("measureText", text);
        }
        [Export("putImageData")]
        public void PutImageData(ImageData imagedata, double dx, double dy, double dirtyX, double dirtyY, double dirtyWidth, double dirtyHeight)
        {
            InvokeMethod<object>("putImageData", imagedata, dx, dy, dirtyX, dirtyY, dirtyWidth, dirtyHeight);
        }
        [Export("restore")]
        public void Restore()
        {
            InvokeMethod<object>("restore");
        }
        [Export("rotate")]
        public void Rotate(double angle)
        {
            InvokeMethod<object>("rotate", angle);
        }
        [Export("save")]
        public void Save()
        {
            InvokeMethod<object>("save");
        }
        [Export("scale")]
        public void Scale(double x, double y)
        {
            InvokeMethod<object>("scale", x, y);
        }
        [Export("setLineDash")]
        public void SetLineDash(double[] segments)
        {
            InvokeMethod<object>("setLineDash", segments);
        }
        [Export("setTransform")]
        public void SetTransform(double m11, double m12, double m21, double m22, double dx, double dy)
        {
            InvokeMethod<object>("setTransform", m11, m12, m21, m22, dx, dy);
        }
        [Export("stroke")]
        public void Stroke(Path2D path = null)
        {
            if (path == null)
                InvokeMethod<object>("stroke");
            else
                InvokeMethod<object>("stroke", path);
        }
        [Export("strokeRect")]
        public void StrokeRect(double x, double y, double w, double h)
        {
            InvokeMethod<object>("strokeRect", x, y, w, h);
        }
        [Export("strokeText")]
        public void StrokeText(string text, double x, double y, double maxWidth = Double.MaxValue)
        {
            InvokeMethod<object>("strokeText", text, x, y, maxWidth);
        }
        [Export("transform")]
        public void Transform(double m11, double m12, double m21, double m22, double dx, double dy)
        {
            InvokeMethod<object>("transform", m11, m12, m21, m22, dx, dy);
        }
        [Export("translate")]
        public void Translate(double x, double y)
        {
            InvokeMethod<object>("translate", x, y);
        }
        [Export("arc")]
        public void Arc(double x, double y, double radius, double startAngle, double endAngle, bool anticlockwise = false)
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
        public void Ellipse(double x, double y, double radiusX, double radiusY, double rotation, double startAngle, double endAngle, bool anticlockwise = false)
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