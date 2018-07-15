# Agiil.QueryLanguage.Antlr
The Agiil project uses **[ANTLR]** to create a parser for its query syntax. ANTLR uses [a Java tool] to read a number of **grammar files**: `*.g4` and from those it generates code in other languages, such as C# or ECMAScript.

[Antlr]: http://www.antlr.org/
[a Java tool]: https://github.com/antlr/antlr4/blob/master/doc/getting-started.md

## What this project contains
* The ANTLR grammar files for the Agiil query syntax, in the directory `Grammar\`
* A copy of the ANTLR tool Java executable `lib\antlr-4.7.1-complete.jar`
* Convenience scripts for running the ANTLR tool on Linux and Windows, in the directory `Tools\`
    * **antlr4** - the main ANTRL code geneation tool
    * **grun** - the ANTLR testing & diagnostics suite