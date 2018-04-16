
var MonoDOMRuntime = {

    mono_wasm_debug : false,
    mono_wasm_object_registry: {},
    mono_wasm_ref_counter: 0,
    mono_wasm_free_list: [],
    onWasmDOMInitialized: [],
    onWasmDOMStarted: [],
    defaultBclLibraries: ["mscorlib.dll", "Mono.WebAssembly.DOM.dll", "System.dll", "System.Core.dll"],
    applicationAssemblies: [],
    onRuntimeInitialized: function ()
    {
        if (this.onWasmDOMInitialized) {
            if (typeof this.onWasmDOMInitialized == 'function') this.onWasmDOMInitialized = [this.onWasmDOMInitialized];
            while (this.onWasmDOMInitialized.length) {
                this.onWasmDOMInitialized.shift()();
            }
        }           
    },    
    onBclLoaded: function () {
        Module.print ("Done loading the BCL.");
        
        
        this.load_runtime ("managed", 1);

        Module.print ("Done initializing the runtime.");

        if (this.onWasmDOMStarted) {
            if (typeof this.onWasmDOMStarted == 'function') this.onWasmDOMStarted = [this.onWasmDOMStarted];
            while (this.onWasmDOMStarted.length) {
                this.onWasmDOMStarted.shift()();
            }
        }                  
        
    },
    conv_string: function (mono_obj) {
        if (mono_obj == 0)
            return null;
        var raw = this.mono_string_get_utf8 (mono_obj);
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

        var res = this.invoke_method (method, this_arg, args_mem, eh_throw);

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

    // This routine will setup the correct wrapping of a function for execution 
    // running in javascript as well as Node.js.  In the future this will provide
    // the ability to hook back into Node.js so that 'require' can be used. 
    mono_wasm_compile_function: function(dataPtr, is_exception) {
        var str = UTF8ToString (dataPtr);
        try {

            var wrapper = '(function () { ' + str + ' })';
            var compiledFunc = this.mono_wasm_eval_compile(str);
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
        var wrapper = '(function () { ' + data + ' })';
        //var funcFactory = this.globalEval(wrapper);
        var funcFactory = eval(wrapper);
        var func = funcFactory();
        if (typeof func !== 'function') {
            throw new Error('Eval code must return an instance of a JavaScript function. '
                + 'Please use `return` statement to return a function.');
        }
    
        return func;
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
        
        if (typeof(value) === "undefined")
        {
            requireObject.style[attribute] = "";
        }
        else
        {
            requireObject.style[attribute] = value;
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

                var eventStruct = MonoDOMRuntime.mono_wasm_event_helper.fillEventData(e, this);

                // We will register the object on our object stack so PreventDefault, StopPropogation and other info
                // methods will be available
                var eventHandle = MonoDOMRuntime.mono_wasm_register_obj(e);

                var res = MonoDOMRuntime.call_method (MonoDOMRuntime.dom_runtime_eventWrangler, null, 
                    [MonoDOMRuntime.mono_string(eventStruct["type"]), 
                        MonoDOMRuntime.mono_string(eventStruct["typeOfEvent"]), 
                        MonoDOMRuntime.mono_string(eventHandler.uid.toString()),
                        MonoDOMRuntime.mono_string(eventHandle.toString()),
                        MonoDOMRuntime.mono_string(JSON.stringify(eventStruct)),
                    ]);

                // We are now done with the event so we need to unregister the object from our object stack
                // and free the handle for re-use. 
                MonoDOMRuntime.mono_wasm_unregister_obj(e);
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
            "screenY"]
    
            var eventStruct = {};
            eventStruct["typeOfEvent"] = "Event";
    
            DOMEventProps.forEach(function (prop) {
                eventStruct[prop] = e[prop];
            });
    
            if (e instanceof MouseEvent)
            {
                MonoDOMRuntime.mono_wasm_event_helper.fillMouseEventData(eventStruct, e, target);
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
            "movementY"]
    
            DOMMouseEventProps.forEach(function (prop) {
                eventStruct[prop] = e[prop];
            });
    
            eventStruct["typeOfEvent"] = "MouseEvent";

            if (e instanceof DragEvent)
            {
                MonoDOMRuntime.mono_wasm_event_helper.fillDragEventData(eventStruct, e, target);
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
    },
    runMainClass: function (assembly, name_Space, name, entryPoint, args)
    {
        this.mono_webassembly_dom = MonoDOMRuntime.assembly_load("Mono.WebAssembly.DOM");
        if (!this.mono_webassembly_dom)
            throw "Could not find assembly: " + "Mono.WebAssembly.DOM";

        this.dom_runtime_class = MonoDOMRuntime.find_class (this.mono_webassembly_dom, "Mono.WebAssembly", "RuntimeEventManager");
        if (!this.dom_runtime_class)
            throw "Could not find: Runtime in Mono.WebAssembly.DOM";

        this.dom_runtime_eventWrangler = MonoDOMRuntime.find_method (this.dom_runtime_class, "EventWrangler", -1);
        if (!this.dom_runtime_eventWrangler)
            throw "Could not find: 'eventWrangler' in 'Runtime'";

        var res = MonoDOMRuntime.call_method (this.dom_runtime_eventWrangler, null, [MonoDOMRuntime.mono_string("initialize"), MonoDOMRuntime.mono_string("initialize"), MonoDOMRuntime.mono_string("-1")]);

        this.app_Assembly = MonoDOMRuntime.assembly_load (assembly);
        if (!this.app_Assembly)
            throw "Could not find assembly: " + assembly;

        this.main_class = MonoDOMRuntime.find_class (this.app_Assembly, name_Space, name);
        if (!this.main_class)
            throw "Could not find: " + name_Space + "." + name + " in: " + assembly;

        this.main_invoke = MonoDOMRuntime.find_method (this.main_class, entryPoint, -1);
        if (!this.main_invoke)
            throw "Could not find: " + entryPoint + " in: " + nameSpace + "." + name;
        

        if (typeof args === 'undefined')
        {
            args = [0];
        }
        else
        {
            var tempArgs;
            if (typeof args === 'string' || args instanceof String)
                tempArgs = args;
            else
            {
                tempArgs = JSON.stringify(args);
            }
            args = [MonoDOMRuntime.mono_string(tempArgs)];
        }

        var res = MonoDOMRuntime.call_method (this.main_invoke, null, args);
        return MonoDOMRuntime.conv_string (res);
    }



};

var Module = {

    print: function(x) { if (MonoDOMRuntime.mono_wasm_debug) console.log ("WASM-DOM: " + x) },
    printErr: function(x) { if (MonoDOMRuntime.mono_wasm_debug) console.log ("WASM-DOM-ERR: " + x) },
    startLoadTime: Date.now(),
    runtimeLoadTime: null,
    bclLoadTime: null,
    onRuntimeInitialized: function ()
    {
        MonoDOMRuntime.onRuntimeInitialized();
    },
    mono_wasm_eval_hook: function (dataPtr, is_exception)
    {
        var str = UTF8ToString (dataPtr);
        try {

            var wrapper = '(function () { ' + str + ' })';
            var compiledFunc = this.mono_wasm_eval_compile(str);
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
        var wrapper = '(function () { ' + data + ' })';
        //var funcFactory = this.globalEval(wrapper);
        var funcFactory = eval(wrapper);
        var func = funcFactory();
        if (typeof func !== 'function') {
            throw new Error('Eval code must return an instance of a JavaScript function. '
                + 'Please use `return` statement to return a function.');
        }
    
        return func;
    },      
};

Module["preRun"] = [];
Module["postRun"] = [];

// override the preRun
Module['preRun'].push(function() {

    Module.print('preRun');

    // it is ok to call cwrap before the runtime is loaded. we don't need the code
    // and everything to be ready, since cwrap just prepares to call code, it 
    // doesn't actually call it
    MonoDOMRuntime.load_runtime = Module.cwrap ('mono_wasm_load_runtime', null, ['string'])
    MonoDOMRuntime.assembly_load = Module.cwrap ('mono_wasm_assembly_load', 'number', ['string'])
    MonoDOMRuntime.find_class = Module.cwrap ('mono_wasm_assembly_find_class', 'number', ['number', 'string', 'string'])
    MonoDOMRuntime.find_method = Module.cwrap ('mono_wasm_assembly_find_method', 'number', ['number', 'string', 'number'])
    MonoDOMRuntime.invoke_method = Module.cwrap ('mono_wasm_invoke_method', 'number', ['number', 'number', 'number'])
    MonoDOMRuntime.mono_string_get_utf8 = Module.cwrap ('mono_wasm_string_get_utf8', 'number', ['number'])
    MonoDOMRuntime.mono_string = Module.cwrap ('mono_wasm_string_from_js', 'number', ['string'])

    
});

// override the postRun
Module['postRun'].push(function() {

    Module.print ("postRun");

    Module.runtimeLoadTime = Date.now ();
    Module.print ("Done with WASM module instantiation. Took " + (Module.runtimeLoadTime - Module.startLoadTime) + " ms");

    Module.FS_createPath ("/", "managed", true, true);

    var pending = 0;
    var runAssemblies = MonoDOMRuntime.defaultBclLibraries;
    if (MonoDOMRuntime.applicationAssemblies) {
        runAssemblies = runAssemblies.concat(MonoDOMRuntime.applicationAssemblies);
    }           

    runAssemblies.forEach (function(asm_name) {
        Module.print ("loading " + asm_name);
        ++pending;
        fetch ("managed/" + asm_name, { credentials: 'same-origin' }).then (function (response) {
            if (!response.ok)
                throw "failed to load Assembly '" + asm_name + "'";
            return response['arrayBuffer']();
        }).then (function (blob) {
            var asm = new Uint8Array (blob);
            Module.FS_createDataFile ("managed/" + asm_name, null, asm, true, true, true);
            Module.print ("LOADED: " + asm_name);
            --pending;
            if (pending == 0)
                MonoDOMRuntime.onBclLoaded ();
        });
    });

});

