using CALCULATOR.Expound;
using CALCULATOR.Expression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALCULATOR.Calculation
{
    public class CalculationVisitor : Visitior
    {
        public override IExpression VisitName(NameExpression expression)
        {
            return expression.Clone();
        }

        public override IExpression VisitFunc(FuncExpression expression)
        {
            var argument = expression.Argument.Accept(this);
            if (argument is ConstantExpression)
            {
                var calculator = new Calculate();
                return calculator.FuncCalculate(new FuncExpression(expression.Name, argument));
            }
            return new FuncExpression(expression.Name, argument);
        }

        public override IExpression VisitConst(ConstantExpression expression)
        {
            return expression.Clone();
        }

        public override IExpression VisitBinary(BinaryOperator expression)
        {
            var left = expression.Left.Accept(this);
            var right = expression.Right.Accept(this);
            if ((left is ConstantExpression) && (right is ConstantExpression))
            {
                var calculator = new Calculate();
                return calculator.BinaryCalculate(new BinaryOperator(expression.Name, left, right));
            }
            return new BinaryOperator(expression.Name, left, right);
        }

        public override IExpression VisitUnary(UnaryOperator expression)
        {
            return expression.Clone();
        }
    }
}
