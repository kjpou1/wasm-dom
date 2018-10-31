using System;
using System.Runtime.CompilerServices;
using WebAssembly;
using WebAssembly.Browser.DOM.Events;

namespace WebAssembly.Browser.DOM
{

    public interface IEventTarget
    {
        [Export("addEventListener")]
        void AddEventListener(string type, DOMEventHandler listener, object options);
        [Export("dispatchEvent")]
        bool DispatchEvent(Event evt);
        [Export("removeEventListener")]
        void RemoveEventListener(string type, DOMEventHandler listener, object options);
        int DispatchDOMEvent(string eventType, string typeOfEvent, JSObject eventTarget, JSObject eventHandle,
                                      bool evAltKey,
                                      bool evBubbles,
                                      bool evCancelable,
                                      bool evCtrlKey,
                                      int evDetail,
                                      int evEventPhase,
                                      bool evMetaKey,
                                      bool evShiftKey,
                                      int evKeyCode,
                                      int evPointerId,
                                      string evPointerType,
                                      double evScreenX,
                                      double evScreenY,
                                      double timeStamp,
                                      bool evIsTrusted,
                                      bool evScoped,
                                      double evClientX,
                                      double evClientY,
                                      int evButton,
                             string eventInfo);

    }

    public interface INode : IEventTarget
    {
        // needs to be generated again
    }


    public interface INamedNodeMap
    {
        [Export("length")]
        double Length { get; }
        [Export("getNamedItem")]
        Attr GetNamedItem(string name);
        [Export("getNamedItemNS")]
        Attr GetNamedItemNs(string namespaceURI, string localName);
        [Export("item")]
        Attr Item(double index);
        [Export("removeNamedItem")]
        Attr RemoveNamedItem(string name);
        [Export("removeNamedItemNS")]
        Attr RemoveNamedItemNs(string namespaceURI, string localName);
        [Export("setNamedItem")]
        Attr SetNamedItem(Attr arg);
        [Export("setNamedItemNS")]
        Attr SetNamedItemNs(Attr arg);
        [IndexerName("TheItem")]  
        Attr this[double index] { get; set; }
    }

    public interface IHistory
    {
        [Export("length")]
        double Length { get; }
        [Export("state")]
        Object State { get; }
        [Export("scrollRestoration")]
        ScrollRestoration ScrollRestoration { get; set; }
        [Export("back")]
        void Back();
        [Export("forward")]
        void Forward();
        [Export("go")]
        void Go(double delta);
        [Export("pushState")]
        void PushState(Object data, string title, string url);
        [Export("replaceState")]
        void ReplaceState(Object data, string title, string url);
    }

    public interface INodeList
    {
        [Export("length")]
        double Length { get; }
        [Export("item")]
        Node Item(double index);
        [IndexerName("TheItem")]
        Node this[double index] { get; set; }
    }

    public interface IElementTraversal
    {
        [Export("childElementCount")]
        double ChildElementCount { get; }
        [Export("firstElementChild")]
        Element FirstElementChild { get; }
        [Export("lastElementChild")]
        Element LastElementChild { get; }
        [Export("nextElementSibling")]
        Element NextElementSibling { get; }
        [Export("previousElementSibling")]
        Element PreviousElementSibling { get; }
    }

    public interface IDOMTokenList
    {
        [Export("length")]
        double Length { get; }
        [Export("add")]
        void Add(params string[] token);
        [Export("contains")]
        bool Contains(string token);
        [Export("item")]
        string Item(double index);
        [Export("remove")]
        void Remove(params string[] token);
        [Export("toggle")]
        bool Toggle(string token, bool force);
        [Export("toString")]
        string ToString();
        [IndexerName("TheItem")]
        string this[double index] { get; set; }
    }



    public interface INodeSelector
    {
    }

    public interface IChildNode
    {
        [Export("remove")]
        void Remove();
    }

    public interface IParentNode
    {
        //[Export("children")]
        //HTMLCollection Children { get; }
        [Export("firstElementChild")]
        Element FirstElementChild { get; }
        [Export("lastElementChild")]
        Element LastElementChild { get; }
        [Export("childElementCount")]
        double ChildElementCount { get; }
    }

    public interface IHTMLCollectionBase
    {
        /**
         * Sets or retrieves the number of objects in a collection.
         */
        [Export("length")]
        double Length { get; }
        /**
         * Retrieves an object from various collections.
         */
        [Export("item")]
        Element Item(double index);
        [IndexerName("TheItem")]
        Element this[double index] { get; set; }
    }

    public interface IHTMLCollection : IHTMLCollectionBase
    {
        /**
         * Retrieves a select object or an object from an options collection.
         */
        [Export("namedItem")]
        Element NamedItem(string name);
    }


    public interface IElement : INode, IElementTraversal, INodeSelector, IChildNode, IParentNode //IGlobalEventHandlers, 
    {
        [Export("classList")]
        DOMTokenList ClassList { get; }
        [Export("className")]
        string ClassName { get; set; }
        [Export("clientHeight")]
        double ClientHeight { get; }
        [Export("clientLeft")]
        double ClientLeft { get; }
        [Export("clientTop")]
        double ClientTop { get; }
        [Export("clientWidth")]
        double ClientWidth { get; }
        [Export("id")]
        string Id { get; set; }
        [Export("innerHTML")]
        string InnerHtml { get; set; }
        [Export("msContentZoomFactor")]
        double MsContentZoomFactor { get; set; }
        [Export("msRegionOverflow")]
        string MsRegionOverflow { get; }
        event DOMEventHandler OnAriarequest;
        event DOMEventHandler OnCommand;
        event DOMEventHandler OnGotpointercapture;
        event DOMEventHandler OnLostpointercapture;
        event DOMEventHandler OnMsgesturechange;
        event DOMEventHandler OnMsgesturedoubletap;
        event DOMEventHandler OnMsgestureend;
        event DOMEventHandler OnMsgesturehold;
        event DOMEventHandler OnMsgesturestart;
        event DOMEventHandler OnMsgesturetap;
        event DOMEventHandler OnMsgotpointercapture;
        event DOMEventHandler OnMsinertiastart;
        event DOMEventHandler OnMslostpointercapture;
        event DOMEventHandler OnMspointercancel;
        event DOMEventHandler OnMspointerdown;
        event DOMEventHandler OnMspointerenter;
        event DOMEventHandler OnMspointerleave;
        event DOMEventHandler OnMspointermove;
        event DOMEventHandler OnMspointerout;
        event DOMEventHandler OnMspointerover;
        event DOMEventHandler OnMspointerup;
        [Export("ontouchcancel")]
        Action Ontouchcancel { get; set; }
        [Export("ontouchend")]
        Action Ontouchend { get; set; }
        [Export("ontouchmove")]
        Action Ontouchmove { get; set; }
        [Export("ontouchstart")]
        Action Ontouchstart { get; set; }
        event DOMEventHandler OnWebkitfullscreenchange;
        event DOMEventHandler OnWebkitfullscreenerror;
        [Export("outerHTML")]
        string OuterHtml { get; set; }
        [Export("prefix")]
        string Prefix { get; }
        [Export("scrollHeight")]
        double ScrollHeight { get; }
        [Export("scrollLeft")]
        double ScrollLeft { get; set; }
        [Export("scrollTop")]
        double ScrollTop { get; set; }
        [Export("scrollWidth")]
        double ScrollWidth { get; }
        [Export("tagName")]
        string TagName { get; }
        //[Export("assignedSlot")]
        //HTMLSlotElement AssignedSlot { get; }
        [Export("slot")]
        string Slot { get; set; }
        //[Export("shadowRoot")]
        //ShadowRoot ShadowRoot { get; }
        [Export("getAttribute")]
        string GetAttribute(string name);
        [Export("getAttributeNode")]
        Attr GetAttributeNode(string name);
        [Export("getAttributeNodeNS")]
        Attr GetAttributeNodeNs(string namespaceURI, string localName);
        [Export("getAttributeNS")]
        string GetAttributeNs(string namespaceURI, string localName);
        [Export("getBoundingClientRect")]
        object GetBoundingClientRect();
        [Export("getClientRects")]
        object GetClientRects();
        [Export("getElementsByTagName")]
        NodeListOf<Element> GetElementsByTagName(string name);
        [Export("getElementsByTagNameNS")]
        HTMLCollectionOf<HTMLElement> GetElementsByTagNameNs(string namespaceURI, string localName);
        //[Export("getElementsByTagNameNS")]
        //HTMLCollectionOf<SVGElement> GetElementsByTagNameNs(string namespaceURI, string localName);
        //[Export("getElementsByTagNameNS")]
        //HTMLCollectionOf<Element> GetElementsByTagNameNs(string namespaceURI, string localName);
        [Export("hasAttribute")]
        bool HasAttribute(string name);
        [Export("hasAttributeNS")]
        bool HasAttributeNs(string namespaceURI, string localName);
        //[Export("msGetRegionContent")]
        //MSRangeCollection MsGetRegionContent();
        //[Export("msGetUntransformedBounds")]
        //ClientRect MsGetUntransformedBounds();
        [Export("msMatchesSelector")]
        bool MsMatchesSelector(string selectors);
        [Export("msReleasePointerCapture")]
        void MsReleasePointerCapture(double pointerId);
        [Export("msSetPointerCapture")]
        void MsSetPointerCapture(double pointerId);
        //[Export("msZoomTo")]
        //void MsZoomTo(MsZoomToOptions args);
        [Export("releasePointerCapture")]
        void ReleasePointerCapture(double pointerId);
        [Export("removeAttribute")]
        void RemoveAttribute(string qualifiedName);
        [Export("removeAttributeNode")]
        Attr RemoveAttributeNode(Attr oldAttr);
        [Export("removeAttributeNS")]
        void RemoveAttributeNs(string namespaceURI, string localName);
        [Export("requestFullscreen")]
        void RequestFullscreen();
        [Export("requestPointerLock")]
        void RequestPointerLock();
        [Export("setAttribute")]
        void SetAttribute(string name, string value);
        [Export("setAttributeNode")]
        Attr SetAttributeNode(Attr newAttr);
        [Export("setAttributeNodeNS")]
        Attr SetAttributeNodeNs(Attr newAttr);
        [Export("setAttributeNS")]
        void SetAttributeNs(string namespaceURI, string qualifiedName, string value);
        [Export("setPointerCapture")]
        void SetPointerCapture(double pointerId);
        [Export("webkitMatchesSelector")]
        bool WebkitMatchesSelector(string selectors);
        [Export("webkitRequestFullscreen")]
        void WebkitRequestFullscreen();
        [Export("webkitRequestFullScreen")]
        void WebkitRequestFullScreen();
        [Export("getElementsByClassName")]
        NodeListOf<Element> GetElementsByClassName(string classNames);
        [Export("matches")]
        bool Matches(string selector);
        [Export("closest")]
        Element Closest(string selector);
        //[Export("scrollIntoView")]
        //void ScrollIntoView(object arg);
        //[Export("scroll")]
        //void Scroll(ScrollToOptions options);
        [Export("scroll")]
        void Scroll(double x, double y);
        //[Export("scrollTo")]
        //void ScrollTo(ScrollToOptions options);
        [Export("scrollTo")]
        void ScrollTo(double x, double y);
        //[Export("scrollBy")]
        //void ScrollBy(ScrollToOptions options);
        [Export("scrollBy")]
        void ScrollBy(double x, double y);
        [Export("insertAdjacentElement")]
        Element InsertAdjacentElement(InsertPosition position, Element insertedElement);
        [Export("insertAdjacentHTML")]
        void InsertAdjacentHtml(InsertPosition where, string html);
        [Export("insertAdjacentText")]
        void InsertAdjacentText(InsertPosition where, string text);
        //[Export("attachShadow")]
        //ShadowRoot AttachShadow(ShadowRootInit shadowRootInitDict);
        //[Export("addEventListener")]
        //void AddEventListener(string type, DOMEventHandler listener, object options);
        //[Export("removeEventListener")]
        //void RemoveEventListener(string type, DOMEventHandler listener, object options);
    }

