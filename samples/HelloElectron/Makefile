TOP=$(realpath $(CURDIR)/../..)

#Use either 'release' or 'debug' dependending on what you need
DRIVER_CONF=debug

#Use either 'release' or 'debug' dependending on what you need
DOM_CONF=release

#WASM_SDK=$(TOP)/../JSInterop2/WebAssembly.JSInterop/tools/mono/sdks/bcl
#WASM_SDK_FRAMEWORK=$(TOP)/../JSInterop2/WebAssembly.JSInterop/tools/mono/sdks/framework
#WASM_SDK_PACKAGER=$(TOP)/../JSInterop2/WebAssembly.JSInterop/tools/mono/sdks
  WASM_SDK=$(TOP)/../mono/sdks/out/wasm-bcl/wasm
  WASM_SDK_FRAMEWORK=$(TOP)/../mono/sdks/wasm
  WASM_SDK_PACKAGER=$(TOP)/../mono/sdks/wasm

APP_SOURCES = \
    ./Program.cs   \
    ./DemoButtons.cs   \
    ./LinkImports.cs   \
    ./Nav   \

ASSETS = \
    --asset=index.html   \
	
HelloElectron.dll: 
	msbuild src/HelloElectron.csproj /p:configuration=$(DOM_CONF)

gen-runtime:
	mono $(WASM_SDK_PACKAGER)/packager.exe --debugrt --copy=ifnewer --template=electron-runtime.js --out=./publish --prefix=./src/bin/$(DOM_CONF) $(ASSETS) HelloElectron.exe

build-managed: HelloElectron.dll gen-runtime

build: build-managed

clean:
	rm -rf ./publish
