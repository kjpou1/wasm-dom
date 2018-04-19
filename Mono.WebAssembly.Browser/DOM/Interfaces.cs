using System;
using System.Runtime.CompilerServices;
using Mono.WebAssembly;
using Mono.WebAssembly.Browser.DOM.Events;

namespace Mono.WebAssembly.Browser.DOM
{

    public interface IEventTarget
    {
        [Export("addEventListener")]
        void AddEventListener(string type, DOMEventHandler listener, object options);
        [Export("dispatchEvent")]
        bool DispatchEvent(Event evt);
        [Export("removeEventListener")]
        void RemoveEventListener(string type, DOMEventHandler listener, object options);
        void DispatchDOMEvent(string type, string eventType, string UID, string eventHandle, string eventInfo = null);
    }

    public interface INode
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
        string ScrollRestoration { get; set; }
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


    public interface IElement //: INode, IGlobalEventHandlers, IElementTraversal, INodeSelector, IChildNode, IParentNode
    {
    //    //[Export("classList")]
    //    //DOMTokenList ClassList { get; }
    //    [Export("className")]
    //    string ClassName { get; set; }
    //    [Export("clientHeight")]
    //    double ClientHeight { get; }
    //    [Export("clientLeft")]
    //    double ClientLeft { get; }
    //    [Export("clientTop")]
    //    double ClientTop { get; }
    //    [Export("clientWidth")]
    //    double ClientWidth { get; }
    //    [Export("id")]
    //    string Id { get; set; }
    //    [Export("innerHTML")]
    //    string InnerHtml { get; set; }
    //    [Export("msContentZoomFactor")]
    //    double MsContentZoomFactor { get; set; }
    //    [Export("msRegionOverflow")]
    //    string MsRegionOverflow { get; }
    //    event DOMEventHandler OnAriarequest;
    //    event DOMEventHandler OnCommand;
    //    event DOMEventHandler OnGotpointercapture;
    //    event DOMEventHandler OnLostpointercapture;
    //    event DOMEventHandler OnMsgesturechange;
    //    event DOMEventHandler OnMsgesturedoubletap;
    //    event DOMEventHandler OnMsgestureend;
    //    event DOMEventHandler OnMsgesturehold;
    //    event DOMEventHandler OnMsgesturestart;
    //    event DOMEventHandler OnMsgesturetap;
    //    event DOMEventHandler OnMsgotpointercapture;
    //    event DOMEventHandler OnMsinertiastart;
    //    event DOMEventHandler OnMslostpointercapture;
    //    event DOMEventHandler OnMspointercancel;
    //    event DOMEventHandler OnMspointerdown;
    //    event DOMEventHandler OnMspointerenter;
    //    event DOMEventHandler OnMspointerleave;
    //    event DOMEventHandler OnMspointermove;
    //    event DOMEventHandler OnMspointerout;
    //    event DOMEventHandler OnMspointerover;
    //    event DOMEventHandler OnMspointerup;
    //    [Export("ontouchcancel")]
    //    Action Ontouchcancel { get; set; }
    //    [Export("ontouchend")]
    //    Action Ontouchend { get; set; }
    //    [Export("ontouchmove")]
    //    Action Ontouchmove { get; set; }
    //    [Export("ontouchstart")]
    //    Action Ontouchstart { get; set; }
    //    event DOMEventHandler OnWebkitfullscreenchange;
    //    event DOMEventHandler OnWebkitfullscreenerror;
    //    [Export("outerHTML")]
    //    string OuterHtml { get; set; }
    //    [Export("prefix")]
    //    string Prefix { get; }
    //    [Export("scrollHeight")]
    //    double ScrollHeight { get; }
    //    [Export("scrollLeft")]
    //    double ScrollLeft { get; set; }
    //    [Export("scrollTop")]
    //    double ScrollTop { get; set; }
    //    [Export("scrollWidth")]
    //    double ScrollWidth { get; }
    //    [Export("tagName")]
    //    string TagName { get; }
    //    //[Export("assignedSlot")]
    //    //HTMLSlotElement AssignedSlot { get; }
    //    [Export("slot")]
    //    string Slot { get; set; }
    //    //[Export("shadowRoot")]
    //    //ShadowRoot ShadowRoot { get; }
    //    [Export("getAttribute")]
    //    string GetAttribute(string name);
    //    [Export("getAttributeNode")]
    //    Attr GetAttributeNode(string name);
    //    [Export("getAttributeNodeNS")]
    //    Attr GetAttributeNodeNs(string namespaceURI, string localName);
    //    [Export("getAttributeNS")]
    //    string GetAttributeNs(string namespaceURI, string localName);
    //    [Export("getBoundingClientRect")]
    //    object GetBoundingClientRect();
    //    [Export("getClientRects")]
    //    object GetClientRects();
    //    //[Export("getElementsByTagName")]
    //    //NodeListOf<Element> GetElementsByTagName(string name);
    //    //[Export("getElementsByTagNameNS")]
    //    //HTMLCollectionOf<HTMLElement> GetElementsByTagNameNs(string namespaceURI, string localName);
    //    //[Export("getElementsByTagNameNS")]
    //    //HTMLCollectionOf<SVGElement> GetElementsByTagNameNs(string namespaceURI, string localName);
    //    //[Export("getElementsByTagNameNS")]
    //    //HTMLCollectionOf<Element> GetElementsByTagNameNs(string namespaceURI, string localName);
    //    [Export("hasAttribute")]
    //    bool HasAttribute(string name);
    //    [Export("hasAttributeNS")]
    //    bool HasAttributeNs(string namespaceURI, string localName);
    //    [Export("msGetRegionContent")]
    //    MSRangeCollection MsGetRegionContent();
    //    [Export("msGetUntransformedBounds")]
    //    ClientRect MsGetUntransformedBounds();
    //    [Export("msMatchesSelector")]
    //    bool MsMatchesSelector(string selectors);
    //    [Export("msReleasePointerCapture")]
    //    void MsReleasePointerCapture(double pointerId);
    //    [Export("msSetPointerCapture")]
    //    void MsSetPointerCapture(double pointerId);
    //    [Export("msZoomTo")]
    //    void MsZoomTo(MsZoomToOptions args);
    //    [Export("releasePointerCapture")]
    //    void ReleasePointerCapture(double pointerId);
    //    [Export("removeAttribute")]
    //    void RemoveAttribute(string qualifiedName);
    //    [Export("removeAttributeNode")]
    //    Attr RemoveAttributeNode(Attr oldAttr);
    //    [Export("removeAttributeNS")]
    //    void RemoveAttributeNs(string namespaceURI, string localName);
    //    [Export("requestFullscreen")]
    //    void RequestFullscreen();
    //    [Export("requestPointerLock")]
    //    void RequestPointerLock();
    //    [Export("setAttribute")]
    //    void SetAttribute(string name, string value);
    //    [Export("setAttributeNode")]
    //    Attr SetAttributeNode(Attr newAttr);
    //    [Export("setAttributeNodeNS")]
    //    Attr SetAttributeNodeNs(Attr newAttr);
    //    [Export("setAttributeNS")]
    //    void SetAttributeNs(string namespaceURI, string qualifiedName, string value);
    //    [Export("setPointerCapture")]
    //    void SetPointerCapture(double pointerId);
    //    [Export("webkitMatchesSelector")]
    //    bool WebkitMatchesSelector(string selectors);
    //    [Export("webkitRequestFullscreen")]
    //    void WebkitRequestFullscreen();
    //    [Export("webkitRequestFullScreen")]
    //    void WebkitRequestFullScreen();
    //    [Export("getElementsByClassName")]
    //    NodeListOf<Element> GetElementsByClassName(string classNames);
    //    [Export("matches")]
    //    bool Matches(string selector);
    //    [Export("closest")]
    //    IElement Closest(string selector);
    //    [Export("scrollIntoView")]
    //    void ScrollIntoView(object arg);
    //    [Export("scroll")]
    //    void Scroll(ScrollToOptions options);
    //    [Export("scroll")]
    //    void Scroll(double x, double y);
    //    [Export("scrollTo")]
    //    void ScrollTo(ScrollToOptions options);
    //    [Export("scrollTo")]
    //    void ScrollTo(double x, double y);
    //    [Export("scrollBy")]
    //    void ScrollBy(ScrollToOptions options);
    //    [Export("scrollBy")]
    //    void ScrollBy(double x, double y);
    //    [Export("insertAdjacentElement")]
    //    IElement InsertAdjacentElement(InsertPosition position, IElement insertedElement);
    //    [Export("insertAdjacentHTML")]
    //    void InsertAdjacentHtml(InsertPosition where, string html);
    //    [Export("insertAdjacentText")]
    //    void InsertAdjacentText(InsertPosition where, string text);
    //    [Export("attachShadow")]
    //    ShadowRoot AttachShadow(ShadowRootInit shadowRootInitDict);
    //    [Export("addEventListener")]
    //    void AddEventListener(string type, DOMEventHandler listener, object options);
    //    [Export("removeEventListener")]
    //    void RemoveEventListener(string type, DOMEventHandler listener, object options);
    }

