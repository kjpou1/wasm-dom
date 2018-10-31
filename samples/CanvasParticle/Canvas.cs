using System;
using WebAssembly.Browser.DOM;

namespace CanvasParticle
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

            Initialize();
            // make sure we start the animation
            Animate();


            window.OnMouseMove += (DOMObject sender, DOMEventArgs args) => 
            {
                mousePosition.X = args.ClientX;
                mousePosition.Y = args.ClientY;
            };
            window.OnResize += (DOMObject sender, DOMEventArgs args) =>
            {
                // resize the canvas 
                canvas.Width = screenWidth = window.InnerWidth;
                canvas.Height = screenHeight = window.InnerHeight;
                Initialize();
            };


            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            System.Console.WriteLine($"elapsedMs: {elapsedMs}");

        }

        static void Initialize(){

            if (circles == null)
                circles = new Circle[100];

            for (int c = 0; c < circles.Length; c++)
            {
                var radius = random.NextDouble() * 3 + 3;
                var x = random.NextDouble() * (screenWidth - radius * 2) + radius;
                var y = random.NextDouble() * (screenHeight - radius * 2) + radius;
                var dx = (random.NextDouble() - 0.5d) * 1;
                var dy = (random.NextDouble() - 0.5d) * 1;
                var color = colors[(int)Math.Floor(random.NextDouble() * colors.Length)];

                circles[c] = new Circle(x, y, dx, dy, radius, color);

            }

        }

        static Circle[] circles = null;
        static double screenWidth = 0;
        static double screenHeight = 0;
        static Point2D mousePosition = new Point2D();
        static string[] colors = new string[] { 
            "#ffaa33",
            "#99ffaaa",
            "#00ff00",
            "#4411aa",
            "#ff1100",
        };

        public static void Animate(double time = 0)
        {
            window.RequestAnimationFrame(Animate);

            ctx.ClearRect(0, 0, screenWidth, screenHeight);

            for (int c = 0; c < circles.Length; c++)
            {

                circles[c].Update(ctx, screenWidth, screenHeight, mousePosition);

            }


        }

    }

    public class Circle
    {
        static readonly double MAX_RADIUS = 40;

        public double X { get; set; }
        public double Y { get; set; }
        public double Radius { get; set; }
        public double DeltaX { get; set; }
        public double DeltaY { get; set; }
        public double MinRadius { get; set; }
        public string Color { get; set; } 

        public Circle(double x, double y, double dx, double dy, double radius, string color = "#0000ff")
        {
            X = x;
            Y = y;
            DeltaX = dx;
            DeltaY = dy;
            Radius = (int)radius;
            MinRadius = radius;
            Color = color;
        }

        public void Draw(CanvasRenderingContext2D ctx)
        {
            ctx.BeginPath();
            ctx.Arc(X, Y, Radius, 0, Math.PI * 2, false);
            ctx.FillStyle = Color;
            ctx.Fill();
            ctx.ClosePath();

        }

        public void Update(CanvasRenderingContext2D ctx, double screenWidth, double screenHeight, Point2D mousePosition)
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

            if (Point2D.Distance(mousePosition, X, Y) < 50 && Radius < MAX_RADIUS)
                Radius += 1;
            else if (Radius > MinRadius)
                Radius -= 1;

            Draw(ctx);
        }
    }
}
