using CALCULATOR.Expound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALCULATOR.Expression
{
    public class UnaryOperator : IExpression
    {
        public string Representation()
        {
            return Name + Right.Representation();
        }

        public IExpression Clone()
        {
            return new UnaryOperator(Name, Right.Clone());
        }

        public string Name { get; private set; }

        public IExpression Right { get; private set; }

        public UnaryOperator(string name, IExpression right)
        {
            this.Name = name;
            this.Right = right;
        }

        public IExpression Accept(Visitior v)
        {
            return v.VisitUnary(this);
        }
    }
}
