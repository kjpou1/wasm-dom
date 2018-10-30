using System;
using WebAssembly.Browser.DOM;

namespace CanvasAnimation
{
    class MainClass
    {

        private static Random random = new Random((int)DateTime.Now.Ticks);
        private static Window window;
        private static CanvasRenderingContext2D ctx;
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

            window = Web.Window;

            // resize the canvas 
            canvas.Width = screenWidth = window.InnerWidth;
            canvas.Height = screenHeight = window.InnerHeight;

            Console.WriteLine($"width: {canvas.Width} height: {canvas.Height}");


            // Obtain a reference to the canvas's 2D context
            ctx = canvas.GetContext2D();

            circles = new Circle[100];

            for (int c = 0; c < circles.Length; c++)
            {
                var radius = 30;
                var x = random.NextDouble() * (screenWidth - radius * 2) + radius;
                var y = random.NextDouble() * (screenHeight - radius * 2) + radius;
                var dx = (random.NextDouble() - 0.5d);// * 8;
                var dy = (random.NextDouble() - 0.5d);// * 8;

                circles[c] = new Circle(x, y, dx, dy, radius);

            }

            // make sure we start the animation
            Animate();
            
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            System.Console.WriteLine($"elapsedMs: {elapsedMs}");

        }

        static Circle[] circles = null;
        static double screenWidth = 0;
        static double screenHeight = 0;

        public static void Animate(double time = 0)
        {
            window.RequestAnimationFrame(Animate);

            ctx.ClearRect(0, 0, screenWidth, screenHeight);

            for (int c = 0; c < circles.Length; c++)
            {

                circles[c].Update(ctx, screenWidth, screenHeight);

            }


        }

    }

    public class Circle
    {
        public double X {get; set; }
        public double Y { get; set; }
        public double Radius { get; set; }
        public double DeltaX { get; set; }
        public double DeltaY { get; set; }

        public Circle (double x, double y, double dx, double dy, double radius)
        {
            X = x;
            Y = y;
            DeltaX = dx;
            DeltaY = dy;
            Radius = radius;
        }

        public void Draw(CanvasRenderingContext2D ctx)
        {
            ctx.BeginPath();
            ctx.Arc(X, Y, Radius, 0, Math.PI * 2, false);
            ctx.StrokeStyle = "blue";
            ctx.Stroke();
            //ctx.Fill();
            ctx.ClosePath();

        }

        public void Update(CanvasRenderingContext2D ctx, double screenWidth, double screenHeight)
        {
            if (X + Radius > screenWidth || X - Radius < 0)
            {
                DeltaX = -DeltaX;
            }

            if (Y + Radius > screenHeight || Y - Radius < 0)
            {
                DeltaY = -DeltaY;
            }
            X += DeltaX;
            Y += DeltaY;

            Draw(ctx);
        }

    }
}
