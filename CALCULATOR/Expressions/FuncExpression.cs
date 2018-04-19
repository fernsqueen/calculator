using CALCULATOR.Expound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALCULATOR.Expression
{
    class FuncExpression : IExpression
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

        public IExpression Argument { get; private set; }

        public FuncExpression(string name, IExpression argument)
        {
            this.Name = name;
            this.Argument = argument;
            this.ChildNodes = new List<IExpression>();
            this.ChildNodes.Add(argument);
        }

        public readonly List<IExpression> ChildNodes;

        public void ExpoundArgument(IExpression newArgument)
        {
            this.Argument = newArgument;
        }

        public void Accept(Visitior v)
        {
            v.VisitFunc(this);
        }

    }

}
