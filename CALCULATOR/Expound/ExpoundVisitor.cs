using CALCULATOR.Expression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALCULATOR.Expound
{
    class ExpoundVisitor : Visitior
    {
        public override void VisitName(NameExpression expression)
        {
            return;
        }

        public override void VisitFunc(FuncExpression expression)
        {
            foreach (var child in expression.ChildNodes)
            {
                if (child.GetType() == typeof(NameExpression))
                {
                    NameExpression child1 = (NameExpression)child;
                    IExpression newArgument = thisNamesTable.NameSearch(child1.Name);
                    if (newArgument != null)
                    {
                        expression.ExpoundArgument(newArgument);
                    }
                }

                child.Accept(this);
            }
        }

        public override void VisitConst(ConstantExpression expression)
        {
            return;
        }

        public override void VisitBinary(BinaryOperator expression)
        {
            foreach (var child in expression.ChildNodes)
            {
                if (child.GetType() == typeof(NameExpression))
                {
                    NameExpression child1 = (NameExpression)child;
                    IExpression newArgument = thisNamesTable.NameSearch(child1.Name);
                    if (newArgument != null)
                    {
                        expression.ExpoundArgument(newArgument, child1.Name);
                    }
                }

                child.Accept(this);
            }
        }

        public override void VisitUnary(UnaryOperator expression)
        {
            foreach (var child in expression.ChildNodes)
            {
                if (child.GetType() == typeof(NameExpression))
                {
                    NameExpression child1 = (NameExpression)child;
                    IExpression newArgument = thisNamesTable.NameSearch(child1.Name);
                    if (newArgument != null)
                    {
                        expression.ExpoundArgument(newArgument);
                    }
                }

                child.Accept(this);
            }
        }

        NamesTable thisNamesTable { get; set; }

        public ExpoundVisitor(NamesTable namesTable)
        {
            thisNamesTable = namesTable;
        }
    }
}
