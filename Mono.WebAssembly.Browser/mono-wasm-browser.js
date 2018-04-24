
var MonoWasmBrowserAPI = {

    mono_wasm_object_registry: {},
    mono_wasm_ref_counter: 0,
    mono_wasm_free_list: [],
    mono_wasm_browser_assembly: function() { return "Mono.WebAssembly.Browser.dll" },
    mono_wasm_browser_init: function() {  
        this.mono_webassembly_browser = Module.assembly_load("Mono.WebAssembly.Browser");
        if (!this.mono_webassembly_browser)
            throw "Could not find assembly: " + "Mono.WebAssembly.Browser";

        this.browser_event_manager = Module.find_class (this.mono_webassembly_browser, "Mono.WebAssembly", "RuntimeEventManager");
        if (!this.browser_event_manager)
            throw "Could not find: RuntimeEventManager in Mono.WebAssembly.Browser";

        this.browser_eventWrangler = Module.find_method (this.browser_event_manager, "EventWrangler", -1);
        if (!this.browser_eventWrangler)
            throw "Could not find: 'EventWrangler' in 'Runtime'";

        var res = this.call_method (this.browser_eventWrangler, 
            null, 
            [Module.mono_string("initialize"), 
            Module.mono_string("initialize"), 
            Module.mono_string("-1")]);


    },
    conv_string: function (mono_obj) {
        if (mono_obj == 0)
            return null;
        var raw = Module.mono_string_get_utf8 (mono_obj);
        var res = Module.UTF8ToString (raw);
        Module._free (raw);

        return res;
    },        
    call_method: function (method, this_arg, args) {
        var args_mem = Module._malloc (args.length * 4);
        var eh_throw = Module._malloc (4);
        for (var i = 0; i < args.length; ++i)
            Module.setValue (args_mem + i * 4, args [i], "i32");
        Module.setValue (eh_throw, 0, "i32");

        var res = Module.invoke_method (method, this_arg, args_mem, eh_throw);

        var eh_res = Module.getValue (eh_throw, "i32");

        Module._free (args_mem);
        Module._free (eh_throw);

        if (eh_res != 0) {
            var msg = this.conv_string (res);
            throw new Error (msg);
        }

        return res;
    },
    // Object wrapping helper functions to handle reference handles that will
    // be used in managed code.
    mono_wasm_register_obj: function(obj) {
        var handle = undefined;
        if (typeof(obj) !== "undefined" && obj !== null) {
            handle = obj.__mono_wasm_handle__;
            if (typeof(handle) === "undefined") {
                obj.__mono_wasm_handle__ = handle = this.mono_wasm_free_list.length ?
                this.mono_wasm_free_list.pop() : this.mono_wasm_ref_counter++;
            }
            this.mono_wasm_object_registry[handle] = obj;
        }
        return handle;
    },
    mono_wasm_require_handle: function(handle) {
        return this.mono_wasm_object_registry[handle];
    },
    mono_wasm_unregister_obj: function(obj) {

        if (typeof(obj) !== "undefined" && obj !== null) {
            handle = obj.__mono_wasm_handle__;
            if (typeof(handle) !== "undefined") {
                this.mono_wasm_free_list.push(handle);
                delete obj.__mono_wasm_handle__;
            }
        }
    },
    mono_wasm_free_handle: function(handle) {
        this.mono_wasm_unregister_obj(this.mono_wasm_object_registry[handle]);
    },
    mono_wasm_val_global: function (globalName) {
        function get_global() { return (function(){return Function;})()('return this')(); }
        var globalObj = get_global()[globalName];
        res = this.mono_wasm_register_obj(globalObj);           
        return res;
    },
    mono_wasm_get_property: function (handle, property) {
    
        var requireObject = this.mono_wasm_require_handle(handle);
        if (typeof(requireObject) === 'undefined')
        {
            // We should probably throw an error here but for now
            // we will just set the result
                // error 'Set Property error: Object with handle id \'' + handle + '\' may have already been garbage collected.', null);
                return false;
        }


        let objProp = requireObject[property];
        return objProp;
    },
    mono_wasm_set_property: function (handle, property, value, createIfNotExists, hasOwnProperty) {
        var requireObject = this.mono_wasm_require_handle(handle);
        if (typeof(requireObject) === 'undefined')
        {
            // We should probably throw an error here but for now
            // we will just set the result
                // error 'Set Property error: Object with handle id \'' + handle + '\' may have already been garbage collected.', null);
                return false;
        }
    
        var result = false;

        if (createIfNotExists === true) {
            requireObject[property] = value;
            result = true;
        }
        else {
            result = false;
            if (hasOwnProperty === true) {
                if (requireObject.hasOwnProperty(property)) {
                    requireObject[property] = value;
                    result = true;
                }
            }
            else {
                requireObject[property] = value;
                result = true;
            }
        
        }
        return result;
    },
    mono_wasm_get_attribute: function (handle, attribute) {
        var requireObject = this.mono_wasm_require_handle(handle);
        if (typeof(requireObject) === 'undefined')
        {
            // We should probably throw an error here but for now
            // we will just set the result
                return ;
        }
        return requireObject.getAttribute(attribute);
    },
    mono_wasm_set_attribute: function (handle, attribute, value) {
        var requireObject = this.mono_wasm_require_handle(handle);
        if (typeof(requireObject) === 'undefined')
        {
            // We should probably throw an error here but for now
            // we will just set the result
                return ;
        }
        //console.log('set attribute -> ' + attribute + ' [ ' + value + ' ]');
        if (typeof(value) === "undefined")
        {
            requireObject.removeAttribute(attribute);
        }
        else
        {
            requireObject.setAttribute(attribute, value);
        }
        
        return true;
    },
    mono_wasm_get_style_attribute: function (handle, attribute) {
        var requireObject = this.mono_wasm_require_handle(handle);
        if (typeof(requireObject) === 'undefined')
        {
            // We should probably throw an error here but for now
            // we will just set the result
                return ;
        }
        return requireObject.style[attribute];
    },
    mono_wasm_set_style_attribute: function (handle, attribute, value) {
        var requireObject = this.mono_wasm_require_handle(handle);
        if (typeof(requireObject) === 'undefined')
        {
            // We should probably throw an error here but for now
            // we will just set the result
                return ;
        }
        
        try {
            if (requireObject.style)
            {
                if (typeof(value) === "undefined")
                {
                    requireObject.style[attribute] = "";
                }
                else
                {
                    requireObject.style[attribute] = value;
                }
            }
        
        }
        catch (ex)
        {
            console.error(ex.message);
            throw ex;
        }
        
        return true;
    },
    mono_wasm_invoke: function (handle, methodName, args) {
        var requireObject = this.mono_wasm_require_handle(handle);
        if (typeof(requireObject) === 'undefined')
        {
            // We should probably throw an error here but for now
            // we will just set the result
                return ;
        }
        var invokeResult;

        if (typeof requireObject[methodName] === 'function') {

            try{
                invokeResult = requireObject[methodName].apply(requireObject, args);
            }
            catch (ex)
            {
                console.error(ex.message);
                throw ex;
            }
            return invokeResult;
        }
        else
            throw new Error("Invoke error: Function '" + methodName + "' not found.");

    },
    mono_wasm_addEventListener: function (handle, eventTypeString, uid) {

        var target = this.mono_wasm_require_handle(handle);
        if (typeof(target) === 'undefined' && target !== null)
        {
            // We should probably throw an error here but for now
            // we will just set the result
                return ;
        }

        var eventHandler = {
            target: target,
            eventTypeString: eventTypeString,
            uid: uid
          };
        this.mono_wasm_event_helper.add(eventHandler);
    },
    mono_wasm_removeEventListener: function (handle, eventTypeString, uid) {

        var target = this.mono_wasm_require_handle(handle);
        if (typeof(target) === 'undefined' && target !== null)
        {
            // We should probably throw an error here but for now
            // we will just set the result
                return ;
        }

        var eventHandler = {
            target: target,
            eventTypeString: eventTypeString,
            uid: uid
          };
        this.mono_wasm_event_helper.remove(eventHandler);
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

                var eventStruct = MonoWasmBrowserAPI.mono_wasm_event_helper.fillEventData(e, this);

                // We will register the object on our object stack so PreventDefault, StopPropogation and other info
                // methods will be available
                var eventHandle = MonoWasmBrowserAPI.mono_wasm_register_obj(e);

                var res = MonoWasmBrowserAPI.call_method (MonoWasmBrowserAPI.browser_eventWrangler, null, 
                    [Module.mono_string(eventStruct["type"]), 
                        Module.mono_string(eventStruct["typeOfEvent"]), 
                        Module.mono_string(eventHandler.uid.toString()),
                        Module.mono_string(eventHandle.toString()),

                        Module.mono_string(JSON.stringify(eventStruct)),
                        //Module.mono_string("a"),
                    ]);

                // We are now done with the event so we need to unregister the object from our object stack
                // and free the handle for re-use. 
                MonoWasmBrowserAPI.mono_wasm_unregister_obj(e);
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
                MonoWasmBrowserAPI.mono_wasm_event_helper.fillMouseEventData(eventStruct, e, target);
            }
            else if (e instanceof UIEvent)
            {
                MonoWasmBrowserAPI.mono_wasm_event_helper.fillUIEventData(eventStruct, e, target);
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
                MonoWasmBrowserAPI.mono_wasm_event_helper.fillDragEventData(eventStruct, e, target);
            }
            else if (e instanceof WheelEvent)
            {
                MonoWasmBrowserAPI.mono_wasm_event_helper.fillWheelEventData(eventStruct, e, target);
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
                MonoWasmBrowserAPI.mono_wasm_event_helper.fillFocusEventData(eventStruct, e, target);
            }
            if (e instanceof KeyboardEvent)
            {
                MonoWasmBrowserAPI.mono_wasm_event_helper.fillKeyboardEventData(eventStruct, e, target);
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
    mono_wasm_eval_hook: function (dataPtr, is_exception)
    {
        var str = UTF8ToString (dataPtr);
        try {
            var wrappedData = "return function () { return " + str + "};"
            var wrapper = '(function () { ' + wrappedData + ' })';
            var compiledFunc = this.mono_wasm_eval_compile(wrapper);
            // Execute the function
            var res = compiledFunc();
            if (typeof res === 'undefined' || res === null)
                return 0;
            res = res.toString ();
            setValue (is_exception, 0, "i32");
        } catch (e) {
            res = e.toString ();
            Module.setValue (is_exception, 1, "i32");
            if (typeof res === 'undefined' || res === null)
                res = "unknown exception";
        }
        var buff = Module._malloc((res.length + 1) * 2);
        stringToUTF16 (res, buff, (res.length + 1) * 2);
        return buff;
    },
    mono_wasm_eval_compile: function (data) {
        
        //var funcFactory = this.globalEval(wrapper);
        var funcFactory = eval(data);
        var func = funcFactory();
        if (typeof func !== 'function') {
            throw new Error('Eval code must return an instance of a JavaScript function. '
                + 'Please use `return` statement to return a function.');
        }
    
        return func;
    },     
};
