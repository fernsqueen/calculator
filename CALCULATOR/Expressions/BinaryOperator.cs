using CALCULATOR.Expound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALCULATOR.Expression
{
    class BinaryOperator : IExpression
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

        public IExpression Left { get; private set; }

        public IExpression Right { get; private set; }

        public BinaryOperator(string name, IExpression left, IExpression right)
        {
            this.Name = name;
            this.Left = left;
            this.Right = right;
            this.ChildNodes.Add(Left);
            this.ChildNodes.Add(Right);
        }

        public List<IExpression> ChildNodes = new List<IExpression>();

        public void ExpoundArgument(IExpression newArgument, int index)
        {

            if (index == 0)
            {
                this.Left = newArgument;
            }
            else
            {
                this.Right = newArgument;
            }
            this.ChildNodes.Clear();
            this.ChildNodes.Add(Left);
            this.ChildNodes.Add(Right);
        }

        public IExpression Accept(Visitior v)
        {
            return v.VisitBinary(this);
        }

    }
}
