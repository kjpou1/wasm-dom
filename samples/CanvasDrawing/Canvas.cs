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

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            System.Console.WriteLine($"elapsedMs: {elapsedMs}");

        }
    }
}
