
var MonoDOMSupportLib = {
	$MONO: {

	},

	// This routine will setup the correct wrapping of a function for execution 
	// running in javascript as well as Node.js.  In the future this will provode
	// the ability to hook back into Node.js so that 'require' can be used. 
	mono_wasm_eval_hook: function(dataPtr, is_exception) {
		return Module.mono_wasm_eval_hook(dataPtr, is_exception);
	},


};

autoAddDeps(MonoDOMSupportLib, '$MONO')
mergeInto(LibraryManager.library, MonoDOMSupportLib)

