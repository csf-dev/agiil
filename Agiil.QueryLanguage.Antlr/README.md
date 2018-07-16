# Agiil.QueryLanguage.Antlr
The Agiil project uses **[ANTLR]** to create a parser for its query syntax. ANTLR
uses [a Java tool] to read **grammar files**: `*.g4` and from those it generates
code in other languages, such as C# or ECMAScript.

*All code in the **Generated_XXX** directories is automatically generated* by the
ANTLR tool.  None of thair contents are intended to be edited by developers and
*any changes will be lost* when the tool is run (during the build process).

[Antlr]: http://www.antlr.org/
[a Java tool]: https://github.com/antlr/antlr4/blob/master/doc/getting-started.md

## What this project contains
* The ANTLR grammar file for the Agiil query syntax: `AgiilQuery.g4`
    * This is the source file for all of the code generation
* A copy of the ANTLR tool Java executable `lib\antlr-4.7.1-complete.jar`
* Convenience scripts for running the ANTLR tool on Linux and Windows, in the directory `Tools\`
    * **antlr4** - the main ANTRL code geneation tool
    * **grun** - the ANTLR testing & diagnostics suite (for Java parsers)
    * **compile-java** - invokes the Java compiler to transform generated code to executable Java
* An msbuild *targets file* integrating code generation into the build process: `Tools\BuildAntlrGrammar.targets`
* Various directories named `Generated_XXX`.  These are the output directories for the ANTLR code generation.

The msbuild targets file contains targets which generate parsers for:
* C#
* JavaScript
* Java

The Java generation target exists only for debugging purposes, using the **grun**
tool, it is skipped in `RELEASE` builds.  You may find the generated Java helpful when
developing the grammar, as the grun utility provides immediate feedback about how an
input has been tokenized and parsed.
