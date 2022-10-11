%namespace Interpreter
%using QUT.Gppg;
%option out:Generated/Lexer.cs

alpha [a-zA-Z]
digit [0-9]
alphanum {alpha}|{digit}

%%

" "|\n|\r		{}
"//".*$			{}

"void"			{return (int) Tokens.VOID;}
","				{return (int) Tokens.COMMA;}
";"				{return (int) Tokens.SEMIC;}
"="				{return (int) Tokens.ASN;}
"("				{return (int) Tokens.LPAR;}
")"				{return (int) Tokens.RPAR;}
"{"				{return (int) Tokens.LCUR;}
"}"				{return (int) Tokens.RCUR;}
"+"				{return (int) Tokens.ADD;}
"-"				{return (int) Tokens.SUB;}
"*"				{return (int) Tokens.MUL;}
"/"				{return (int) Tokens.DIV;}
"||"			{return (int) Tokens.OR;}
"&&"			{return (int) Tokens.AND;}
"=="			{return (int) Tokens.TESTEQ;}
"!="			{return (int) Tokens.NOTEQ;}
">"				{return (int) Tokens.SUP;}
">="			{return (int) Tokens.SUPEQ;}
"<"				{return (int) Tokens.INF;}
"<="			{return (int) Tokens.INFEQ;}
"!"				{return (int) Tokens.NOT;}
"if"			{return (int) Tokens.IF;}
"else"			{return (int) Tokens.ELSE;}
"while"			{return (int) Tokens.WHILE;}
"return"		{return (int) Tokens.RETURN;}
"int"			{return (int) Tokens.INT;}
"bool"			{return (int) Tokens.BOOL;}
"true"			{return (int) Tokens.TRUE;}
"false"			{return (int) Tokens.FALSE;}

{digit}+		{
	yylval.Value = yytext;
	return (int) Tokens.NUM;
}

{alpha}{alphanum}*		{
	yylval.Value = yytext;
	return (int) Tokens.ID;
}

. {
	yylval.Value = yytext;
	return (int) Tokens.LEXERR;
}

%{
	yylloc = new LexLocation(tokLin, tokCol, tokELin, tokECol);
%}

%%

override public void yyerror(string msg, object[] args){
	Console.WriteLine("{0} on line {1} column {2}", msg, yylloc.StartLine, yylloc.StartColumn);
}