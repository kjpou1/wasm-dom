using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM
{

    [Export("Comment", typeof(JSObject))]
    public sealed class Comment : CharacterData, IComment
    {
        internal Comment(JSObject handle) : base(handle) { }

        //public Comment () { }
        [Export("text")]
        public string Text { get => GetProperty<string>("text"); set => SetProperty<string>("text", value); }
    }
}