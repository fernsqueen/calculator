using CALCULATOR.Expound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALCULATOR.Expression
{
    public class BinaryOperator : IExpression
    {

        public string Representation()
        {
            if ((Name == "+") || (Name == "-"))
            {
                return "(" + Left.Representation() + Name + Right.Representation() + ")";
            }

            return Left.Representation() + Name + Right.Representation();
        }

        public IExpression Clone()
        {
            return new BinaryOperator(Name, Left, Right);
        }

        public string Name { get; private set; }

        public IExpression Left { get; private set; }

        public IExpression Right { get; private set; }

        public BinaryOperator(string name, IExpression left, IExpression right)
        {
            this.Name = name;
            this.Left = left;
            this.Right = right;
        }

        public IExpression Accept(Visitior v)
        {
            return v.VisitBinary(this);
        }

    }
}