    public interface IHTMLElement : IElement
    {
        [Export("accessKey")]
        string AccessKey { get; set; }
        [Export("children")]
        HTMLCollection Children { get; }
        [Export("contentEditable")]
        string ContentEditable { get; set; }
        //[Export("dataset")]
        //DOMStringMap Dataset { get; }
        [Export("dir")]
        string Dir { get; set; }
        [Export("draggable")]
        bool Draggable { get; set; }
        [Export("hidden")]
        bool Hidden { get; set; }
        [Export("hideFocus")]
        bool HideFocus { get; set; }
        [Export("innerText")]
        string InnerText { get; set; }
        [Export("isContentEditable")]
        bool IsContentEditable { get; }
        [Export("lang")]
        string Lang { get; set; }
        [Export("offsetHeight")]
        double OffsetHeight { get; }
        [Export("offsetLeft")]
        double OffsetLeft { get; }
        [Export("offsetParent")]
        Element OffsetParent { get; }
        [Export("offsetTop")]
        double OffsetTop { get; }
        [Export("offsetWidth")]
        double OffsetWidth { get; }
        event DOMEventHandler OnAbort;
        event DOMEventHandler OnActivate;
        event DOMEventHandler OnBeforeactivate;
        event DOMEventHandler OnBeforecopy;
        event DOMEventHandler OnBeforecut;
        event DOMEventHandler OnBeforedeactivate;
        event DOMEventHandler OnBeforepaste;
        event DOMEventHandler OnBlur;
        event DOMEventHandler OnCanplay;
        event DOMEventHandler OnCanplaythrough;
        event DOMEventHandler OnChange;
        event DOMEventHandler OnClick;
        event DOMEventHandler OnContextmenu;
        event DOMEventHandler OnCopy;
        event DOMEventHandler OnCuechange;
        event DOMEventHandler OnCut;
        event DOMEventHandler OnDblclick;
        event DOMEventHandler OnDeactivate;
        event DOMEventHandler OnDrag;
        event DOMEventHandler OnDragend;
        event DOMEventHandler OnDragenter;
        event DOMEventHandler OnDragleave;
        event DOMEventHandler OnDragover;
        event DOMEventHandler OnDragstart;
        event DOMEventHandler OnDrop;
        event DOMEventHandler OnDurationchange;
        event DOMEventHandler OnEmptied;
        event DOMEventHandler OnEnded;
        event DOMEventHandler OnError;
        event DOMEventHandler OnFocus;
        event DOMEventHandler OnInput;
        event DOMEventHandler OnInvalid;
        event DOMEventHandler OnKeydown;
        event DOMEventHandler OnKeypress;
        event DOMEventHandler OnKeyup;
        event DOMEventHandler OnLoad;
        event DOMEventHandler OnLoadeddata;
        event DOMEventHandler OnLoadedmetadata;
        event DOMEventHandler OnLoadstart;
        event DOMEventHandler OnMousedown;
        event DOMEventHandler OnMouseenter;
        event DOMEventHandler OnMouseleave;
        event DOMEventHandler OnMousemove;
        event DOMEventHandler OnMouseout;
        event DOMEventHandler OnMouseover;
        event DOMEventHandler OnMouseup;
        event DOMEventHandler OnMousewheel;
        event DOMEventHandler OnMscontentzoom;
        event DOMEventHandler OnMsmanipulationstatechanged;
        event DOMEventHandler OnPaste;
        event DOMEventHandler OnPause;
        event DOMEventHandler OnPlay;
        event DOMEventHandler OnPlaying;
        event DOMEventHandler OnProgress;
        event DOMEventHandler OnRatechange;
        event DOMEventHandler OnReset;
        event DOMEventHandler OnScroll;
        event DOMEventHandler OnSeeked;
        event DOMEventHandler OnSeeking;
        event DOMEventHandler OnSelect;
        event DOMEventHandler OnSelectstart;
        event DOMEventHandler OnStalled;
        event DOMEventHandler OnSubmit;
        event DOMEventHandler OnSuspend;
        event DOMEventHandler OnTimeupdate;
        event DOMEventHandler OnVolumechange;
        event DOMEventHandler OnWaiting;
        [Export("outerText")]
        string OuterText { get; set; }
        [Export("spellcheck")]
        bool Spellcheck { get; set; }
        //[Export("style")]
        //CSSStyleDeclaration Style { get; }
        [Export("tabIndex")]
        double TabIndex { get; set; }
        [Export("title")]
        string Title { get; set; }
        [Export("blur")]
        void Blur();
        [Export("click")]
        void Click();
        [Export("dragDrop")]
        bool DragDrop();
        [Export("focus")]
        void Focus();
        //[Export("msGetInputContext")]
        //MSInputMethodContext MsGetInputContext();
    }

    public interface ILinkStyle
    {
        [Export("sheet")]
        StyleSheet Sheet { get; }
    }

    public interface IStyleSheet
    {
        [Export("disabled")]
        bool Disabled { get; set; }
        [Export("href")]
        string Href { get; }
        //[Export("media")]
        //MediaList Media { get; }
        [Export("ownerNode")]
        Node OwnerNode { get; }
        [Export("parentStyleSheet")]
        StyleSheet ParentStyleSheet { get; }
        [Export("title")]
        string Title { get; }
        [Export("type")]
        string Type { get; }
    }

    public interface IHTMLLinkElement //: IHTMLElement, ILinkStyle
    {
        /**
         * Sets or retrieves the character set used to encode the object.
         */
        [Export("charset")]
        string Charset { get; set; }
        [Export("disabled")]
        bool Disabled { get; set; }
        /**
         * Sets or retrieves a destination URL or an anchor point.
         */
        [Export("href")]
        string Href { get; set; }
        /**
         * Sets or retrieves the language code of the object.
         */
        [Export("hreflang")]
        string Hreflang { get; set; }
        /**
         * Sets or retrieves the media type.
         */
        [Export("media")]
        string Media { get; set; }
        /**
         * Sets or retrieves the relationship between the object and the destination of the link.
         */
        [Export("rel")]
        string Rel { get; set; }
        /**
         * Sets or retrieves the relationship between the object and the destination of the link.
         */
        [Export("rev")]
        string Rev { get; set; }
        /**
         * Sets or retrieves the window or frame at which to target content.
         */
        [Export("target")]
        string Target { get; set; }
        /**
         * Sets or retrieves the MIME type of the object.
         */
        [Export("type")]
        string Type { get; set; }
        [Export("import")]
        Document Import { get; set; }
        [Export("integrity")]
        string Integrity { get; set; }
    //    [Export("addEventListener")]
    //    void AddEventListener(string type, DOMEventHandler listener, object options);
    //    [Export("removeEventListener")]
    //    void RemoveEventListener(string type, DOMEventHandler listener, object options);
    }

    public interface IHTMLTemplateElement : IHTMLElement
    {
        [Export("content")]
        DocumentFragment Content { get; }
    }

    //public interface IDocumentFragment : INode, INodeSelector, IParentNode
    //{
    //    [Export("getElementById")]
    //    HTMLElement GetElementById(string elementId);
    //}

    public interface IHTMLParagraphElement : IHTMLElement
    {
        /**
         * Sets or retrieves how the object is aligned with adjacent text.
         */
        [Export("align")]
        string Align { get; set; }
        [Export("clear")]
        string Clear { get; set; }
    }

    public interface IHTMLButtonElement : IHTMLElement
    {
        [Export("autofocus")]
        bool Autofocus { get; set; }
        [Export("disabled")]
        bool Disabled { get; set; }
        //[Export("form")]
        //HTMLFormElement Form { get; }
        [Export("formAction")]
        string FormAction { get; set; }
        [Export("formEnctype")]
        string FormEnctype { get; set; }
        [Export("formMethod")]
        string FormMethod { get; set; }
        [Export("formNoValidate")]
        string FormNoValidate { get; set; }
        [Export("formTarget")]
        string FormTarget { get; set; }
        [Export("name")]
        string Name { get; set; }
        [Export("status")]
        Object Status { get; set; }
        [Export("type")]
        string Type { get; set; }
        [Export("validationMessage")]
        string ValidationMessage { get; }
        //[Export("validity")]
        //ValidityState Validity { get; }
        [Export("value")]
        string Value { get; set; }
        [Export("willValidate")]
        bool WillValidate { get; }
        [Export("checkValidity")]
        bool CheckValidity();
        [Export("setCustomValidity")]
        void SetCustomValidity(string error);
        //[Export("addEventListener")]
        //void AddEventListener(string type, DOMEventHandler listener, object options);
        //[Export("removeEventListener")]
        //void RemoveEventListener(string type, DOMEventHandler listener, object options);
    }


    public interface IEventInit
    {
        [Export("scoped")]
        bool Scoped { get; set; }
        [Export("bubbles")]
        bool Bubbles { get; set; }
        [Export("cancelable")]
        bool Cancelable { get; set; }
    }

    public interface IErrorEventInit : IEventInit
    {
        [Export("colno")]
        double Colno { get; set; }
        [Export("error")]
        Object Error { get; set; }
        [Export("filename")]
        string Filename { get; set; }
        [Export("lineno")]
        double Lineno { get; set; }
        [Export("message")]
        string Message { get; set; }
    }

    public interface IEvent
    {
        [Export("bubbles")]
        bool Bubbles { get; }
        [Export("cancelable")]
        bool Cancelable { get; }
        [Export("cancelBubble")]
        bool CancelBubble { get; set; }
        [Export("currentTarget")]
        EventTarget CurrentTarget { get; }
        [Export("defaultPrevented")]
        bool DefaultPrevented { get; }
        [Export("eventPhase")]
        double EventPhase { get; }
        [Export("isTrusted")]
        bool IsTrusted { get; }
        [Export("returnValue")]
        bool ReturnValue { get; set; }
        [Export("srcElement")]
        Element SrcElement { get; }
        [Export("target")]
        EventTarget Target { get; }
        [Export("timeStamp")]
        double TimeStamp { get; }
        [Export("type")]
        string Type { get; }
        [Export("scoped")]
        bool Scoped { get; }
        [Export("initEvent")]
        void InitEvent(string eventTypeArg, bool canBubbleArg, bool cancelableArg);
        [Export("preventDefault")]
        void PreventDefault();
        [Export("stopImmediatePropagation")]
        void StopImmediatePropagation();
        [Export("stopPropagation")]
        void StopPropagation();
        [Export("deepPath")]
        EventTarget[] DeepPath();
        [Export("AT_TARGET")]
        double AtTarget { get; }
        [Export("BUBBLING_PHASE")]
        double BubblingPhase { get; }
        [Export("CAPTURING_PHASE")]
        double CapturingPhase { get; }
    }

    public interface IUIEventInit : IEventInit
    {
        [Export("detail")]
        double Detail { get; set; }
        [Export("view")]
        Window View { get; set; }
    }

