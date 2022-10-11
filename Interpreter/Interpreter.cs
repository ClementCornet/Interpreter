using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    public class Variable
    {
        public Types type { get; set; } 
        public string name { get; set; }
        public int value { get; set; }
        public int depth { get; set; }
        
        public Variable(Types type, string name, int value, int depth)
        {
            this.type = type;
            this.name = name;
            this.value = value;
            this.depth = depth;
        }
    }

    public class Function
    {
        public Types type { get; set; }
        public string name { get; set; }
        public FormalListExpression args { get; set; }
        public StatementListExpression actions { get; set; }

        public Function(Types type, string name, FormalListExpression args, StatementListExpression actions)
        {
            this.name = name;
            this.args = args;
            this.actions = actions;
        }
    }

    public partial class Interpreter
    {
        List<Variable> LocalVariables;
        List<Function> LocalFunctions;
        int stackdepth;
        int returnValue;

        public Interpreter()
        {
            LocalVariables = new List<Variable>();
            LocalFunctions = new List<Function>();
            this.stackdepth = 0;
            this.returnValue = 0;
        }

        void clearStack()
        {
            /*
            foreach (Variable v in LocalVariables)
            {
                if (v.depth <= stackdepth) LocalVariables.Remove(v);
            }
            */
            while (LocalVariables.Count != 0 && LocalVariables.Last().depth >= stackdepth) 
                LocalVariables.Remove(LocalVariables.Last());

            stackdepth--;
        }

        public void ReportError(string str, Expression expr)
        {
            Console.WriteLine($"\nINTERPRETATION ERROR : {str} at Line {expr?.Line} in column {expr?.Column}");
            throw new Exception();
        }

        public int Eval(Expression expr)
        {

            if (expr is PrgmExpression) return EvalPrgmExpression(expr as PrgmExpression);
            else if (expr is DeclareExpression) return EvalDeclExpression(expr as DeclareExpression);
            else if (expr is FormalListExpression) return EvalFormalListExpression(expr as FormalListExpression);
            else if (expr is StatementListExpression) return EvalStmtList(expr as StatementListExpression);
            else if (expr is IfExpression) return EvalIfExpression(expr as IfExpression);
            else if (expr is IfElseExpression) return EvalIfElseExpression(expr as IfElseExpression);
            else if (expr is WhileExpression) return EvalWhileExpression(expr as WhileExpression);
            else if (expr is ReturnExpression) return EvalReturnExpression(expr as ReturnExpression);
            else if (expr is VariableExpression) return EvalVariableExpression(expr as VariableExpression);
            else if (expr is BinaryOperatorsExpression) return EvalBOPExpr(expr as BinaryOperatorsExpression);
            else if (expr is NumberExpression) return EvalNumberExpression(expr as NumberExpression);
            else if (expr is IdentifierExpression) return EvalIdentifierExpr(expr as IdentifierExpression);
            else if (expr is BooleanExpression) return EvalBooleanExpression(expr as BooleanExpression);
            else if (expr is UOPExpression) return EvalUOPExpressions(expr as UOPExpression);
            else if (expr is NamedExpressionList) return EvalNamedExprList(expr as NamedExpressionList);


            return 0;
        }

        int EvalPrgmExpression(PrgmExpression expr)
        {
            foreach (DeclareExpression func in expr.expr)
            {
                if (func.identifier != "main") Eval(func);
            }
            foreach (DeclareExpression func in expr.expr)
            {
                if (func.identifier == "main") Eval(func.actions);
            }
            return 0;
        }

        int EvalDeclExpression (DeclareExpression expr)
        {
            this.LocalFunctions.Add(new Function(expr.type, expr.identifier, expr.args, expr.actions));
            return 0;
        }

        int EvalFormalListExpression (FormalListExpression expr)
        {
            foreach(VariableExpression va in expr.variables)
            {
                Eval(va);
            }
            return 0;
        }

        int EvalStmtList (StatementListExpression expr)
        {
            stackdepth++;
            foreach (Expression e in expr.statements)
            {
                if (e is ReturnExpression)
                {
                    int temp = Eval(e);
                    clearStack();
                    returnValue = temp;
                    return temp;
                }
                Eval(e);
            }
            clearStack();
            return 0;
        }

        int EvalIfExpression (IfExpression expr)
        {
            Console.WriteLine("Deprecated");
            return 0;
        }

        int EvalIfElseExpression (IfElseExpression expr)
        {
            if (Eval(expr.condition) == 1)
            {
                Eval(expr.then);
            }
            else
            {
                Eval(expr.or?.action);
            }
            return 0;
        }

        int EvalWhileExpression (WhileExpression expr)
        {
            while (Eval(expr.condition) == 1)
            {
                Eval(expr.action);
            }
            return 0;
        }

        int EvalReturnExpression (ReturnExpression expr)
        {
            returnValue = Eval(expr.returnValue);
            return returnValue;
        }

        int EvalVariableExpression (VariableExpression expr)
        {
            LocalVariables.Add(new Variable(expr.type, expr.identifier, 0, stackdepth));
            return 0;
        }

        int EvalBOPExpr (BinaryOperatorsExpression expr)
        {
            //if (EvalType(expr.left) != EvalType(expr.right)) ReportError("Operands Types not compatible.", expr);
            EvalType(expr);
            if (expr.op == BinaryOperators.Add)
            {
                return Eval(expr.left) + Eval(expr.right);
            }
            if (expr.op == BinaryOperators.Sub)
            {
                return Eval(expr.left) - Eval(expr.right);
            }
            if (expr.op == BinaryOperators.Mul)
            {
                return Eval(expr.left) * Eval(expr.right);
            }
            if (expr.op == BinaryOperators.Div)
            {
                if (Eval(expr.right) != 0)
                    return Eval(expr.left) / Eval(expr.right);
                else
                {
                    ReportError("Division By Zero.", expr);
                }
            }
            if (expr.op == BinaryOperators.Inf)
            {
                if (Eval(expr.left) < Eval(expr.right)) return 1;
                return 0;
            }
            if (expr.op == BinaryOperators.InfEq)
            {
                if (Eval(expr.left) <= Eval(expr.right)) return 1;
                return 0;
            }
            if (expr.op == BinaryOperators.TestEq)
            {
                if (Eval(expr.left) == Eval(expr.right)) return 1;
                return 0;
            }
            if (expr.op == BinaryOperators.And)
            {
                if (Eval(expr.right) == 1 &&  Eval(expr.left)==1) return 1;
                return 0;
            }
            if (expr.op == BinaryOperators.Or)
            {
                if (Eval(expr.right) == 1 || Eval(expr.left) == 1) return 1;
                return 0;
            }
            if (expr.op == BinaryOperators.Asn)
            {
                if (expr.left is BinaryOperatorsExpression && ((BinaryOperatorsExpression)expr.left).op == BinaryOperators.Asn)
                {
                    if (((BinaryOperatorsExpression)expr.left).right is IdentifierExpression)
                    {
                        Eval(new BinaryOperatorsExpression((IdentifierExpression)(((BinaryOperatorsExpression)expr.left).right),BinaryOperators.Asn,expr.right));
                        Eval(expr.left);
                        return 0;
                    }
                }

                if (expr.left is not IdentifierExpression) ReportError($"Cannot assign something that is not a Variable.", expr);
                for (int i = LocalVariables.Count - 1; i >= 0; i--)
                {
                    if (LocalVariables[i].name == ((IdentifierExpression)expr.left).name)
                    {
                        LocalVariables[i].value = Eval(expr.right);
                        break;
                    }
                }
            }
            return 0;
        }

        int EvalNumberExpression (NumberExpression expr)
        {
            return Convert.ToInt32(expr.number);
        }

        int EvalIdentifierExpr (IdentifierExpression expr)
        {
            for (int i = LocalVariables.Count - 1; i >= 0; i--)
            {
                if (LocalVariables[i].name == expr.name)
                {
                    return LocalVariables[i].value;
                }
            }
            ReportError($"Did not Find variable named {expr.name}.", expr);
            return 0;
        }

        int EvalBooleanExpression (BooleanExpression expr)
        {
            if (expr.flag == Boolean.trueE) return 1;
            return 0;
        }

        int EvalUOPExpressions (UOPExpression expr)
        {
            if (expr.op == UOP.Negative) return -Eval(expr.expr);
            if (expr.op == UOP.Negative) return 1-Eval(expr.expr);
            return 0;
        }

        int EvalNamedExprList (NamedExpressionList expr)
        {
            if (expr.name == "print")
            {
                string str = string.Empty;
                for (int i = 0; i < expr.list.Count; i++)
                {
                    if (EvalType(expr.list[i]) == Types.boolean)
                    {
                        if (Eval(expr.list[i]) == 1) str += "True";
                        else str += "False";
                    }
                    else
                    {
                        str += Eval(expr.list[i]).ToString();
                    }
                    if (i < expr.list.Count - 1) str += ", ";
                }
                Console.WriteLine(str);
                return 0;
            }
            
            stackdepth++;
            foreach(Function func in LocalFunctions)
            {
                if (func.name == expr.name)
                {
                    if ((func.args?.variables.Count ?? 0) != expr.list.Count) ReportError("Wrong Number of Arguments.", expr);
                    for (int i = 0; i < expr.list.Count; i++)
                    {
                        int value = Eval(expr.list[i]);
                        Eval(func.args.variables[i]);
                        //LocalVariables.Last().value = Eval(expr.list[i]);
                        LocalVariables.Last().value = value;
                    }
                    
                    Eval(func.actions);
                    break;
                }
            }
            clearStack();
            return returnValue;
        }
    }
}
