


var Module = { 

    // Make sure we set our environment so that the NODE filesystem is used.
    // This overrides the default mechanism that tries to determine the environment and will
    // error out because it tries to use Browser API to read the files.
	ENVIRONMENTNode: 'NODE',
    // Needed to locate the wasm modules correctly
    locateFile: function (module)
    {
        var pathtomodule = require("path").resolve(__dirname, './publish/',module);
        return pathtomodule;
    },    
	onRuntimeInitialized: function () {
		MONO.mono_load_runtime_and_bcl (
			config.vfs_prefix,
			config.deploy_prefix,
			config.enable_debugging,
			config.file_list,
			function () {
				config.add_bindings ();
				BINDING.mono_wasm_get_global()["__WASM_DOM_BROWSER_INTERFACE__"] = __WASM_DOM_INTERFACE_INTERFACE__;
				App.init ();
			}
		)
	},
};

var __WASM_DOM_INTERFACE_INTERFACE__ = {
	
	mono_wasm_get_js_style_attribute: function(js_handle, js_name) {
		BINDING.bindings_lazy_init ();

		// var obj = BINDING.mono_wasm_require_handle (js_handle);
		// if (!obj) {
		// 	setValue (is_exception, 1, "i32");
		// 	return BINDING.js_string_to_mono_string ("Invalid JS object handle '" + js_handle + "'");
		// }

		// var js_name = BINDING.conv_string (attr_name);
		// if (!js_name) {
		// 	setValue (is_exception, 1, "i32");
		// 	return BINDING.js_string_to_mono_string ("Invalid attribute name object '" + js_name + "'");
		// }

		// var res;
		var m = obj.style[js_name];
		return m;
	},
	mono_wasm_set_js_style_attribute: function(obj, attribute, js_value) {
		BINDING.bindings_lazy_init ();

		// var obj = BINDING.mono_wasm_require_handle (js_handle);
		// if (!obj) {
		// 	setValue (is_exception, 1, "i32");
		// 	return BINDING.js_string_to_mono_string ("Invalid JS object handle '" + js_handle + "'");
		// }

		// var attribute = BINDING.conv_string (attr_name);
		// if (!attribute) {
		// 	setValue (is_exception, 1, "i32");
		// 	return BINDING.js_string_to_mono_string ("Invalid attribute name object '" + attribute + "'");
		// }

		try {
			if (obj.style)
			{
				//var js_value = BINDING.unbox_mono_obj(new_value);

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
		} catch (e) {
			var res = e.toString ();
			setValue (is_exception, 1, "i32");
			if (res === null || typeof res === "undefined")
				res = "unknown exception";
			return BINDING.js_string_to_mono_string (res);
		}
	
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

				var eventStruct = __WASM_DOM_INTERFACE_INTERFACE__.mono_wasm_event_helper.fillEventData(e, this);
				// We will register the object on our object stack so PreventDefault, StopPropogation and other info
				// methods will be available
				BINDING.mono_wasm_register_obj(e);
				
				eventHandler.delegate(eventStruct["type"],
				 	eventStruct["typeOfEvent"],
					eventHandler.target,
					e,
					JSON.stringify(eventStruct)
				);
				// We are now done with the event so we need to unregister the object from our object stack
				// and free the handle for re-use. 
				BINDING.mono_wasm_unregister_obj(e);
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
				__WASM_DOM_INTERFACE_INTERFACE__.mono_wasm_event_helper.fillMouseEventData(eventStruct, e, target);
			}
			else if (e instanceof UIEvent)
			{
				__WASM_DOM_INTERFACE_INTERFACE__.mono_wasm_event_helper.fillUIEventData(eventStruct, e, target);
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
				__WASM_DOM_INTERFACE_INTERFACE__.mono_wasm_event_helper.fillDragEventData(eventStruct, e, target);
			}
			else if (e instanceof WheelEvent)
			{
				__WASM_DOM_INTERFACE_INTERFACE__.mono_wasm_event_helper.fillWheelEventData(eventStruct, e, target);
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
				__WASM_DOM_INTERFACE_INTERFACE__.mono_wasm_event_helper.fillFocusEventData(eventStruct, e, target);
			}
			if (e instanceof KeyboardEvent)
			{
				__WASM_DOM_INTERFACE_INTERFACE__.mono_wasm_event_helper.fillKeyboardEventData(eventStruct, e, target);
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

}
