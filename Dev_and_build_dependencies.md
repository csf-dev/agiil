# Development & build dependencies
Agiil is a .NET Framework web application which includes usage of **Java** and **node/npm** in its build process.

## Build dependencies
In order to build Agiil from source, the following must be available in your development/build environment. *These tools and frameworks must be available from your `PATH`*.

* A .NET Framework SDK capable of building .NET Framework 4.7.2 applications written with C# v6
    * Mono SDK v5.10.1 is tested, other versions may also work
* NuGet package manager
    * Version 4.4 is tested, other versions might also work
* Node JS
    * Version 10 is tested, other versions might also work
* npm package manager
    * The latest version is recommended
* Java JDK & runtime
    * OpenJDK 12 is tested, other versions might also work

## Build process
Building Agiil is performed from **msbuild**. A number of build configurations are supported:

```
msbuild /p:Configuration=Debug
msbuild /p:Configuration=Testing
msbuild /p:Configuration=Release
```

* Debug builds are for internal development
* Testing builds are for ruining browser-based acceptance tests
* Release builds are for releases to production