using CALCULATOR.Expression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALCULATOR.Expound
{
    abstract class Visitior
    {
        virtual public void VisitName(NameExpression expression)
        {
        }

        virtual public void VisitFunc(FuncExpression expression)
        {
        }

        virtual public void VisitConst(ConstantExpression expression)
        {
        }

        virtual public void VisitBinary(BinaryOperator expression)
        {
        }

        virtual public void VisitUnary(UnaryOperator expression)
        {
        }
    }
}
