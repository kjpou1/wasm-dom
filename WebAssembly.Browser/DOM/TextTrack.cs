using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM
{


    [Export("TextTrack", typeof(JSObject))]
    public sealed class TextTrack : EventTarget
    {
        internal TextTrack(JSObject handle) : base(handle) { }

        //public TextTrack() { }
        [Export("DISABLED")]
        public double Disabled => GetProperty<double>("DISABLED");
        [Export("ERROR")]
        public double Error => GetProperty<double>("ERROR");
        [Export("HIDDEN")]
        public double Hidden => GetProperty<double>("HIDDEN");
        [Export("LOADED")]
        public double Loaded => GetProperty<double>("LOADED");
        [Export("LOADING")]
        public double Loading => GetProperty<double>("LOADING");
        [Export("NONE")]
        public double None => GetProperty<double>("NONE");
        [Export("SHOWING")]
        public double Showing => GetProperty<double>("SHOWING");
        //[Export("activeCues")]
        //public TextTrackCueList ActiveCues => GetProperty<TextTrackCueList>("activeCues");
        //[Export("cues")]
        //public TextTrackCueList Cues => GetProperty<TextTrackCueList>("cues");
        [Export("inBandMetadataTrackDispatchType")]
        public string InBandMetadataTrackDispatchType => GetProperty<string>("inBandMetadataTrackDispatchType");
        [Export("kind")]
        public string Kind => GetProperty<string>("kind");
        [Export("label")]
        public string Label => GetProperty<string>("label");
        [Export("language")]
        public string Language => GetProperty<string>("language");
        [Export("mode")]
        public Object Mode { get => GetProperty<Object>("mode"); set => SetProperty<Object>("mode", value); }
        public event DOMEventHandler OnCuechange
        {
            add => AddEventListener("cuechange", value, false);
            remove => RemoveEventListener("cuechange", value, false);
        }
        public event DOMEventHandler OnError
        {
            add => AddEventListener("error", value, false);
            remove => RemoveEventListener("error", value, false);
        }
        public event DOMEventHandler OnLoad
        {
            add => AddEventListener("load", value, false);
            remove => RemoveEventListener("load", value, false);
        }
        [Export("readyState")]
        public double ReadyState => GetProperty<double>("readyState");
        [Export("addCue")]
        public void AddCue(TextTrackCue cue)
        {
            InvokeMethod<object>("addCue", cue);
        }
        [Export("removeCue")]
        public void RemoveCue(TextTrackCue cue)
        {
            InvokeMethod<object>("removeCue", cue);
        }
    }
}