using CALCULATOR.Expression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALCULATOR.Expound
{
    class ExpoundVisitor : Visitior
    {
        public override IExpression VisitName(NameExpression expression)
        {
            IExpression name = expression;
            if (NameTable.TryGetValue(expression.Name, out name))
            {
                return name.Clone().Accept(this);
            }
            else
            {
                return expression.Clone();
            }
        }

        public override IExpression VisitFunc(FuncExpression expression)
        {
            return new FuncExpression(expression.Name, expression.Argument.Accept(this));
        }

        public override IExpression VisitConst(ConstantExpression expression)
        {
            return expression.Clone();
        }

        public override IExpression VisitBinary(BinaryOperator expression)
        {
            return new BinaryOperator(expression.Name, expression.Left.Clone().Accept(this), expression.Right.Clone().Accept(this));
        }

        public override IExpression VisitUnary(UnaryOperator expression)
        {
            return new UnaryOperator(expression.Name, expression.Right.Clone().Accept(this));
        }

        Dictionary<string, IExpression> NameTable { get; set; }

        public ExpoundVisitor(Dictionary<string, IExpression> namesTable)
        {
            NameTable = namesTable;
        }
    }
}
