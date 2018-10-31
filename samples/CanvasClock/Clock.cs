using System;
using WebAssembly.Browser.DOM;

namespace CanvasClock
{
    public class Clock
    {
        private static Window window;
        private static CanvasRenderingContext2D ctx;
        static double radius;

        public static void InitializeClock()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();


            var document = Web.Document;


            // Get the canvas object
            var canvas = document.QuerySelector<HTMLCanvasElement>("canvas");

            window = Web.Window;

            // Obtain a reference to the canvas"s 2D context
            ctx = canvas.GetContext2D();

            radius = canvas.Height / 2;
            ctx.Translate(radius, radius);
            radius = radius * 0.90;

            drawClock(ctx, radius);


            Animate();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            System.Console.WriteLine($"elapsedMs: {elapsedMs}");

        }

        static void drawClock(CanvasRenderingContext2D ctx, double radius)
        {
            drawFace(ctx, radius);
            drawNumbers(ctx, radius);
            drawTime(ctx, radius);
        }

        static CanvasGradient grad;  // make this static so and created only one time so it does not get GC'd
        static void drawFace(CanvasRenderingContext2D ctx, double radius)
        {

            ctx.BeginPath();
            ctx.Arc(0, 0, radius, 0, 2 * Math.PI);
            ctx.FillStyle = "white";
            ctx.Fill();

            if (grad == null)
            {
                grad = ctx.CreateRadialGradient(0, 0, radius * 0.95, 0, 0, radius * 1.05);
                grad.AddColorStop(0, "#333");
                grad.AddColorStop(0.5, "white");
                grad.AddColorStop(1, "#333");
            }

            ctx.StrokeStyle = grad;
            ctx.LineWidth = radius * 0.1;
            ctx.Stroke();

            ctx.BeginPath();
            ctx.Arc(0, 0, radius * 0.1, 0, 2 * Math.PI);
            ctx.FillStyle = "#333";
            ctx.Fill();

        }

        static void drawNumbers(CanvasRenderingContext2D ctx, double radius)
        {
            double ang;
            int num;
            ctx.Font = radius * 0.15 + "px arial";
            ctx.TextBaseline = TextBaseline.Middle;
            ctx.TextAlign = TextAlign.Center;
            for (num = 1; num < 13; num++)
            {
                ang = num * Math.PI / 6;
                ctx.Rotate(ang);
                ctx.Translate(0, -radius * 0.85);
                ctx.Rotate(-ang);
                ctx.FillText(num.ToString(), 0, 0);
                ctx.Rotate(ang);
                ctx.Translate(0, radius * 0.85);
                ctx.Rotate(-ang);
            }
        }

        static void drawTime(CanvasRenderingContext2D ctx, double radius)
        {
            var now = DateTime.Now;
            double hour = now.Hour;
            double minute = now.Minute;
            double second = now.Second;
            //hour
            hour = hour % 12;
            hour = (hour * Math.PI / 6) + (minute * Math.PI / (6 * 60)) + (second * Math.PI / (360 * 60));
            drawHand(ctx, hour, radius * 0.5, radius * 0.07);
            //minute
            minute = (minute * Math.PI / 30) + (second * Math.PI / (30 * 60));
            drawHand(ctx, minute, radius * 0.8, radius * 0.07);
            // second
            second = (second * Math.PI / 30);
            drawHand(ctx, second, radius * 0.9, radius * 0.02);
        }

        static void drawHand(CanvasRenderingContext2D ctx, double pos, double length, double width)
        {
            ctx.BeginPath();
            ctx.LineWidth = width;
            ctx.LineCap = LineCap.Round;
            ctx.MoveTo(0, 0);
            ctx.Rotate(pos);
            ctx.LineTo(0, -length);
            ctx.Stroke();
            ctx.Rotate(-pos);
        }

        static void Animate(double time = 0)
        {
            window.RequestAnimationFrame(Animate);
            drawClock(ctx, radius);

        }
    }
}

