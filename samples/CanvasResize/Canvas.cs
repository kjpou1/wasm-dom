using System;
using System.Collections.Generic;
using System.Linq;

using WebAssembly;
using WebAssembly.Browser.DOM;

namespace CanvasResize
{
    class MainClass
    {

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
            ctx.FillRect(100, 100, 100, 100);
            ctx.FillRect(400, 100, 100, 100);
            ctx.FillRect(300, 300, 100, 100);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            System.Console.WriteLine($"elapsedMs: {elapsedMs}");

        }

        public static void Fibinacci()
        {
            foreach (var i in Fibonacci().Take(20))
            {
                Console.WriteLine(i);
            }
        }

        private static IEnumerable<int> Fibonacci()
        {
            int current = 1, next = 1;

            while (true)
            {
                yield return current;
                next = current + (current = next);
            }
        }
    }
}
