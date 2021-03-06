grammar AgiilQuery;

/*
 * Parser rules
 */
search                    : BOM? criteria? orders? EOF;

criteria                  : logicalcriteriagroups;

logicalcriteriagroups     : criterionorgroup (logicaloperator? criterionorgroup)*;

criterionorgroup          : (criterion | criteriagroup);

criteriagroup             : OPENPAREN logicalcriteriagroups CLOSEPAREN;

criterion                 : element elementtest;

elementtest               : ((predicate value) | (NOT? functioninvocation));

logicaloperator           : (AND | OR);

element                   : NAME;

predicate                 : NOT? predicatename;

predicatename             : (EQUALS | NOTEQUALS | TILDE | NAME | comparison);

comparison                : (GREATERTHAN | LESSTHAN | GREATERTHANOREQUAL | LESSTHANOREQUAL);

value                     : (constantvalue | functioninvocation);

constantvalue             : (NAME | NOT | AND | OR | WORD+ | DESCENDING | ASCENDING | QUOTEDVALUE);

functioninvocation        : NAME OPENPAREN functionparameters CLOSEPAREN;

functionparameters        : (value (COMMA value)*)?;

orders                    : ORDERBY orderelement (COMMA orderelement)*;

orderelement              : (NAME | functioninvocation) (ASCENDING | DESCENDING)?;

/*
 * Lexer rules
 */
fragment A                : ('a'|'A');
fragment B                : ('b'|'B');
fragment C                : ('c'|'C');
fragment D                : ('d'|'D');
fragment E                : ('e'|'E');
fragment G                : ('g'|'G');
fragment H                : ('h'|'H');
fragment I                : ('i'|'I');
fragment K                : ('k'|'K');
fragment L                : ('l'|'L');
fragment N                : ('n'|'N');
fragment O                : ('o'|'O');
fragment R                : ('r'|'R');
fragment S                : ('s'|'S');
fragment T                : ('t'|'T');
fragment Y                : ('y'|'Y');
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
DOUBLEQUOTE               : '"';
GREATERTHAN               : '>';
LESSTHAN                  : '<';
GREATERTHANOREQUAL        : '>=';
LESSTHANOREQUAL           : '<=';
WHITESPACE                : (' '|'\t'|'\r\n'|'\n') -> skip;
NOT                       : N O T;
AND                       : A N D;
OR                        : O R;
ORDERBY                   : O R D E R ' ' B Y;
DESCENDING                : D E S C (E N D I N G)?;
ASCENDING                 : A S C (E N D I N G)?;
NAME                      : (UPPERCASE | LOWERCASE | '_') (UPPERCASE | LOWERCASE | '_' | DIGIT)+;
WORD                      : ~[()=!~, \t\r\n];
QUOTEDVALUE               : '"' (~[\\"] | '\\' [\\"])* '"';
ANY                       : .;
