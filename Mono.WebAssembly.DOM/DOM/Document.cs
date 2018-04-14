using System;
using Mono.WebAssembly;

namespace Mono.WebAssembly.DOM
{

    [Export("Document", typeof(Mono.WebAssembly.JSObject))]
    public sealed class Document : Node
    {
        internal Document(int handle) : base(handle) { }

        public Document() : base("document") { }

        [Export("activeElement")]
        public Element ActiveElement => GetProperty<Element>("activeElement");
        /**
         * Sets or gets the color of all active links in the document.
         */
        [Export("alinkColor")]
        public string AlinkColor { get => GetProperty<string>("alinkColor"); set => SetProperty<string>("alinkColor", value); }
        /**
         * Returns a reference to the collection of elements contained by the object.
         */
        // [Export("all")]
        // public HTMLAllCollection All => GetProperty<HTMLAllCollection>("all");
        /**
         * Retrieves a collection of all a objects that have a name and/or id property. Objects in this collection are in HTML source order.
         */
        // [Export("anchors")]
        // public HTMLCollectionOf<HTMLAnchorElement> Anchors { get => GetProperty<HTMLCollectionOf<HTMLAnchorElement>>("anchors"); set => SetProperty<HTMLCollectionOf<HTMLAnchorElement>>("anchors", value); }
        /**
         * Retrieves a collection of all applet objects in the document.
         */
        // [Export("applets")]
        // public HTMLCollectionOf<HTMLAppletElement> Applets { get => GetProperty<HTMLCollectionOf<HTMLAppletElement>>("applets"); set => SetProperty<HTMLCollectionOf<HTMLAppletElement>>("applets", value); }
        /**
         * Deprecated. Sets or retrieves a value that indicates the background color behind the object.
         */
        // [Export("bgColor")]
        // public string BgColor { get => GetProperty<string>("bgColor"); set => SetProperty<string>("bgColor", value); }
         [Export("body")]
         public HTMLElement Body { get => GetProperty<HTMLElement>("body"); set => SetProperty<HTMLElement>("body", value); }
        [Export("characterSet")]
        public string CharacterSet => GetProperty<string>("characterSet");
        /**
         * Gets or sets the character set used to encode the object.
         */
        [Export("charset")]
        public string Charset { get => GetProperty<string>("charset"); set => SetProperty<string>("charset", value); }
        /**
         * Gets a value that indicates whether standards-compliant mode is switched on for the object.
         */
        [Export("compatMode")]
        public string CompatMode => GetProperty<string>("compatMode");
        [Export("cookie")]
        public string Cookie { get => GetProperty<string>("cookie"); set => SetProperty<string>("cookie", value); }
        [Export("currentScript")]
        public object CurrentScript => GetProperty<object>("currentScript");
        [Export("defaultView")]
        public Window DefaultView => GetProperty<Window>("defaultView");
        /**
         * Sets or gets a value that indicates whether the document can be edited.
         */
        [Export("designMode")]
        public string DesignMode { get => GetProperty<string>("designMode"); set => SetProperty<string>("designMode", value); }
        /**
         * Sets or retrieves a value that indicates the reading order of the object.
         */
        [Export("dir")]
        public string Dir { get => GetProperty<string>("dir"); set => SetProperty<string>("dir", value); }
        /**
         * Gets an object representing the document type declaration associated with the current document.
         */
        // [Export("doctype")]
        // public DocumentType Doctype => GetProperty<DocumentType>("doctype");
         [Export("documentElement")]
         public HTMLElement DocumentElement { get => GetProperty<HTMLElement>("documentElement"); set => SetProperty<HTMLElement>("documentElement", value); }
        [Export("domain")]
        public string Domain { get => GetProperty<string>("domain"); set => SetProperty<string>("domain", value); }
        /**
         * Retrieves a collection of all embed objects in the document.
         */
        // [Export("embeds")]
        // public HTMLCollectionOf<HTMLEmbedElement> Embeds { get => GetProperty<HTMLCollectionOf<HTMLEmbedElement>>("embeds"); set => SetProperty<HTMLCollectionOf<HTMLEmbedElement>>("embeds", value); }
        [Export("fgColor")]
        public string FgColor { get => GetProperty<string>("fgColor"); set => SetProperty<string>("fgColor", value); }
        // [Export("forms")]
        // public HTMLCollectionOf<HTMLFormElement> Forms { get => GetProperty<HTMLCollectionOf<HTMLFormElement>>("forms"); set => SetProperty<HTMLCollectionOf<HTMLFormElement>>("forms", value); }
        [Export("fullscreenElement")]
        public Element FullscreenElement => GetProperty<Element>("fullscreenElement");
        [Export("fullscreenEnabled")]
        public bool FullscreenEnabled => GetProperty<bool>("fullscreenEnabled");
        // [Export("head")]
        // public HTMLHeadElement Head => GetProperty<HTMLHeadElement>("head");
        [Export("hidden")]
        public bool Hidden => GetProperty<bool>("hidden");
        // [Export("images")]
        // public HTMLCollectionOf<HTMLImageElement> Images { get => GetProperty<HTMLCollectionOf<HTMLImageElement>>("images"); set => SetProperty<HTMLCollectionOf<HTMLImageElement>>("images", value); }
        // [Export("implementation")]
        // public DOMImplementation Implementation => GetProperty<DOMImplementation>("implementation");
        [Export("inputEncoding")]
        public string InputEncoding => GetProperty<string>("inputEncoding");
        [Export("lastModified")]
        public string LastModified => GetProperty<string>("lastModified");
        [Export("linkColor")]
        public string LinkColor { get => GetProperty<string>("linkColor"); set => SetProperty<string>("linkColor", value); }
        // [Export("links")]
        // public HTMLCollectionOf<HTMLAnchorElement | HTMLAreaElement> Links { get => GetProperty < HTMLCollectionOf < HTMLAnchorElement | HTMLAreaElement >> ("links"); set => SetProperty < HTMLCollectionOf < HTMLAnchorElement | HTMLAreaElement >> ("links", value); }
        [Export("location")]
        public Location Location => GetProperty<Location>("location");
        [Export("msCapsLockWarningOff")]
        public bool MsCapsLockWarningOff { get => GetProperty<bool>("msCapsLockWarningOff"); set => SetProperty<bool>("msCapsLockWarningOff", value); }
        [Export("msCSSOMElementFloatMetrics")]
        public bool MsCssomElementFloatMetrics { get => GetProperty<bool>("msCSSOMElementFloatMetrics"); set => SetProperty<bool>("msCSSOMElementFloatMetrics", value); }
        /**
         * Fires when the user aborts the download.
         * @param ev The event.
         */
        public event DOMEventHandler OnAbort
        {
            add => AddEventListener("abort", value, false);
            remove => RemoveEventListener("abort", value, false);
        }
        /**
         * Fires when the object is set as the active element.
         * @param ev The event.
         */
        public event DOMEventHandler OnActivate
        {
            add => AddEventListener("activate", value, false);
            remove => RemoveEventListener("activate", value, false);
        }
        /**
         * Fires immediately before the object is set as the active element.
         * @param ev The event.
         */
        public event DOMEventHandler OnBeforeactivate
        {
            add => AddEventListener("beforeactivate", value, false);
            remove => RemoveEventListener("beforeactivate", value, false);
        }
        /**
         * Fires immediately before the activeElement is changed from the current object to another object in the parent document.
         * @param ev The event.
         */
        public event DOMEventHandler OnBeforedeactivate
        {
            add => AddEventListener("beforedeactivate", value, false);
            remove => RemoveEventListener("beforedeactivate", value, false);
        }
        /**
         * Fires when the object loses the input focus.
         * @param ev The focus event.
         */
        public event DOMEventHandler OnBlur
        {
            add => AddEventListener("blur", value, false);
            remove => RemoveEventListener("blur", value, false);
        }
        /**
         * Occurs when playback is possible, but would require further buffering.
         * @param ev The event.
         */
        public event DOMEventHandler OnCanplay
        {
            add => AddEventListener("canplay", value, false);
            remove => RemoveEventListener("canplay", value, false);
        }
        public event DOMEventHandler OnCanplaythrough
        {
            add => AddEventListener("canplaythrough", value, false);
            remove => RemoveEventListener("canplaythrough", value, false);
        }
        /**
         * Fires when the contents of the object or selection have changed.
         * @param ev The event.
         */
        public event DOMEventHandler OnChange
        {
            add => AddEventListener("change", value, false);
            remove => RemoveEventListener("change", value, false);
        }
        /**
         * Fires when the user clicks the left mouse button on the object
         * @param ev The mouse event.
         */
        public event DOMEventHandler OnClick
        {
            add => AddEventListener("click", value, false);
            remove => RemoveEventListener("click", value, false);
        }
        /**
         * Fires when the user clicks the right mouse button in the client area, opening the context menu.
         * @param ev The mouse event.
         */
        public event DOMEventHandler OnContextmenu
        {
            add => AddEventListener("contextmenu", value, false);
            remove => RemoveEventListener("contextmenu", value, false);
        }
        /**
         * Fires when the user double-clicks the object.
         * @param ev The mouse event.
         */
        public event DOMEventHandler OnDblclick
        {
            add => AddEventListener("dblclick", value, false);
            remove => RemoveEventListener("dblclick", value, false);
        }
        /**
         * Fires when the activeElement is changed from the current object to another object in the parent document.
         * @param ev The UI Event
         */
        public event DOMEventHandler OnDeactivate
        {
            add => AddEventListener("deactivate", value, false);
            remove => RemoveEventListener("deactivate", value, false);
        }
        /**
         * Fires on the source object continuously during a drag operation.
         * @param ev The event.
         */
        public event DOMEventHandler OnDrag
        {
            add => AddEventListener("drag", value, false);
            remove => RemoveEventListener("drag", value, false);
        }
        /**
         * Fires on the source object when the user releases the mouse at the close of a drag operation.
         * @param ev The event.
         */
        public event DOMEventHandler OnDragend
        {
            add => AddEventListener("dragend", value, false);
            remove => RemoveEventListener("dragend", value, false);
        }
        /**
         * Fires on the target element when the user drags the object to a valid drop target.
         * @param ev The drag event.
         */
        public event DOMEventHandler OnDragenter
        {
            add => AddEventListener("dragenter", value, false);
            remove => RemoveEventListener("dragenter", value, false);
        }
        /**
         * Fires on the target object when the user moves the mouse out of a valid drop target during a drag operation.
         * @param ev The drag event.
         */
        public event DOMEventHandler OnDragleave
        {
            add => AddEventListener("dragleave", value, false);
            remove => RemoveEventListener("dragleave", value, false);
        }
        /**
         * Fires on the target element continuously while the user drags the object over a valid drop target.
         * @param ev The event.
         */
        public event DOMEventHandler OnDragover
        {
            add => AddEventListener("dragover", value, false);
            remove => RemoveEventListener("dragover", value, false);
        }
        /**
         * Fires on the source object when the user starts to drag a text selection or selected object.
         * @param ev The event.
         */
        public event DOMEventHandler OnDragstart
        {
            add => AddEventListener("dragstart", value, false);
            remove => RemoveEventListener("dragstart", value, false);
        }
        public event DOMEventHandler OnDrop
        {
            add => AddEventListener("drop", value, false);
            remove => RemoveEventListener("drop", value, false);
        }
        /**
         * Occurs when the duration attribute is updated.
         * @param ev The event.
         */
        public event DOMEventHandler OnDurationchange
        {
            add => AddEventListener("durationchange", value, false);
            remove => RemoveEventListener("durationchange", value, false);
        }
        /**
         * Occurs when the media element is reset to its initial state.
         * @param ev The event.
         */
        public event DOMEventHandler OnEmptied
        {
            add => AddEventListener("emptied", value, false);
            remove => RemoveEventListener("emptied", value, false);
        }
        /**
         * Occurs when the end of playback is reached.
         * @param ev The event
         */
        public event DOMEventHandler OnEnded
        {
            add => AddEventListener("ended", value, false);
            remove => RemoveEventListener("ended", value, false);
        }
        /**
         * Fires when an error occurs during object loading.
         * @param ev The event.
         */
        public event DOMEventHandler OnError
        {
            add => AddEventListener("error", value, false);
            remove => RemoveEventListener("error", value, false);
        }
        /**
         * Fires when the object receives focus.
         * @param ev The event.
         */
        public event DOMEventHandler OnFocus
        {
            add => AddEventListener("focus", value, false);
            remove => RemoveEventListener("focus", value, false);
        }
        public event DOMEventHandler OnFullscreenchange
        {
            add => AddEventListener("fullscreenchange", value, false);
            remove => RemoveEventListener("fullscreenchange", value, false);
        }
        public event DOMEventHandler OnFullscreenerror
        {
            add => AddEventListener("fullscreenerror", value, false);
            remove => RemoveEventListener("fullscreenerror", value, false);
        }
        public event DOMEventHandler OnInput
        {
            add => AddEventListener("input", value, false);
            remove => RemoveEventListener("input", value, false);
        }
        public event DOMEventHandler OnInvalid
        {
            add => AddEventListener("invalid", value, false);
            remove => RemoveEventListener("invalid", value, false);
        }
        /**
         * Fires when the user presses a key.
         * @param ev The keyboard event
         */
        public event DOMEventHandler OnKeydown
        {
            add => AddEventListener("keydown", value, false);
            remove => RemoveEventListener("keydown", value, false);
        }
        /**
         * Fires when the user presses an alphanumeric key.
         * @param ev The event.
         */
        public event DOMEventHandler OnKeypress
        {
            add => AddEventListener("keypress", value, false);
            remove => RemoveEventListener("keypress", value, false);
        }
        /**
         * Fires when the user releases a key.
         * @param ev The keyboard event
         */
        public event DOMEventHandler OnKeyup
        {
            add => AddEventListener("keyup", value, false);
            remove => RemoveEventListener("keyup", value, false);
        }
        /**
         * Fires immediately after the browser loads the object.
         * @param ev The event.
         */
        public event DOMEventHandler OnLoad
        {
            add => AddEventListener("load", value, false);
            remove => RemoveEventListener("load", value, false);
        }
        /**
         * Occurs when media data is loaded at the current playback position.
         * @param ev The event.
         */
        public event DOMEventHandler OnLoadeddata
        {
            add => AddEventListener("loadeddata", value, false);
            remove => RemoveEventListener("loadeddata", value, false);
        }
        /**
         * Occurs when the duration and dimensions of the media have been determined.
         * @param ev The event.
         */
        public event DOMEventHandler OnLoadedmetadata
        {
            add => AddEventListener("loadedmetadata", value, false);
            remove => RemoveEventListener("loadedmetadata", value, false);
        }
        /**
         * Occurs when Internet Explorer begins looking for media data.
         * @param ev The event.
         */
        public event DOMEventHandler OnLoadstart
        {
            add => AddEventListener("loadstart", value, false);
            remove => RemoveEventListener("loadstart", value, false);
        }
        /**
         * Fires when the user clicks the object with either mouse button.
         * @param ev The mouse event.
         */
        public event DOMEventHandler OnMousedown
        {
            add => AddEventListener("mousedown", value, false);
            remove => RemoveEventListener("mousedown", value, false);
        }
        /**
         * Fires when the user moves the mouse over the object.
         * @param ev The mouse event.
         */
        public event DOMEventHandler OnMousemove
        {
            add => AddEventListener("mousemove", value, false);
            remove => RemoveEventListener("mousemove", value, false);
        }
        /**
         * Fires when the user moves the mouse pointer outside the boundaries of the object.
         * @param ev The mouse event.
         */
        public event DOMEventHandler OnMouseout
        {
            add => AddEventListener("mouseout", value, false);
            remove => RemoveEventListener("mouseout", value, false);
        }
        /**
         * Fires when the user moves the mouse pointer into the object.
         * @param ev The mouse event.
         */
        public event DOMEventHandler OnMouseover
        {
            add => AddEventListener("mouseover", value, false);
            remove => RemoveEventListener("mouseover", value, false);
        }
        /**
         * Fires when the user releases a mouse button while the mouse is over the object.
         * @param ev The mouse event.
         */
        public event DOMEventHandler OnMouseup
        {
            add => AddEventListener("mouseup", value, false);
            remove => RemoveEventListener("mouseup", value, false);
        }
        /**
         * Fires when the wheel button is rotated.
         * @param ev The mouse event
         */
        public event DOMEventHandler OnMousewheel
        {
            add => AddEventListener("mousewheel", value, false);
            remove => RemoveEventListener("mousewheel", value, false);
        }
        public event DOMEventHandler OnMscontentzoom
        {
            add => AddEventListener("mscontentzoom", value, false);
            remove => RemoveEventListener("mscontentzoom", value, false);
        }
        public event DOMEventHandler OnMsgesturechange
        {
            add => AddEventListener("msgesturechange", value, false);
            remove => RemoveEventListener("msgesturechange", value, false);
        }
        public event DOMEventHandler OnMsgesturedoubletap
        {
            add => AddEventListener("msgesturedoubletap", value, false);
            remove => RemoveEventListener("msgesturedoubletap", value, false);
        }
        public event DOMEventHandler OnMsgestureend
        {
            add => AddEventListener("msgestureend", value, false);
            remove => RemoveEventListener("msgestureend", value, false);
        }
        public event DOMEventHandler OnMsgesturehold
        {
            add => AddEventListener("msgesturehold", value, false);
            remove => RemoveEventListener("msgesturehold", value, false);
        }
        public event DOMEventHandler OnMsgesturestart
        {
            add => AddEventListener("msgesturestart", value, false);
            remove => RemoveEventListener("msgesturestart", value, false);
        }
        public event DOMEventHandler OnMsgesturetap
        {
            add => AddEventListener("msgesturetap", value, false);
            remove => RemoveEventListener("msgesturetap", value, false);
        }
        public event DOMEventHandler OnMsinertiastart
        {
            add => AddEventListener("msinertiastart", value, false);
            remove => RemoveEventListener("msinertiastart", value, false);
        }
        public event DOMEventHandler OnMsmanipulationstatechanged
        {
            add => AddEventListener("msmanipulationstatechanged", value, false);
            remove => RemoveEventListener("msmanipulationstatechanged", value, false);
        }
        public event DOMEventHandler OnMspointercancel
        {
            add => AddEventListener("mspointercancel", value, false);
            remove => RemoveEventListener("mspointercancel", value, false);
        }
        public event DOMEventHandler OnMspointerdown
        {
            add => AddEventListener("mspointerdown", value, false);
            remove => RemoveEventListener("mspointerdown", value, false);
        }
        public event DOMEventHandler OnMspointerenter
        {
            add => AddEventListener("mspointerenter", value, false);
            remove => RemoveEventListener("mspointerenter", value, false);
        }
        public event DOMEventHandler OnMspointerleave
        {
            add => AddEventListener("mspointerleave", value, false);
            remove => RemoveEventListener("mspointerleave", value, false);
        }
        public event DOMEventHandler OnMspointermove
        {
            add => AddEventListener("mspointermove", value, false);
            remove => RemoveEventListener("mspointermove", value, false);
        }
        public event DOMEventHandler OnMspointerout
        {
            add => AddEventListener("mspointerout", value, false);
            remove => RemoveEventListener("mspointerout", value, false);
        }
        public event DOMEventHandler OnMspointerover
        {
            add => AddEventListener("mspointerover", value, false);
            remove => RemoveEventListener("mspointerover", value, false);
        }
        public event DOMEventHandler OnMspointerup
        {
            add => AddEventListener("mspointerup", value, false);
            remove => RemoveEventListener("mspointerup", value, false);
        }
        /**
         * Occurs when an item is removed from a Jump List of a webpage running in Site Mode.
         * @param ev The event.
         */
        public event DOMEventHandler OnMssitemodejumplistitemremoved
        {
            add => AddEventListener("mssitemodejumplistitemremoved", value, false);
            remove => RemoveEventListener("mssitemodejumplistitemremoved", value, false);
        }
        /**
         * Occurs when a user clicks a button in a Thumbnail Toolbar of a webpage running in Site Mode.
         * @param ev The event.
         */
        public event DOMEventHandler OnMsthumbnailclick
        {
            add => AddEventListener("msthumbnailclick", value, false);
            remove => RemoveEventListener("msthumbnailclick", value, false);
        }
        /**
         * Occurs when playback is paused.
         * @param ev The event.
         */
        public event DOMEventHandler OnPause
        {
            add => AddEventListener("pause", value, false);
            remove => RemoveEventListener("pause", value, false);
        }
        /**
         * Occurs when the play method is requested.
         * @param ev The event.
         */
        public event DOMEventHandler OnPlay
        {
            add => AddEventListener("play", value, false);
            remove => RemoveEventListener("play", value, false);
        }
        /**
         * Occurs when the audio or video has started playing.
         * @param ev The event.
         */
        public event DOMEventHandler OnPlaying
        {
            add => AddEventListener("playing", value, false);
            remove => RemoveEventListener("playing", value, false);
        }
        public event DOMEventHandler OnPointerlockchange
        {
            add => AddEventListener("pointerlockchange", value, false);
            remove => RemoveEventListener("pointerlockchange", value, false);
        }
        public event DOMEventHandler OnPointerlockerror
        {
            add => AddEventListener("pointerlockerror", value, false);
            remove => RemoveEventListener("pointerlockerror", value, false);
        }
        /**
         * Occurs to indicate progress while downloading media data.
         * @param ev The event.
         */
        public event DOMEventHandler OnProgress
        {
            add => AddEventListener("progress", value, false);
            remove => RemoveEventListener("progress", value, false);
        }
        /**
         * Occurs when the playback rate is increased or decreased.
         * @param ev The event.
         */
        public event DOMEventHandler OnRatechange
        {
            add => AddEventListener("ratechange", value, false);
            remove => RemoveEventListener("ratechange", value, false);
        }
        /**
         * Fires when the state of the object has changed.
         * @param ev The event
         */
        public event DOMEventHandler OnReadystatechange
        {
            add => AddEventListener("readystatechange", value, false);
            remove => RemoveEventListener("readystatechange", value, false);
        }
        /**
         * Fires when the user resets a form.
         * @param ev The event.
         */
        public event DOMEventHandler OnReset
        {
            add => AddEventListener("reset", value, false);
            remove => RemoveEventListener("reset", value, false);
        }
        /**
         * Fires when the user repositions the scroll box in the scroll bar on the object.
         * @param ev The event.
         */
        public event DOMEventHandler OnScroll
        {
            add => AddEventListener("scroll", value, false);
            remove => RemoveEventListener("scroll", value, false);
        }
        /**
         * Occurs when the seek operation ends.
         * @param ev The event.
         */
        public event DOMEventHandler OnSeeked
        {
            add => AddEventListener("seeked", value, false);
            remove => RemoveEventListener("seeked", value, false);
        }
        /**
         * Occurs when the current playback position is moved.
         * @param ev The event.
         */
        public event DOMEventHandler OnSeeking
        {
            add => AddEventListener("seeking", value, false);
            remove => RemoveEventListener("seeking", value, false);
        }
        /**
         * Fires when the current selection changes.
         * @param ev The event.
         */
        public event DOMEventHandler OnSelect
        {
            add => AddEventListener("select", value, false);
            remove => RemoveEventListener("select", value, false);
        }
        /**
         * Fires when the selection state of a document changes.
         * @param ev The event.
         */
        public event DOMEventHandler OnSelectionchange
        {
            add => AddEventListener("selectionchange", value, false);
            remove => RemoveEventListener("selectionchange", value, false);
        }
        public event DOMEventHandler OnSelectstart
        {
            add => AddEventListener("selectstart", value, false);
            remove => RemoveEventListener("selectstart", value, false);
        }
        /**
         * Occurs when the download has stopped.
         * @param ev The event.
         */
        public event DOMEventHandler OnStalled
        {
            add => AddEventListener("stalled", value, false);
            remove => RemoveEventListener("stalled", value, false);
        }
        /**
         * Fires when the user clicks the Stop button or leaves the Web page.
         * @param ev The event.
         */
        public event DOMEventHandler OnStop
        {
            add => AddEventListener("stop", value, false);
            remove => RemoveEventListener("stop", value, false);
        }
        public event DOMEventHandler OnSubmit
        {
            add => AddEventListener("submit", value, false);
            remove => RemoveEventListener("submit", value, false);
        }
        /**
         * Occurs if the load operation has been intentionally halted.
         * @param ev The event.
         */
        public event DOMEventHandler OnSuspend
        {
            add => AddEventListener("suspend", value, false);
            remove => RemoveEventListener("suspend", value, false);
        }
        /**
         * Occurs to indicate the current playback position.
         * @param ev The event.
         */
        public event DOMEventHandler OnTimeupdate
        {
            add => AddEventListener("timeupdate", value, false);
            remove => RemoveEventListener("timeupdate", value, false);
        }
        // [Export("ontouchcancel")]
        // public Action Ontouchcancel { get => GetProperty<Action>("ontouchcancel"); set => SetProperty<Action>("ontouchcancel", value); }
        // [Export("ontouchend")]
        // public Action Ontouchend { get => GetProperty<Action>("ontouchend"); set => SetProperty<Action>("ontouchend", value); }
        // [Export("ontouchmove")]
        // public Action Ontouchmove { get => GetProperty<Action>("ontouchmove"); set => SetProperty<Action>("ontouchmove", value); }
        // [Export("ontouchstart")]
        // public Action Ontouchstart { get => GetProperty<Action>("ontouchstart"); set => SetProperty<Action>("ontouchstart", value); }
        public event DOMEventHandler OnVolumechange
        {
            add => AddEventListener("volumechange", value, false);
            remove => RemoveEventListener("volumechange", value, false);
        }
        public event DOMEventHandler OnWaiting
        {
            add => AddEventListener("waiting", value, false);
            remove => RemoveEventListener("waiting", value, false);
        }
        public event DOMEventHandler OnWebkitfullscreenchange
        {
            add => AddEventListener("webkitfullscreenchange", value, false);
            remove => RemoveEventListener("webkitfullscreenchange", value, false);
        }
        public event DOMEventHandler OnWebkitfullscreenerror
        {
            add => AddEventListener("webkitfullscreenerror", value, false);
            remove => RemoveEventListener("webkitfullscreenerror", value, false);
        }
        // [Export("plugins")]
        // public HTMLCollectionOf<HTMLEmbedElement> Plugins { get => GetProperty<HTMLCollectionOf<HTMLEmbedElement>>("plugins"); set => SetProperty<HTMLCollectionOf<HTMLEmbedElement>>("plugins", value); }
        [Export("pointerLockElement")]
        public Element PointerLockElement => GetProperty<Element>("pointerLockElement");
        [Export("readyState")]
        public string ReadyState => GetProperty<string>("readyState");
        [Export("referrer")]
        public string Referrer => GetProperty<string>("referrer");
        // [Export("rootElement")]
        // public SVGSVGElement RootElement => GetProperty<SVGSVGElement>("rootElement");
        // [Export("scripts")]
        // public HTMLCollectionOf<HTMLScriptElement> Scripts { get => GetProperty<HTMLCollectionOf<HTMLScriptElement>>("scripts"); set => SetProperty<HTMLCollectionOf<HTMLScriptElement>>("scripts", value); }
        [Export("scrollingElement")]
        public Element ScrollingElement => GetProperty<Element>("scrollingElement");
        // [Export("styleSheets")]
        // public StyleSheetList StyleSheets => GetProperty<StyleSheetList>("styleSheets");
        [Export("title")]
        public string Title { get => GetProperty<string>("title"); set => SetProperty<string>("title", value); }
        /**
         * Sets or gets the URL for the current document.
         */
        [Export("URL")]
        public string Url => GetProperty<string>("URL");
        /**
         * Gets the URL for the document, stripped of any character encoding.
         */
        [Export("URLUnencoded")]
        public string UrlUnencoded => GetProperty<string>("URLUnencoded");
        // [Export("visibilityState")]
        // public VisibilityState VisibilityState => GetProperty<VisibilityState>("visibilityState");
        /**
         * Sets or gets the color of the links that the user has visited.
         */
        [Export("vlinkColor")]
        public string VlinkColor { get => GetProperty<string>("vlinkColor"); set => SetProperty<string>("vlinkColor", value); }
        [Export("webkitCurrentFullScreenElement")]
        public Element WebkitCurrentFullScreenElement => GetProperty<Element>("webkitCurrentFullScreenElement");
        [Export("webkitFullscreenElement")]
        public Element WebkitFullscreenElement => GetProperty<Element>("webkitFullscreenElement");
        [Export("webkitFullscreenEnabled")]
        public bool WebkitFullscreenEnabled => GetProperty<bool>("webkitFullscreenEnabled");
        [Export("webkitIsFullScreen")]
        public bool WebkitIsFullScreen => GetProperty<bool>("webkitIsFullScreen");
        [Export("xmlEncoding")]
        public string XmlEncoding => GetProperty<string>("xmlEncoding");
        [Export("xmlStandalone")]
        public bool XmlStandalone { get => GetProperty<bool>("xmlStandalone"); set => SetProperty<bool>("xmlStandalone", value); }
        [Export("xmlVersion")]
        public string XmlVersion { get => GetProperty<string>("xmlVersion"); set => SetProperty<string>("xmlVersion", value); }
        //[Export("ownerDocument")]
        //public Document OwnerDocument => GetProperty<Document>("ownerDocument");
        [Export("parentElement")]
        public new HTMLElement ParentElement => GetProperty<HTMLElement>("parentElement");
        [Export("parentNode")]
        public Node IParentNode => GetProperty<Node>("parentNode");
        public event DOMEventHandler OnPointercancel
        {
            add => AddEventListener("pointercancel", value, false);
            remove => RemoveEventListener("pointercancel", value, false);
        }
        public event DOMEventHandler OnPointerdown
        {
            add => AddEventListener("pointerdown", value, false);
            remove => RemoveEventListener("pointerdown", value, false);
        }
        public event DOMEventHandler OnPointerenter
        {
            add => AddEventListener("pointerenter", value, false);
            remove => RemoveEventListener("pointerenter", value, false);
        }
        public event DOMEventHandler OnPointerleave
        {
            add => AddEventListener("pointerleave", value, false);
            remove => RemoveEventListener("pointerleave", value, false);
        }
        public event DOMEventHandler OnPointermove
        {
            add => AddEventListener("pointermove", value, false);
            remove => RemoveEventListener("pointermove", value, false);
        }
        public event DOMEventHandler OnPointerout
        {
            add => AddEventListener("pointerout", value, false);
            remove => RemoveEventListener("pointerout", value, false);
        }
        public event DOMEventHandler OnPointerover
        {
            add => AddEventListener("pointerover", value, false);
            remove => RemoveEventListener("pointerover", value, false);
        }
        public event DOMEventHandler OnPointerup
        {
            add => AddEventListener("pointerup", value, false);
            remove => RemoveEventListener("pointerup", value, false);
        }
        public event DOMEventHandler OnWheel
        {
            add => AddEventListener("wheel", value, false);
            remove => RemoveEventListener("wheel", value, false);
        }
        [Export("children")]
        public HTMLCollection Children => GetProperty<HTMLCollection>("children");
        [Export("firstElementChild")]
        public Element FirstElementChild => GetProperty<Element>("firstElementChild");
        [Export("lastElementChild")]
        public Element LastElementChild => GetProperty<Element>("lastElementChild");
        [Export("childElementCount")]
        public double ChildElementCount => GetProperty<double>("childElementCount");
        // [Export("stylesheets")]
        // public StyleSheetList Stylesheets => GetProperty<StyleSheetList>("stylesheets");
        [Export("captureEvents")]
        public void CaptureEvents()
        {
            InvokeMethod<object>("captureEvents");
        }
        // [Export("caretRangeFromPoint")]
        // public Range CaretRangeFromPoint(double x, double y)
        // {
        //     return InvokeMethod<Range>("caretRangeFromPoint", x, y);
        // }
        [Export("clear")]
        public void Clear()
        {
            InvokeMethod<object>("clear");
        }
        [Export("close")]
        public void Close()
        {
            InvokeMethod<object>("close");
        }
        [Export("createAttribute")]
        public Attr CreateAttribute(string name)
        {
            return InvokeMethod<Attr>("createAttribute", name);
        }
        [Export("createAttributeNS")]
        public Attr CreateAttributeNs(string namespaceURI, string qualifiedName)
        {
            return InvokeMethod<Attr>("createAttributeNS", namespaceURI, qualifiedName);
        }
        // [Export("createCDATASection")]
        // public CDATASection CreateCdataSection(string data)
        // {
        //     return InvokeMethod<CDATASection>("createCDATASection", data);
        // }
        // [Export("createComment")]
        // public Comment CreateComment(string data)
        // {
        //     return InvokeMethod<Comment>("createComment", data);
        // }
        [Export("createDocumentFragment")]
        public DocumentFragment CreateDocumentFragment()
        {
            return InvokeMethod<DocumentFragment>("createDocumentFragment");
        }
        [Export("createElementNS")]
        public HTMLElement CreateElementNs(string namespaceURI, string qualifiedName)
        {
            return InvokeMethod<HTMLElement>("createElementNS", namespaceURI, qualifiedName);
        }

