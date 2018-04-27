using CALCULATOR.Expound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALCULATOR.Expression
{
    public class FuncExpression : IExpression
    {
        public string Representation()
        {
            return Name + "(" + Argument.Representation() + ")";
        }

        public IExpression Clone()
        {
            return new FuncExpression(Name, Argument);
        }

        public string Name { get; private set; }

        public IExpression Argument { get; private set; }

        public FuncExpression(string name, IExpression argument)
        {
            this.Name = name;
            this.Argument = argument;
        }

        public IExpression Accept(Visitior v)
        {
            return v.VisitFunc(this);
        }

    }

}
