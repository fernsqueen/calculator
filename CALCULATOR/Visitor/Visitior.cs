using CALCULATOR.Expression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALCULATOR.Expound
{
    public abstract class Visitior
    {
        virtual public IExpression VisitName(NameExpression expression)
        {
            return null;
        }

        virtual public IExpression VisitFunc(FuncExpression expression)
        {
            return null;
        }

        virtual public IExpression VisitConst(ConstantExpression expression)
        {
            return null;
        }

        virtual public IExpression VisitBinary(BinaryOperator expression)
        {
            return null;
        }

        virtual public IExpression VisitUnary(UnaryOperator expression)
        {
            return null;
        }
    }
}
