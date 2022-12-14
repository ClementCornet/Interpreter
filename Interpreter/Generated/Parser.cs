// This code was generated by the Gardens Point Parser Generator
// Copyright (c) Wayne Kelly, John Gough, QUT 2005-2014
// (see accompanying GPPGcopyright.rtf)

// GPPG version 1.5.2
// Machine:  LAPTOP-KT7GVI77
// DateTime: 14/02/2022 11:08:12
// UserName: cleme
// Input file <.\Parser.y - 14/02/2022 11:06:35>

// options: lines gplex

using System;
using System.Collections.Generic;
using System.CodeDom.Compiler;
using System.Globalization;
using System.Text;
using QUT.Gppg;

namespace Interpreter
{
public enum Tokens {error=2,EOF=3,ID=4,NUM=5,INT=6,
    BOOL=7,TRUE=8,FALSE=9,VOID=10,COMMA=11,SEMIC=12,
    ASN=13,LPAR=14,RPAR=15,LCUR=16,RCUR=17,ADD=18,
    SUB=19,MUL=20,DIV=21,OR=22,AND=23,TESTEQ=24,
    NOTEQ=25,SUP=26,SUPEQ=27,INF=28,INFEQ=29,NOT=30,
    IF=31,ELSE=32,WHILE=33,RETURN=34,LEXERR=35};

public struct ValueType
#line 4 ".\Parser.y"
       {
    public string Value;
    public Expression Expression;
    public PrgmExpression PrgmExpression;
    public DeclareExpression DeclareExpression;
    public FormalListExpression FormalListExpression;
    public StatementListExpression StatementListExpression;
    public ElseExpression ElseExpression;
    public ExpressionList ExpressionList;
}
#line default
// Abstract base class for GPLEX scanners
[GeneratedCodeAttribute( "Gardens Point Parser Generator", "1.5.2")]
public abstract class ScanBase : AbstractScanner<ValueType,LexLocation> {
  private LexLocation __yylloc = new LexLocation();
  public override LexLocation yylloc { get { return __yylloc; } set { __yylloc = value; } }
  protected virtual bool yywrap() { return true; }
}

// Utility class for encapsulating token information
[GeneratedCodeAttribute( "Gardens Point Parser Generator", "1.5.2")]
public class ScanObj {
  public int token;
  public ValueType yylval;
  public LexLocation yylloc;
  public ScanObj( int t, ValueType val, LexLocation loc ) {
    this.token = t; this.yylval = val; this.yylloc = loc;
  }
}

[GeneratedCodeAttribute( "Gardens Point Parser Generator", "1.5.2")]
public class Parser: ShiftReduceParser<ValueType, LexLocation>
{
#pragma warning disable 649
  private static Dictionary<int, string> aliases;
#pragma warning restore 649
  private static Rule[] rules = new Rule[57];
  private static State[] states = new State[125];
  private static string[] nonTerms = new string[] {
      "P", "Prgm", "Decl", "FormalList", "FL2", "StmtList", "Stmt", "Expr", "S2", 
      "E2", "E3", "E4", "E1", "E2bis", "ElseStmt", "ExprList", "EL2", "$accept", 
      };

