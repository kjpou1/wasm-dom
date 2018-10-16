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

APP_SOURCES = \
    ./Program.cs   \
    ./Dragger.cs   \

ASSETS = \
    --asset=index.html   \
	
DragNDrop.dll: ${APP_SOURCES}
	msbuild DragNDrop.csproj /t:Rebuild /p:configuration=${DOM_CONF}

gen-runtime:
	mono $(WASM_SDK_PACKAGER)/packager.exe ${DRIVER_CONF} --copy=ifnewer --template=../runtime.js --out=publish --prefix=./bin/${DOM_CONF} $(ASSETS) DragNDrop.exe

build-managed: DragNDrop.dll gen-runtime

build: build-managed

clean:
	rm -rf publish


