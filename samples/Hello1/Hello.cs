using System;
using Mono.WebAssembly.Browser.DOM;
using Mono.WebAssembly.Browser.DOM.Events;
using Mono.WebAssembly;

namespace Hello
{
    public class Program
    {
        static int numTimes = 1;
        static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            System.Console.WriteLine("hello world from Main!");

            var document = HTMLPage.Document;

            var button = document.CreateElement<HTMLButtonElement>();
            button.TextContent = "Click Me";

            document.Body.AppendChild(button);
            button.OnClick += Button_OnClick;
            button.OnClick += (JSObject sender, DOMEventArgs args1) => {

                var eventObject = args1.EventObject;

                if (eventObject is MouseEvent)
                {
                    Console.WriteLine("We have a MouseEvent");
                    var m = (MouseEvent)eventObject;
                    Console.WriteLine($" Default Prevented   : {m.DefaultPrevented}");
                    args1.PreventDefault();
                    Console.WriteLine($" Default Prevented   : {m.DefaultPrevented}");

                }

                ((HTMLButtonElement)sender).TextContent = $"We be clicked {numTimes++}";

            };
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            System.Console.WriteLine($"elapsedMs: {elapsedMs}");
        }


        static void Button_OnClick(JSObject sender, DOMEventArgs args)
        {
            var button = (HTMLButtonElement)sender;
            //button.TextContent = "Clicked";

        }

    }
}
