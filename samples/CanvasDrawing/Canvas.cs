using System;
using WebAssembly.Browser.DOM;

namespace CanvasDrawing
{
    class MainClass
    {

        private static Random random = new Random((int)DateTime.Now.Ticks);

        public static void Main()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();


            var document = Web.Document;


            // Add a style for body margin to be 0 pixels
            var head = document.QuerySelector<HTMLHeadElement>("head");
            var style = document.CreateElement<HTMLStyleElement>();
            style.InnerHtml = "body { margin: 0; }";
            head.AppendChild(style);

            // Get the canvas object
            var canvas = document.QuerySelector<HTMLCanvasElement>("canvas");

            var window = Web.Window;

            // resize the canvas 
            canvas.Width = window.InnerWidth;
            canvas.Height = window.InnerHeight;

            Console.WriteLine($"width: {canvas.Width} height: {canvas.Height}");


            // Obtain a reference to the canvas's 2D context
            var ctx = canvas.GetContext2D();
            ctx.FillStyle = "rgba(255,0,0,0.5)";
            ctx.FillRect(100, 100, 100, 100);
            ctx.FillStyle = "rgba(0,255,0,0.5)";
            ctx.FillRect(400, 100, 100, 100);
            ctx.FillStyle = "rgba(0,0,255,0.5)";
            ctx.FillRect(300, 300, 100, 100);


            // Line

            ctx.BeginPath();
            ctx.MoveTo(50, 300);
            ctx.LineTo(300, 100);
            ctx.LineTo(400, 300);
            ctx.StrokeStyle = "#fa34a3";
            ctx.Stroke();
            ctx.ClosePath();


            // Arc / Circle
            //ctx.BeginPath();
            //ctx.Arc(300, 300, 30, 0, Math.PI * 2, false);
            //ctx.StrokeStyle = "blue";
            //ctx.Stroke();
            //ctx.ClosePath();

            var width = (int)window.InnerWidth;
            var height = (int)window.InnerHeight;

            for (var i = 0; i < 100; i++)
            {
                var x = random.Next(0, width);
                var y = random.Next(0, height);
                var red = random.Next(0, 255);
                var green = random.Next(0, 255);
                var blue = random.Next(0, 255);
                ctx.BeginPath();
                ctx.Arc(x, y, 30, 0, Math.PI * 2, false);
                ctx.StrokeStyle = $"rgba({red},{green},{blue},1)";
                ctx.Stroke();
                ctx.ClosePath();
            }

            ctx.Save();

            // Quadratric curves example
            ctx.BeginPath();
            ctx.MoveTo(75, 25);
            ctx.QuadraticCurveTo(25, 25, 25, 62.5);
            ctx.QuadraticCurveTo(25, 100, 50, 100);
            ctx.QuadraticCurveTo(50, 120, 30, 125);
            ctx.QuadraticCurveTo(60, 120, 65, 100);
            ctx.QuadraticCurveTo(125, 100, 125, 62.5);
            ctx.QuadraticCurveTo(125, 25, 75, 25);
            ctx.StrokeStyle = "black";
            ctx.Fill();
            ctx.Stroke();
            ctx.ClosePath();

            ctx.Restore();


            // Cubic curves example
            ctx.Save();
            ctx.Translate(200, 150);
            ctx.BeginPath();
            ctx.MoveTo(75, 40);
            ctx.BezierCurveTo(75, 37, 70, 25, 50, 25);
            ctx.BezierCurveTo(20, 25, 20, 62.5, 20, 62.5);
            ctx.BezierCurveTo(20, 80, 40, 102, 75, 120);
            ctx.BezierCurveTo(110, 102, 130, 80, 130, 62.5);
            ctx.BezierCurveTo(130, 62.5, 130, 25, 100, 25);
            ctx.BezierCurveTo(85, 25, 75, 37, 75, 40);
            ctx.FillStyle = "red";
            ctx.Fill();
            ctx.ClosePath();

            ctx.Restore();

            // Combination
            ctx.Save();

            ctx.Translate(200, 300);

            ctx.StrokeStyle = "black";

            roundedRect(ctx, 12, 12, 150, 150, 15);
            roundedRect(ctx, 19, 19, 150, 150, 9);
            roundedRect(ctx, 53, 53, 49, 33, 10);
            roundedRect(ctx, 53, 119, 49, 16, 6);
            roundedRect(ctx, 135, 53, 49, 33, 10);
            roundedRect(ctx, 135, 119, 25, 49, 10);

            ctx.BeginPath();
            ctx.Arc(37, 37, 13, Math.PI / 7, -Math.PI / 7, false);
            ctx.LineTo(31, 37);
            ctx.FillStyle = "green";
            ctx.Fill();

