using System;
using System.Collections.Generic;
using WebAssembly;

namespace WebAssembly.Browser.DOM.Events
{

    [Export("DragEvent", typeof(JSObject))]
    public sealed class DragEvent : MouseEvent
    {
        internal DragEvent(JSObject handle) : base(handle) { }

        //public DragEvent(object type, object dragEventInit) { }
        DataTransfer dataTransfer;
        [Export("dataTransfer")]
        public DataTransfer DataTransfer { 
            get
            {
                if (dataTransfer == null)
                    dataTransfer = GetProperty<DataTransfer>("dataTransfer");
                return dataTransfer;
            }
            set => SetProperty<DataTransfer>("dataTransfer", value); 
        }
		//[Export("initDragEvent")]
		//public void InitDragEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, double detailArg, double screenXArg, double screenYArg, double clientXArg, double clientYArg, bool ctrlKeyArg, bool altKeyArg, bool shiftKeyArg, bool metaKeyArg, double buttonArg, EventTarget relatedTargetArg, IDataTransfer dataTransferArg)
		//{
		//    InvokeMethod<object>("initDragEvent", typeArg, canBubbleArg, cancelableArg, viewArg, detailArg, screenXArg, screenYArg, clientXArg, clientYArg, ctrlKeyArg, altKeyArg, shiftKeyArg, metaKeyArg, buttonArg, relatedTargetArg, dataTransferArg);
		//}
		//[Export("msConvertURL")]
		//public void MsConvertUrl(File file, string targetType, string targetURL)
		//{
		//    InvokeMethod<object>("msConvertURL", file, targetType, targetURL);
		//}

		protected override void Dispose(bool disposing)
		{
            base.Dispose(disposing);

            // Drag Events have a DataTransfer associated.  This needs to be disposed as well.
            if (disposing)
            {
                if (dataTransfer != null)
                {
                    dataTransfer.Dispose();    
                }
            }

		}

        internal override void InitEvent(string eventTypeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, int detailArg,
                                         double screenXArg, double screenYArg, double clientXArg, double clientYArg,
                                         bool ctrlKeyArg, bool altKeyArg, bool shiftKeyArg, bool metaKeyArg, int buttonArg,
                                        int eventPhaseArg, bool scopedArg, double timeStampArg,
                                         Dictionary<string, string> eventInfoDic)
        {
            base.InitEvent(eventTypeArg, canBubbleArg, cancelableArg, viewArg, detailArg, screenXArg, screenYArg, clientXArg, clientYArg,
                           ctrlKeyArg, altKeyArg, shiftKeyArg, metaKeyArg, buttonArg, eventPhaseArg, scopedArg, timeStampArg, eventInfoDic);
        }
	}

}