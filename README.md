# libstorj.NET
[![Storj.io](https://storj.io/img/storj-badge.svg)](https://storj.io)

**A .Net/C#-wrapper for Storj**

This library enables you to connect to the storj-network to upload and retrieve files to the distributed and secure cloud-storage. It is based on the [java-libstorj-binding](https://github.com/Storj/java-libstorj) and has the same feature-set. The JAR of the java-binding was converted via [IKVM.Net](https://www.ikvm.net/) and therefore has some restrictions. It currently does not work from UWP and it might be sligthly slower than other wrappers as it involves the Java Virtual Machine provided by IKVM. And during runtime there are many DLL-files needed (which are all included in this wrapper, though). Furthermore, there is only an x64-bit-version available.

But beside that it is the very first fully working .Net-Wrapper for Storj! Yay!

## Available Functions

* List Buckets
* List Files
* Upload / Download Files
* Delete Files
* Register new user
* Various helper methods (GetTimestamp, GenerateMnemonic and others)

All Methods use the async/await-pattern.

## Usage

A nuget-package is currently in the works. Until this is finished, get the latest release and add the included DLLs within your project. Set those DLL's to "Copy if newer", so they get copied to the output directory. Add the following DLL's as assembly-references to your project:

* LibStorj.Wrapper.Contracts.dll
* LibStorj.Wrapper.x64.dll

Be sure that you build your project for x64.

Create a storj-object:

```csharp
 LibStorj.Wrapper.x64.Storj storj = new  LibStorj.Wrapper.x64.Storj();
```
 
 Have fun! More info on how to use it will be found in the wiki, soon.
 
 ## Build
 
 Simply open the solution in Visual Studio 2017 and hit F5. All dependencies are included or should download automatically. If you want to build the IKVM-wrapper-DLL on your own, follow these steps:
 * Download and install [IKVM.Net](https://www.ikvm.net/)
 * Download the JAR-file from the java-libstorj-release you are interested in
 * open a command-prompt and type `ikvmc YOURJAR.jar -platform:x64`
 * include the resulting DLL in your project and build. Don't forget to also update the java-storj.dll
 
 ## IKVM.Net
 
Unfortunately, [IKVM.Net is not supported anymore](http://weblog.ikvm.net/). The [sourceforge-repo](https://sourceforge.net/projects/ikvm/files/) is still available, so if there are any issues, you might help yourself there. If someone is capable of doing a total P/Invoke-library based on the original libstorj.dll, then we could leave the java-binding and IKVM aside. I did not get very far as my understanding of C/C++, structs, marshalling and such did not help. Nevertheless, this should be possible and I would be happy to get my IKVM-based wrapper replaced by that. If you want to try it out, it would be great if you could use the Storj-interface-file provided in the DLL LibStorj.Wrapper.Contracts. Your implementation could the be used by all projects that are or will use my libstorj.NET-wrapper without big changes.
