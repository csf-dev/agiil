grammar AgiilQuery;

/*
 * Parser rules
 */
criteria                  : BOM? logicalcriteriagroups? EOF;

logicalcriteriagroups     : criterionorgroup (logicalcombination? criterionorgroup)*;

criterionorgroup          : (criterion | criteriagroup);

criteriagroup             : OPENPAREN logicalcriteriagroups CLOSEPAREN;

criterion                 : element elementtest;

elementtest               : ((predicate value) | (NOT? functioninvocation));

logicalcombination        : (AND | OR);

element                   : NAME;

predicate                 : NOT? predicatename;

predicatename             : (EQUALS | NOTEQUALS | TILDE | NAME);

value                     : (constantvalue | functioninvocation);

constantvalue             : (NAME | NOT | AND | OR | WORD+ | QUOTEDVALUE);

functioninvocation        : NAME OPENPAREN functionparameters CLOSEPAREN;

functionparameters        : (value (COMMA value)*)?;

/*
 * Lexer rules
 */
fragment A                : ('a'|'A');
fragment D                : ('d'|'D');
fragment E                : ('e'|'E');
fragment H                : ('h'|'H');
fragment I                : ('i'|'I');
fragment K                : ('k'|'K');
fragment L                : ('l'|'L');
fragment N                : ('n'|'N');
fragment O                : ('o'|'O');
fragment R                : ('r'|'R');
fragment S                : ('s'|'S');
fragment T                : ('t'|'T');
fragment UPPERCASE        : [A-Z];
fragment LOWERCASE        : [a-z];
fragment DIGIT            : [0-9];

/* The byte order marker might appear at the beginning of a file */
BOM                       : '\uFEFF';
OPENPAREN                 : '(';
CLOSEPAREN                : ')';
EQUALS                    : '=';
NOTEQUALS                 : '!=';
TILDE                     : '~';
COMMA                     : ',';
WHITESPACE                : (' '|'\t'|'\r\n'|'\n') -> skip;
NOT                       : N O T;
AND                       : A N D;
OR                        : O R;
NAME                      : (UPPERCASE | LOWERCASE | '_') (UPPERCASE | LOWERCASE | '_' | DIGIT)+;
WORD                      : ~[()=!~, \t\r\n];
QUOTEDVALUE               : '"' (~[\\"] | '\\' [\\"])* '"';
ANY                       : .;
