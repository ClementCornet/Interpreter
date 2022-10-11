using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    public partial class Interpreter
    {

        void ReportTypeError(Expression expr)
        {
            Console.WriteLine($"\nfail {expr.Line} {expr.Column}");
            throw new Exception();
        }

        public bool CheckType(Expression expr)
        {
            if (expr is PrgmExpression) return CheckPrgm(expr as PrgmExpression);
            else if (expr is DeclareExpression) return CheckDecl(expr as DeclareExpression);
            else if (expr is FormalListExpression) return CheckFormalList(expr as FormalListExpression);
            else if (expr is StatementListExpression) return CheckStmtList(expr as StatementListExpression);
            else if (expr is IfExpression) return CheckIfExpression(expr as IfExpression);
            else if (expr is IfElseExpression) return CheckIfElseExpression(expr as IfElseExpression);
            else if (expr is WhileExpression) return CheckWhileExpression(expr as WhileExpression);
            else if (expr is ReturnExpression) return CheckReturnExpression(expr as ReturnExpression);
            else if (expr is VariableExpression) return CheckVariableExpr(expr as VariableExpression);
            else if (expr is BinaryOperatorsExpression) return CheckBOPExpr(expr as BinaryOperatorsExpression);
            else if (expr is NumberExpression) return CheckNumberExpr(expr as NumberExpression);
            else if (expr is IdentifierExpression) return CheckIdentifier(expr as IdentifierExpression);
            else if (expr is BooleanExpression) return CheckBoolean(expr as BooleanExpression);
            else if (expr is UOPExpression) return CheckUOPExpr(expr as UOPExpression);
            else if (expr is NamedExpressionList) return CheckNamedExprList(expr as NamedExpressionList);

            //ReportError("No corresponding expression type found",expr);
            return true;
        }

        bool CheckPrgm(PrgmExpression expr)
        {
            //foreach(var va in variables)
            //{
            //    Console.WriteLine($"{va.id} {va.type} {va.value}");
            //}
            foreach (DeclareExpression e in expr.expr)
            {
                if (!CheckType(e))
                {
                    //Console.WriteLine("lalal");
                    ReportTypeError(expr);
                }
            }
            Console.WriteLine("\npass");
            return true;
        }

        bool CheckDecl(DeclareExpression expr)
        {
            return CheckStmtList(expr.actions);
        }

        bool CheckFormalList(FormalListExpression expr)
        {
            return true;
        }

        bool CheckStmtList(StatementListExpression expr)
        {
            foreach (Expression e in expr.statements)
            {
                if (!CheckType(e)) ReportTypeError(expr);
            }
            return true;
        }

        bool CheckIfExpression(IfExpression expr)
        {
            if (!CheckType(expr.condition)) ReportTypeError(expr);
            if (!CheckType(expr.then)) ReportTypeError(expr);
            return true;
        }

        bool CheckIfElseExpression(IfElseExpression expr)
        {
            if (!CheckType(expr.condition)) ReportTypeError(expr);
            if (!CheckType(expr.then)) ReportTypeError(expr);
            if (!CheckType(expr.or)) ReportTypeError(expr);
            return true;
        }

        bool CheckWhileExpression(WhileExpression expr)
        {
            if (!CheckType(expr.condition)) ReportTypeError(expr);
            if (!CheckType(expr.action)) ReportTypeError(expr);
            return true;
        }

        bool CheckReturnExpression(ReturnExpression expr)
        {
            return true;
        }

        bool CheckVariableExpr(VariableExpression expr)
        {
            //Console.WriteLine(expr.type);
            return true;
        }

        bool CheckBOPExpr(BinaryOperatorsExpression expr)
        {
            //Console.WriteLine(EvalType(expr.left));
            //Console.WriteLine(EvalType(expr.right));
            //Console.WriteLine((expr.left));
            //Console.WriteLine((expr.op));
            //Console.WriteLine((expr.right));
            //Console.WriteLine(Eval(expr.right));
            //if (EvalType(expr.left) != EvalType(expr.right)) return false;
            if ((new[] { BinaryOperators.Add, BinaryOperators.Sub, BinaryOperators.Mul, BinaryOperators.Div }).Contains(expr.op))
            {
                if (EvalType(expr.left) != Types.integer)
                    ReportTypeError(expr.left);
                else if (EvalType(expr.right) != Types.integer)
                    ReportTypeError(expr.right);

                else return true;
            }
            else if (expr.op == BinaryOperators.Asn)
            {
                //return true;
                //Console.WriteLine(expr.op);
                if (expr.left is IdentifierExpression)
                {
                    //Console.WriteLine();
                    //Console.WriteLine(EvalType(expr.left));
                    //Console.WriteLine(EvalType(expr.right));
                    //Console.WriteLine(expr.right);

                    if ((EvalType(expr.left) == EvalType(expr.right)) && (CheckType(expr.right) == CheckType(expr.right)==true))
                            return true;
                    ReportTypeError(expr);
                }
                return true;
            }
            else if ((new[] { BinaryOperators.TestEq, BinaryOperators.NotEq }.Contains(expr.op)))
            {
                //Console.WriteLine("TEST WITH ==");
                //Console.WriteLine(expr.left);
                //Console.WriteLine(expr.right);

                if (EvalType(expr.left) != EvalType(expr.right))
                {
                    ReportTypeError(expr);
                    //Console.WriteLine("FAILED TEST WITH ==");
                    ReportTypeError(expr);
                }
                else return true;
            }
            else if ((new[] { BinaryOperators.Sup, BinaryOperators.SupEq,BinaryOperators.Inf,BinaryOperators.InfEq})
                .Contains(expr.op))// Comparison operators
            {
                //Console.WriteLine("quhfau");
                if (EvalType(expr.left) != Types.integer) ReportTypeError(expr);
                else return true;
            }
            else
            {
                //ReportTypeError(expr);
                //return false;
                //Console.WriteLine("hehehere");

                CheckType(expr.left);
                CheckType(expr.right);

                //Console.WriteLine(expr.left);
                //Console.WriteLine(EvalType(expr.left));
                if (EvalType(expr.left) != Types.boolean) ReportTypeError(expr.left);
                else if (EvalType(expr.right) != Types.boolean) ReportTypeError(expr.right);
                //Console.WriteLine("wut");

                //Console.WriteLine(expr.left);

                return true;
            }
            return false;
        }

        bool CheckNumberExpr(NumberExpression expr)
        {
            return true;
        }

        bool CheckIdentifier(IdentifierExpression expr)
        {
            return true;
        }

        bool CheckBoolean(BooleanExpression expr)
        {
            return true;
        }

        bool CheckUOPExpr(UOPExpression expr)
        {
            if (expr.op == UOP.Not)
            {
                if (EvalType(expr.expr) != Types.boolean) ReportTypeError(expr);
                else return true;
            }
            if (expr.op == UOP.Negative)
            {
                if (EvalType(expr.expr) != Types.integer) ReportTypeError(expr);
                else return true;
            }
            ReportTypeError(expr);
            return false;
        }

        bool CheckNamedExprList(NamedExpressionList expr)
        {
            if (expr.name == "print")
            {
                return true;
            }
            else
            {
                foreach (Function func in LocalFunctions)
                {
                    if (func.name == expr.name)
                    {
                        for (int i = 0; i < expr.list.Count; i++)
                        {
                            if (EvalType(func.args.variables[i]) != EvalType(expr.list[i]))
                                ReportTypeError(expr);
                        }
                    }
                }
            }
            return true;
        }
    }
}
