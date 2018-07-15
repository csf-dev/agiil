grammar AgiilQuery;

/*
 * Parser rules
 */
criteria                  : (criterion (logicalcombination? criterion)*)? WHITESPACE* EOF;

criterion                 : element elementtest;

elementtest               : ((predicate value) | (NOT? functioninvocation));

logicalcombination        : (AND | OR);

element                   : NAME;

predicate                 : NOT? predicatename;

predicatename             : (EQUALS | NOTEQUALS | TILDE | NAME);

value                     : (constantvalue | functioninvocation);

constantvalue             : (NAME | (WORD | DIGITS)+ | QUOTEDVALUE);

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
WORD                      : (UPPERCASE | LOWERCASE | '_')+;
DIGITS                    : DIGIT+;
QUOTEDVALUE               : '"' (~[\\"] | '\\' [\\"])* '"';
ANY                       : .;
