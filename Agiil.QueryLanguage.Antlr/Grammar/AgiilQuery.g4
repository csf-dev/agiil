grammar AgiilQuery;

/*
 * Parser rules
 */
criteria                  : (criterion (WHITESPACE+ (logicalcombination WHITESPACE+)? criterion)*)? EOF;

criterion                 : ((element WHITESPACE+ predicate WHITESPACE+ value)
                             | (element WHITESPACE+ predicatefunction));

logicalcombination        : (AND | OR);

element                   : NAME;

predicate                 : (NOT WHITESPACE+)? predicatename;

predicatename             : (EQUALS | NOTEQUALS | TILDE | NAME);

value                     : (CONSTANTVALUE | quotedvalue | valuefunction);

quotedvalue               : DOUBLEQUOTE QUOTEDCONSTANTVALUE DOUBLEQUOTE;

predicatefunction         : functioninvocation;

valuefunction             : functioninvocation;

functioninvocation        : NAME WHITESPACE* OPENPAREN functionparameter* CLOSEPAREN;

functionparameter         : value;

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
fragment WORD             : (UPPERCASE | LOWERCASE | '_')+;

EQUALS                    : '=';
NOTEQUALS                 : '!=';
TILDE                     : '~';
OPENPAREN                 : '(';
CLOSEPAREN                : ')';
DOUBLEQUOTE               : '"';
WHITESPACE                : (' '|'\t'|'\r\n'|'\n');
NOT                       : N O T;
AND                       : A N D;
OR                        : O R;
NAME                      : (UPPERCASE | LOWERCASE) (WORD | DIGIT)+;
CONSTANTVALUE             : (WORD | DIGIT)+;
QUOTEDCONSTANTVALUE       : [^"]*;
