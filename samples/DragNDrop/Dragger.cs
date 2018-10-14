using System;
using WebAssembly.Browser.DOM;
using WebAssembly.Browser.DOM.Events;

namespace DragNDrop
{
    //https://developer.mozilla.org/en-US/docs/Web/Events/dragstart
    public class Dragger
    {
        public Dragger()
        {

            var document = Web.Document;

            HTMLElement dragged = null;

            // events fired on the draggable target */
            document.OnDrag += (DOMObject sender, DOMEventArgs args) =>
            {
                //Console.WriteLine("dragged");

            };

            document.OnDragStart += (DOMObject sender, DOMEventArgs args) => {
                //Console.WriteLine("Drag Start");

                // This is needed for FireFox to work
                try
                {
                    // Internet Explorer throws an Invalide Argument error
                    ((DragEvent)args.EventObject).DataTransfer.SetData("text/plain", null);
                }
                catch { }


                dragged = ((DragEvent)args.EventObject).Target.As<HTMLElement>();
                dragged.SetStyleAttribute("opacity", ".5");

            };

            document.OnDragEnd += (DOMObject sender, DOMEventArgs args) => {
                //Console.WriteLine("DragEnd");
                ((DragEvent)args.EventObject).Target.As<HTMLElement>().SetStyleAttribute("opacity", null);
            };

            document.OnDragLeave += (DOMObject sender, DOMEventArgs args) => {
                //Console.WriteLine("DragLeave");
                ((DragEvent)args.EventObject).Target.As<HTMLElement>().SetStyleAttribute("background", "");
            };


            //Events fired on the drop targets
            document.OnDragOver += (DOMObject sender, DOMEventArgs args) => {
                //Console.WriteLine("DragOver");
                args.PreventDefault();
                args.StopPropagation();
                var target = ((DragEvent)args.EventObject).Target.As<HTMLElement>();
                if (target.ClassName == "dropzone")
                {

                    // A DropEffect must be set
                    ((DragEvent)args.EventObject).DataTransfer.DropEffect = DropEffect.Copy;
                }
                else
                    // A DropEffect must be set
                    ((DragEvent)args.EventObject).DataTransfer.DropEffect = DropEffect.None;

            };

            document.OnDragEnter += (DOMObject sender, DOMEventArgs args) => {
                //Console.WriteLine("DragEnter");
                var target = ((DragEvent)args.EventObject).Target.As<HTMLElement>();
                if (target.ClassName == "dropzone")
                {
                    target.SetStyleAttribute("background", "purple");
                }
            };

            document.OnDragLeave += (DOMObject sender, DOMEventArgs args) => {
                //Console.WriteLine("DragLeave");
                var target = ((DragEvent)args.EventObject).Target.As<HTMLElement>();
                if (target.ClassName == "dropzone")
                {
                    target.SetStyleAttribute("background", "");
                }

            };

            document.OnDrop += (DOMObject sender, DOMEventArgs args) => {
                //Console.WriteLine("Drop");
                args.PreventDefault();
                args.StopPropagation();

                var target = ((DragEvent)args.EventObject).Target.As<HTMLElement>();
                if (target.ClassName == "dropzone")
                {
                    target.SetStyleAttribute("background", "");
                    dragged.ParentNode.RemoveChild(dragged);
                    target.AppendChild(dragged);
                }

            };
        }
    }
}
