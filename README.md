# wasm-dom

This project is intended to support C# API bindings to the Web browser API's via mono's webassembly implementation.

## Current Work

This is a work in progress, and we are only getting started.   This means that the activation
workflow for .NET code is not finalized, nor is the Web browser API that is exposed to running .NET code.

The `TsToCSharp` project is being used to generate a strongly typed .NET API from TypeScript type definitions.  The definitions of the .NET API that are included in the `Mono.WebAssembly.DOM` module are generated from the TypeScript `lib.dom.d.ts` file. 

With that being said, the following are functioning:

- Global Object access which includes javascrip objects like `Window` and `Document`. 
- Property Getters and Setters
- Method Invoke
- Attributes and Attribute Styles (`Setters` are in progress)
- AddEventListener and RemoveEventListener - These are made available via the `event DOMEventHandler` and `DOMEventArgs` classes.  C# event handlers code can be used to attach to these events that are made public.
    
## Contents
You should now have the following directory structure

```
.
|--- wasm-dom                           
     |--- samples					// Where you can find sample code.	 
     |--- mono						// Custom mono webassembly module (see README.md)
     |--- Mono.WebAssembly.DOM 		// DOM Integration Code
     |--- wasm-dom-library.sln      // Solution file
```

## Prerequisites

A custom mono webassembly module needs to be build for now.  Please follow the [Build Instructions](./mono/README.md#building-custom-mono).  See [README](./mono/README.md).

## Building wasm-dom

Open the `wasm-dom-library.sln` in Visual Studio and build or the following command line:

```
$ msbuild wasm-dom-library.sln
``` 

## Samples

The [sampes](./samples) directory contains samples that can be run.

## Future Work

- Support for dotnet projects
- Project Templates
- Generated NuGets to be made available