using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{

    
    public partial class Interpreter
    {
        // Evaluate type from an Expression for enum Types{integer,boolean,voidT}
        public Types EvalType(Expression expr)
        {
            if (expr is PrgmExpression) return TypePrgmExpression(expr as PrgmExpression);
            else if (expr is DeclareExpression) return TypeDeclExpression(expr as DeclareExpression);
            else if (expr is FormalListExpression) return TypeFormalListExpression(expr as FormalListExpression);
            else if (expr is StatementListExpression) return TypeStmtList(expr as StatementListExpression);
            else if (expr is IfExpression) return TypeIfExpression(expr as IfExpression);
            else if (expr is IfElseExpression) return TypeIfElseExpression(expr as IfElseExpression);
            else if (expr is WhileExpression) return TypeWhileExpression(expr as WhileExpression);
            else if (expr is ReturnExpression) return TypeReturnExpression(expr as ReturnExpression);
            else if (expr is VariableExpression) return TypeVariableExpression(expr as VariableExpression);
            else if (expr is BinaryOperatorsExpression) return TypeBOPExpr(expr as BinaryOperatorsExpression);
            else if (expr is NumberExpression) return TypeNumberExpression(expr as NumberExpression);
            else if (expr is IdentifierExpression) return TypeIdentifierExpr(expr as IdentifierExpression);
            else if (expr is BooleanExpression) return TypeBooleanExpression(expr as BooleanExpression);
            else if (expr is UOPExpression) return TypeUOPExpressions(expr as UOPExpression);
            else if (expr is NamedExpressionList) return TypeNamedExprList(expr as NamedExpressionList);

            return Types.voidT;
        }

        #region Return void for every type of expression that always returns Zero in Interpreter
        Types TypePrgmExpression(PrgmExpression expr)
        {
            return Types.voidT;
        }

        Types TypeDeclExpression(DeclareExpression expr)
        {
            return Types.voidT;
        }

        Types TypeFormalListExpression(FormalListExpression expr)
        {
            return Types.voidT;
        }

        Types TypeStmtList(StatementListExpression expr)
        {
            return Types.voidT;
        }

        Types TypeIfExpression(IfExpression expr)
        {
            return Types.voidT;
        }

        Types TypeIfElseExpression(IfElseExpression expr)
        {
            return Types.voidT;
        }

        Types TypeWhileExpression(WhileExpression expr)
        {
            return Types.voidT;
        }
        #endregion

        Types TypeReturnExpression(ReturnExpression expr)
        {
            return EvalType(expr.returnValue);
        }

        Types TypeVariableExpression(VariableExpression expr)
        {
            //Console.WriteLine(expr.type);
            //Console.WriteLine(expr.type);
            return expr.type;
        }

        Types TypeBOPExpr(BinaryOperatorsExpression expr)
        {
            //if (EvalType(expr.left) != EvalType(expr.right)) ReportError("Operands of different types", expr);

            if ((new[] { BinaryOperators.Add, BinaryOperators.Sub, BinaryOperators.Mul, BinaryOperators.Div }).Contains(expr.op))
            {
                if (EvalType(expr.left)!=Types.integer)
                    ReportError("Only Accepting integers with this operator",expr.left);
                if (EvalType(expr.right) != Types.integer) 
                    ReportError("Only Accepting integers with this operator", expr.right);

                return Types.integer;
            }



            else
            {
                //Console.WriteLine("here");
                //if (EvalType(expr.left) != Types.boolean) ReportError("Operands of different types", expr);
                return Types.boolean;
            }
        }

        Types TypeNumberExpression(NumberExpression expr)
        {
            return Types.integer;
        }

        Types TypeIdentifierExpr(IdentifierExpression expr)
        {
            int depth = 0;
            Types t = Types.voidT;
            //Console.WriteLine(this.variables.Count);
            foreach (Variable va in this.LocalVariables)
            {
                //Console.Write($" {va.id}{va.value}");

                t = va.type;
                if (va.name == expr.name)
                {
                    return va.type;
                }
                //Console.WriteLine(t);
            }
            return Types.voidT;
        }

        Types TypeBooleanExpression(BooleanExpression expr)
        {
            return Types.boolean;
        }

        Types TypeUOPExpressions(UOPExpression expr)
        {                
            if (expr.op == UOP.Not)
            {
                //if (EvalType(expr.expr) != Types.boolean) ReportError("Unary Operator 'Not' only supports bool", expr);
                return Types.boolean;
            }
            if (expr.op == UOP.Negative)
            {
                //if (EvalType(expr.expr) != Types.integer) ReportError("Unary Operator 'Not' only supports int", expr);
                return Types.integer;
            }
            return Types.voidT;
        }

        Types TypeNamedExprList(NamedExpressionList expr)
        {
            if (expr.name == "print") return Types.voidT;

            foreach (var func in this.LocalFunctions)
            {
                if (expr.name == func.name) return func.type;
            }

            return Types.voidT;
        }
    }
}
