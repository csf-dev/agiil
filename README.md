# The Agiil issue tracker
An issue tracker for agile software development.  It is currently in the **very early stages of development** and is *not recommended for any kind of production usage*.

## Dependency projects
At this point in time, Agiil is being used as a sort-of 'canary' project for some other software projects.  Thus, development on Agiil may often be blocked by issues with those dependencies:

* [ZPT-Sharp](https://github.com/csf-dev/ZPT-Sharp)
* [CSF.Screenplay](https://github.com/csf-dev/CSF.Screenplay)

## Building from source
If you wish to contribute or evaluate Agiil, please see the [documentation about building Agiil from source](BUILDING.md).

## Continuous integration builds
CI builds are configured via both Travis (for build & test on Linux/Mono) and AppVeyor (Windows/.NET).
Below are links to the most recent build statuses for these two CI platforms.

Platform | Status
-------- | ------
Linux/Mono (Travis) | [![Travis Status](https://travis-ci.org/csf-dev/agiil.svg?branch=master)](https://travis-ci.org/csf-dev/agiil)
Windows/.NET (AppVeyor) | [![AppVeyor status](https://ci.appveyor.com/api/projects/status/rg6mnp8sephi5equ?svg=true)](https://ci.appveyor.com/project/craigfowler/agiil)
