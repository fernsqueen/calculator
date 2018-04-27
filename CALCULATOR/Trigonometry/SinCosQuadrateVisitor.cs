using CALCULATOR.Expound;
using CALCULATOR.Expression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALCULATOR.Trigonometry
{
    public class SinCosQuadrateVisitor : Visitior
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
            /* return new BinaryOperator("/", new BinaryOperator("-", new ConstantExpression("1"),
                new FuncExpression("cos", new BinaryOperator("*", new ConstantExpression("2"),
                expression.Argument))), new ConstantExpression("2"));
            return new BinaryOperator("/", new BinaryOperator("+", new ConstantExpression("1"),
    new FuncExpression("cos", new BinaryOperator("*", new ConstantExpression("2"),
    expression.Argument))), new ConstantExpression("2"));
            */
            return null;
        }

        public override IExpression VisitUnary(UnaryOperator expression)
        {
            return null;
        }
    }
}
