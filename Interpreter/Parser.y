﻿%output=Generated/Parser.cs
%namespace Interpreter

%union {
    public string Value;
    public Expression Expression;
    public PrgmExpression PrgmExpression;
    public DeclareExpression DeclareExpression;
    public FormalListExpression FormalListExpression;
    public StatementListExpression StatementListExpression;
    public ElseExpression ElseExpression;
    public ExpressionList ExpressionList;
}


%token <Value> ID
%token <Value> NUM
%token INT "int"
%token BOOL "bool"
%token TRUE "true"
%token FALSE "false"
%token VOID "void"
%token COMMA ","
%token SEMIC ";"
%token ASN "="
%token LPAR "("
%token RPAR ")"
%token LCUR "{"
%token RCUR "}"
%token ADD "+"
%token SUB "-"
%token MUL "*"
%token DIV "/"
%token OR "||"
%token AND "&&"
%token TESTEQ "=="
%token NOTEQ "!="
%token SUP ">"
%token SUPEQ ">="
%token INF "<"
%token INFEQ "<="

%token NOT "!"

%token IF "if"
%token ELSE "else"
%token WHILE "while"
%token RETURN "return"

%token LEXERR 
%start P

%type <PrgmExpression> Prgm, P
%type <DeclareExpression> Decl
%type <FormalListExpression> FormalList, FL2
%type <StatementListExpression> StmtList
%type <Expression> Stmt, Expr, S2, E2, E3, E4, E1, E2bis
%type <ElseExpression> ElseStmt
%type <ExpressionList> ExprList, EL2

%%
    
P: Prgm EOF                                                               { $$ = new PrgmExpression(); Program = $1;$$.SetLocation(@$);}
    ;

Prgm : Prgm Decl                                                          { $$ = new PrgmExpression($1,$2);$$.SetLocation(@$);}
    |
    ;

Decl : INT ID "(" FormalList ")" "{" StmtList "}"                         { $$ = new DeclareExpression(Types.integer,$2,$4,$7);$$.SetLocation(@$);}
    | BOOL ID "(" FormalList ")" "{" StmtList "}"                         { $$ = new DeclareExpression(Types.boolean,$2,$4,$7);$$.SetLocation(@$);}
    | VOID ID "(" FormalList ")" "{" StmtList "}"                         { $$ = new DeclareExpression(Types.voidT,$2,$4,$7);$$.SetLocation(@$);}
    ;


FormalList : INT ID FL2                                                  { $$ = new FormalListExpression(Types.integer,$2,$3);$$.SetLocation(@$);}
    | BOOL ID FL2                                                        { $$ = new FormalListExpression(Types.boolean,$2,$3);$$.SetLocation(@$);}
    | 
    ;

FL2 : FL2 "," INT ID                                                     { $$ = new FormalListExpression(Types.integer,$4,$1);$$.SetLocation(@$);}
    | FL2 "," BOOL ID                                                    { $$ = new FormalListExpression(Types.integer,$4,$1);$$.SetLocation(@$);}
    |
    ;

StmtList : StmtList Stmt                                                 { $$ = new StatementListExpression($1,$2);$$.SetLocation(@$);}
    |
    ;



ElseStmt : ELSE Stmt                                        { $$ = new ElseExpression($2);$$.SetLocation(@$);}
    ;

Stmt : IF "(" Expr ")" S2 ElseStmt                          { $$ = new IfElseExpression($3,$5,$6);$$.SetLocation(@$);}
    | S2
    ;


S2 : IF "(" Expr ")" S2                                     { $$ = new IfElseExpression($3,$5,null);$$.SetLocation(@$);}
    | WHILE "(" Expr ")" S2                               { $$ = new WhileExpression($3,$5);$$.SetLocation(@$);}
    | RETURN Expr ";"                                                   { $$ = new ReturnExpression($2);$$.SetLocation(@$);}
    | RETURN ";"                                                        { $$ = new ReturnExpression(null);$$.SetLocation(@$);}
    | Expr ";"                                                          { $$ = $1;}
    | INT ID ";"                                                        { $$ = new VariableExpression(Types.integer, $2);$$.SetLocation(@$);}
    | BOOL ID ";"                                                       { $$ = new VariableExpression(Types.boolean, $2);$$.SetLocation(@$);}
    | "{" StmtList "}"                                                  { $$ = new StatementListExpression($2);$$.SetLocation(@$);}
    ;

