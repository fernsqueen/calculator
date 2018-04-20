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
            if (expression.ChildNodes[0].GetType() == typeof(NameExpression))
            {
                NameExpression child = (NameExpression)expression.ChildNodes[0];
                IExpression newArgument = thisNamesTable.NameSearch(child.Name);
                if (newArgument != null)
                {
                    expression.ExpoundArgument(newArgument);
                    expression.ChildNodes[0].Accept(this);
                }
            }
            expression.ChildNodes[0].Accept(this);
        }

        public override void VisitConst(ConstantExpression expression)
        {
            return;
        }

        public override void VisitBinary(BinaryOperator expression)
        {
            for (int i = 0; i < 2; i++)
            {
                if (expression.ChildNodes[i].GetType() == typeof(NameExpression))
                {
                    NameExpression child = (NameExpression)expression.ChildNodes[i];
                    IExpression newArgument = thisNamesTable.NameSearch(child.Name);
                    if (newArgument != null)
                    {
                        expression.ExpoundArgument(newArgument, child.Name);
                    }
                }
            }
            foreach (var child in expression.ChildNodes)
            {
                child.Accept(this);
            }
        }

        public override void VisitUnary(UnaryOperator expression)
        {
            if (expression.ChildNodes[0].GetType() == typeof(NameExpression))
            {
                NameExpression child = (NameExpression)expression.ChildNodes[0];
                IExpression newArgument = thisNamesTable.NameSearch(child.Name);
                if (newArgument != null)
                {
                    expression.ExpoundArgument(newArgument);
                    expression.ChildNodes[0].Accept(this);
                }
            }
            expression.ChildNodes[0].Accept(this);
        }

        NamesTable thisNamesTable { get; set; }

        public ExpoundVisitor(NamesTable namesTable)
        {
            thisNamesTable = namesTable;
        }
    }
}
