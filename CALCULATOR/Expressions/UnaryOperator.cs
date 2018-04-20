﻿using CALCULATOR.Expound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALCULATOR.Expression
{
    class UnaryOperator : IExpression
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

        public IExpression Right { get; private set; }

        public UnaryOperator(string name, IExpression right)
        {
            this.Name = name;
            this.Right = right;
            this.ChildNodes.Add(right);
        }

        public readonly List<IExpression> ChildNodes = new List<IExpression>();

        public void ExpoundArgument(IExpression newArgument)
        {
            this.Right = newArgument;
            this.ChildNodes.RemoveAt(0);
            this.ChildNodes.Add(newArgument);
        }

        public void Accept(Visitior v)
        {
            v.VisitUnary(this);
        }
    }
}
