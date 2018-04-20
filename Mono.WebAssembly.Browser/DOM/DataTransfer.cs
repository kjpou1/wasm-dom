using System;
namespace Mono.WebAssembly.Browser.DOM
{
    [Export("DataTransfer", typeof(Mono.WebAssembly.JSObject))]
    public sealed class DataTransfer : JSObject
    {
        internal DataTransfer(int handle) : base(handle) { }
        bool disposed = false;
        public DataTransfer() { }
        [Export("dropEffect")]
        public string DropEffect { get => GetProperty<string>("dropEffect"); set => SetProperty<string>("dropEffect", value); }
        [Export("effectAllowed")]
        public string EffectAllowed { get => GetProperty<string>("effectAllowed"); set => SetProperty<string>("effectAllowed", value); }
        //[Export("files")]
        //public FileList Files => GetProperty<FileList>("files");
        [Export("items")]
        public DataTransferItemList Items => GetProperty<DataTransferItemList>("items");
        [Export("types")]
        public string[] Types => GetProperty<string[]>("types");
        [Export("clearData")]
        public bool ClearData(string format)
        {
            return InvokeMethod<bool>("clearData", format);
        }
        [Export("getData")]
        public string GetData(string format)
        {
            return InvokeMethod<string>("getData", format);
        }
        [Export("setData")]
        public bool SetData(string format, string data)
        {
            return InvokeMethod<bool>("setData", format, data);
        }
        [Export("setDragImage")]
        public void SetDragImage(Element image, double x, double y)
        {
            InvokeMethod<object>("setDragImage", image, x, y);
        }

		protected override void Dispose(bool disposing)
		{
            if (disposed)
                return;

            base.Dispose(disposing);

		}
	}
}
