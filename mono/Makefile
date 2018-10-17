TOP=$(realpath $(CURDIR))

$(TOP)/sdks/:
	mkdir -p $@

.stamp-wasm-bcl: | $(TOP)/sdks
	curl -L 'https://jenkins.mono-project.com/job/test-mono-mainline-wasm/1219/label=ubuntu-1804-amd64/Azure/processDownloadRequest/1219/ubuntu-1804-amd64/sdks/wasm/mono-wasm-0beb0875670.zip' -o "mono-wasm.zip" -#
	unzip mono-wasm.zip -d $(TOP)/sdks
	touch $@

.PHONY: wasmbcl
wasmbcl: .stamp-wasm-bcl


build: wasmbcl

clean:
	
