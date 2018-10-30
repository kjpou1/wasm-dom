
var Module = {
	onRuntimeInitialized: function () {
		MONO.mono_load_runtime_and_bcl (
		config.vfs_prefix,
		config.deploy_prefix,
		config.enable_debugging,
		config.file_list,
		function () {
			config.add_bindings ();
			WebAssembly_Browser_DOM();
			App.init ();
		}
	)
	},
};


(function(global) {
    
	__WebAssembly_Browser_DOM__ = function () {
		return new __WebAssembly_Browser_DOM__.init();
	}

	__WebAssembly_Browser_DOM__.prototype = {
		mono_wasm_get_js_style_attribute: function(js_handle, js_name) {
			BINDING.bindings_lazy_init ();
	
			// var res;
			var m = obj.style[js_name];
			return m;
		},
		mono_wasm_set_js_style_attribute: function(obj, attribute, js_value) {
			BINDING.bindings_lazy_init ();
	
			if (obj.style)
			{

				if (js_value === null || typeof js_value  === "undefined")
				{
					obj.style[attribute] = "";
				}
				else
				{
					obj.style[attribute] = js_value;
				}
			}
			return true;

		},
		mono_wasm_add_js_event_listener: function(target, eventName, eventDelegate, event_uid) {
			BINDING.bindings_lazy_init ();
	
			if (!eventName) {
				throw Error("Invalid attribute name object '" + eventName + "'");
			}
	
			var eventHandler = {
				target: target,
				eventTypeString: eventName,
				uid: event_uid,
				delegate: eventDelegate
			};
			this.mono_wasm_event_helper.add(eventHandler);
	
		},
		/*
		* Helper functions for managing events
		*/
		mono_wasm_event_helper: {
	
			add: 
			function (eventHandler)
			{
				
				var wasm_events = undefined;
				wasm_events = eventHandler.target.__mono_wasm_events__;
				if (typeof(wasm_events) === "undefined") {
					eventHandler.target.__mono_wasm_events__ = wasm_events = {};
				}
	
				// make sure we do not set this multiple times.
				if (wasm_events[eventHandler.uid])
					return;
	
				var handler = function (event) {
	
					// window.event - Microsoft Internet Explorer
					// window.event is a proprietary Microsoft Internet Explorer property which is only available while a 
					// DOM event handler is being called. Its value is the Event object currently being handled.
					// this may need to be used on windows and needs testing ??????
					var e = event || window.event;
	
					var eventStruct = __WebAssembly_Browser_DOM__.prototype.mono_wasm_event_helper.fillEventData(e, this);

					eventHandler.delegate(e["type"], eventStruct["typeOfEvent"], e.target, e,
							eventStruct._event_params[0],
							eventStruct._event_params[1],
							eventStruct._event_params[2],
							eventStruct._event_params[3],
							eventStruct._event_params[4],
							eventStruct._event_params[5],
							eventStruct._event_params[6],
							eventStruct._event_params[7],
							eventStruct._event_params[8],
							eventStruct._event_params[9],
							eventStruct._event_params[10],
							eventStruct._event_params[11],
							eventStruct._event_params[12],
							eventStruct._event_params[13],
							eventStruct._event_params[14],
							eventStruct._event_params[15],
							eventStruct._event_params[16],
							eventStruct._event_params[17],
							eventStruct._event_params[18],
							JSON.stringify(eventStruct._event_props)
							);
				}
				eventHandler.target.addEventListener(eventHandler.eventTypeString, handler, false);
				wasm_events[eventHandler.uid] = handler;
			},
			remove: function( eventHandler ) {
				
				var wasm_events = undefined;
				wasm_events = eventHandler.target.__mono_wasm_events__;
				if (!wasm_events || typeof(wasm_events) === "undefined") {
					return true;
				}
	
	
				var handler = wasm_events[eventHandler.uid];
				if (!handler)
					return false;
				eventHandler.target.removeEventListener(eventHandler.eventTypeString, handler, false);
				delete wsevents[eventHandler.uid];
				return true;
			},
			fillEventData: function (e, target)
			{
				var DOMEventProps = [
				"altKey", // bool
				"bubbles", // bool
				"cancelable", // bool
				"ctrlKey", // bool
				"detail", // int
				"eventPhase", // int
				"metaKey", // bool
				"shiftKey", // bool
				"keyCode", // int
				"pointerId", // int
				"pointerType", // string
				"screenX", // double
				"screenY", // double
				"timeStamp", // double
				"isTrusted", // bool
				"scoped", // bool
				"clientX", // double
				"clientY", // double
				"button", // int
				]
	
				var eventStruct = {};
				eventStruct._event_params = [];
				eventStruct._event_props = {};
				eventStruct["typeOfEvent"] = "Event";
	
				// Load common event properties
				DOMEventProps.forEach(function (prop) {
					eventStruct._event_params.push(e[prop]);
				});

				switch (e.type) {

					// Mouse events
					case 'contextmenu':
					case 'click':
					case 'mouseover':
					case 'mouseout':
					case 'mousemove':
					case 'mousedown':
					case 'mouseup':
					case 'dblclick':					
					case 'drag':
					case 'dragend':
					case 'dragenter':
					case 'dragleave':
					case 'dragover':
					case 'dragstart':
					case 'drop':
					case 'wheel':
					case 'mousewheel':					
						this.fillMouseEventData(eventStruct, e, target);
						break;
					case 'keydown':
					case 'keyup':
					case 'keypress':						
						this.fillKeyboardEventData(eventStruct, e, target);
						break;
					case 'copy':
					case 'cut':
					case 'paste':
						this.fillClipboardEventData(eventStruct, e, target);
						break;
					case 'keydown':
					case 'keyup':
					case 'keypress':
						this.fillKeyboardEventData(eventStruct, e, target);					
						break;
					case 'focus':
					case 'blur':
					case 'focusin':
					case 'focusout':
						this.fillFocusEventData(eventStruct, e, target);					
						break;
					default:
						this.fillUIEventData(eventStruct, e, target);
						break;
				}
	
				return eventStruct;
			},
			fillMouseEventData: function (eventStruct, e, target)
			{
				var DOMMouseEventProps = ["pageX",
				"pageY",
				"button",
				"buttons",
				"clientX",
				"clientY",
				"offsetX",
				"offsetY",
				"layerX",
				"layerY",
				"movementX",
				"movementY",
				"metaKey",
				"which",
				"x",
				"y"]
	
				DOMMouseEventProps.forEach(function (prop) {
					eventStruct._event_props[prop] = e[prop];
				});
	
				eventStruct["typeOfEvent"] = "MouseEvent";

				switch(e.type)
				{
					case 'drag':
					case 'dragend':
					case 'dragenter':
					case 'dragleave':
					case 'dragover':
					case 'dragstart':
					case 'drop':
						this.fillDragEventData(eventStruct, e, target);
						break;
					case 'wheel':
					case 'mousewheel':
						this.fillWheelEventData(eventStruct, e, target);					
						break;

				}
	
			},        
			fillDragEventData: function (eventStruct, e, target)
			{
				var DOMDragEventProps = [];
	
				DOMDragEventProps.forEach(function (prop) {
					eventStruct._event_props[prop] = e[prop];
				});
	
				eventStruct["typeOfEvent"] = "DragEvent";
			},     
			fillUIEventData: function (eventStruct, e, target)
			{
				var DOMUIEventProps = []
	
				DOMUIEventProps.forEach(function (prop) {
					eventStruct._event_props[prop] = e[prop];
				});
	
				eventStruct["typeOfEvent"] = "UIEvent";
	
				if (e instanceof FocusEvent)
				{
					this.fillFocusEventData(eventStruct, e, target);
				}
				if (e instanceof KeyboardEvent)
				{
					this.fillKeyboardEventData(eventStruct, e, target);
				}
	
			},        
			fillFocusEventData: function (eventStruct, e, target)
			{
				var DOMFocusEventProps = [];
	
				DOMFocusEventProps.forEach(function (prop) {
					eventStruct._event_props[prop] = e[prop];
				});
	
				eventStruct["typeOfEvent"] = "FocusEvent";
			},     
			fillWheelEventData: function (eventStruct, e, target)
			{
				var DOMWheelEventProps = ["deltaMode",
				"deltaX",
				"deltaY",
				"deltaZ",
				"wheelDelta",
				"wheelDeltaX",
				"wheelDeltaY",
				"DOM_DELTA_LINE",
				"DOM_DELTA_PAGE",
				"DOM_DELTA_PIXEL"];
	
				DOMWheelEventProps.forEach(function (prop) {
					eventStruct._event_props[prop] = e[prop];
				});
	
				eventStruct["typeOfEvent"] = "WheelEvent";
			}, 
			fillKeyboardData: function (eventStruct, e, target)
			{
				var DOMKeyboardEventProps = ["locale",
				"location",
				"repeat",
				"which",
				"code",
				"DOM_KEY_LOCATION_JOYSTICK",
				"DOM_KEY_LOCATION_LEFT",
				"DOM_KEY_LOCATION_MOBILE",
				"DOM_KEY_LOCATION_NUMPAD",
				"DOM_KEY_LOCATION_RIGHT",
				"DOM_KEY_LOCATION_STANDARD"
				];
	
				DOMKeyboardEventProps.forEach(function (prop) {
					eventStruct._event_props[prop] = e[prop];
				});
	
				eventStruct["typeOfEvent"] = "KeyboardEvent";
			},  
			fillClipboardEventData: function (eventStruct, e, target)
			{
				var DOMClipboardEventProps = [];
	
				DOMClipboardEventProps.forEach(function (prop) {
					eventStruct._event_props[prop] = e[prop];
				});
	
				// what else do we need here.
				eventStruct["typeOfEvent"] = "ClipboardEvent";
			
			},     


		
		},			
	

	};

	__WebAssembly_Browser_DOM__.init = function ()
	{
		var self = this;
		// place other initialization here.
	}

	__WebAssembly_Browser_DOM__.init.prototype = __WebAssembly_Browser_DOM__.prototype;

	global.WebAssembly_Browser_DOM = __WebAssembly_Browser_DOM__;
    
}(window));
