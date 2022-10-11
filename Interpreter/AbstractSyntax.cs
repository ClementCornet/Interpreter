using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    public abstract partial class Expression
    {
        public int Line;
        public int Column;

        public void SetLocation(QUT.Gppg.LexLocation loc)
        {
            Line = loc?.StartLine ?? 0; Column = loc?.StartColumn ?? 0;
            //Line = 2;
            //Column = 0;
        }
        public abstract void Pretty(PrettyBuilder builder, int outerPrecedence, bool opposite);
        public string Pretty()
        {
            var builder = new PrettyBuilder();
            Pretty(builder, 0, false);
            return builder.ToString();
        }
    }

    public partial class PrgmExpression : Expression
    {
        public List<DeclareExpression> expr;

        public PrgmExpression()
        {
            expr = new List<DeclareExpression>();
        }

        public PrgmExpression(PrgmExpression prgm)
        {
            this.expr = prgm?.expr ?? new List<DeclareExpression>();
        }

        public PrgmExpression(PrgmExpression prgm, DeclareExpression decl)
        {
            this.expr = prgm?.expr?? new List<DeclareExpression>();
            
            expr.Add(decl);
        }
    }

    public partial class DeclareExpression : Expression
    {
        public Types type;
        public string identifier;
        public FormalListExpression args;
        public StatementListExpression actions;

        public DeclareExpression(Types type, string identifier, FormalListExpression args, StatementListExpression actions)
        {
            this.type = type;
            this.identifier = identifier;
            this.args = args;
            this.actions = actions;
        }
    }

    public enum Types { integer, boolean, voidT}

    public partial class FormalListExpression : Expression
    {
        public List<VariableExpression> variables;

        public FormalListExpression(Types type, string name, FormalListExpression FL)
        {
            this.variables = FL?.variables ?? new List<VariableExpression>();
            this.variables.Add(new VariableExpression(type, name));
        }
    }

    public partial class StatementListExpression : Expression
    {
        public List<Expression> statements;

        public StatementListExpression(StatementListExpression l)
        {
            this.statements = l?.statements ?? new List<Expression>();
        }
        public StatementListExpression(StatementListExpression l, Expression stmt)
        {
            this.statements = l?.statements ?? new List<Expression>();
            this.statements.Add(stmt);
        }
    }

    public partial class IfExpression : Expression
    {
        public Expression condition;
        public Expression then;


        public IfExpression(Expression condition, Expression then)
        {
            this.condition = condition;
            this.then = then;
        }
    }

    public partial class IfElseExpression : Expression
    {
        public Expression condition;
        public Expression then;
        public ElseExpression or;

        public IfElseExpression(Expression condition, Expression then, ElseExpression or)
        {
            this.condition = condition;
            this.then = then;
            this.or = or;
        }
    }

    public partial class ElseExpression : Expression
    {
        public Expression action;

        public ElseExpression(Expression action)
        {
            this.action = action;
        }
    }

    public partial class WhileExpression : Expression
    {
        public Expression condition;
        public Expression action;

        public WhileExpression(Expression condition, Expression action)
        {
            this.condition = condition;
            this.action = action;
        }
    }

    public partial class ReturnExpression : Expression
    {
        public Expression returnValue;

        public ReturnExpression(Expression returnValue)
        {
            this.returnValue = returnValue;
        }
    }


    public partial class VariableExpression : Expression
    {
        public Types type;
        public string identifier;

        public VariableExpression(Types type, string identifier)
        {
            this.type = type;
            this.identifier = identifier;
        }
    }

    public enum BinaryOperators { Add, Sub, Mul, Div, Or, And, TestEq, NotEq, Sup, SupEq, Inf, InfEq, Asn }

    public partial class BinaryOperatorsExpression : Expression
    {
        public Expression left;
        public Expression right;
        public BinaryOperators op;

        public BinaryOperatorsExpression(Expression left, BinaryOperators op, Expression right)
        {
            this.left = left;
            this.right = right;
            this.op = op;
        }
    }

    public partial class NumberExpression : Expression
    {
        public string number;

        public NumberExpression(string number)
        {
            this.number = number;
        }
    }

    public partial class IdentifierExpression : Expression
    {
        public string name;

        public IdentifierExpression(string name)
        {
            this.name = name;
        }
    }

    public enum Boolean { trueE, falseE}

    public partial class BooleanExpression : Expression
    {
        public Boolean flag;

        public BooleanExpression(Boolean flag)
        {
            this.flag = flag;
        }
    }

    public enum UOP { Not, Negative }

    public partial class UOPExpression : Expression
    {
        public UOP op;
        public Expression expr;

        public UOPExpression(UOP op, Expression expr)
        {
            this.op = op;
            this.expr = expr;
        }
    }

    public partial class NamedExpressionList : Expression
    {
        public string name;
        public List<Expression> list;

        public NamedExpressionList(string name, ExpressionList EL)
        {
            this.name = name;
            list = EL?.list ?? new List<Expression>();
        }

    }

    public partial class ExpressionList : Expression
    {
        public List<Expression> list;

        public ExpressionList(ExpressionList EL, Expression expr)
        {
            list = EL?.list?? new List<Expression>();
            list.Add(expr);
        }
    }
}
