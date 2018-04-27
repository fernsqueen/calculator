using CALCULATOR.Expound;
using CALCULATOR.Expression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALCULATOR.Trigonometry
{
    public class AddDivVisitor : Visitior
    {
        public override IExpression VisitName(NameExpression expression)
        {
            return null;
        }

        public override IExpression VisitFunc(FuncExpression expression)
        {
            return expression.Argument.Clone();
        }

        public override IExpression VisitConst(ConstantExpression expression)
        {
            return null;
        }

        public override IExpression VisitBinary(BinaryOperator expression)
        {
            FuncExpression left = (FuncExpression)expression.Left;
            FuncExpression right = (FuncExpression)expression.Right;
            if ((left.Name == "sin") && (right.Name == "sin"))
            {
                if (expression.Name == "+")
                {
                    return new BinaryOperator("*", new ConstantExpression("2"), new BinaryOperator("*",
                        new FuncExpression("sin", new BinaryOperator("/", new BinaryOperator("+",
                           left.Accept(this), right.Accept(this)), new ConstantExpression("2"))),
                             new FuncExpression("cos", new BinaryOperator("/", new BinaryOperator("-",
                                left.Accept(this), right.Accept(this)), new ConstantExpression("2")))));
                }
            }
            if ((left.Name == "sin") && (right.Name == "sin"))
            {
                if (expression.Name == "-")
                {
                    return new BinaryOperator("*", new ConstantExpression("2"), new BinaryOperator("*",
                        new FuncExpression("sin", new BinaryOperator("/", new BinaryOperator("-",
                           left.Accept(this), right.Accept(this)), new ConstantExpression("2"))),
                             new FuncExpression("cos", new BinaryOperator("/", new BinaryOperator("+",
                                left.Accept(this), right.Accept(this)), new ConstantExpression("2")))));
                }
            }
            if ((left.Name == "cos") && (right.Name == "cos"))
            {
                if (expression.Name == "+")
                {
                    return new BinaryOperator("*", new ConstantExpression("2"), new BinaryOperator("*",
                        new FuncExpression("cos", new BinaryOperator("/", new BinaryOperator("+",
                           left.Accept(this), right.Accept(this)), new ConstantExpression("2"))),
                             new FuncExpression("cos", new BinaryOperator("/", new BinaryOperator("-",
                                left.Accept(this), right.Accept(this)), new ConstantExpression("2")))));
                }
            }
            if ((left.Name == "cos") && (right.Name == "cos"))
            {
                if (expression.Name == "-")
                {
                    return new UnaryOperator("-", new BinaryOperator("*", new ConstantExpression("2"), new BinaryOperator("*",
                        new FuncExpression("sin", new BinaryOperator("/", new BinaryOperator("+",
                           left.Accept(this), right.Accept(this)), new ConstantExpression("2"))),
                             new FuncExpression("sin", new BinaryOperator("/", new BinaryOperator("-",
                                left.Accept(this), right.Accept(this)), new ConstantExpression("2"))))));
                }
            }
            return null;

        }

        public override IExpression VisitUnary(UnaryOperator expression)
        {
            return null;
        }
    }
}
