


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
					
					eventHandler.delegate(eventStruct["type"],
						 eventStruct["typeOfEvent"],
						eventHandler.target,
						e,
						JSON.stringify(eventStruct)
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
				var DOMEventProps = ["type",
				"altKey",
				"bubbles",
				"cancelable",
				"changedTouches",
				"ctrlKey",
				"detail",
				"eventPhase",
				"metaKey",
				"shiftKey",
				"char",
				"charCode",
				"key",
				"keyCode",
				"pointerId",
				"pointerType",
				"screenX",
				"screenY",
				"timeStamp",
				"isTrusted",
				"scoped"]
	
				var eventStruct = {};
				eventStruct["typeOfEvent"] = "Event";
	
				DOMEventProps.forEach(function (prop) {
					eventStruct[prop] = e[prop];
				});
	
				if (e instanceof MouseEvent)
				{
					this.fillMouseEventData(eventStruct, e, target);
				}
				else if (e instanceof UIEvent)
				{
					this.fillUIEventData(eventStruct, e, target);
				}
				else if (e instanceof ClipboardEvent)
				{
					eventStruct["typeOfEvent"] = "ClipboardEvent";
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
					eventStruct[prop] = e[prop];
				});
	
				eventStruct["typeOfEvent"] = "MouseEvent";
	
				if (e instanceof DragEvent)
				{
					this.fillDragEventData(eventStruct, e, target);
				}
				else if (e instanceof WheelEvent)
				{
					this.fillWheelEventData(eventStruct, e, target);
				}
	
			},        
			fillDragEventData: function (eventStruct, e, target)
			{
				var DOMDragEventProps = [];
	
				DOMDragEventProps.forEach(function (prop) {
					eventStruct[prop] = e[prop];
				});
	
				eventStruct["typeOfEvent"] = "DragEvent";
			},     
			fillUIEventData: function (eventStruct, e, target)
			{
				var DOMUIEventProps = []
	
				DOMUIEventProps.forEach(function (prop) {
					eventStruct[prop] = e[prop];
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
					eventStruct[prop] = e[prop];
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
					eventStruct[prop] = e[prop];
				});
	
				eventStruct["typeOfEvent"] = "WheelEvent";
			}, 
			fillFocusEventData: function (eventStruct, e, target)
			{
				var DOMKeyboardEventProps = ["locale",
				"location",
				"metakey",
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
					eventStruct[prop] = e[prop];
				});
	
				eventStruct["typeOfEvent"] = "KeyboardEvent";
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
