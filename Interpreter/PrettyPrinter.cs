using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    public partial class PrgmExpression
    {
        public override void Pretty(PrettyBuilder builder, int outerPrecedence, bool opposite)
        {
            if (outerPrecedence > 0)
            {
                builder.Append("(");
                builder.Indent();
                builder.NewLine();
            }

            for (int i = 0; i< this.expr.Count; i++)
            {
                this.expr[i].Pretty(builder, 0, false);
                //builder.Append(";");
                builder.NewLine();
            }

            if (outerPrecedence > 0)
            {
                builder.Unindent();
                builder.NewLine();
                builder.Append(")");
            }
        }
    }

    public partial class DeclareExpression : Expression
    {
        public override void Pretty(PrettyBuilder builder, int outerPrecedence, bool opposite)
        {
            builder.Append($"{prettyType(type)} {this.identifier}");
            builder.Append("(");
            args?.Pretty(builder, 1, false);
            builder.Append(")");
            builder.NewLine();
            //builder.Append("{");
            //builder.Indent();
            //builder.NewLine();
            this.actions?.Pretty(builder, 0, false);
            //builder.Unindent();
            //builder.NewLine();
            //builder.Append("}");
        }

        private string prettyType(Types t)
        {
            if (t == Types.boolean) return "bool";
            else if (t == Types.integer) return "int";
            else return "void";
        }
    }



    public partial class FormalListExpression : Expression
    {
        public override void Pretty(PrettyBuilder builder, int outerPrecedence, bool opposite)
        {
            for (int i = 0; i<this.variables.Count-1; i++)
            {
                this.variables[i].Pretty(builder, 0, false);
                builder.Append(", ");
            }
            this.variables[variables.Count - 1].Pretty(builder, 0, false);
        }
    }

    public partial class StatementListExpression : Expression
    {
        public override void Pretty(PrettyBuilder builder, int outerPrecedence, bool opposite)
        {
            builder.Append("{");
            builder.Indent();
            foreach (var stmt in this.statements)
            {
                builder.NewLine();
                stmt.Pretty(builder, 0, false);
                if (stmt is not IfElseExpression && stmt is not WhileExpression && stmt is not StatementListExpression)
                    builder.Append(";");
                //builder.NewLine();
            }
            builder.Unindent();
            builder.NewLine();
            builder.Append("}");
        }
    }

    public partial class IfExpression : Expression
    {
        public override void Pretty(PrettyBuilder builder, int outerPrecedence, bool opposite)
        {
            builder.Append("if ");
            this.condition.Pretty(builder, 1, false);
            builder.Append("{");
            builder.NewLine();
            builder.Indent();
            this.then.Pretty(builder, 0, false);
            builder.NewLine();
            builder.Unindent();
            builder.Append("}");
        }
    }

    public partial class IfElseExpression
    {
        public override void Pretty(PrettyBuilder builder, int outerPrecedence, bool opposite)
        {
            builder.Append("if (");
            this.condition.Pretty(builder, 1, false);
            builder.Append(")");
            builder.NewLine();
            //builder.Append("{");
            //builder.Indent();
            //builder.NewLine();
            //builder.Unindent();
            this.then.Pretty(builder, 0, false);
            //builder.Unindent();
            //builder.NewLine();
            //builder.Append("}");
            builder.NewLine();
            this.or?.Pretty(builder, 0, false);
        }
    }

    public partial class ElseExpression : Expression
    {
        public override void Pretty(PrettyBuilder builder, int outerPrecedence, bool opposite)
        {
            builder.Append("else ");
            builder.NewLine();

            
            //builder.Append("{");
            //builder.Indent();
            //builder.NewLine();
            //builder.Unindent();
            this.action.Pretty(builder, 0, false);
            //builder.Unindent();
            //builder.NewLine();
            
            //builder.Append("}");
        }
    }

    public partial class WhileExpression : Expression
    {
        public override void Pretty(PrettyBuilder builder, int outerPrecedence, bool opposite)
        {
            builder.Append("while ");
            builder.Append("(");
            this.condition.Pretty(builder, 1, false);
            builder.Append(")");
            //builder.Append("{");
            builder.NewLine();
            //builder.Indent();
            this.action.Pretty(builder, 0, false);
            //builder.NewLine();
            //builder.Unindent();
            //builder.Append("}");
        }
    }

    public partial class ReturnExpression : Expression
    {
        public override void Pretty(PrettyBuilder builder, int outerPrecedence, bool opposite)
        {
            builder.Append("return ");
            this.returnValue?.Pretty(builder, 0, false);
            //builder.Append(";");
        }
    }

    public partial class VariableExpression : Expression
    {
        public override void Pretty(PrettyBuilder builder, int outerPrecedence, bool opposite)
        {
            builder.Append($"{prettyType(type)} {this.identifier}");
        }
        private string prettyType(Types t)
        {
            if (t == Types.boolean) return "bool";
            else if (t == Types.integer) return "int";
            else return "void";
        }
    }

    public partial class BinaryOperatorsExpression : Expression
    {
        static Dictionary<BinaryOperators, string> Operators =
           new Dictionary<BinaryOperators, string>()
           {
                {BinaryOperators.Add, " + " },
                {BinaryOperators.Sub, " - " },
                {BinaryOperators.Mul, " * " },
                {BinaryOperators.Div, " / " },
                {BinaryOperators.Or, " || " },
                {BinaryOperators.And, " && " },
                {BinaryOperators.TestEq, " == " },
                {BinaryOperators.NotEq, " != " },
                {BinaryOperators.Sup, " > " },
                {BinaryOperators.SupEq, " >= " },
                {BinaryOperators.Inf, " < " },
                {BinaryOperators.InfEq, " <= " },
                {BinaryOperators.Asn, " = " },
           };

        static Dictionary<BinaryOperators, int> Precedences =
           new Dictionary<BinaryOperators, int>()
           {
                {BinaryOperators.Add, 6 },
                {BinaryOperators.Sub, 6 },
                {BinaryOperators.Mul, 7 },
                {BinaryOperators.Div, 7 },
                {BinaryOperators.Or, 2 },
                {BinaryOperators.And, 3 },
                {BinaryOperators.TestEq, 4 },
                {BinaryOperators.NotEq, 4 },
                {BinaryOperators.Sup, 5 },
                {BinaryOperators.SupEq, 5 },
                {BinaryOperators.Inf, 5 },
                {BinaryOperators.InfEq, 5 },
                {BinaryOperators.Asn, 1 },
           };

        enum Associativity { Left, Right, Both }

        static Dictionary<BinaryOperators, Associativity> Associativities =
           new Dictionary<BinaryOperators, Associativity>()
           {
                {BinaryOperators.Add, Associativity.Left },
                {BinaryOperators.Sub, Associativity.Left },
                {BinaryOperators.Mul, Associativity.Left },
                {BinaryOperators.Div, Associativity.Left },
                {BinaryOperators.Or, Associativity.Left },
                {BinaryOperators.And, Associativity.Left },
                {BinaryOperators.TestEq, Associativity.Left },
                {BinaryOperators.NotEq, Associativity.Left },
                {BinaryOperators.Sup, Associativity.Left },
                {BinaryOperators.SupEq, Associativity.Left },
                {BinaryOperators.Inf, Associativity.Left },
                {BinaryOperators.InfEq, Associativity.Left },
                {BinaryOperators.Asn, Associativity.Right },
           };

        public override void Pretty(PrettyBuilder builder, int outerPrecedence, bool opposite)
        {
            var needsParenthesis = outerPrecedence > Precedences[op] ||
                    opposite && (outerPrecedence == Precedences[op]);

            if (needsParenthesis)
            {
                builder.Append("(");
            }

            left.Pretty(builder, Precedences[op], Associativities[op] == Associativity.Right);
            builder.Append(Operators[op]);
            right.Pretty(builder, Precedences[op], Associativities[op] == Associativity.Left);

            if (needsParenthesis)
            {
                builder.Append(")");
            }
            //if (this.op == BinaryOperators.Asn) builder.Append(";");
        }
    }

    public partial class NumberExpression : Expression
    {
        public override void Pretty(PrettyBuilder builder, int outerPrecedence, bool opposite)
        {
            builder.Append(this.number.ToString());
        }
    }

    public partial class IdentifierExpression : Expression
    {
        public override void Pretty(PrettyBuilder builder, int outerPrecedence, bool opposite)
        {
            builder.Append(name);
        }
    }

    public partial class BooleanExpression : Expression
    {
        public override void Pretty(PrettyBuilder builder, int outerPrecedence, bool opposite)
        {
            if (flag == Boolean.trueE) builder.Append("True");
            else if (flag == Boolean.falseE) builder.Append("False");
        }
    }

    public partial class UOPExpression : Expression
    {
        public override void Pretty(PrettyBuilder builder, int outerPrecedence, bool opposite)
        {
            builder.Append(op.ToString());
            this.expr.Pretty(builder, 8, false);
        }
    }

    public partial class NamedExpressionList : Expression
    {
        public override void Pretty(PrettyBuilder builder, int outerPrecedence, bool opposite)
        {
            builder.Append($"{name}(");
            for (int i = 0; i < list.Count ; i++)
            {
                list[list.Count -1 -i].Pretty(builder, 1, false);
                if (i != list.Count -1)
                    builder.Append(", ");
            }
            //list[list.Count - 1].Pretty(builder, 1, false);
            builder.Append(")");
        }
    }

    public partial class ExpressionList : Expression
    {
        public override void Pretty(PrettyBuilder builder, int outerPrecedence, bool opposite)
        {
            for (int i = 0; i < outerPrecedence - 1; i++)
            {
                list[i].Pretty(builder, 1, false);
                builder.Append(", ");
            }
            list[list.Count - 1].Pretty(builder, 1, false);
        }
    }
}