Expr : Expr "=" E2bis                                                      { $$ = new BinaryOperatorsExpression($1,BinaryOperators.Asn, $3);$$.SetLocation(@$);}
    | E2bis
    ;
         
E1 : E1 "+" E2                                                          { $$ = new BinaryOperatorsExpression($1,BinaryOperators.Add, $3);$$.SetLocation(@$);}
    | E1 "-" E2                                                         { $$ = new BinaryOperatorsExpression($1,BinaryOperators.Sub, $3);$$.SetLocation(@$);}
    | E2                                                                { $$ = $1;}
    ;

E2 : E2 "*" E4                                                          { $$ = new BinaryOperatorsExpression($1,BinaryOperators.Mul, $3);$$.SetLocation(@$);}
    | E2 "/" E4                                                         { $$ = new BinaryOperatorsExpression($1,BinaryOperators.Div, $3);$$.SetLocation(@$);}
    | E4                                                                { $$ = $1;}
    ;

E2bis : E2bis "||" E3                                                   { $$ = new BinaryOperatorsExpression($1,BinaryOperators.Or, $3);$$.SetLocation(@$);}
    | E2bis "&&" E3                                                     { $$ = new BinaryOperatorsExpression($1,BinaryOperators.And, $3);$$.SetLocation(@$);}
    | E3
    ;

E3  : E3 "==" E1                                                        { $$ = new BinaryOperatorsExpression($1,BinaryOperators.TestEq, $3);$$.SetLocation(@$);}
    | E3 "!=" E1                                                        { $$ = new BinaryOperatorsExpression($1,BinaryOperators.NotEq, $3);$$.SetLocation(@$);}
    | E3 ">" E1                                                         { $$ = new BinaryOperatorsExpression($1,BinaryOperators.Sup, $3);$$.SetLocation(@$);}
    | E3 ">=" E1                                                        { $$ = new BinaryOperatorsExpression($1,BinaryOperators.SupEq, $3);$$.SetLocation(@$);}
    | E3 "<" E1                                                         { $$ = new BinaryOperatorsExpression($1,BinaryOperators.Inf, $3);$$.SetLocation(@$);}
    | E3 "<=" E1                                                        { $$ = new BinaryOperatorsExpression($1,BinaryOperators.InfEq, $3);$$.SetLocation(@$);}
    | E1                                                                { $$ = $1;}
    ;

E4 : NUM                                                                { $$ = new NumberExpression($1);$$.SetLocation(@$);}
    | ID                                                                { $$ = new IdentifierExpression($1);$$.SetLocation(@$);}
    | TRUE                                                              { $$ = new BooleanExpression(Boolean.trueE);$$.SetLocation(@$);}
    | FALSE                                                             { $$ = new BooleanExpression(Boolean.falseE);$$.SetLocation(@$);}
    | NOT E4                                                            { $$ = new UOPExpression(UOP.Not, $2);$$.SetLocation(@$);}
    | SUB E4                                                            { $$ = new UOPExpression(UOP.Negative, $2);$$.SetLocation(@$);}
    | ID "(" ExprList ")"                                               { $$ = new NamedExpressionList($1,$3);$$.SetLocation(@$);}
    | "(" Expr ")"                                                        { $$ = $2;}
    ;

ExprList : Expr EL2                                                     { $$ = new ExpressionList($2,$1);$$.SetLocation(@$);}
    |
    ;

EL2 : "," ExprList                                                      { $$ = $2;}
    |
    ;


%%

public Parser( Scanner s ) : base( s ) { }
public Expression Program;