using CALCULATOR.Expound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALCULATOR
{
    interface IExpression
    {
        string Representation();
        IExpression Clone();
        void Accept(Visitior v);
    }
}
