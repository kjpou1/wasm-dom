using System;
using WebAssembly.Browser.DOM;
using WebAssembly.Browser.DOM.Events;
using System.Threading.Tasks;

namespace HelloDotNetStandard
{
    public class Program
    {
        static int numTimes = 1;

        static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            System.Console.WriteLine("hello world from Main!");


            var document = Web.Document;
            Console.WriteLine($"Visibility State: {document}");
            Console.WriteLine($"Visibility State: {document.VisibilityState}");

            var button = document.CreateElement<HTMLButtonElement>();
            button.TextContent = "Click Me";

            button.OnWheel += (DOMObject sender, DOMEventArgs args1) => {

                var evt = (WheelEvent)args1.EventObject;
                Console.WriteLine($"We got a wheel wwwhhheeeeee! {evt.CurrentTarget}");
            };

            document.Body.AppendChild(button);
            button.OnClick += Button_OnClick;
            button.OnClick += async (DOMObject sender, DOMEventArgs args1) => {

                var evt = args1.EventObject;

                Console.WriteLine("before await");
                await Task.Run(() => UpdateButton(((HTMLButtonElement)sender) )).ConfigureAwait(false); 
                Console.WriteLine("after await");

            };

            // Make a list
            var ul = document.CreateElement<HTMLUListElement>();
            document.Body.AppendChild(ul);

            var li1 = document.CreateElement<HTMLLIElement>();
            var li2 = document.CreateElement<HTMLLIElement>();
            ul.AppendChild(li1);
            ul.AppendChild(li2);

            ul.OnClick += (DOMObject sender, DOMEventArgs args2) => {
                args2.EventObject.Target.ConvertTo<HTMLElement>().SetStyleAttribute("visibility", "hidden");
            };


            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            System.Console.WriteLine($"elapsedMs: {elapsedMs}");
        }

        static Task<object> UpdateButton(HTMLButtonElement button)
        {
            var tcs = new TaskCompletionSource<object>();

            button.TextContent = $"We be clicked {numTimes++} times";
            tcs.SetResult(null);

            return tcs.Task;
        }

        static void Button_OnClick(DOMObject sender, DOMEventArgs args)
        {
            var button = (HTMLButtonElement)sender;
            button.TextContent = "Clicked";

        }


    }
}