  static Parser() {
    states[0] = new State(-4,new int[]{-1,1,-2,3});
    states[1] = new State(new int[]{3,2});
    states[2] = new State(-1);
    states[3] = new State(new int[]{3,4,6,6,7,109,10,117},new int[]{-3,5});
    states[4] = new State(-2);
    states[5] = new State(-3);
    states[6] = new State(new int[]{4,7});
    states[7] = new State(new int[]{14,8});
    states[8] = new State(new int[]{6,98,7,106,15,-10},new int[]{-4,9});
    states[9] = new State(new int[]{15,10});
    states[10] = new State(new int[]{16,11});
    states[11] = new State(-15,new int[]{-6,12});
    states[12] = new State(new int[]{17,13,31,15,33,24,34,34,5,47,4,48,8,65,9,66,30,67,19,69,14,71,6,89,7,92,16,95},new int[]{-7,14,-9,23,-8,87,-14,56,-11,74,-13,85,-10,77,-12,78});
    states[13] = new State(-5);
    states[14] = new State(-14);
    states[15] = new State(new int[]{14,16});
    states[16] = new State(new int[]{5,47,4,48,8,65,9,66,30,67,19,69,14,71},new int[]{-8,17,-14,56,-11,74,-13,85,-10,77,-12,78});
    states[17] = new State(new int[]{15,18,13,37});
    states[18] = new State(new int[]{31,29,33,24,34,34,5,47,4,48,8,65,9,66,30,67,19,69,14,71,6,89,7,92,16,95},new int[]{-9,19,-8,87,-14,56,-11,74,-13,85,-10,77,-12,78});
    states[19] = new State(new int[]{32,21,17,-19,31,-19,33,-19,34,-19,5,-19,4,-19,8,-19,9,-19,30,-19,19,-19,14,-19,6,-19,7,-19,16,-19},new int[]{-15,20});
    states[20] = new State(-17);
    states[21] = new State(new int[]{31,15,33,24,34,34,5,47,4,48,8,65,9,66,30,67,19,69,14,71,6,89,7,92,16,95},new int[]{-7,22,-9,23,-8,87,-14,56,-11,74,-13,85,-10,77,-12,78});
    states[22] = new State(-16);
    states[23] = new State(-18);
    states[24] = new State(new int[]{14,25});
    states[25] = new State(new int[]{5,47,4,48,8,65,9,66,30,67,19,69,14,71},new int[]{-8,26,-14,56,-11,74,-13,85,-10,77,-12,78});
    states[26] = new State(new int[]{15,27,13,37});
    states[27] = new State(new int[]{31,29,33,24,34,34,5,47,4,48,8,65,9,66,30,67,19,69,14,71,6,89,7,92,16,95},new int[]{-9,28,-8,87,-14,56,-11,74,-13,85,-10,77,-12,78});
    states[28] = new State(-20);
    states[29] = new State(new int[]{14,30});
    states[30] = new State(new int[]{5,47,4,48,8,65,9,66,30,67,19,69,14,71},new int[]{-8,31,-14,56,-11,74,-13,85,-10,77,-12,78});
    states[31] = new State(new int[]{15,32,13,37});
    states[32] = new State(new int[]{31,29,33,24,34,34,5,47,4,48,8,65,9,66,30,67,19,69,14,71,6,89,7,92,16,95},new int[]{-9,33,-8,87,-14,56,-11,74,-13,85,-10,77,-12,78});
    states[33] = new State(-19);
    states[34] = new State(new int[]{12,86,5,47,4,48,8,65,9,66,30,67,19,69,14,71},new int[]{-8,35,-14,56,-11,74,-13,85,-10,77,-12,78});
    states[35] = new State(new int[]{12,36,13,37});
    states[36] = new State(-21);
    states[37] = new State(new int[]{5,47,4,48,8,65,9,66,30,67,19,69,14,71},new int[]{-14,38,-11,74,-13,85,-10,77,-12,78});
    states[38] = new State(new int[]{22,39,23,57,12,-27,13,-27,15,-27,11,-27});
    states[39] = new State(new int[]{5,47,4,48,8,65,9,66,30,67,19,69,14,71},new int[]{-11,40,-13,85,-10,77,-12,78});
    states[40] = new State(new int[]{24,41,25,59,26,75,27,79,28,81,29,83,22,-35,23,-35,12,-35,13,-35,15,-35,11,-35});
    states[41] = new State(new int[]{5,47,4,48,8,65,9,66,30,67,19,69,14,71},new int[]{-13,42,-10,77,-12,78});
    states[42] = new State(new int[]{18,43,19,61,24,-38,25,-38,26,-38,27,-38,28,-38,29,-38,22,-38,23,-38,12,-38,13,-38,15,-38,11,-38});
    states[43] = new State(new int[]{5,47,4,48,8,65,9,66,30,67,19,69,14,71},new int[]{-10,44,-12,78});
    states[44] = new State(new int[]{20,45,21,63,18,-29,19,-29,24,-29,25,-29,26,-29,27,-29,28,-29,29,-29,22,-29,23,-29,12,-29,13,-29,15,-29,11,-29});
    states[45] = new State(new int[]{5,47,4,48,8,65,9,66,30,67,19,69,14,71},new int[]{-12,46});
    states[46] = new State(-32);
    states[47] = new State(-45);
    states[48] = new State(new int[]{14,49,20,-46,21,-46,18,-46,19,-46,24,-46,25,-46,26,-46,27,-46,28,-46,29,-46,22,-46,23,-46,12,-46,13,-46,15,-46,11,-46});
    states[49] = new State(new int[]{5,47,4,48,8,65,9,66,30,67,19,69,14,71,15,-54},new int[]{-16,50,-8,52,-14,56,-11,74,-13,85,-10,77,-12,78});
    states[50] = new State(new int[]{15,51});
    states[51] = new State(-51);
    states[52] = new State(new int[]{13,37,11,54,15,-56},new int[]{-17,53});
    states[53] = new State(-53);
    states[54] = new State(new int[]{5,47,4,48,8,65,9,66,30,67,19,69,14,71,15,-54},new int[]{-16,55,-8,52,-14,56,-11,74,-13,85,-10,77,-12,78});
    states[55] = new State(-55);
    states[56] = new State(new int[]{22,39,23,57,12,-28,13,-28,15,-28,11,-28});
    states[57] = new State(new int[]{5,47,4,48,8,65,9,66,30,67,19,69,14,71},new int[]{-11,58,-13,85,-10,77,-12,78});
    states[58] = new State(new int[]{24,41,25,59,26,75,27,79,28,81,29,83,22,-36,23,-36,12,-36,13,-36,15,-36,11,-36});
    states[59] = new State(new int[]{5,47,4,48,8,65,9,66,30,67,19,69,14,71},new int[]{-13,60,-10,77,-12,78});
    states[60] = new State(new int[]{18,43,19,61,24,-39,25,-39,26,-39,27,-39,28,-39,29,-39,22,-39,23,-39,12,-39,13,-39,15,-39,11,-39});
    states[61] = new State(new int[]{5,47,4,48,8,65,9,66,30,67,19,69,14,71},new int[]{-10,62,-12,78});
    states[62] = new State(new int[]{20,45,21,63,18,-30,19,-30,24,-30,25,-30,26,-30,27,-30,28,-30,29,-30,22,-30,23,-30,12,-30,13,-30,15,-30,11,-30});
    states[63] = new State(new int[]{5,47,4,48,8,65,9,66,30,67,19,69,14,71},new int[]{-12,64});
    states[64] = new State(-33);
    states[65] = new State(-47);
    states[66] = new State(-48);
    states[67] = new State(new int[]{5,47,4,48,8,65,9,66,30,67,19,69,14,71},new int[]{-12,68});
    states[68] = new State(-49);
    states[69] = new State(new int[]{5,47,4,48,8,65,9,66,30,67,19,69,14,71},new int[]{-12,70});
    states[70] = new State(-50);
    states[71] = new State(new int[]{5,47,4,48,8,65,9,66,30,67,19,69,14,71},new int[]{-8,72,-14,56,-11,74,-13,85,-10,77,-12,78});
    states[72] = new State(new int[]{15,73,13,37});
    states[73] = new State(-52);
    states[74] = new State(new int[]{24,41,25,59,26,75,27,79,28,81,29,83,22,-37,23,-37,12,-37,13,-37,15,-37,11,-37});
    states[75] = new State(new int[]{5,47,4,48,8,65,9,66,30,67,19,69,14,71},new int[]{-13,76,-10,77,-12,78});
    states[76] = new State(new int[]{18,43,19,61,24,-40,25,-40,26,-40,27,-40,28,-40,29,-40,22,-40,23,-40,12,-40,13,-40,15,-40,11,-40});
    states[77] = new State(new int[]{20,45,21,63,18,-31,19,-31,24,-31,25,-31,26,-31,27,-31,28,-31,29,-31,22,-31,23,-31,12,-31,13,-31,15,-31,11,-31});
    states[78] = new State(-34);
    states[79] = new State(new int[]{5,47,4,48,8,65,9,66,30,67,19,69,14,71},new int[]{-13,80,-10,77,-12,78});
    states[80] = new State(new int[]{18,43,19,61,24,-41,25,-41,26,-41,27,-41,28,-41,29,-41,22,-41,23,-41,12,-41,13,-41,15,-41,11,-41});
    states[81] = new State(new int[]{5,47,4,48,8,65,9,66,30,67,19,69,14,71},new int[]{-13,82,-10,77,-12,78});
    states[82] = new State(new int[]{18,43,19,61,24,-42,25,-42,26,-42,27,-42,28,-42,29,-42,22,-42,23,-42,12,-42,13,-42,15,-42,11,-42});
    states[83] = new State(new int[]{5,47,4,48,8,65,9,66,30,67,19,69,14,71},new int[]{-13,84,-10,77,-12,78});
    states[84] = new State(new int[]{18,43,19,61,24,-43,25,-43,26,-43,27,-43,28,-43,29,-43,22,-43,23,-43,12,-43,13,-43,15,-43,11,-43});
    states[85] = new State(new int[]{18,43,19,61,24,-44,25,-44,26,-44,27,-44,28,-44,29,-44,22,-44,23,-44,12,-44,13,-44,15,-44,11,-44});
    states[86] = new State(-22);
    states[87] = new State(new int[]{12,88,13,37});
    states[88] = new State(-23);
    states[89] = new State(new int[]{4,90});
    states[90] = new State(new int[]{12,91});
    states[91] = new State(-24);
    states[92] = new State(new int[]{4,93});
    states[93] = new State(new int[]{12,94});
    states[94] = new State(-25);
    states[95] = new State(-15,new int[]{-6,96});
    states[96] = new State(new int[]{17,97,31,15,33,24,34,34,5,47,4,48,8,65,9,66,30,67,19,69,14,71,6,89,7,92,16,95},new int[]{-7,14,-9,23,-8,87,-14,56,-11,74,-13,85,-10,77,-12,78});
    states[97] = new State(-26);
    states[98] = new State(new int[]{4,99});
    states[99] = new State(-13,new int[]{-5,100});
    states[100] = new State(new int[]{11,101,15,-8});
    states[101] = new State(new int[]{6,102,7,104});
    states[102] = new State(new int[]{4,103});
    states[103] = new State(-11);
    states[104] = new State(new int[]{4,105});
    states[105] = new State(-12);
    states[106] = new State(new int[]{4,107});
    states[107] = new State(-13,new int[]{-5,108});
    states[108] = new State(new int[]{11,101,15,-9});
    states[109] = new State(new int[]{4,110});
    states[110] = new State(new int[]{14,111});
    states[111] = new State(new int[]{6,98,7,106,15,-10},new int[]{-4,112});
    states[112] = new State(new int[]{15,113});
    states[113] = new State(new int[]{16,114});
    states[114] = new State(-15,new int[]{-6,115});
    states[115] = new State(new int[]{17,116,31,15,33,24,34,34,5,47,4,48,8,65,9,66,30,67,19,69,14,71,6,89,7,92,16,95},new int[]{-7,14,-9,23,-8,87,-14,56,-11,74,-13,85,-10,77,-12,78});
    states[116] = new State(-6);
    states[117] = new State(new int[]{4,118});
    states[118] = new State(new int[]{14,119});
    states[119] = new State(new int[]{6,98,7,106,15,-10},new int[]{-4,120});
    states[120] = new State(new int[]{15,121});
    states[121] = new State(new int[]{16,122});
    states[122] = new State(-15,new int[]{-6,123});
    states[123] = new State(new int[]{17,124,31,15,33,24,34,34,5,47,4,48,8,65,9,66,30,67,19,69,14,71,6,89,7,92,16,95},new int[]{-7,14,-9,23,-8,87,-14,56,-11,74,-13,85,-10,77,-12,78});
    states[124] = new State(-7);

    for (int sNo = 0; sNo < states.Length; sNo++) states[sNo].number = sNo;

    rules[1] = new Rule(-18, new int[]{-1,3});
    rules[2] = new Rule(-1, new int[]{-2,3});
    rules[3] = new Rule(-2, new int[]{-2,-3});
    rules[4] = new Rule(-2, new int[]{});
    rules[5] = new Rule(-3, new int[]{6,4,14,-4,15,16,-6,17});
    rules[6] = new Rule(-3, new int[]{7,4,14,-4,15,16,-6,17});
    rules[7] = new Rule(-3, new int[]{10,4,14,-4,15,16,-6,17});
    rules[8] = new Rule(-4, new int[]{6,4,-5});
    rules[9] = new Rule(-4, new int[]{7,4,-5});
    rules[10] = new Rule(-4, new int[]{});
    rules[11] = new Rule(-5, new int[]{-5,11,6,4});
    rules[12] = new Rule(-5, new int[]{-5,11,7,4});
    rules[13] = new Rule(-5, new int[]{});
    rules[14] = new Rule(-6, new int[]{-6,-7});
    rules[15] = new Rule(-6, new int[]{});
    rules[16] = new Rule(-15, new int[]{32,-7});
    rules[17] = new Rule(-7, new int[]{31,14,-8,15,-9,-15});
    rules[18] = new Rule(-7, new int[]{-9});
    rules[19] = new Rule(-9, new int[]{31,14,-8,15,-9});
    rules[20] = new Rule(-9, new int[]{33,14,-8,15,-9});
    rules[21] = new Rule(-9, new int[]{34,-8,12});
    rules[22] = new Rule(-9, new int[]{34,12});
    rules[23] = new Rule(-9, new int[]{-8,12});
    rules[24] = new Rule(-9, new int[]{6,4,12});
    rules[25] = new Rule(-9, new int[]{7,4,12});
    rules[26] = new Rule(-9, new int[]{16,-6,17});
    rules[27] = new Rule(-8, new int[]{-8,13,-14});
    rules[28] = new Rule(-8, new int[]{-14});
    rules[29] = new Rule(-13, new int[]{-13,18,-10});
    rules[30] = new Rule(-13, new int[]{-13,19,-10});
    rules[31] = new Rule(-13, new int[]{-10});
    rules[32] = new Rule(-10, new int[]{-10,20,-12});
    rules[33] = new Rule(-10, new int[]{-10,21,-12});
    rules[34] = new Rule(-10, new int[]{-12});
    rules[35] = new Rule(-14, new int[]{-14,22,-11});
    rules[36] = new Rule(-14, new int[]{-14,23,-11});
    rules[37] = new Rule(-14, new int[]{-11});
    rules[38] = new Rule(-11, new int[]{-11,24,-13});
    rules[39] = new Rule(-11, new int[]{-11,25,-13});
    rules[40] = new Rule(-11, new int[]{-11,26,-13});
    rules[41] = new Rule(-11, new int[]{-11,27,-13});
    rules[42] = new Rule(-11, new int[]{-11,28,-13});
    rules[43] = new Rule(-11, new int[]{-11,29,-13});
    rules[44] = new Rule(-11, new int[]{-13});
    rules[45] = new Rule(-12, new int[]{5});
    rules[46] = new Rule(-12, new int[]{4});
    rules[47] = new Rule(-12, new int[]{8});
    rules[48] = new Rule(-12, new int[]{9});
    rules[49] = new Rule(-12, new int[]{30,-12});
    rules[50] = new Rule(-12, new int[]{19,-12});
    rules[51] = new Rule(-12, new int[]{4,14,-16,15});
    rules[52] = new Rule(-12, new int[]{14,-8,15});
    rules[53] = new Rule(-16, new int[]{-8,-17});
    rules[54] = new Rule(-16, new int[]{});
    rules[55] = new Rule(-17, new int[]{11,-16});
    rules[56] = new Rule(-17, new int[]{});

    aliases = new Dictionary<int, string>();
    aliases.Add(6, "int");
    aliases.Add(7, "bool");
    aliases.Add(8, "true");
    aliases.Add(9, "false");
    aliases.Add(10, "void");
    aliases.Add(11, ",");
    aliases.Add(12, ";");
    aliases.Add(13, "=");
    aliases.Add(14, "(");
    aliases.Add(15, ")");
    aliases.Add(16, "{");
    aliases.Add(17, "}");
    aliases.Add(18, "+");
    aliases.Add(19, "-");
    aliases.Add(20, "*");
    aliases.Add(21, "/");
    aliases.Add(22, "||");
    aliases.Add(23, "&&");
    aliases.Add(24, "==");
    aliases.Add(25, "!=");
    aliases.Add(26, ">");
    aliases.Add(27, ">=");
    aliases.Add(28, "<");
    aliases.Add(29, "<=");
    aliases.Add(30, "!");
    aliases.Add(31, "if");
    aliases.Add(32, "else");
    aliases.Add(33, "while");
    aliases.Add(34, "return");
  }

