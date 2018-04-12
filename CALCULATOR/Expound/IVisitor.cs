using CALCULATOR.Expression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALCULATOR.Expound
{
    interface IVisitor
    {
        void VisitFunctionExpression(FuncExpression expr);
    }
}
