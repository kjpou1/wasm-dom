using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM
{

    [Export("TextTrackCue", typeof(JSObject))]
    public sealed class TextTrackCue : EventTarget
    {
        internal TextTrackCue(JSObject handle) : base(handle) { }

        //public TextTrackCue(double startTime, double endTime, string text) { }
        [Export("endTime")]
        public double EndTime { get => GetProperty<double>("endTime"); set => SetProperty<double>("endTime", value); }
        [Export("id")]
        public string Id { get => GetProperty<string>("id"); set => SetProperty<string>("id", value); }
        public event DOMEventHandler OnEnter
        {
            add => AddEventListener("enter", value, false);
            remove => RemoveEventListener("enter", value, false);
        }
        public event DOMEventHandler OnExit
        {
            add => AddEventListener("exit", value, false);
            remove => RemoveEventListener("exit", value, false);
        }
        [Export("pauseOnExit")]
        public bool PauseOnExit { get => GetProperty<bool>("pauseOnExit"); set => SetProperty<bool>("pauseOnExit", value); }
        [Export("startTime")]
        public double StartTime { get => GetProperty<double>("startTime"); set => SetProperty<double>("startTime", value); }
        [Export("text")]
        public string Text { get => GetProperty<string>("text"); set => SetProperty<string>("text", value); }
        [Export("track")]
        public TextTrack Track => GetProperty<TextTrack>("track");
        [Export("getCueAsHTML")]
        public DocumentFragment GetCueAsHtml()
        {
            return InvokeMethod<DocumentFragment>("getCueAsHTML");
        }
    }
}