            for (var i = 0; i < 8; i++)
            {
                ctx.FillRect(51 + i * 16, 35, 4, 4);
            }

            for (var i = 0; i < 6; i++)
            {
                ctx.FillRect(115, 51 + i * 16, 4, 4);
            }

            for (var i = 0; i < 8; i++)
            {
                ctx.FillRect(51 + i * 16, 99, 4, 4);
            }

            ctx.BeginPath();
            ctx.MoveTo(83, 116);
            ctx.LineTo(83, 102);
            ctx.BezierCurveTo(83, 94, 89, 88, 97, 88);
            ctx.BezierCurveTo(105, 88, 111, 94, 111, 102);
            ctx.LineTo(111, 116);
            ctx.LineTo(106.333, 111.333);
            ctx.LineTo(101.666, 116);
            ctx.LineTo(97, 111.333);
            ctx.LineTo(92.333, 116);
            ctx.LineTo(87.666, 111.333);
            ctx.LineTo(83, 116);
            ctx.FillStyle = "blue";
            ctx.Fill();

            ctx.FillStyle = "white";
            ctx.BeginPath();
            ctx.MoveTo(91, 96);
            ctx.BezierCurveTo(88, 96, 87, 99, 87, 101);
            ctx.BezierCurveTo(87, 103, 88, 106, 91, 106);
            ctx.BezierCurveTo(94, 106, 95, 103, 95, 101);
            ctx.BezierCurveTo(95, 99, 94, 96, 91, 96);
            ctx.MoveTo(103, 96);
            ctx.BezierCurveTo(100, 96, 99, 99, 99, 101);
            ctx.BezierCurveTo(99, 103, 100, 106, 103, 106);
            ctx.BezierCurveTo(106, 106, 107, 103, 107, 101);
            ctx.BezierCurveTo(107, 99, 106, 96, 103, 96);
            ctx.Fill();

            ctx.FillStyle = "black";
            ctx.BeginPath();
            ctx.Arc(101, 102, 2, 0, Math.PI * 2, true);
            ctx.Fill();

            ctx.BeginPath();
            ctx.Arc(89, 102, 2, 0, Math.PI * 2, true);
            ctx.Fill();

            ctx.Restore();



            // shows four elements: a red rectangle, a gradient rectangle, a multicolor rectangle, and a multicolor text.

            ctx.Save();
            ctx.Translate(400, 300);

            ctx.FillStyle = "#FF0000";
            ctx.FillRect(20, 20, 100, 50);

            var grd = ctx.CreateLinearGradient(140, 20, 240, 70);
            grd.AddColorStop(0, "black");
            grd.AddColorStop(1, "white");
            ctx.FillStyle = grd;
            ctx.FillRect(140, 20, 100, 50);

            var grd2 = ctx.CreateLinearGradient(20, 90, 120, 90);
            grd2.AddColorStop(0, "black");
            grd2.AddColorStop(0.3, "magenta");
            grd2.AddColorStop(0.5, "blue");
            grd2.AddColorStop(0.6, "green");
            grd2.AddColorStop(0.8, "yellow");
            grd2.AddColorStop(1, "red");
            ctx.FillStyle = grd2;
            ctx.FillRect(20, 90, 100, 50);

            ctx.Font = "30px Verdana";
            var grd3 = ctx.CreateLinearGradient(140, 20, 240, 90);
            grd3.AddColorStop(0, "black");
            grd3.AddColorStop(0.3, "magenta");
            grd3.AddColorStop(0.6, "blue");
            grd3.AddColorStop(0.8, "green");
            grd3.AddColorStop(1, "red");
            ctx.StrokeStyle = grd3;
            ctx.StrokeText("Smile!", 140, 120);

            ctx.Restore();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            System.Console.WriteLine($"elapsedMs: {elapsedMs}");

        }

        // A utility function to draw a rectangle with rounded corners.
        static void roundedRect(CanvasRenderingContext2D  ctx, double x, double y, double width, double height, double radius)
        {
            ctx.BeginPath();
            ctx.MoveTo(x, y + radius);
            ctx.LineTo(x, y + height - radius);
            ctx.ArcTo(x, y + height, x + radius, y + height, radius);
            ctx.LineTo(x + width - radius, y + height);
            ctx.ArcTo(x + width, y + height, x + width, y + height - radius, radius);
            ctx.LineTo(x + width, y + radius);
            ctx.ArcTo(x + width, y, x + width - radius, y, radius);
            ctx.LineTo(x + radius, y);
            ctx.ArcTo(x, y, x, y + radius, radius);
            ctx.Stroke();
        }
    }
}