    public interface IHTMLElement : IElement
    {
    //    [Export("accessKey")]
    //    string AccessKey { get; set; }
    //    [Export("children")]
    //    HTMLCollection Children { get; }
    //    [Export("contentEditable")]
    //    string ContentEditable { get; set; }
    //    [Export("dataset")]
    //    DOMStringMap Dataset { get; }
    //    [Export("dir")]
    //    string Dir { get; set; }
    //    [Export("draggable")]
    //    bool Draggable { get; set; }
    //    [Export("hidden")]
    //    bool Hidden { get; set; }
    //    [Export("hideFocus")]
    //    bool HideFocus { get; set; }
    //    [Export("innerText")]
    //    string InnerText { get; set; }
    //    [Export("isContentEditable")]
    //    bool IsContentEditable { get; }
    //    [Export("lang")]
    //    string Lang { get; set; }
    //    [Export("offsetHeight")]
    //    double OffsetHeight { get; }
    //    [Export("offsetLeft")]
    //    double OffsetLeft { get; }
    //    [Export("offsetParent")]
    //    Element OffsetParent { get; }
    //    [Export("offsetTop")]
    //    double OffsetTop { get; }
    //    [Export("offsetWidth")]
    //    double OffsetWidth { get; }
    //    event DOMEventHandler OnAbort;
    //    event DOMEventHandler OnActivate;
    //    event DOMEventHandler OnBeforeactivate;
    //    event DOMEventHandler OnBeforecopy;
    //    event DOMEventHandler OnBeforecut;
    //    event DOMEventHandler OnBeforedeactivate;
    //    event DOMEventHandler OnBeforepaste;
    //    event DOMEventHandler OnBlur;
    //    event DOMEventHandler OnCanplay;
    //    event DOMEventHandler OnCanplaythrough;
    //    event DOMEventHandler OnChange;
    //    event DOMEventHandler OnClick;
    //    event DOMEventHandler OnContextmenu;
    //    event DOMEventHandler OnCopy;
    //    event DOMEventHandler OnCuechange;
    //    event DOMEventHandler OnCut;
    //    event DOMEventHandler OnDblclick;
    //    event DOMEventHandler OnDeactivate;
    //    event DOMEventHandler OnDrag;
    //    event DOMEventHandler OnDragend;
    //    event DOMEventHandler OnDragenter;
    //    event DOMEventHandler OnDragleave;
    //    event DOMEventHandler OnDragover;
    //    event DOMEventHandler OnDragstart;
    //    event DOMEventHandler OnDrop;
    //    event DOMEventHandler OnDurationchange;
    //    event DOMEventHandler OnEmptied;
    //    event DOMEventHandler OnEnded;
    //    event DOMEventHandler OnError;
    //    event DOMEventHandler OnFocus;
    //    event DOMEventHandler OnInput;
    //    event DOMEventHandler OnInvalid;
    //    event DOMEventHandler OnKeydown;
    //    event DOMEventHandler OnKeypress;
    //    event DOMEventHandler OnKeyup;
    //    event DOMEventHandler OnLoad;
    //    event DOMEventHandler OnLoadeddata;
    //    event DOMEventHandler OnLoadedmetadata;
    //    event DOMEventHandler OnLoadstart;
    //    event DOMEventHandler OnMousedown;
    //    event DOMEventHandler OnMouseenter;
    //    event DOMEventHandler OnMouseleave;
    //    event DOMEventHandler OnMousemove;
    //    event DOMEventHandler OnMouseout;
    //    event DOMEventHandler OnMouseover;
    //    event DOMEventHandler OnMouseup;
    //    event DOMEventHandler OnMousewheel;
    //    event DOMEventHandler OnMscontentzoom;
    //    event DOMEventHandler OnMsmanipulationstatechanged;
    //    event DOMEventHandler OnPaste;
    //    event DOMEventHandler OnPause;
    //    event DOMEventHandler OnPlay;
    //    event DOMEventHandler OnPlaying;
    //    event DOMEventHandler OnProgress;
    //    event DOMEventHandler OnRatechange;
    //    event DOMEventHandler OnReset;
    //    event DOMEventHandler OnScroll;
    //    event DOMEventHandler OnSeeked;
    //    event DOMEventHandler OnSeeking;
    //    event DOMEventHandler OnSelect;
    //    event DOMEventHandler OnSelectstart;
    //    event DOMEventHandler OnStalled;
    //    event DOMEventHandler OnSubmit;
    //    event DOMEventHandler OnSuspend;
    //    event DOMEventHandler OnTimeupdate;
    //    event DOMEventHandler OnVolumechange;
    //    event DOMEventHandler OnWaiting;
    //    [Export("outerText")]
    //    string OuterText { get; set; }
    //    [Export("spellcheck")]
    //    bool Spellcheck { get; set; }
    //    [Export("style")]
    //    CSSStyleDeclaration Style { get; }
    //    [Export("tabIndex")]
    //    double TabIndex { get; set; }
    //    [Export("title")]
    //    string Title { get; set; }
    //    [Export("blur")]
    //    void Blur();
    //    [Export("click")]
    //    void Click();
    //    [Export("dragDrop")]
    //    bool DragDrop();
    //    [Export("focus")]
    //    void Focus();
    //    [Export("msGetInputContext")]
    //    MSInputMethodContext MsGetInputContext();
    //    [Export("addEventListener")]
    //    void AddEventListener(string type, DOMEventHandler listener, object options);
    //    [Export("removeEventListener")]
    //    void RemoveEventListener(string type, DOMEventHandler listener, object options);
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
        [Export("addEventListener")]
        void AddEventListener(string type, DOMEventHandler listener, object options);
        [Export("removeEventListener")]
        void RemoveEventListener(string type, DOMEventHandler listener, object options);
    }


    public interface IHTMLLIElement : IHTMLElement
    {
        [Export("type")]
        string Type { get; set; }
        [Export("value")]
        double Value { get; set; }
        [Export("addEventListener")]
        void AddEventListener(string type, DOMEventHandler listener, object options);
        [Export("removeEventListener")]
        void RemoveEventListener(string type, DOMEventHandler listener, object options);
    }

    public interface IHTMLFormElement : IHTMLElement
    {
        [Export("acceptCharset")]
        string AcceptCharset { get; set; }
        [Export("action")]
        string Action { get; set; }
        [Export("autocomplete")]
        string Autocomplete { get; set; }
        //[Export("elements")]
        //HTMLFormControlsCollection Elements { get; }
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
        [Export("item")]
        Object Item(Object name, Object index);
        [Export("namedItem")]
        Object NamedItem(string name);
        [Export("reset")]
        void Reset();
        [Export("submit")]
        void Submit();
        [Export("reportValidity")]
        bool ReportValidity();
        [Export("addEventListener")]
        void AddEventListener(string type, DOMEventHandler listener, object options);
        [Export("removeEventListener")]
        void RemoveEventListener(string type, DOMEventHandler listener, object options);
        //Object this[string name] { get; set; }
    }

}