using System;
using System.Collections.Generic;
using System.Linq;

using WebAssembly;
using WebAssembly.Browser.DOM;

namespace HelloCanvas
{
    class MainClass
    {

        public static void Main()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            var document = Web.Document;

            var canvas = document.GetElementById("myCanvas").As<HTMLCanvasElement>();

            Console.WriteLine($"width: {canvas.Width} height: {canvas.Height}");
            var ctx = canvas.GetContext2D();
            ctx.FillStyle = "green";
            ctx.FillRect(0, 0, canvas.Width, canvas.Height);
            ctx.TextAlign = TextAlign.Center;
            ctx.TextBaseline = TextBaseline.Middle;
            ctx.Font = "48px serif";
            ctx.StrokeText("Hello world", canvas.Width / 2, canvas.Height / 2);

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
