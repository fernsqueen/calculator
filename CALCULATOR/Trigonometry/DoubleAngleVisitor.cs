using CALCULATOR.Expound;
using CALCULATOR.Expression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALCULATOR.Trigonometry
{
    public class DoubleAngleVisitor : Visitior
    {
        public override IExpression VisitName(NameExpression expression)
        {
            return null;
        }

        public override IExpression VisitFunc(FuncExpression expression)
        {
            if (expression.Name == "sin")
            {
                return new BinaryOperator("*", new ConstantExpression("2"), new BinaryOperator("*",
                        new FuncExpression("sin", expression.Argument.Clone().Accept(this)),
                        new FuncExpression("cos", expression.Argument.Clone().Accept(this))));
            }
            if (expression.Name == "cos")
            {
                 return new BinaryOperator("-", new BinaryOperator("^", new FuncExpression("cos", expression.Argument.Clone().Accept(this)),
                       new ConstantExpression("2")), new BinaryOperator("^", new FuncExpression("sin", expression.Argument.Clone().Accept(this)),
                       new ConstantExpression("2")));
            }


            return expression.Argument.Clone().Accept(this);
        }

        public override IExpression VisitConst(ConstantExpression expression)
        {
            return null;
        }

        public override IExpression VisitBinary(BinaryOperator expression)
        {
            ConstantExpression left = (ConstantExpression)expression.Left;
            if (left.Name == "2")
            {
                return expression.Right.Clone();
            }
            return null;
        }

        public override IExpression VisitUnary(UnaryOperator expression)
        {
            return null;
        }
    }
}
