TOP=$(realpath $(CURDIR))

#Use either 'release' or 'debug' dependending on what you need
DRIVER_CONF=debug


EMCC=source $(TOP)/emsdk/emsdk_env.sh && emcc
EMPLUSPLUS=source $(TOP)/emsdk/emsdk_env.sh && em++
D8=$(TOP)/v8/out.gn/x64.release/d8
WASM_SDKS_DIR=$(TOP)/sdks
WASM_BCL_DIR=$(WASM_SDKS_DIR)/bcl/
MANAGED_DEPLOY_DIR=$(TOP)/managed
BUILD_DIR=$(TOP)/build

EXTRA_EXPORTED_RUNTIME_METHODS=['ccall', 'FS_createPath', 'FS_createDataFile', 'cwrap', 'setValue', 'getValue', 'UTF8ToString']

BCL_ASSEMBLIES= \
        mscorlib.dll    \
        System.dll      \
        System.Core.dll      \

NATIVE_RUNTIME_SOURCES = \
	./src/Mono/driver.cpp	

TEST_DEPS = $(patsubst %,managed/%,$(BCL_ASSEMBLIES))
TEST_CSC_DEPS = $(patsubst %,-r:%, $(TEST_DEPS))

$(TOP)/emsdk:
	git clone https://github.com/juj/emsdk.git $(TOP)/emsdk

.stamp-wasm-toolchain: | $(TOP)/emsdk
	cd $(TOP)/emsdk && ./emsdk install latest
	cd $(TOP)/emsdk && ./emsdk activate --embedded latest
	touch $@

.PHONY: toolchain
toolchain: .stamp-wasm-toolchain

$(TOP)/sdks/:
	mkdir -p $@

.stamp-wasm-bcl: | $(TOP)/sdks
	curl -L 'https://xamjenkinsartifact.azureedge.net/test-mono-mainline-webassembly/108/highsierra/sdks/wasm/mono-wasm-a14f41ca260.zip' -o "mono-wasm.zip" -#
	unzip mono-wasm.zip -d $(TOP)/sdks
	touch $@

.PHONY: wasmbcl
wasmbcl: .stamp-wasm-bcl

# .stamp-depot-tools:
# 	rm -rf $(TOP)/depot_tools
# 	git clone https://chromium.googlesource.com/chromium/tools/depot_tools.git $(TOP)/depot_tools
# 	touch $@

# .stamp-v8: .stamp-depot-tools
# 	rm -rf $(TOP)/v8
# 	rm -rf $(TOP)/.gclient*
# 	cd $(TOP)/ && PATH=$(TOP)/depot_tools:$$PATH fetch v8
# 	cd $(TOP)/v8 && tools/dev/v8gen.py -vv x64.release
# 	cd $(TOP)/v8 && $(TOP)/depot_tools/ninja -C out.gn/x64.release
# 	touch $@

#.PHONY: toolchain
#toolchain: .stamp-v8

out/:
	mkdir -p $(BUILD_DIR)

driver.o: $(NATIVE_RUNTIME_SOURCES) | out/
	$(EMPLUSPLUS) -g -Os -s WASM=1 -s ALLOW_MEMORY_GROWTH=1 -s BINARYEN=1 -s "BINARYEN_TRAP_MODE='clamp'" -s TOTAL_MEMORY=134217728 -s ALIASING_FUNCTION_POINTERS=0 -std=c++11 $(NATIVE_RUNTIME_SOURCES) -c -o $(BUILD_DIR)/driver.o

debug/:
	mkdir -p $@
release/:
	mkdir -p $@

debug/mono.wasm debug/mono.js: driver.o $(WASM_SDKS_DIR)/library_mono.js library_mono_dom.js $(WASM_SDKS_DIR)/libmonosgen-2.0.a | debug/
	$(EMCC) -g4 -Os -s WASM=1 -s ALLOW_MEMORY_GROWTH=1 -s BINARYEN=1 -s "BINARYEN_TRAP_MODE='clamp'" -s TOTAL_MEMORY=134217728 -s ALIASING_FUNCTION_POINTERS=0 -s ASSERTIONS=2 --js-library $(WASM_SDKS_DIR)/library_mono.js --js-library library_mono_dom.js $(BUILD_DIR)/driver.o $(WASM_SDKS_DIR)/libmonosgen-2.0.a -o debug/mono.js -s NO_EXIT_RUNTIME=1 -s "EXTRA_EXPORTED_RUNTIME_METHODS=$(EXTRA_EXPORTED_RUNTIME_METHODS)"

release/mono.wasm release/mono.js: driver.o $(WASM_SDKS_DIR)/library_mono.js library_mono_dom.js $(WASM_SDKS_DIR)/libmonosgen-2.0.a | release/
	$(EMCC) -Oz --llvm-opts 2 --llvm-lto 1 -s WASM=1 -s ALLOW_MEMORY_GROWTH=1 -s BINARYEN=1 -s "BINARYEN_TRAP_MODE='clamp'" -s TOTAL_MEMORY=134217728 -s ALIASING_FUNCTION_POINTERS=0 --js-library $(WASM_SDKS_DIR)/library_mono.js --js-library library_mono_dom.js $(BUILD_DIR)/driver.o $(WASM_SDKS_DIR)/libmonosgen-2.0.a -o release/mono.js -s NO_EXIT_RUNTIME=1 -s "EXTRA_EXPORTED_RUNTIME_METHODS=$(EXTRA_EXPORTED_RUNTIME_METHODS)"

build/mono.js: $(DRIVER_CONF)/mono.js
	cp $< $@

build/mono.wasm: $(DRIVER_CONF)/mono.wasm
	cp $< $@

build-native: build/mono.js build/mono.wasm debug/mono.js release/mono.js

build: toolchain wasmbcl build-native

clean:
	rm -rf debug
	rm -rf build
	rm -rf release
	
package: build
	rm -rf tmp
	mkdir tmp
	mkdir tmp/bcl
	cp -r $(WASM_BCL_DIR) tmp/bcl/
	cp $(WASM_SDKS_DIR)/libmonosgen-2.0.a tmp/
	cp $(WASM_SDKS_DIR)/library_mono.js tmp/
	cp library_mono_dom.js tmp/
	cp build/mono.js tmp/
	cp -r debug tmp/
	cp -r release tmp/
	cp -r build tmp/
	cp -r src tmp/
	cp README.md tmp/
	cp $(WASM_SDKS_DIR)/server.py tmp/
	(cd tmp;  zip -r9 ../mono-dom-wasm-$(shell git rev-parse --short HEAD).zip .)
	rm -rf tmp

package-only: 
	rm -rf tmp
	mkdir tmp
	mkdir tmp/bcl
	cp -r $(WASM_BCL_DIR) tmp/bcl/
	cp $(WASM_SDKS_DIR)/libmonosgen-2.0.a tmp/
	cp $(WASM_SDKS_DIR)/library_mono.js tmp/
	cp library_mono_dom.js tmp/
	cp build/mono.js tmp/
	cp -r debug tmp/
	cp -r release tmp/
	cp -r build tmp/
	cp -r src tmp/
	cp README.md tmp/
	cp $(WASM_SDKS_DIR)/server.py tmp/
	(cd tmp;  zip -r9 ../mono-dom-wasm-$(shell git rev-parse --short HEAD).zip .)
	rm -rf tmp

FORCE:
