# Building Agiil
This document contains information related to building Agiil from source.

## Build dependencies
These pieces of software are required in order to build Agiil.  They must be installed (at the minimum stated versions), before attempting to build:

* .NET framework v4.5
* msbuild
* NuGet v4.4.1.4656
* NodeJs v10.0.0 (including npm)

### Why Node 10?
I elected not to use a LTS version of Node at this time.  That is because I expect Agiil's development time to exceed the period of support offered by the current LTS release (v8.x).  At a later date, soon before Agiil is preparing for its first production release, I will revisit this decision with whatever versions of Node/npm are current at the time, and draw up an upgrade plan (as well as reconsider my minimum version support).