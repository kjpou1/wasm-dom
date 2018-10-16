TOP=$(realpath $(CURDIR)/../..)

#Use either ' ' or '--debugrt' dependending on what you need
DRIVER_CONF=--debugrt
#DRIVER_CONF=

#Use either 'release' or 'debug' dependending on what you need
DOM_CONF=debug

#WASM_SDK=$(TOP)/../JSInterop2/WebAssembly.JSInterop/tools/mono/sdks/bcl
#WASM_SDK_FRAMEWORK=$(TOP)/../JSInterop2/WebAssembly.JSInterop/tools/mono/sdks/framework
#WASM_SDK_PACKAGER=$(TOP)/../JSInterop2/WebAssembly.JSInterop/tools/mono/sdks
  WASM_SDK=$(TOP)/../mono/sdks/out/wasm-bcl/wasm
  WASM_SDK_FRAMEWORK=$(TOP)/../mono/sdks/wasm
  WASM_SDK_PACKAGER=$(TOP)/../mono/sdks/wasm

WASM_DOM=../../WebAssembly.Browser/bin/Debug/netstandard2.0/WebAssembly.Browser.dll

APP_SOURCES = \
	./Hello.cs

ASSETS = \
    --asset=index.html   \
	
CreateElement.dll: 
	msbuild CreateElement.csproj /p:configuration=$(DOM_CONF)

gen-runtime:
	mono $(WASM_SDK_PACKAGER)/packager.exe ${DRIVER_CONF} --copy=ifnewer --out=publish --prefix=./bin/Debug $(ASSETS) CreateElement.exe

build-managed: CreateElement.dll gen-runtime

build: build-managed

clean:
	rm -rf managed publish
