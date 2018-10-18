using System;
using System.Collections.Generic;
using WebAssembly;

namespace WebAssembly.Browser.DOM.Events
{

    [Export("ClipboardEvent", typeof(JSObject))]
    public sealed class ClipboardEvent : Event
    {
        internal ClipboardEvent(JSObject handle) : base(handle) { }

        //public ClipboardEvent (string type, ClipboardEventInit eventInitDict) { }
        DataTransfer clipboardData;

        [Export("clipboardData")]
        public DataTransfer ClipboardData
        {
            get
            {
                if (clipboardData == null)
                    clipboardData = GetProperty<DataTransfer>("clipboardData");
                return clipboardData;
            }
            set => SetProperty<DataTransfer>("clipboardData", value);
        }


        protected override void Dispose(bool disposing)
        {
            // the event object handle is already unregistered within the event handling function
            // no need to do this again.
            if (disposing)
            {
                if (clipboardData != null)
                {
                    clipboardData.Dispose();
                }
            }

        }

        internal override void InitEvent(string eventTypeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, int detailArg,
                                         double screenXArg, double screenYArg, double clientXArg, double clientYArg,
                                         bool ctrlKeyArg, bool altKeyArg, bool shiftKeyArg, bool metaKeyArg, int buttonArg,
                                        int eventPhaseArg, bool scopedArg, double timeStampArg,
                                         Dictionary<string, string> eventInfoDic)
        {
            base.InitEvent(eventTypeArg, canBubbleArg, cancelableArg, viewArg, detailArg, screenXArg,screenYArg,clientXArg,clientYArg,
                           ctrlKeyArg, altKeyArg, shiftKeyArg,metaKeyArg,buttonArg, eventPhaseArg, scopedArg, timeStampArg,
                           eventInfoDic);
        }


    }

}