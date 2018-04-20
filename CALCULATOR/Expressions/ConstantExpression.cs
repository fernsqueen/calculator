using CALCULATOR.Expound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALCULATOR.Expression
{
    class ConstantExpression : IExpression
    {
        public string Representation()
        {
            return "";
        }

        public IExpression Clone()
        {
            return null;
        }

        public string Name { get; private set; }

        public ConstantExpression(string name)
        {
            this.Name = name;
        }

        public IExpression Accept(Visitior v)
        {
            return v.VisitConst(this);
        }
    }
}
