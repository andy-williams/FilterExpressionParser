
grammar FilterExpressionDsl;

/* 
PARSER RULES
 */

expr: expr booleanOperator expr
    | OpenParen expr CloseParen 
    | operand operator operand;

booleanOperator: (And | Or);
operator: (GreaterThan | GreaterThanEqual | LessThan | LessThanEqual | Equal);
operand: (STRING | NUMBER | VARIABLE);

/*
LEXER RULES
 */

// operators 
GreaterThan: '>';
GreaterThanEqual: '>=';
LessThan: '<'; 
LessThanEqual: '<=';
Equal: '=';
Or: 'or' | 'OR';
And: 'and' | 'AND'; 
IN: 'in';

OpenParen: '(';
CloseParen: ')'; 

// operands
VARIABLE: ':'[a-zA-Z]+':' ;
NUMBER: [0-9]+;
STRING: '\''[a-zA-Z]+'\'' ;

WHITESPACE: [ \t\f\r\n]+ -> channel(HIDDEN) ; // skip whitespaces 