        [Export("createElement")]
        public HTMLElement CreateElement(string tagName)
        {
            return InvokeMethod<HTMLElement>("createElement", tagName);
        }
        [Export("createElement")]
        public T CreateElement<T>() 
        {
            var tagName = string.Empty;
            var typeOfT = typeof(T);
            if (typeof(HTMLButtonElement) == typeOfT)
            {
                tagName = "button";
            }
            else
                throw new NotSupportedException($"Element of type {typeOfT} is not supported yet.  Please use the method CreateElement(tagName).");

            return InvokeMethod<T>("createElement", tagName);
        }
        // [Export("createExpression")]
        // public XPathExpression CreateExpression(string expression, XPathNSResolver resolver)
        // {
        //     return InvokeMethod<XPathExpression>("createExpression", expression, resolver);
        // }
        // [Export("createNodeIterator")]
        // public NodeIterator CreateNodeIterator(INode root, double whatToShow, NodeFilter filter, bool entityReferenceExpansion)
        // {
        //     return InvokeMethod<NodeIterator>("createNodeIterator", root, whatToShow, filter, entityReferenceExpansion);
        // }
        // [Export("createNSResolver")]
        // public XPathNSResolver CreateNsResolver(INode nodeResolver)
        // {
        //     return InvokeMethod<XPathNSResolver>("createNSResolver", nodeResolver);
        // }
        // [Export("createProcessingInstruction")]
        // public ProcessingInstruction CreateProcessingInstruction(string target, string data)
        // {
        //     return InvokeMethod<ProcessingInstruction>("createProcessingInstruction", target, data);
        // }
        /**
         *  Returns an empty range object that has both of its boundary points positioned at the beginning of the document.
         */
        // [Export("createRange")]
        // public Range CreateRange()
        // {
        //     return InvokeMethod<Range>("createRange");
        // }
        /**
         * Creates a text string from the specified value.
         * @param data String that specifies the nodeValue property of the text node.
         */
        // [Export("createTextNode")]
        // public Text CreateTextNode(string data)
        // {
        //     return InvokeMethod<Text>("createTextNode", data);
        // }
        // [Export("createTouch")]
        // public Touch CreateTouch(Window view, EventTarget target, double identifier, double pageX, double pageY, double screenX, double screenY)
        // {
        //     return InvokeMethod<Touch>("createTouch", view, target, identifier, pageX, pageY, screenX, screenY);
        // }
        // [Export("createTouchList")]
        // public TouchList CreateTouchList(params Touch[] touches)
        // {
        //     return InvokeMethod<TouchList>("createTouchList", touches);
        // }
        // [Export("createTreeWalker")]
        // public TreeWalker CreateTreeWalker(INode root, double whatToShow, NodeFilter filter, bool entityReferenceExpansion)
        // {
        //     return InvokeMethod<TreeWalker>("createTreeWalker", root, whatToShow, filter, entityReferenceExpansion);
        // }
        [Export("elementFromPoint")]
        public Element ElementFromPoint(double x, double y)
        {
            return InvokeMethod<Element>("elementFromPoint", x, y);
        }
        // [Export("evaluate")]
        // public XPathResult Evaluate(string expression, INode contextNode, XPathNSResolver resolver, double type, XPathResult result)
        // {
        //     return InvokeMethod<XPathResult>("evaluate", expression, contextNode, resolver, type, result);
        // }
        [Export("execCommand")]
        public bool ExecCommand(string commandId, bool showUI, Object value)
        {
            return InvokeMethod<bool>("execCommand", commandId, showUI, value);
        }
        [Export("execCommandShowHelp")]
        public bool ExecCommandShowHelp(string commandId)
        {
            return InvokeMethod<bool>("execCommandShowHelp", commandId);
        }
        [Export("exitFullscreen")]
        public void ExitFullscreen()
        {
            InvokeMethod<object>("exitFullscreen");
        }
        [Export("exitPointerLock")]
        public void ExitPointerLock()
        {
            InvokeMethod<object>("exitPointerLock");
        }
        [Export("focus")]
        public void Focus()
        {
            InvokeMethod<object>("focus");
        }
         [Export("getElementById")]
         public HTMLElement GetElementById(string elementId)
         {
             return InvokeMethod<HTMLElement>("getElementById", elementId);
         }
         [Export("getElementsByClassName")]
         public HTMLCollectionOf<Element> GetElementsByClassName(string classNames)
         {
             return InvokeMethod<HTMLCollectionOf<Element>>("getElementsByClassName", classNames);
         }
         [Export("getElementsByName")]
         public NodeListOf<HTMLElement> GetElementsByName(string elementName)
         {
             return InvokeMethod<NodeListOf<HTMLElement>>("getElementsByName", elementName);
         }
        [Export("getElementsByTagNameNS")]
        public HTMLCollectionOf<HTMLElement> GetElementsByTagNameNs(string namespaceURI, string localName)
        {
            return InvokeMethod<HTMLCollectionOf<HTMLElement>>("getElementsByTagNameNS", namespaceURI, localName);
        }
        [Export("getElementsByTagName")]
        public NodeListOf<Element> GetElementsByTagName(string name)
        {
            return InvokeMethod<NodeListOf<Element>>("getElementsByTagName", name);
        }
        [Export("querySelectorAll")]
        public NodeListOf<T> QuerySelectorAll<T>(string selectors)
        {
            return InvokeMethod<NodeListOf<T>>("querySelectorAll", selectors);
        }