  protected override void Initialize() {
    this.InitSpecialTokens((int)Tokens.error, (int)Tokens.EOF);
    this.InitStates(states);
    this.InitRules(rules);
    this.InitNonTerminals(nonTerms);
  }

  protected override void DoAction(int action)
  {
#pragma warning disable 162, 1522
    switch (action)
    {
      case 2: // P -> Prgm, EOF
#line 63 ".\Parser.y"
                                                                          { CurrentSemanticValue.PrgmExpression = new PrgmExpression(); Program = ValueStack[ValueStack.Depth-2].PrgmExpression;CurrentSemanticValue.PrgmExpression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 3: // Prgm -> Prgm, Decl
#line 66 ".\Parser.y"
                                                                          { CurrentSemanticValue.PrgmExpression = new PrgmExpression(ValueStack[ValueStack.Depth-2].PrgmExpression,ValueStack[ValueStack.Depth-1].DeclareExpression);CurrentSemanticValue.PrgmExpression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 5: // Decl -> "int", ID, "(", FormalList, ")", "{", StmtList, "}"
#line 70 ".\Parser.y"
                                                                          { CurrentSemanticValue.DeclareExpression = new DeclareExpression(Types.integer,ValueStack[ValueStack.Depth-7].Value,ValueStack[ValueStack.Depth-5].FormalListExpression,ValueStack[ValueStack.Depth-2].StatementListExpression);CurrentSemanticValue.DeclareExpression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 6: // Decl -> "bool", ID, "(", FormalList, ")", "{", StmtList, "}"
#line 71 ".\Parser.y"
                                                                          { CurrentSemanticValue.DeclareExpression = new DeclareExpression(Types.boolean,ValueStack[ValueStack.Depth-7].Value,ValueStack[ValueStack.Depth-5].FormalListExpression,ValueStack[ValueStack.Depth-2].StatementListExpression);CurrentSemanticValue.DeclareExpression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 7: // Decl -> "void", ID, "(", FormalList, ")", "{", StmtList, "}"
#line 72 ".\Parser.y"
                                                                          { CurrentSemanticValue.DeclareExpression = new DeclareExpression(Types.voidT,ValueStack[ValueStack.Depth-7].Value,ValueStack[ValueStack.Depth-5].FormalListExpression,ValueStack[ValueStack.Depth-2].StatementListExpression);CurrentSemanticValue.DeclareExpression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 8: // FormalList -> "int", ID, FL2
#line 76 ".\Parser.y"
                                                                         { CurrentSemanticValue.FormalListExpression = new FormalListExpression(Types.integer,ValueStack[ValueStack.Depth-2].Value,ValueStack[ValueStack.Depth-1].FormalListExpression);CurrentSemanticValue.FormalListExpression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 9: // FormalList -> "bool", ID, FL2
#line 77 ".\Parser.y"
                                                                         { CurrentSemanticValue.FormalListExpression = new FormalListExpression(Types.boolean,ValueStack[ValueStack.Depth-2].Value,ValueStack[ValueStack.Depth-1].FormalListExpression);CurrentSemanticValue.FormalListExpression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 11: // FL2 -> FL2, ",", "int", ID
#line 81 ".\Parser.y"
                                                                         { CurrentSemanticValue.FormalListExpression = new FormalListExpression(Types.integer,ValueStack[ValueStack.Depth-1].Value,ValueStack[ValueStack.Depth-4].FormalListExpression);CurrentSemanticValue.FormalListExpression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 12: // FL2 -> FL2, ",", "bool", ID
#line 82 ".\Parser.y"
                                                                         { CurrentSemanticValue.FormalListExpression = new FormalListExpression(Types.integer,ValueStack[ValueStack.Depth-1].Value,ValueStack[ValueStack.Depth-4].FormalListExpression);CurrentSemanticValue.FormalListExpression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 14: // StmtList -> StmtList, Stmt
#line 86 ".\Parser.y"
                                                                         { CurrentSemanticValue.StatementListExpression = new StatementListExpression(ValueStack[ValueStack.Depth-2].StatementListExpression,ValueStack[ValueStack.Depth-1].Expression);CurrentSemanticValue.StatementListExpression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 16: // ElseStmt -> "else", Stmt
#line 92 ".\Parser.y"
                                                            { CurrentSemanticValue.ElseExpression = new ElseExpression(ValueStack[ValueStack.Depth-1].Expression);CurrentSemanticValue.ElseExpression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 17: // Stmt -> "if", "(", Expr, ")", S2, ElseStmt
#line 95 ".\Parser.y"
                                                            { CurrentSemanticValue.Expression = new IfElseExpression(ValueStack[ValueStack.Depth-4].Expression,ValueStack[ValueStack.Depth-2].Expression,ValueStack[ValueStack.Depth-1].ElseExpression);CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 19: // S2 -> "if", "(", Expr, ")", S2
#line 100 ".\Parser.y"
                                                            { CurrentSemanticValue.Expression = new IfElseExpression(ValueStack[ValueStack.Depth-3].Expression,ValueStack[ValueStack.Depth-1].Expression,null);CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 20: // S2 -> "while", "(", Expr, ")", S2
#line 101 ".\Parser.y"
                                                          { CurrentSemanticValue.Expression = new WhileExpression(ValueStack[ValueStack.Depth-3].Expression,ValueStack[ValueStack.Depth-1].Expression);CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 21: // S2 -> "return", Expr, ";"
#line 102 ".\Parser.y"
                                                                        { CurrentSemanticValue.Expression = new ReturnExpression(ValueStack[ValueStack.Depth-2].Expression);CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 22: // S2 -> "return", ";"
#line 103 ".\Parser.y"
                                                                        { CurrentSemanticValue.Expression = new ReturnExpression(null);CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 23: // S2 -> Expr, ";"
#line 104 ".\Parser.y"
                                                                        { CurrentSemanticValue.Expression = ValueStack[ValueStack.Depth-2].Expression;}
#line default
        break;
      case 24: // S2 -> "int", ID, ";"
#line 105 ".\Parser.y"
                                                                        { CurrentSemanticValue.Expression = new VariableExpression(Types.integer, ValueStack[ValueStack.Depth-2].Value);CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 25: // S2 -> "bool", ID, ";"
#line 106 ".\Parser.y"
                                                                        { CurrentSemanticValue.Expression = new VariableExpression(Types.boolean, ValueStack[ValueStack.Depth-2].Value);CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 26: // S2 -> "{", StmtList, "}"
#line 107 ".\Parser.y"
                                                                        { CurrentSemanticValue.Expression = new StatementListExpression(ValueStack[ValueStack.Depth-2].StatementListExpression);CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 27: // Expr -> Expr, "=", E2bis
#line 110 ".\Parser.y"
                                                                           { CurrentSemanticValue.Expression = new BinaryOperatorsExpression(ValueStack[ValueStack.Depth-3].Expression,BinaryOperators.Asn, ValueStack[ValueStack.Depth-1].Expression);CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 29: // E1 -> E1, "+", E2
#line 114 ".\Parser.y"
                                                                        { CurrentSemanticValue.Expression = new BinaryOperatorsExpression(ValueStack[ValueStack.Depth-3].Expression,BinaryOperators.Add, ValueStack[ValueStack.Depth-1].Expression);CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 30: // E1 -> E1, "-", E2
#line 115 ".\Parser.y"
                                                                        { CurrentSemanticValue.Expression = new BinaryOperatorsExpression(ValueStack[ValueStack.Depth-3].Expression,BinaryOperators.Sub, ValueStack[ValueStack.Depth-1].Expression);CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 31: // E1 -> E2
#line 116 ".\Parser.y"
                                                                        { CurrentSemanticValue.Expression = ValueStack[ValueStack.Depth-1].Expression;}
#line default
        break;
      case 32: // E2 -> E2, "*", E4
#line 119 ".\Parser.y"
                                                                        { CurrentSemanticValue.Expression = new BinaryOperatorsExpression(ValueStack[ValueStack.Depth-3].Expression,BinaryOperators.Mul, ValueStack[ValueStack.Depth-1].Expression);CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 33: // E2 -> E2, "/", E4
#line 120 ".\Parser.y"
                                                                        { CurrentSemanticValue.Expression = new BinaryOperatorsExpression(ValueStack[ValueStack.Depth-3].Expression,BinaryOperators.Div, ValueStack[ValueStack.Depth-1].Expression);CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 34: // E2 -> E4
#line 121 ".\Parser.y"
                                                                        { CurrentSemanticValue.Expression = ValueStack[ValueStack.Depth-1].Expression;}
#line default
        break;
      case 35: // E2bis -> E2bis, "||", E3
#line 124 ".\Parser.y"
                                                                        { CurrentSemanticValue.Expression = new BinaryOperatorsExpression(ValueStack[ValueStack.Depth-3].Expression,BinaryOperators.Or, ValueStack[ValueStack.Depth-1].Expression);CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 36: // E2bis -> E2bis, "&&", E3
#line 125 ".\Parser.y"
                                                                        { CurrentSemanticValue.Expression = new BinaryOperatorsExpression(ValueStack[ValueStack.Depth-3].Expression,BinaryOperators.And, ValueStack[ValueStack.Depth-1].Expression);CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 38: // E3 -> E3, "==", E1
#line 129 ".\Parser.y"
                                                                        { CurrentSemanticValue.Expression = new BinaryOperatorsExpression(ValueStack[ValueStack.Depth-3].Expression,BinaryOperators.TestEq, ValueStack[ValueStack.Depth-1].Expression);CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 39: // E3 -> E3, "!=", E1
#line 130 ".\Parser.y"
                                                                        { CurrentSemanticValue.Expression = new BinaryOperatorsExpression(ValueStack[ValueStack.Depth-3].Expression,BinaryOperators.NotEq, ValueStack[ValueStack.Depth-1].Expression);CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 40: // E3 -> E3, ">", E1
#line 131 ".\Parser.y"
                                                                        { CurrentSemanticValue.Expression = new BinaryOperatorsExpression(ValueStack[ValueStack.Depth-3].Expression,BinaryOperators.Sup, ValueStack[ValueStack.Depth-1].Expression);CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 41: // E3 -> E3, ">=", E1
#line 132 ".\Parser.y"
                                                                        { CurrentSemanticValue.Expression = new BinaryOperatorsExpression(ValueStack[ValueStack.Depth-3].Expression,BinaryOperators.SupEq, ValueStack[ValueStack.Depth-1].Expression);CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 42: // E3 -> E3, "<", E1
#line 133 ".\Parser.y"
                                                                        { CurrentSemanticValue.Expression = new BinaryOperatorsExpression(ValueStack[ValueStack.Depth-3].Expression,BinaryOperators.Inf, ValueStack[ValueStack.Depth-1].Expression);CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 43: // E3 -> E3, "<=", E1
#line 134 ".\Parser.y"
                                                                        { CurrentSemanticValue.Expression = new BinaryOperatorsExpression(ValueStack[ValueStack.Depth-3].Expression,BinaryOperators.InfEq, ValueStack[ValueStack.Depth-1].Expression);CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 44: // E3 -> E1
#line 135 ".\Parser.y"
                                                                        { CurrentSemanticValue.Expression = ValueStack[ValueStack.Depth-1].Expression;}
#line default
        break;
      case 45: // E4 -> NUM
#line 138 ".\Parser.y"
                                                                        { CurrentSemanticValue.Expression = new NumberExpression(ValueStack[ValueStack.Depth-1].Value);CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 46: // E4 -> ID
#line 139 ".\Parser.y"
                                                                        { CurrentSemanticValue.Expression = new IdentifierExpression(ValueStack[ValueStack.Depth-1].Value);CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 47: // E4 -> "true"
#line 140 ".\Parser.y"
                                                                        { CurrentSemanticValue.Expression = new BooleanExpression(Boolean.trueE);CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 48: // E4 -> "false"
#line 141 ".\Parser.y"
                                                                        { CurrentSemanticValue.Expression = new BooleanExpression(Boolean.falseE);CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 49: // E4 -> "!", E4
#line 142 ".\Parser.y"
                                                                        { CurrentSemanticValue.Expression = new UOPExpression(UOP.Not, ValueStack[ValueStack.Depth-1].Expression);CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 50: // E4 -> "-", E4
#line 143 ".\Parser.y"
                                                                        { CurrentSemanticValue.Expression = new UOPExpression(UOP.Negative, ValueStack[ValueStack.Depth-1].Expression);CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 51: // E4 -> ID, "(", ExprList, ")"
#line 144 ".\Parser.y"
                                                                        { CurrentSemanticValue.Expression = new NamedExpressionList(ValueStack[ValueStack.Depth-4].Value,ValueStack[ValueStack.Depth-2].ExpressionList);CurrentSemanticValue.Expression.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 52: // E4 -> "(", Expr, ")"
#line 145 ".\Parser.y"
                                                                          { CurrentSemanticValue.Expression = ValueStack[ValueStack.Depth-2].Expression;}
#line default
        break;
      case 53: // ExprList -> Expr, EL2
#line 148 ".\Parser.y"
                                                                        { CurrentSemanticValue.ExpressionList = new ExpressionList(ValueStack[ValueStack.Depth-1].ExpressionList,ValueStack[ValueStack.Depth-2].Expression);CurrentSemanticValue.ExpressionList.SetLocation(CurrentLocationSpan);}
#line default
        break;
      case 55: // EL2 -> ",", ExprList
#line 152 ".\Parser.y"
                                                                        { CurrentSemanticValue.ExpressionList = ValueStack[ValueStack.Depth-1].ExpressionList;}
#line default
        break;
    }
#pragma warning restore 162, 1522
  }

  protected override string TerminalToString(int terminal)
  {
    if (aliases != null && aliases.ContainsKey(terminal))
        return aliases[terminal];
    else if (((Tokens)terminal).ToString() != terminal.ToString(CultureInfo.InvariantCulture))
        return ((Tokens)terminal).ToString();
    else
        return CharToString((char)terminal);
  }

#line 158 ".\Parser.y"

public Parser( Scanner s ) : base( s ) { }
public Expression Program;
#line default
}
}
