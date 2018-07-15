# Agiil.QueryLanguage.Antlr
The Agiil project uses **[ANTLR]** to create a parser for its query syntax. ANTLR
uses [a Java tool] to read **grammar files**: `*.g4` and from those it generates
code in other languages, such as C# or ECMAScript.

[Antlr]: http://www.antlr.org/
[a Java tool]: https://github.com/antlr/antlr4/blob/master/doc/getting-started.md

## What this project contains
* The ANTLR grammar file for the Agiil query syntax: `AgiilQuery.g4`
* A copy of the ANTLR tool Java executable `lib\antlr-4.7.1-complete.jar`
* Convenience scripts for running the ANTLR tool on Linux and Windows, in the directory `Tools\`
    * **antlr4** - the main ANTRL code geneation tool
    * **grun** - the ANTLR testing & diagnostics suite (for Java parsers)
    * **compile-java** - invokes the Java compiler to transform generated code to executable Java
* An msbuild *targets file* integrating code generation into the build process: `BuildAntlrGrammar.targets`

The msbuild targets file contains targets which generate parsers for:
* C#
* JavaScript
* Java

The Java generation target exists only for debugging purposes, using the **grun**
tool, it is skipped in `RELEASE` builds.  You may find this helpful when developing
the grammar, as the grun utility provides immediate feedback about how an input has
been tokenized and parsed.

## Generated code
The `generated_code` directory is the output directory for the generation & build process.
There is nothing developer-editable in here, it is all created automatically by the ANTLR
tool and the grammar file.