        [Export("querySelectorAll")]
        public NodeListOf<Element> QuerySelectorAll(string selectors)
        {
            return InvokeMethod<NodeListOf<Element>>("querySelectorAll", selectors);
        }
        [Export("querySelector")]
        public T QuerySelector<T>(string selectors)
        {
            return InvokeMethod<T>("querySelector", selectors);
        }
        [Export("querySelector")]
        public Element QuerySelector(string selectors)
        {
            return InvokeMethod<Element>("querySelector", selectors);
        }
        // [Export("getSelection")]
        // public Selection GetSelection()
        // {
        //     return InvokeMethod<Selection>("getSelection");
        // }
        /**
         * Gets a value indicating whether the object currently has focus.
         */
        [Export("hasFocus")]
        public bool HasFocus()
        {
            return InvokeMethod<bool>("hasFocus");
        }
        [Export("importNode")]
        public T ImportNode<T>(T importedNode, bool deep) where T : Node
        {
            return InvokeMethod<T>("importNode", importedNode, deep);
        }
         [Export("msElementsFromPoint")]
         public NodeListOf<Element> MsElementsFromPoint(double x, double y)
         {
             return InvokeMethod<NodeListOf<Element>>("msElementsFromPoint", x, y);
         }
         [Export("msElementsFromRect")]
         public NodeListOf<Element> MsElementsFromRect(double left, double top, double width, double height)
         {
             return InvokeMethod<NodeListOf<Element>>("msElementsFromRect", left, top, width, height);
         }
        [Export("open")]
        public Document Open(string url, string name, string features, bool replace)
        {
            return InvokeMethod<Document>("open", url, name, features, replace);
        }
        [Export("queryCommandEnabled")]
        public bool QueryCommandEnabled(string commandId)
        {
            return InvokeMethod<bool>("queryCommandEnabled", commandId);
        }
        [Export("queryCommandIndeterm")]
        public bool QueryCommandIndeterm(string commandId)
        {
            return InvokeMethod<bool>("queryCommandIndeterm", commandId);
        }
        [Export("queryCommandState")]
        public bool QueryCommandState(string commandId)
        {
            return InvokeMethod<bool>("queryCommandState", commandId);
        }
        [Export("queryCommandSupported")]
        public bool QueryCommandSupported(string commandId)
        {
            return InvokeMethod<bool>("queryCommandSupported", commandId);
        }
        [Export("queryCommandText")]
        public string QueryCommandText(string commandId)
        {
            return InvokeMethod<string>("queryCommandText", commandId);
        }
        [Export("queryCommandValue")]
        public string QueryCommandValue(string commandId)
        {
            return InvokeMethod<string>("queryCommandValue", commandId);
        }
        [Export("releaseEvents")]
        public void ReleaseEvents()
        {
            InvokeMethod<object>("releaseEvents");
        }
        [Export("updateSettings")]
        public void UpdateSettings()
        {
            InvokeMethod<object>("updateSettings");
        }
        [Export("webkitCancelFullScreen")]
        public void WebkitCancelFullScreen()
        {
            InvokeMethod<object>("webkitCancelFullScreen");
        }
        [Export("webkitExitFullscreen")]
        public void WebkitExitFullscreen()
        {
            InvokeMethod<object>("webkitExitFullscreen");
        }
        [Export("write")]
        public void Write(params string[] content)
        {
            InvokeMethod<object>("write", content);
        }
        [Export("writeln")]
        public void Writeln(params string[] content)
        {
            InvokeMethod<object>("writeln", content);
        }
        [Export("elementsFromPoint")]
        public Element[] ElementsFromPoint(double x, double y)
        {
            return InvokeMethod<Element[]>("elementsFromPoint", x, y);
        }
    }
}