    public interface IUIEvent : IEvent
    {
        [Export("detail")]
        double Detail { get; }
        [Export("view")]
        Window View { get; }
        [Export("initUIEvent")]
        void InitUiEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, double detailArg);
    }

    public interface IMouseEvent : IUIEvent
    {
        [Export("altKey")]
        bool AltKey { get; }
        [Export("button")]
        double Button { get; }
        [Export("buttons")]
        double Buttons { get; }
        [Export("clientX")]
        double ClientX { get; }
        [Export("clientY")]
        double ClientY { get; }
        [Export("ctrlKey")]
        bool CtrlKey { get; }
        [Export("fromElement")]
        Element FromElement { get; }
        [Export("layerX")]
        double LayerX { get; }
        [Export("layerY")]
        double LayerY { get; }
        [Export("metaKey")]
        bool MetaKey { get; }
        [Export("movementX")]
        double MovementX { get; }
        [Export("movementY")]
        double MovementY { get; }
        [Export("offsetX")]
        double OffsetX { get; }
        [Export("offsetY")]
        double OffsetY { get; }
        [Export("pageX")]
        double PageX { get; }
        [Export("pageY")]
        double PageY { get; }
        [Export("relatedTarget")]
        EventTarget RelatedTarget { get; }
        [Export("screenX")]
        double ScreenX { get; }
        [Export("screenY")]
        double ScreenY { get; }
        [Export("shiftKey")]
        bool ShiftKey { get; }
        [Export("toElement")]
        Element ToElement { get; }
        [Export("which")]
        double Which { get; }
        [Export("x")]
        double X { get; }
        [Export("y")]
        double Y { get; }
        [Export("getModifierState")]
        bool GetModifierState(string keyArg);
        [Export("initMouseEvent")]
        void InitMouseEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, double detailArg, double screenXArg, double screenYArg, double clientXArg, double clientYArg, bool ctrlKeyArg, bool altKeyArg, bool shiftKeyArg, bool metaKeyArg, double buttonArg, EventTarget relatedTargetArg);
    }

    public interface IMouseEventInit : IEventModifierInit
    {
        [Export("button")]
        double Button { get; set; }
        [Export("buttons")]
        double Buttons { get; set; }
        [Export("clientX")]
        double ClientX { get; set; }
        [Export("clientY")]
        double ClientY { get; set; }
        [Export("relatedTarget")]
        EventTarget RelatedTarget { get; set; }
        [Export("screenX")]
        double ScreenX { get; set; }
        [Export("screenY")]
        double ScreenY { get; set; }
    }

    public interface IPointerEvent : IMouseEvent
    {
        [Export("currentPoint")]
        Object CurrentPoint { get; }
        [Export("height")]
        double Height { get; }
        [Export("hwTimestamp")]
        double HwTimestamp { get; }
        [Export("intermediatePoints")]
        Object IntermediatePoints { get; }
        [Export("isPrimary")]
        bool IsPrimary { get; }
        [Export("pointerId")]
        double PointerId { get; }
        [Export("pointerType")]
        Object PointerType { get; }
        [Export("pressure")]
        double Pressure { get; }
        [Export("rotation")]
        double Rotation { get; }
        [Export("tiltX")]
        double TiltX { get; }
        [Export("tiltY")]
        double TiltY { get; }
        [Export("width")]
        double Width { get; }
        [Export("getCurrentPoint")]
        void GetCurrentPoint(Element element);
        [Export("getIntermediatePoints")]
        void GetIntermediatePoints(Element element);
        [Export("initPointerEvent")]
        void InitPointerEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, double detailArg, double screenXArg, double screenYArg, double clientXArg, double clientYArg, bool ctrlKeyArg, bool altKeyArg, bool shiftKeyArg, bool metaKeyArg, double buttonArg, EventTarget relatedTargetArg, double offsetXArg, double offsetYArg, double widthArg, double heightArg, double pressure, double rotation, double tiltX, double tiltY, double pointerIdArg, Object pointerType, double hwTimestampArg, bool isPrimary);
    }

    public interface IPointerEventInit : IMouseEventInit
    {
        [Export("height")]
        double Height { get; set; }
        [Export("isPrimary")]
        bool IsPrimary { get; set; }
        [Export("pointerId")]
        double PointerId { get; set; }
        [Export("pointerType")]
        string PointerType { get; set; }
        [Export("pressure")]
        double Pressure { get; set; }
        [Export("tiltX")]
        double TiltX { get; set; }
        [Export("tiltY")]
        double TiltY { get; set; }
        [Export("width")]
        double Width { get; set; }
    }

    public interface IWheelEvent : IMouseEvent
    {
        [Export("deltaMode")]
        double DeltaMode { get; }
        [Export("deltaX")]
        double DeltaX { get; }
        [Export("deltaY")]
        double DeltaY { get; }
        [Export("deltaZ")]
        double DeltaZ { get; }
        [Export("wheelDelta")]
        double WheelDelta { get; }
        [Export("wheelDeltaX")]
        double WheelDeltaX { get; }
        [Export("wheelDeltaY")]
        double WheelDeltaY { get; }
        [Export("getCurrentPoint")]
        void GetCurrentPoint(Element element);
        [Export("initWheelEvent")]
        void InitWheelEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, double detailArg, double screenXArg, double screenYArg, double clientXArg, double clientYArg, double buttonArg, EventTarget relatedTargetArg, string modifiersListArg, double deltaXArg, double deltaYArg, double deltaZArg, double deltaMode);
        [Export("DOM_DELTA_LINE")]
        double DomDeltaLine { get; }
        [Export("DOM_DELTA_PAGE")]
        double DomDeltaPage { get; }
        [Export("DOM_DELTA_PIXEL")]
        double DomDeltaPixel { get; }
    }

    public interface IWheelEventInit : IMouseEventInit
    {
        [Export("deltaMode")]
        double DeltaMode { get; set; }
        [Export("deltaX")]
        double DeltaX { get; set; }
        [Export("deltaY")]
        double DeltaY { get; set; }
        [Export("deltaZ")]
        double DeltaZ { get; set; }
    }

    public interface IDragEvent : IMouseEvent
    {
        [Export("dataTransfer")]
        DataTransfer DataTransfer { get; }
        //[Export("initDragEvent")]
        //void InitDragEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, double detailArg, double screenXArg, double screenYArg, double clientXArg, double clientYArg, bool ctrlKeyArg, bool altKeyArg, bool shiftKeyArg, bool metaKeyArg, double buttonArg, EventTarget relatedTargetArg, IDataTransfer dataTransferArg);
        //[Export("msConvertURL")]
        //void MsConvertUrl(File file, string targetType, string targetURL);
    }

    public interface IFocusEvent : IUIEvent
    {
        [Export("relatedTarget")]
        EventTarget RelatedTarget { get; }
        //[Export("initFocusEvent")]
        //void InitFocusEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, double detailArg, EventTarget relatedTargetArg);
    }



    public interface IEventModifierInit : IUIEventInit
    {
        [Export("altKey")]
        bool AltKey { get; set; }
        [Export("ctrlKey")]
        bool CtrlKey { get; set; }
        [Export("metaKey")]
        bool MetaKey { get; set; }
        [Export("modifierAltGraph")]
        bool ModifierAltGraph { get; set; }
        [Export("modifierCapsLock")]
        bool ModifierCapsLock { get; set; }
        [Export("modifierFn")]
        bool ModifierFn { get; set; }
        [Export("modifierFnLock")]
        bool ModifierFnLock { get; set; }
        [Export("modifierHyper")]
        bool ModifierHyper { get; set; }
        [Export("modifierNumLock")]
        bool ModifierNumLock { get; set; }
        [Export("modifierOS")]
        bool ModifierOs { get; set; }
        [Export("modifierScrollLock")]
        bool ModifierScrollLock { get; set; }
        [Export("modifierSuper")]
        bool ModifierSuper { get; set; }
        [Export("modifierSymbol")]
        bool ModifierSymbol { get; set; }
        [Export("modifierSymbolLock")]
        bool ModifierSymbolLock { get; set; }
        [Export("shiftKey")]
        bool ShiftKey { get; set; }
    }

    public interface IDataTransfer
    {
        [Export("dropEffect")]
        string DropEffect { get; set; }
        [Export("effectAllowed")]
        string EffectAllowed { get; set; }
        //[Export("files")]
        //FileList Files { get; }
        [Export("items")]
        DataTransferItemList Items { get; }
        [Export("types")]
        string[] Types { get; }
        [Export("clearData")]
        bool ClearData(string format);
        [Export("getData")]
        string GetData(string format);
        [Export("setData")]
        bool SetData(string format, string data);
        [Export("setDragImage")]
        void SetDragImage(Element image, double x, double y);
    }

    public interface IDataTransferItem
    {
        [Export("kind")]
        string Kind { get; }
        [Export("type")]
        string Type { get; }
        //[Export("getAsFile")]
        //File GetAsFile();
        //[Export("getAsString")]
        //void GetAsString(FunctionStringCallback _callback);
        //[Export("webkitGetAsEntry")]
        //Object WebkitGetAsEntry();
    }

    public interface IDataTransferItemList
    {
        [Export("length")]
        double Length { get; }
        //[Export("add")]
        //IDataTransferItem Add(File data);
        [Export("clear")]
        void Clear();
        [Export("item")]
        DataTransferItem Item(double index);
        [Export("remove")]
        void Remove(double index);
        [IndexerName("TheItem")]
        DataTransferItem this[double index] { get; set; }
    }




    public interface IURLSearchParams
    {
        [Export("append")]
        void Append(string name, string value);
        [Export("delete")]
        void Delete(string name);
        [Export("get")]
        string Get(string name);
        [Export("getAll")]
        string[] GetAll(string name);
        [Export("has")]
        bool Has(string name);
        [Export("set")]
        void Set(string name, string value);
    }

    public interface IURL
    {
        [Export("hash")]
        string Hash { get; set; }
        [Export("host")]
        string Host { get; set; }
        [Export("hostname")]
        string Hostname { get; set; }
        [Export("href")]
        string Href { get; set; }
        [Export("origin")]
        string Origin { get; }
        [Export("password")]
        string Password { get; set; }
        [Export("pathname")]
        string Pathname { get; set; }
        [Export("port")]
        string Port { get; set; }
        [Export("protocol")]
        string Protocol { get; set; }
        [Export("search")]
        string Search { get; set; }
        [Export("username")]
        string Username { get; set; }
        [Export("searchParams")]
        URLSearchParams SearchParams { get; }
        [Export("toString")]
        string ToString();
    }

    public interface IHTMLDivElement : IHTMLElement
    {
        [Export("align")]
        string Align { get; set; }
        [Export("noWrap")]
        bool NoWrap { get; set; }
    }


    public interface IText : ICharacterData
    {
        [Export("wholeText")]
        string WholeText { get; }
        //[Export("assignedSlot")]
        //HTMLSlotElement AssignedSlot { get; }
        //[Export("splitText")]
        //IText SplitText(double offset);
    }

    public interface ICharacterData : INode, IChildNode
    {
        [Export("data")]
        string Data { get; set; }
        [Export("length")]
        double Length { get; }
        [Export("appendData")]
        void AppendData(string arg);
        [Export("deleteData")]
        void DeleteData(double offset, double count);
        [Export("insertData")]
        void InsertData(double offset, string arg);
        [Export("replaceData")]
        void ReplaceData(double offset, double count, string arg);
        [Export("substringData")]
        string SubstringData(double offset, double count);
    }

    public interface IHTMLUListElement : IHTMLElement
    {
        [Export("compact")]
        bool Compact { get; set; }
        [Export("type")]
        string Type { get; set; }
    }


    public interface IHTMLLIElement : IHTMLElement
    {
        [Export("type")]
        string Type { get; set; }
        [Export("value")]
        double Value { get; set; }
    }

    public interface IHTMLFormElement : IHTMLElement
    {
        [Export("acceptCharset")]
        string AcceptCharset { get; set; }
        [Export("action")]
        string Action { get; set; }
        [Export("autocomplete")]
        string Autocomplete { get; set; }
        [Export("elements")]
        HTMLFormControlsCollection Elements { get; }
        [Export("encoding")]
        string Encoding { get; set; }
        [Export("enctype")]
        string Enctype { get; set; }
        [Export("length")]
        double Length { get; }
        [Export("method")]
        string Method { get; set; }
        [Export("name")]
        string Name { get; set; }
        [Export("noValidate")]
        bool NoValidate { get; set; }
        [Export("target")]
        string Target { get; set; }
        [Export("checkValidity")]
        bool CheckValidity();
        //[Export("item")]
        //Element Item(Object name, Object index);
        [Export("namedItem")]
        Element NamedItem(string name);
        [Export("reset")]
        void Reset();
        [Export("submit")]
        void Submit();
        [Export("reportValidity")]
        bool ReportValidity();
        Element this[string name] { get; set; }
    }

    public interface IHTMLLabelElement : IHTMLElement
    {
        [Export("form")]
        HTMLFormElement Form { get; }
        [Export("htmlFor")]
        string HtmlFor { get; set; }
        [Export("control")]
        HTMLInputElement Control { get; }
    }

    public interface IHTMLInputElement : IHTMLElement
    {
        [Export("accept")]
        string Accept { get; set; }
        [Export("align")]
        string Align { get; set; }
        [Export("alt")]
        string Alt { get; set; }
        [Export("autocomplete")]
        string Autocomplete { get; set; }
        [Export("autofocus")]
        bool Autofocus { get; set; }
        [Export("border")]
        string Border { get; set; }
        [Export("checked")]
        bool Checked { get; set; }
        [Export("complete")]
        bool Complete { get; }
        [Export("defaultChecked")]
        bool DefaultChecked { get; set; }
        [Export("defaultValue")]
        string DefaultValue { get; set; }
        [Export("disabled")]
        bool Disabled { get; set; }
        //[Export("files")]
        //FileList Files { get; }
        [Export("form")]
        HTMLFormElement Form { get; }
        [Export("formAction")]
        string FormAction { get; set; }
        [Export("formEnctype")]
        string FormEnctype { get; set; }
        [Export("formMethod")]
        string FormMethod { get; set; }
        [Export("formNoValidate")]
        string FormNoValidate { get; set; }
        [Export("formTarget")]
        string FormTarget { get; set; }
        [Export("height")]
        string Height { get; set; }
        [Export("hspace")]
        double Hspace { get; set; }
        [Export("indeterminate")]
        bool Indeterminate { get; set; }
        [Export("list")]
        HTMLElement List { get; }
        [Export("max")]
        string Max { get; set; }
        [Export("maxLength")]
        double MaxLength { get; set; }
        [Export("min")]
        string Min { get; set; }
        [Export("multiple")]
        bool Multiple { get; set; }
        [Export("name")]
        string Name { get; set; }
        [Export("pattern")]
        string Pattern { get; set; }
        [Export("placeholder")]
        string Placeholder { get; set; }
        [Export("readOnly")]
        bool ReadOnly { get; set; }
        [Export("required")]
        bool Required { get; set; }
        [Export("selectionDirection")]
        string SelectionDirection { get; set; }
        [Export("selectionEnd")]
        double SelectionEnd { get; set; }
        [Export("selectionStart")]
        double SelectionStart { get; set; }
        [Export("size")]
        double Size { get; set; }
        [Export("src")]
        string Src { get; set; }
        [Export("status")]
        bool Status { get; set; }
        [Export("step")]
        string Step { get; set; }
        [Export("type")]
        InputElementType Type { get; set; }
        [Export("useMap")]
        string UseMap { get; set; }
        [Export("validationMessage")]
        string ValidationMessage { get; }
        [Export("validity")]
        ValidityState Validity { get; }
        [Export("value")]
        string Value { get; set; }
        //[Export("valueAsDate")]
        //Date ValueAsDate { get; set; }
        [Export("valueAsNumber")]
        double ValueAsNumber { get; set; }
        [Export("vspace")]
        double Vspace { get; set; }
        [Export("webkitdirectory")]
        bool Webkitdirectory { get; set; }
        [Export("width")]
        string Width { get; set; }
        [Export("willValidate")]
        bool WillValidate { get; }
        [Export("minLength")]
        double MinLength { get; set; }
        [Export("checkValidity")]
        bool CheckValidity();
        [Export("select")]
        void Select();
        [Export("setCustomValidity")]
        void SetCustomValidity(string error);
        [Export("setSelectionRange")]
        void SetSelectionRange(double start, double end, object direction);
        [Export("stepDown")]
        void StepDown(double n);
        [Export("stepUp")]
        void StepUp(double n);
    }

    public interface IValidityState
    {
        [Export("badInput")]
        bool BadInput { get; }
        [Export("customError")]
        bool CustomError { get; }
        [Export("patternMismatch")]
        bool PatternMismatch { get; }
        [Export("rangeOverflow")]
        bool RangeOverflow { get; }
        [Export("rangeUnderflow")]
        bool RangeUnderflow { get; }
        [Export("stepMismatch")]
        bool StepMismatch { get; }
        [Export("tooLong")]
        bool TooLong { get; }
        [Export("typeMismatch")]
        bool TypeMismatch { get; }
        [Export("valid")]
        bool Valid { get; }
        [Export("valueMissing")]
        bool ValueMissing { get; }
        [Export("tooShort")]
        bool TooShort { get; }
    }

    public interface IClipboardEvent : IEvent
    {
        [Export("clipboardData")]
        DataTransfer ClipboardData { get; }
    }

    public interface IKeyboardEvent : IUIEvent
    {
        [Export("altKey")]
        bool AltKey { get; }
        [Export("char")]
        string Char { get; }
        [Export("charCode")]
        double CharCode { get; }
        [Export("ctrlKey")]
        bool CtrlKey { get; }
        [Export("key")]
        string Key { get; }
        [Export("keyCode")]
        double KeyCode { get; }
        [Export("locale")]
        string Locale { get; }
        [Export("location")]
        double Location { get; }
        [Export("metaKey")]
        bool MetaKey { get; }
        [Export("repeat")]
        bool Repeat { get; }
        [Export("shiftKey")]
        bool ShiftKey { get; }
        [Export("which")]
        double Which { get; }
        [Export("code")]
        string Code { get; }
        [Export("getModifierState")]
        bool GetModifierState(string keyArg);
        //[Export("initKeyboardEvent")]
        //void InitKeyboardEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, string keyArg, double locationArg, string modifiersListArg, bool repeat, string locale);
        [Export("DOM_KEY_LOCATION_JOYSTICK")]
        double DomKeyLocationJoystick { get; }
        [Export("DOM_KEY_LOCATION_LEFT")]
        double DomKeyLocationLeft { get; }
        [Export("DOM_KEY_LOCATION_MOBILE")]
        double DomKeyLocationMobile { get; }
        [Export("DOM_KEY_LOCATION_NUMPAD")]
        double DomKeyLocationNumpad { get; }
        [Export("DOM_KEY_LOCATION_RIGHT")]
        double DomKeyLocationRight { get; }
        [Export("DOM_KEY_LOCATION_STANDARD")]
        double DomKeyLocationStandard { get; }
    }

    public interface IHTMLFormControlsCollection : IHTMLCollectionBase
    {
        [Export("namedItem")]
        object NamedItem(string name);
    }

    public interface IDocumentType : INode, IChildNode
    {
        [Export("entities")]
        NamedNodeMap Entities { get; }
        [Export("internalSubset")]
        string InternalSubset { get; }
        [Export("name")]
        string Name { get; }
        [Export("notations")]
        NamedNodeMap Notations { get; }
        [Export("publicId")]
        string PublicId { get; }
        [Export("systemId")]
        string SystemId { get; }
    }

    public interface IHTMLAnchorElement : IHTMLElement
    {
        [Export("charset")]
        string Charset { get; set; }
        [Export("coords")]
        string Coords { get; set; }
        [Export("download")]
        string Download { get; set; }
        [Export("hash")]
        string Hash { get; set; }
        [Export("host")]
        string Host { get; set; }
        [Export("hostname")]
        string Hostname { get; set; }
        [Export("href")]
        string Href { get; set; }
        [Export("hreflang")]
        string Hreflang { get; set; }
        [Export("Methods")]
        string Methods { get; set; }
        [Export("mimeType")]
        string MimeType { get; }
        [Export("name")]
        string Name { get; set; }
        [Export("nameProp")]
        string NameProp { get; }
        [Export("pathname")]
        string Pathname { get; set; }
        [Export("port")]
        string Port { get; set; }
        [Export("protocol")]
        string Protocol { get; set; }
        [Export("protocolLong")]
        string ProtocolLong { get; }
        [Export("rel")]
        string Rel { get; set; }
        [Export("rev")]
        string Rev { get; set; }
        [Export("search")]
        string Search { get; set; }
        [Export("shape")]
        string Shape { get; set; }
        [Export("target")]
        string Target { get; set; }
        [Export("text")]
        string Text { get; set; }
        [Export("type")]
        string Type { get; set; }
        [Export("urn")]
        string Urn { get; set; }
        [Export("toString")]
        string ToString();
    }

    public interface IHTMLFieldSetElement : IHTMLElement
    {
        [Export("align")]
        string Align { get; set; }
        [Export("disabled")]
        bool Disabled { get; set; }
        [Export("form")]
        HTMLFormElement Form { get; }
        [Export("name")]
        string Name { get; set; }
        [Export("validationMessage")]
        string ValidationMessage { get; }
        [Export("validity")]
        ValidityState Validity { get; }
        [Export("willValidate")]
        bool WillValidate { get; }
        [Export("checkValidity")]
        bool CheckValidity();
        [Export("setCustomValidity")]
        void SetCustomValidity(string error);
    }

    public interface IHTMLBRElement : IHTMLElement
    {
        [Export("clear")]
        string Clear { get; set; }
    }

    public interface IHTMLAreaElement : IHTMLElement
    {
        [Export("alt")]
        string Alt { get; set; }
        [Export("coords")]
        string Coords { get; set; }
        [Export("download")]
        string Download { get; set; }
        [Export("hash")]
        string Hash { get; set; }
        [Export("host")]
        string Host { get; set; }
        [Export("hostname")]
        string Hostname { get; set; }
        [Export("href")]
        string Href { get; set; }
        [Export("noHref")]
        bool NoHref { get; set; }
        [Export("pathname")]
        string Pathname { get; set; }
        [Export("port")]
        string Port { get; set; }
        [Export("protocol")]
        string Protocol { get; set; }
        [Export("rel")]
        string Rel { get; set; }
        [Export("search")]
        string Search { get; set; }
        [Export("shape")]
        string Shape { get; set; }
        [Export("target")]
        string Target { get; set; }
        [Export("toString")]
        string ToString();
    }


    public interface IHTMLBaseElement : IHTMLElement
    {
        [Export("href")]
        string Href { get; set; }
        [Export("target")]
        string Target { get; set; }
    }


    public interface IHTMLQuoteElement : IHTMLElement
    {
        [Export("cite")]
        string Cite { get; set; }
    }

    public interface IHTMLHtmlElement : IHTMLElement
    {
        [Export("version")]
        string Version { get; set; }
    }

    public interface IHTMLHeadingElement : IHTMLElement
    {
        [Export("align")]
        string Align { get; set; }
    }

    public interface IHTMLBodyElement : IHTMLElement
    {
        [Export("aLink")]
        Object ALink { get; set; }
        [Export("background")]
        string Background { get; set; }
        [Export("bgColor")]
        Object BgColor { get; set; }
        [Export("bgProperties")]
        string BgProperties { get; set; }
        [Export("link")]
        Object Link { get; set; }
        [Export("noWrap")]
        bool NoWrap { get; set; }
        event DOMEventHandler OnAfterprint;
        event DOMEventHandler OnBeforeprint;
        event DOMEventHandler OnBeforeunload;
        event DOMEventHandler OnHashchange;
        event DOMEventHandler OnMessage;
        event DOMEventHandler OnOffline;
        event DOMEventHandler OnOnline;
        event DOMEventHandler OnOrientationchange;
        event DOMEventHandler OnPagehide;
        event DOMEventHandler OnPageshow;
        event DOMEventHandler OnPopstate;
        event DOMEventHandler OnResize;
        event DOMEventHandler OnStorage;
        event DOMEventHandler OnUnload;
        [Export("text")]
        Object Text { get; set; }
        [Export("vLink")]
        Object VLink { get; set; }
    }

    public interface IComment : ICharacterData
    {
        [Export("text")]
        string Text { get; set; }
    }

    public interface ICDATASection : IText
    {
    }

    public interface IHTMLHeadElement : IHTMLElement
    {
        [Export("profile")]
        string Profile { get; set; }
    }

    public interface IHTMLTableAlignment
    {
        [Export("ch")]
        string Ch { get; set; }
        [Export("chOff")]
        string ChOff { get; set; }
        [Export("vAlign")]
        string VAlign { get; set; }
    }

    public interface IHTMLTableColElement : IHTMLElement, IHTMLTableAlignment
    {
        [Export("align")]
        string Align { get; set; }
        [Export("span")]
        double Span { get; set; }
        [Export("width")]
        Object Width { get; set; }
    }

    public interface IHTMLTableCaptionElement : IHTMLElement
    {
        [Export("align")]
        string Align { get; set; }
        [Export("vAlign")]
        string VAlign { get; set; }
    }

    public interface IHTMLTableCellElement : IHTMLElement, IHTMLTableAlignment
    {
        [Export("abbr")]
        string Abbr { get; set; }
        [Export("align")]
        string Align { get; set; }
        [Export("axis")]
        string Axis { get; set; }
        [Export("bgColor")]
        Object BgColor { get; set; }
        [Export("cellIndex")]
        double CellIndex { get; }
        [Export("colSpan")]
        double ColSpan { get; set; }
        [Export("headers")]
        string Headers { get; set; }
        [Export("height")]
        Object Height { get; set; }
        [Export("noWrap")]
        bool NoWrap { get; set; }
        [Export("rowSpan")]
        double RowSpan { get; set; }
        [Export("scope")]
        string Scope { get; set; }
        [Export("width")]
        string Width { get; set; }
    }

    public interface IHTMLTableDataCellElement : IHTMLTableCellElement
    {
    }


    public interface IHTMLTableSectionElement : IHTMLElement, IHTMLTableAlignment
    {
        [Export("align")]
        string Align { get; set; }
        [Export("rows")]
        HTMLCollectionOf<HTMLTableRowElement> Rows { get; set; }
        [Export("deleteRow")]
        void DeleteRow(double index);
        [Export("insertRow")]
        HTMLTableRowElement InsertRow(double index);
    }

    public interface IHTMLTableRowElement : IHTMLElement, IHTMLTableAlignment
    {
        [Export("align")]
        string Align { get; set; }
        [Export("bgColor")]
        Object BgColor { get; set; }
        [Export("cells")]
        HTMLCollectionOf<HTMLTableCellElement> Cells { get; set; }
        [Export("height")]
        Object Height { get; set; }
        [Export("rowIndex")]
        double RowIndex { get; }
        [Export("sectionRowIndex")]
        double SectionRowIndex { get; }
        [Export("deleteCell")]
        void DeleteCell(double index);
        [Export("insertCell")]
        HTMLTableDataCellElement InsertCell(double index);
    }

    public interface IHTMLTableHeaderCellElement : IHTMLTableCellElement 
    {
        //[Export("scope")]
        //string Scope { get; set; }
    }

    public interface IHTMLTableElement : IHTMLElement
    {
        [Export("align")]
        string Align { get; set; }
        [Export("bgColor")]
        Object BgColor { get; set; }
        [Export("border")]
        string Border { get; set; }
        [Export("borderColor")]
        Object BorderColor { get; set; }
        [Export("caption")]
        HTMLTableCaptionElement Caption { get; set; }
        [Export("cellPadding")]
        string CellPadding { get; set; }
        [Export("cellSpacing")]
        string CellSpacing { get; set; }
        [Export("cols")]
        double Cols { get; set; }
        [Export("frame")]
        string Frame { get; set; }
        [Export("height")]
        Object Height { get; set; }
        [Export("rows")]
        HTMLCollectionOf<HTMLTableRowElement> Rows { get; set; }
        [Export("rules")]
        string Rules { get; set; }
        [Export("summary")]
        string Summary { get; set; }
        [Export("tBodies")]
        HTMLCollectionOf<HTMLTableSectionElement> TBodies { get; set; }
        [Export("tFoot")]
        HTMLTableSectionElement TFoot { get; set; }
        [Export("tHead")]
        HTMLTableSectionElement THead { get; set; }
        [Export("width")]
        string Width { get; set; }
        [Export("createCaption")]
        HTMLTableCaptionElement CreateCaption();
        [Export("createTBody")]
        HTMLTableSectionElement CreateTBody();
        [Export("createTFoot")]
        HTMLTableSectionElement CreateTFoot();
        [Export("createTHead")]
        HTMLTableSectionElement CreateTHead();
        [Export("deleteCaption")]
        void DeleteCaption();
        [Export("deleteRow")]
        void DeleteRow(double index);
        [Export("deleteTFoot")]
        void DeleteTFoot();
        [Export("deleteTHead")]
        void DeleteTHead();
        [Export("insertRow")]
        HTMLTableRowElement InsertRow(double index);
    }

    public interface IHTMLUnknownElement : IHTMLElement
    {
    }

    public interface IDOML2DeprecatedColorProperty
    {
        [Export("color")]
        string Color { get; set; }
    }
    public interface IDOML2DeprecatedSizeProperty
    {
        [Export("size")]
        double Size { get; set; }
    }


    public interface IHTMLHRElement : IHTMLElement, IDOML2DeprecatedColorProperty, IDOML2DeprecatedSizeProperty
    {
        [Export("align")]
        string Align { get; set; }
        [Export("noShade")]
        bool NoShade { get; set; }
        [Export("width")]
        double Width { get; set; }
    }

    public interface IHTMLBaseFontElement : IHTMLElement, IDOML2DeprecatedColorProperty
    {
        [Export("face")]
        string Face { get; set; }
        [Export("size")]
        double Size { get; set; }
    }

    public interface IHTMLFontElement : IHTMLElement, IDOML2DeprecatedColorProperty, IDOML2DeprecatedSizeProperty
    {
        [Export("face")]
        string Face { get; set; }
    }

    public interface IHTMLSpanElement : IHTMLElement
    {
    }

    public interface IHTMLTitleElement : IHTMLElement
    {
        [Export("text")]
        string Text { get; set; }
    }

    public interface IHTMLStyleElement : IHTMLElement, ILinkStyle
    {
        [Export("disabled")]
        bool Disabled { get; set; }
        [Export("media")]
        string Media { get; set; }
        [Export("type")]
        string Type { get; set; }
    }

    public interface IHTMLMetaElement : IHTMLElement
    {
        [Export("charset")]
        string Charset { get; set; }
        [Export("content")]
        string Content { get; set; }
        [Export("httpEquiv")]
        string HttpEquiv { get; set; }
        [Export("name")]
        string Name { get; set; }
        [Export("scheme")]
        string Scheme { get; set; }
        [Export("url")]
        string Url { get; set; }
    }

    public interface IHTMLOListElement : IHTMLElement
    {
        [Export("compact")]
        bool Compact { get; set; }
        [Export("start")]
        double Start { get; set; }
        [Export("type")]
        string Type { get; set; }
    }

    public interface IHTMLOptGroupElement : IHTMLElement
    {
        [Export("defaultSelected")]
        bool DefaultSelected { get; set; }
        [Export("disabled")]
        bool Disabled { get; set; }
        [Export("form")]
        HTMLFormElement Form { get; }
        [Export("index")]
        double Index { get; }
        [Export("label")]
        string Label { get; set; }
        [Export("selected")]
        bool Selected { get; set; }
        [Export("text")]
        string Text { get; }
        [Export("value")]
        string Value { get; set; }
    }

    public interface IHTMLOptionElement : IHTMLElement
    {
        [Export("defaultSelected")]
        bool DefaultSelected { get; set; }
        [Export("disabled")]
        bool Disabled { get; set; }
        [Export("form")]
        HTMLFormElement Form { get; }
        [Export("index")]
        double Index { get; }
        [Export("label")]
        string Label { get; set; }
        [Export("selected")]
        bool Selected { get; set; }
        [Export("text")]
        string Text { get; set; }
        [Export("value")]
        string Value { get; set; }
    }

    public interface IHTMLSelectElement : IHTMLElement
    {
        [Export("autofocus")]
        bool Autofocus { get; set; }
        [Export("disabled")]
        bool Disabled { get; set; }
        [Export("form")]
        HTMLFormElement Form { get; }
        [Export("length")]
        double Length { get; set; }
        [Export("multiple")]
        bool Multiple { get; set; }
        [Export("name")]
        string Name { get; set; }
        [Export("options")]
        HTMLOptionsCollection Options { get; }
        [Export("required")]
        bool Required { get; set; }
        [Export("selectedIndex")]
        double SelectedIndex { get; set; }
        [Export("selectedOptions")]
        HTMLCollectionOf<HTMLOptionElement> SelectedOptions { get; set; }
        [Export("size")]
        double Size { get; set; }
        [Export("type")]
        string Type { get; }
        [Export("validationMessage")]
        string ValidationMessage { get; }
        [Export("validity")]
        ValidityState Validity { get; }
        [Export("value")]
        string Value { get; set; }
        [Export("willValidate")]
        bool WillValidate { get; }
        [Export("add")]
        void Add(HTMLElement element, object before);
        [Export("checkValidity")]
        bool CheckValidity();
        [Export("item")]
        Object Item(Object name, Object index);
        [Export("namedItem")]
        Object NamedItem(string name);
        [Export("remove")]
        void Remove(double index);
        [Export("setCustomValidity")]
        void SetCustomValidity(string error);
        [IndexerName("TheItem")]
        Object this[string name] { get; set; }
    }

    public interface IHTMLTextAreaElement : IHTMLElement
    {
        [Export("autofocus")]
        bool Autofocus { get; set; }
        [Export("cols")]
        double Cols { get; set; }
        [Export("defaultValue")]
        string DefaultValue { get; set; }
        [Export("disabled")]
        bool Disabled { get; set; }
        [Export("form")]
        HTMLFormElement Form { get; }
        [Export("maxLength")]
        double MaxLength { get; set; }
        [Export("name")]
        string Name { get; set; }
        [Export("placeholder")]
        string Placeholder { get; set; }
        [Export("readOnly")]
        bool ReadOnly { get; set; }
        [Export("required")]
        bool Required { get; set; }
        [Export("rows")]
        double Rows { get; set; }
        [Export("selectionEnd")]
        double SelectionEnd { get; set; }
        [Export("selectionStart")]
        double SelectionStart { get; set; }
        [Export("status")]
        Object Status { get; set; }
        [Export("type")]
        string Type { get; }
        [Export("validationMessage")]
        string ValidationMessage { get; }
        [Export("validity")]
        ValidityState Validity { get; }
        [Export("value")]
        string Value { get; set; }
        [Export("willValidate")]
        bool WillValidate { get; }
        [Export("wrap")]
        string Wrap { get; set; }
        [Export("minLength")]
        double MinLength { get; set; }
        [Export("checkValidity")]
        bool CheckValidity();
        [Export("select")]
        void Select();
        [Export("setCustomValidity")]
        void SetCustomValidity(string error);
        [Export("setSelectionRange")]
        void SetSelectionRange(double start, double end, object direction);
    }

    public interface IHTMLDataElement : IHTMLElement
    {
        [Export("value")]
        string Value { get; set; }
    }

    public interface IHTMLDataListElement : IHTMLElement
    {
        [Export("options")]
        HTMLCollectionOf<HTMLOptionElement> Options { get; set; }
    }

    public interface IHTMLImageElement : IHTMLElement
    {
        [Export("align")]
        string Align { get; set; }
        [Export("alt")]
        string Alt { get; set; }
        [Export("border")]
        string Border { get; set; }
        [Export("complete")]
        bool Complete { get; }
        [Export("crossOrigin")]
        string CrossOrigin { get; set; }
        [Export("currentSrc")]
        string CurrentSrc { get; }
        [Export("height")]
        double Height { get; set; }
        [Export("hspace")]
        double Hspace { get; set; }
        [Export("isMap")]
        bool IsMap { get; set; }
        [Export("longDesc")]
        string LongDesc { get; set; }
        [Export("lowsrc")]
        string Lowsrc { get; set; }
        [Export("msPlayToDisabled")]
        bool MsPlayToDisabled { get; set; }
        [Export("msPlayToPreferredSourceUri")]
        string MsPlayToPreferredSourceUri { get; set; }
        [Export("msPlayToPrimary")]
        bool MsPlayToPrimary { get; set; }
        [Export("msPlayToSource")]
        Object MsPlayToSource { get; }
        [Export("name")]
        string Name { get; set; }
        [Export("naturalHeight")]
        double NaturalHeight { get; }
        [Export("naturalWidth")]
        double NaturalWidth { get; }
        [Export("sizes")]
        string Sizes { get; set; }
        [Export("src")]
        string Src { get; set; }
        [Export("srcset")]
        string Srcset { get; set; }
        [Export("useMap")]
        string UseMap { get; set; }
        [Export("vspace")]
        double Vspace { get; set; }
        [Export("width")]
        double Width { get; set; }
        [Export("x")]
        double X { get; }
        [Export("y")]
        double Y { get; }
        [Export("msGetAsCastingSource")]
        Object MsGetAsCastingSource();
    }

    public interface IHTMLModElement : IHTMLElement
    {
        [Export("cite")]
        string Cite { get; set; }
        [Export("dateTime")]
        string DateTime { get; set; }
    }


    public interface IHTMLPreElement : IHTMLElement
    {
        [Export("width")]
        double Width { get; set; }
    }

    public interface IHTMLMarqueeElement : IHTMLElement
    {
        [Export("behavior")]
        string Behavior { get; set; }
        [Export("bgColor")]
        Object BgColor { get; set; }
        [Export("direction")]
        string Direction { get; set; }
        [Export("height")]
        string Height { get; set; }
        [Export("hspace")]
        double Hspace { get; set; }
        [Export("loop")]
        double Loop { get; set; }
        event DOMEventHandler OnBounce;
        event DOMEventHandler OnFinish;
        event DOMEventHandler OnStart;
        [Export("scrollAmount")]
        double ScrollAmount { get; set; }
        [Export("scrollDelay")]
        double ScrollDelay { get; set; }
        [Export("trueSpeed")]
        bool TrueSpeed { get; set; }
        [Export("vspace")]
        double Vspace { get; set; }
        [Export("width")]
        string Width { get; set; }
        [Export("start")]
        void Start();
        [Export("stop")]
        void Stop();
    }

    public interface IHTMLTrackElement : IHTMLElement
    {
        [Export("default")]
        bool Default { get; set; }
        [Export("kind")]
        string Kind { get; set; }
        [Export("label")]
        string Label { get; set; }
        [Export("readyState")]
        double ReadyState { get; }
        [Export("src")]
        string Src { get; set; }
        [Export("srclang")]
        string Srclang { get; set; }
        //[Export("track")]
        //TextTrack Track { get; }
        [Export("ERROR")]
        double Error { get; }
        [Export("LOADED")]
        double Loaded { get; }
        [Export("LOADING")]
        double Loading { get; }
        [Export("NONE")]
        double None { get; }
    }

    public interface IHTMLTimeElement : IHTMLElement
    {
        [Export("dateTime")]
        string DateTime { get; set; }
    }

    public interface IHTMLLegendElement : IHTMLElement
    {
        [Export("align")]
        string Align { get; set; }
        [Export("form")]
        HTMLFormElement Form { get; }
    }

    public interface IHTMLMeterElement : IHTMLElement
    {
        [Export("high")]
        double High { get; set; }
        [Export("low")]
        double Low { get; set; }
        [Export("max")]
        double Max { get; set; }
        [Export("min")]
        double Min { get; set; }
        [Export("optimum")]
        double Optimum { get; set; }
        [Export("value")]
        double Value { get; set; }
    }

    public interface IHTMLProgressElement : IHTMLElement
    {
        [Export("form")]
        HTMLFormElement Form { get; }
        [Export("max")]
        double Max { get; set; }
        [Export("position")]
        double Position { get; }
        [Export("value")]
        double Value { get; set; }
    }

    public interface IHTMLSourceElement : IHTMLElement
    {
        [Export("media")]
        string Media { get; set; }
        [Export("msKeySystem")]
        string MsKeySystem { get; set; }
        [Export("sizes")]
        string Sizes { get; set; }
        [Export("src")]
        string Src { get; set; }
        [Export("srcset")]
        string Srcset { get; set; }
        [Export("type")]
        string Type { get; set; }
    }

    public interface IHTMLDirectoryElement : IHTMLElement
    {
        [Export("compact")]
        bool Compact { get; set; }
    }

    public interface IHTMLDListElement : IHTMLElement
    {
        [Export("compact")]
        bool Compact { get; set; }
    }

    public interface IHTMLParamElement : IHTMLElement
    {
        [Export("name")]
        string Name { get; set; }
        [Export("type")]
        string Type { get; set; }
        [Export("value")]
        string Value { get; set; }
        [Export("valueType")]
        string ValueType { get; set; }
    }

    public interface IHTMLAreasCollection : IHTMLCollectionBase
    {
    }

    public interface IHTMLMapElement : IHTMLElement
    {
        [Export("areas")]
        HTMLAreasCollection Areas { get; }
        [Export("name")]
        string Name { get; set; }
    }

    public interface IHTMLPictureElement : IHTMLElement
    {
    }

    public interface IHTMLMenuElement : IHTMLElement
    {
        [Export("compact")]
        bool Compact { get; set; }
        [Export("type")]
        string Type { get; set; }
    }

    public interface IHTMLScriptElement : IHTMLElement
    {
        [Export("async")]
        bool Async { get; set; }
        [Export("charset")]
        string Charset { get; set; }
        [Export("crossOrigin")]
        string CrossOrigin { get; set; }
        [Export("defer")]
        bool Defer { get; set; }
        [Export("event")]
        string Event { get; set; }
        [Export("htmlFor")]
        string HtmlFor { get; set; }
        [Export("src")]
        string Src { get; set; }
        [Export("text")]
        string Text { get; set; }
        [Export("type")]
        string Type { get; set; }
        [Export("integrity")]
        string Integrity { get; set; }
    }

    public interface IGetSVGDocument
    {
        [Export("getSVGDocument")]
        Document GetSvgDocument();
    }

    public interface IHTMLEmbedElement : IHTMLElement, IGetSVGDocument
    {
        [Export("height")]
        string Height { get; set; }
        //[Export("hidden")]
        //Object Hidden { get; set; }
        [Export("msPlayToDisabled")]
        bool MsPlayToDisabled { get; set; }
        [Export("msPlayToPreferredSourceUri")]
        string MsPlayToPreferredSourceUri { get; set; }
        [Export("msPlayToPrimary")]
        bool MsPlayToPrimary { get; set; }
        //[Export("msPlayToSource")]
        //Object MsPlayToSource { get; }
        [Export("name")]
        string Name { get; set; }
        [Export("palette")]
        string Palette { get; }
        [Export("pluginspage")]
        string Pluginspage { get; }
        [Export("readyState")]
        string ReadyState { get; }
        [Export("src")]
        string Src { get; set; }
        [Export("units")]
        string Units { get; set; }
        [Export("width")]
        string Width { get; set; }
    }

    public interface IHTMLFrameElement : IHTMLElement, IGetSVGDocument
    {
        [Export("border")]
        string Border { get; set; }
        [Export("borderColor")]
        Object BorderColor { get; set; }
        [Export("contentDocument")]
        Document ContentDocument { get; }
        [Export("contentWindow")]
        Window ContentWindow { get; }
        [Export("frameBorder")]
        string FrameBorder { get; set; }
        [Export("frameSpacing")]
        Object FrameSpacing { get; set; }
        [Export("height")]
        string Height { get; set; }
        [Export("longDesc")]
        string LongDesc { get; set; }
        [Export("marginHeight")]
        string MarginHeight { get; set; }
        [Export("marginWidth")]
        string MarginWidth { get; set; }
        [Export("name")]
        string Name { get; set; }
        [Export("noResize")]
        bool NoResize { get; set; }
        [Export("scrolling")]
        string Scrolling { get; set; }
        [Export("src")]
        string Src { get; set; }
        [Export("width")]
        string Width { get; set; }
    }

    public interface IHTMLFrameSetElement : IHTMLElement
    {
        [Export("border")]
        string Border { get; set; }
        [Export("borderColor")]
        string BorderColor { get; set; }
        [Export("cols")]
        string Cols { get; set; }
        [Export("frameBorder")]
        string FrameBorder { get; set; }
        [Export("frameSpacing")]
        string FrameSpacing { get; set; }
        [Export("name")]
        string Name { get; set; }
        event DOMEventHandler OnAfterprint;
        event DOMEventHandler OnBeforeprint;
        event DOMEventHandler OnBeforeunload;
        event DOMEventHandler OnHashchange;
        event DOMEventHandler OnMessage;
        event DOMEventHandler OnOffline;
        event DOMEventHandler OnOnline;
        event DOMEventHandler OnOrientationchange;
        event DOMEventHandler OnPagehide;
        event DOMEventHandler OnPageshow;
        event DOMEventHandler OnPopstate;
        event DOMEventHandler OnResize;
        event DOMEventHandler OnStorage;
        event DOMEventHandler OnUnload;
        [Export("rows")]
        string Rows { get; set; }
    }

    public interface IHTMLAppletElement : IHTMLElement
    {
        [Export("align")]
        string Align { get; set; }
        [Export("alt")]
        string Alt { get; set; }
        [Export("altHtml")]
        string AltHtml { get; set; }
        [Export("archive")]
        string Archive { get; set; }
        [Export("BaseHref")]
        string BaseHref { get; }
        [Export("border")]
        string Border { get; set; }
        [Export("code")]
        string Code { get; set; }
        [Export("codeBase")]
        string CodeBase { get; set; }
        [Export("codeType")]
        string CodeType { get; set; }
        [Export("contentDocument")]
        Document ContentDocument { get; }
        [Export("data")]
        string Data { get; set; }
        [Export("declare")]
        bool Declare { get; set; }
        [Export("form")]
        HTMLFormElement Form { get; }
        [Export("height")]
        string Height { get; set; }
        [Export("hspace")]
        double Hspace { get; set; }
        [Export("name")]
        string Name { get; set; }
        [Export("object")]
        string Object { get; set; }
        [Export("standby")]
        string Standby { get; set; }
        [Export("type")]
        string Type { get; set; }
        [Export("useMap")]
        string UseMap { get; set; }
        [Export("vspace")]
        double Vspace { get; set; }
        [Export("width")]
        double Width { get; set; }
    }

    public interface IHTMLObjectElement : IHTMLElement, IGetSVGDocument
    {
        [Export("align")]
        string Align { get; set; }
        [Export("alt")]
        string Alt { get; set; }
        [Export("altHtml")]
        string AltHtml { get; set; }
        [Export("archive")]
        string Archive { get; set; }
        [Export("BaseHref")]
        string BaseHref { get; }
        [Export("border")]
        string Border { get; set; }
        [Export("code")]
        string Code { get; set; }
        [Export("codeBase")]
        string CodeBase { get; set; }
        [Export("codeType")]
        string CodeType { get; set; }
        [Export("contentDocument")]
        Document ContentDocument { get; }
        [Export("data")]
        string Data { get; set; }
        [Export("declare")]
        bool Declare { get; set; }
        [Export("form")]
        HTMLFormElement Form { get; }
        [Export("height")]
        string Height { get; set; }
        [Export("hspace")]
        double Hspace { get; set; }
        [Export("msPlayToDisabled")]
        bool MsPlayToDisabled { get; set; }
        [Export("msPlayToPreferredSourceUri")]
        string MsPlayToPreferredSourceUri { get; set; }
        [Export("msPlayToPrimary")]
        bool MsPlayToPrimary { get; set; }
        [Export("msPlayToSource")]
        Object MsPlayToSource { get; }
        [Export("name")]
        string Name { get; set; }
        [Export("readyState")]
        double ReadyState { get; }
        [Export("standby")]
        string Standby { get; set; }
        [Export("type")]
        string Type { get; set; }
        [Export("useMap")]
        string UseMap { get; set; }
        [Export("validationMessage")]
        string ValidationMessage { get; }
        [Export("validity")]
        ValidityState Validity { get; }
        [Export("vspace")]
        double Vspace { get; set; }
        [Export("width")]
        string Width { get; set; }
        [Export("willValidate")]
        bool WillValidate { get; }
        [Export("typemustmatch")]
        bool Typemustmatch { get; set; }
        [Export("checkValidity")]
        bool CheckValidity();
        [Export("setCustomValidity")]
        void SetCustomValidity(string error);
    }

    public interface IHTMLIFrameElement : IHTMLElement, IGetSVGDocument
    {
        [Export("align")]
        string Align { get; set; }
        [Export("allowFullscreen")]
        bool AllowFullscreen { get; set; }
        [Export("allowPaymentRequest")]
        bool AllowPaymentRequest { get; set; }
        [Export("border")]
        string Border { get; set; }
        [Export("contentDocument")]
        Document ContentDocument { get; }
        [Export("contentWindow")]
        Window ContentWindow { get; }
        [Export("frameBorder")]
        string FrameBorder { get; set; }
        [Export("frameSpacing")]
        Object FrameSpacing { get; set; }
        [Export("height")]
        string Height { get; set; }
        [Export("hspace")]
        double Hspace { get; set; }
        [Export("longDesc")]
        string LongDesc { get; set; }
        [Export("marginHeight")]
        string MarginHeight { get; set; }
        [Export("marginWidth")]
        string MarginWidth { get; set; }
        [Export("name")]
        string Name { get; set; }
        [Export("noResize")]
        bool NoResize { get; set; }
        [Export("sandbox")]
        DOMSettableTokenList Sandbox { get; }
        [Export("scrolling")]
        string Scrolling { get; set; }
        [Export("src")]
        string Src { get; set; }
        [Export("vspace")]
        double Vspace { get; set; }
        [Export("width")]
        string Width { get; set; }
        [Export("srcdoc")]
        string Srcdoc { get; set; }
    }

    public interface IDOMSettableTokenList : IDOMTokenList
    {
        [Export("value")]
        string Value { get; set; }
    }

    public interface IHTMLOutputElement : IHTMLElement
    {
        [Export("defaultValue")]
        string DefaultValue { get; set; }
        [Export("form")]
        HTMLFormElement Form { get; }
        [Export("htmlFor")]
        DOMSettableTokenList HtmlFor { get; }
        [Export("name")]
        string Name { get; set; }
        [Export("type")]
        string Type { get; }
        [Export("validationMessage")]
        string ValidationMessage { get; }
        [Export("validity")]
        ValidityState Validity { get; }
        [Export("value")]
        string Value { get; set; }
        [Export("willValidate")]
        bool WillValidate { get; }
        [Export("checkValidity")]
        bool CheckValidity();
        [Export("reportValidity")]
        bool ReportValidity();
        [Export("setCustomValidity")]
        void SetCustomValidity(string error);
    }

    public interface IMSGraphicsTrust
    {
        [Export("constrictionActive")]
        bool ConstrictionActive { get; }
        [Export("status")]
        string Status { get; }
    }

    public interface ITimeRanges
    {
        [Export("length")]
        double Length { get; }
        [Export("end")]
        double End(double index);
        [Export("start")]
        double Start(double index);
    }

    //public interface IHTMLMediaElement : IHTMLElement
    //{
    //    [Export("audioTracks")]
    //    AudioTrackList AudioTracks { get; }
    //    [Export("autoplay")]
    //    bool Autoplay { get; set; }
    //    [Export("buffered")]
    //    TimeRanges Buffered { get; }
    //    [Export("controls")]
    //    bool Controls { get; set; }
    //    [Export("crossOrigin")]
    //    string CrossOrigin { get; set; }
    //    [Export("currentSrc")]
    //    string CurrentSrc { get; }
    //    [Export("currentTime")]
    //    double CurrentTime { get; set; }
    //    [Export("defaultMuted")]
    //    bool DefaultMuted { get; set; }
    //    [Export("defaultPlaybackRate")]
    //    double DefaultPlaybackRate { get; set; }
    //    [Export("duration")]
    //    double Duration { get; }
    //    [Export("ended")]
    //    bool Ended { get; }
    //    [Export("error")]
    //    MediaError Error { get; }
    //    [Export("loop")]
    //    bool Loop { get; set; }
    //    [Export("mediaKeys")]
    //    MediaKeys MediaKeys { get; }
    //    [Export("msAudioCategory")]
    //    string MsAudioCategory { get; set; }
    //    [Export("msAudioDeviceType")]
    //    string MsAudioDeviceType { get; set; }
    //    [Export("msGraphicsTrustStatus")]
    //    MSGraphicsTrust MsGraphicsTrustStatus { get; }
    //    [Export("msKeys")]
    //    MSMediaKeys MsKeys { get; }
    //    [Export("msPlayToDisabled")]
    //    bool MsPlayToDisabled { get; set; }
    //    [Export("msPlayToPreferredSourceUri")]
    //    string MsPlayToPreferredSourceUri { get; set; }
    //    [Export("msPlayToPrimary")]
    //    bool MsPlayToPrimary { get; set; }
    //    [Export("msPlayToSource")]
    //    Object MsPlayToSource { get; }
    //    [Export("msRealTime")]
    //    bool MsRealTime { get; set; }
    //    [Export("muted")]
    //    bool Muted { get; set; }
    //    [Export("networkState")]
    //    double NetworkState { get; }
    //    event DOMEventHandler OnEncrypted;
    //    event DOMEventHandler OnMsneedkey;
    //    [Export("paused")]
    //    bool Paused { get; }
    //    [Export("playbackRate")]
    //    double PlaybackRate { get; set; }
    //    [Export("played")]
    //    TimeRanges Played { get; }
    //    [Export("preload")]
    //    string Preload { get; set; }
    //    [Export("readyState")]
    //    double ReadyState { get; set; }
    //    [Export("seekable")]
    //    TimeRanges Seekable { get; }
    //    [Export("seeking")]
    //    bool Seeking { get; }
    //    [Export("src")]
    //    string Src { get; set; }
    //    [Export("srcObject")]
    //    MediaStream SrcObject { get; set; }
    //    [Export("textTracks")]
    //    TextTrackList TextTracks { get; }
    //    [Export("videoTracks")]
    //    VideoTrackList VideoTracks { get; }
    //    [Export("volume")]
    //    double Volume { get; set; }
    //    [Export("addTextTrack")]
    //    TextTrack AddTextTrack(string kind, string label, string language);
    //    [Export("canPlayType")]
    //    string CanPlayType(string type);
    //    [Export("load")]
    //    void Load();
    //    [Export("msClearEffects")]
    //    void MsClearEffects();
    //    [Export("msGetAsCastingSource")]
    //    Object MsGetAsCastingSource();
    //    [Export("msInsertAudioEffect")]
    //    void MsInsertAudioEffect(string activatableClassId, bool effectRequired, Object config);
    //    [Export("msSetMediaKeys")]
    //    void MsSetMediaKeys(MSMediaKeys mediaKeys);
    //    [Export("msSetMediaProtectionManager")]
    //    void MsSetMediaProtectionManager(Object mediaProtectionManager);
    //    [Export("pause")]
    //    void Pause();
    //    //[Export("play")]
    //    //Promise<void> Play();
    //    //[Export("setMediaKeys")]
    //    //Promise<void> SetMediaKeys(MediaKeys mediaKeys);
    //    [Export("HAVE_CURRENT_DATA")]
    //    double HaveCurrentData { get; }
    //    [Export("HAVE_ENOUGH_DATA")]
    //    double HaveEnoughData { get; }
    //    [Export("HAVE_FUTURE_DATA")]
    //    double HaveFutureData { get; }
    //    [Export("HAVE_METADATA")]
    //    double HaveMetadata { get; }
    //    [Export("HAVE_NOTHING")]
    //    double HaveNothing { get; }
    //    [Export("NETWORK_EMPTY")]
    //    double NetworkEmpty { get; }
    //    [Export("NETWORK_IDLE")]
    //    double NetworkIdle { get; }
    //    [Export("NETWORK_LOADING")]
    //    double NetworkLoading { get; }
    //    [Export("NETWORK_NO_SOURCE")]
    //    double NetworkNoSource { get; }
    //    [Export("addEventListener")]
    //    void AddEventListener(string type, DOMEventHandler listener, object options);
    //    [Export("removeEventListener")]
    //    void RemoveEventListener(string type, DOMEventHandler listener, object options);
    //}

    //public interface ITextTrack : IEventTarget
    //{
    //    [Export("activeCues")]
    //    TextTrackCueList ActiveCues { get; }
    //    [Export("cues")]
    //    TextTrackCueList Cues { get; }
    //    [Export("inBandMetadataTrackDispatchType")]
    //    string InBandMetadataTrackDispatchType { get; }
    //    [Export("kind")]
    //    string Kind { get; }
    //    [Export("label")]
    //    string Label { get; }
    //    [Export("language")]
    //    string Language { get; }
    //    [Export("mode")]
    //    Object Mode { get; set; }
    //    event DOMEventHandler OnCuechange;
    //    event DOMEventHandler OnError;
    //    event DOMEventHandler OnLoad;
    //    [Export("readyState")]
    //    double ReadyState { get; }
    //    [Export("addCue")]
    //    void AddCue(TextTrackCue cue);
    //    [Export("removeCue")]
    //    void RemoveCue(TextTrackCue cue);
    //    [Export("DISABLED")]
    //    double Disabled { get; }
    //    [Export("ERROR")]
    //    double Error { get; }
    //    [Export("HIDDEN")]
    //    double Hidden { get; }
    //    [Export("LOADED")]
    //    double Loaded { get; }
    //    [Export("LOADING")]
    //    double Loading { get; }
    //    [Export("NONE")]
    //    double None { get; }
    //    [Export("SHOWING")]
    //    double Showing { get; }
    //}

    public interface ITextTrackCue : IEventTarget
    {
        [Export("endTime")]
        double EndTime { get; set; }
        [Export("id")]
        string Id { get; set; }
        event DOMEventHandler OnEnter;
        event DOMEventHandler OnExit;
        [Export("pauseOnExit")]
        bool PauseOnExit { get; set; }
        [Export("startTime")]
        double StartTime { get; set; }
        [Export("text")]
        string Text { get; set; }
        [Export("track")]
        TextTrack Track { get; }
        [Export("getCueAsHTML")]
        DocumentFragment GetCueAsHtml();
    }

    public interface IHTMLCanvasElement : IHTMLElement
    {
        [Export("height")]
        double Height { get; set; }
        [Export("width")]
        double Width { get; set; }
        //[Export("getContext")]
        //CanvasRenderingContext2D GetContext(string contextId, Canvas2DContextAttributes contextAttributes);
        //[Export("getContext")]
        //WebGLRenderingContext GetContext(object contextId, WebGLContextAttributes contextAttributes);
        [Export("getContext")]
        object GetContext(string contextId, object contextAttributes);
        //[Export("msToBlob")]
        //Blob MsToBlob();
        [Export("toBlob")]
        void ToBlob(Action callback, string type, params Object[] arguments);
        [Export("toDataURL")]
        string ToDataUrl(string type, params Object[] args);
    }

    public interface ICanvasPathMethods
    {
        [Export("arc")]
        void Arc(double x, double y, double radius, double startAngle, double endAngle, bool anticlockwise);
        [Export("arcTo")]
        void ArcTo(double x1, double y1, double x2, double y2, double radius);
        [Export("arcTo")]
        void ArcTo(double x1, double y1, double x2, double y2, double radiusX, double radiusY, double rotation);
        [Export("bezierCurveTo")]
        void BezierCurveTo(double cp1x, double cp1y, double cp2x, double cp2y, double x, double y);
        [Export("closePath")]
        void ClosePath();
        [Export("ellipse")]
        void Ellipse(double x, double y, double radiusX, double radiusY, double rotation, double startAngle, double endAngle, bool anticlockwise);
        [Export("lineTo")]
        void LineTo(double x, double y);
        [Export("moveTo")]
        void MoveTo(double x, double y);
        [Export("quadraticCurveTo")]
        void QuadraticCurveTo(double cpx, double cpy, double x, double y);
        [Export("rect")]
        void Rect(double x, double y, double w, double h);
    }

    public interface ICanvasRenderingContext2D : ICanvasPathMethods
    {
        [Export("canvas")]
        HTMLCanvasElement Canvas { get; }
        [Export("fillStyle")]
        object FillStyle { get; set; }
        [Export("font")]
        string Font { get; set; }
        [Export("globalAlpha")]
        double GlobalAlpha { get; set; }
        [Export("globalCompositeOperation")]
        string GlobalCompositeOperation { get; set; }
        [Export("imageSmoothingEnabled")]
        bool ImageSmoothingEnabled { get; set; }
        [Export("lineCap")]
        LineCap LineCap { get; set; }
        [Export("lineDashOffset")]
        double LineDashOffset { get; set; }
        [Export("lineJoin")]
        LineJoin LineJoin { get; set; }
        [Export("lineWidth")]
        double LineWidth { get; set; }
        [Export("miterLimit")]
        double MiterLimit { get; set; }
        [Export("mozImageSmoothingEnabled")]
        bool MozImageSmoothingEnabled { get; set; }
        [Export("msFillRule")]
        CanvasFillRule MsFillRule { get; set; }
        [Export("oImageSmoothingEnabled")]
        bool OImageSmoothingEnabled { get; set; }
        [Export("shadowBlur")]
        double ShadowBlur { get; set; }
        [Export("shadowColor")]
        string ShadowColor { get; set; }
        [Export("shadowOffsetX")]
        double ShadowOffsetX { get; set; }
        [Export("shadowOffsetY")]
        double ShadowOffsetY { get; set; }
        [Export("strokeStyle")]
        object StrokeStyle { get; set; }
        [Export("textAlign")]
        TextAlign TextAlign { get; set; }
        [Export("textBaseline")]
        TextBaseline TextBaseline { get; set; }
        [Export("webkitImageSmoothingEnabled")]
        bool WebkitImageSmoothingEnabled { get; set; }
        [Export("beginPath")]
        void BeginPath();
        [Export("clearRect")]
        void ClearRect(double x, double y, double w, double h);
        [Export("clip")]
        void Clip(CanvasFillRule fillRule);
        [Export("clip")]
        void Clip(Path2D path, CanvasFillRule fillRule);
        [Export("createImageData")]
        ImageData CreateImageData(object imageDataOrSw, double sh);
        [Export("createLinearGradient")]
        CanvasGradient CreateLinearGradient(double x0, double y0, double x1, double y1);
        [Export("createPattern")]
        CanvasPattern CreatePattern(object image, string repetition);
        [Export("createRadialGradient")]
        CanvasGradient CreateRadialGradient(double x0, double y0, double r0, double x1, double y1, double r1);
        [Export("drawFocusIfNeeded")]
        void DrawFocusIfNeeded(Element element);
        [Export("drawFocusIfNeeded")]
        void DrawFocusIfNeeded(Path2D path, Element element);
        [Export("drawImage")]
        void DrawImage(object image, double dstX, double dstY);
        [Export("drawImage")]
        void DrawImage(object image, double dstX, double dstY, double dstW, double dstH);
        [Export("drawImage")]
        void DrawImage(object image, double srcX, double srcY, double srcW, double srcH, double dstX, double dstY, double dstW, double dstH);
        [Export("fill")]
        void Fill(CanvasFillRule fillRule);
        [Export("fill")]
        void Fill(Path2D path, CanvasFillRule fillRule);
        [Export("fillRect")]
        void FillRect(double x, double y, double w, double h);
        [Export("fillText")]
        void FillText(string text, double x, double y, double maxWidth);
        [Export("getImageData")]
        ImageData GetImageData(double sx, double sy, double sw, double sh);
        [Export("getLineDash")]
        double[] GetLineDash();
        [Export("isPointInPath")]
        bool IsPointInPath(double x, double y, CanvasFillRule fillRule);
        [Export("isPointInPath")]
        bool IsPointInPath(Path2D path, double x, double y, CanvasFillRule fillRule);
        [Export("isPointInStroke")]
        bool IsPointInStroke(double x, double y, CanvasFillRule fillRule);
        [Export("isPointInStroke")]
        bool IsPointInStroke(Path2D path, double x, double y, CanvasFillRule fillRule);
        [Export("measureText")]
        TextMetrics MeasureText(string text);
        [Export("putImageData")]
        void PutImageData(ImageData imagedata, double dx, double dy, double dirtyX, double dirtyY, double dirtyWidth, double dirtyHeight);
        [Export("restore")]
        void Restore();
        [Export("rotate")]
        void Rotate(double angle);
        [Export("save")]
        void Save();
        [Export("scale")]
        void Scale(double x, double y);
        [Export("setLineDash")]
        void SetLineDash(double[] segments);
        [Export("setTransform")]
        void SetTransform(double m11, double m12, double m21, double m22, double dx, double dy);
        [Export("stroke")]
        void Stroke(Path2D path);
        [Export("strokeRect")]
        void StrokeRect(double x, double y, double w, double h);
        [Export("strokeText")]
        void StrokeText(string text, double x, double y, double maxWidth);
        [Export("transform")]
        void Transform(double m11, double m12, double m21, double m22, double dx, double dy);
        [Export("translate")]
        void Translate(double x, double y);
    }

    public interface IPath2D : ICanvasPathMethods
    {
    }

    public interface ICanvasGradient
    {
        [Export("addColorStop")]
        void AddColorStop(double offset, string color);
    }

    // experimental technology https://developer.mozilla.org/en-US/docs/Web/API/CanvasPattern/setTransform
    // do not use for now
    public interface ISVGMatrix
    {
        [Export("a")]
        double A { get; set; }
        [Export("b")]
        double B { get; set; }
        [Export("c")]
        double C { get; set; }
        [Export("d")]
        double D { get; set; }
        [Export("e")]
        double E { get; set; }
        [Export("f")]
        double F { get; set; }
        [Export("flipX")]
        ISVGMatrix FlipX();
        [Export("flipY")]
        ISVGMatrix FlipY();
        [Export("inverse")]
        ISVGMatrix Inverse();
        [Export("multiply")]
        ISVGMatrix Multiply(ISVGMatrix secondMatrix);
        [Export("rotate")]
        ISVGMatrix Rotate(double angle);
        [Export("rotateFromVector")]
        ISVGMatrix RotateFromVector(double x, double y);
        [Export("scale")]
        ISVGMatrix Scale(double scaleFactor);
        [Export("scaleNonUniform")]
        ISVGMatrix ScaleNonUniform(double scaleFactorX, double scaleFactorY);
        [Export("skewX")]
        ISVGMatrix SkewX(double angle);
        [Export("skewY")]
        ISVGMatrix SkewY(double angle);
        [Export("translate")]
        ISVGMatrix Translate(double x, double y);
    }

    public interface ICanvasPattern
    {
        // experimental technology https://developer.mozilla.org/en-US/docs/Web/API/CanvasPattern/setTransform
        //[Export("setTransform")]
        //void SetTransform(SVGMatrix matrix);
    }

    public interface IImageData
    {
        [Export("data")]
        byte[] Data { get; }
        [Export("height")]
        double Height { get; }
        [Export("width")]
        double Width { get; }
    }

    public interface ITextMetrics
    {
        [Export("width")]
        double Width { get; }
    }




}