# Development & build dependencies
Agiil is a .NET Framework web application which includes usage of **Java** and **node/npm** in its build process.

## Build dependencies
In order to build Agiil from source, the following must be available in your development/build environment. *These tools and frameworks must be available from your `PATH`*.

* A **.NET Framework SDK** capable of building .NET Framework 4.7.2 applications written with C# v6
    * Mono SDK v5.10.1 is tested, other versions may also work
* **[NuGet] package manager**
    * Version 4.4 is tested, other versions might also work
* **[Node JS]** (includes the npm package manager)
    * Version 10 of Node JS is tested, other versions might also work
    * It is recommanded to use the latest version of npm
* **Java JDK** & runtime
    * [OpenJDK 12] is tested, other versions might also work
    * [In 2019, Oracle changed the licensing model for Java] which means that the OpenJDK is now the preferred choice
    
[NuGet]: https://www.nuget.org/downloads
[Node JS]: https://nodejs.org/en/download/
[OpenJDK 12]: https://jdk.java.net/
[In 2019, Oracle changed the licensing model for Java]: https://www.oracle.com/technetwork/java/javase/overview/faqs-jsp-136696.html

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
