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
                    //var = ()m.Target
                    Console.WriteLine($" Default Prevented   : {m.DefaultPrevented}");
                    args1.PreventDefault();
                    Console.WriteLine($" Default Prevented   : {m.DefaultPrevented}");

                }

                ((HTMLButtonElement)sender).TextContent = $"We be clicked {numTimes++}";

            };

            // Make a list
            var ul = document.CreateElement<HTMLUListElement>();
            document.Body.AppendChild(ul);

            var li1 = document.CreateElement<HTMLLIElement>();
            var li2 = document.CreateElement<HTMLLIElement>();
            ul.AppendChild(li1);
            ul.AppendChild(li2);

            ul.OnClick += (JSObject sender, DOMEventArgs args2) => {
                args2.EventObject.Target.ConvertTo<HTMLElement>().SetStyleAttribute("visibility", "hidden");
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
