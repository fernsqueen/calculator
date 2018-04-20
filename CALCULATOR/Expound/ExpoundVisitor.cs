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
        public override IExpression VisitName(NameExpression expression)
        {
            if (thisNamesTable.NameSearch(expression.Name) != null)
            {
                thisNamesTable.NameSearch(expression.Name).Accept(this);
                return thisNamesTable.NameSearch(expression.Name);
            }
            else return expression;
        }

        public override IExpression VisitFunc(FuncExpression expression)
        {
            expression.ExpoundArgument(expression.ChildNodes[0].Accept(this));
            return expression;
        }

        public override IExpression VisitConst(ConstantExpression expression)
        {
            return expression;
        }

        public override IExpression VisitBinary(BinaryOperator expression)
        {
            for (int i = 0; i<2; i++)
            {
                expression.ExpoundArgument(expression.ChildNodes[i].Accept(this), i); 
            }
            return expression;
        }

        public override IExpression VisitUnary(UnaryOperator expression)
        {
            expression.ExpoundArgument(expression.ChildNodes[0].Accept(this));
            return expression;
        }

        NamesTable thisNamesTable { get; set; }

        public ExpoundVisitor(NamesTable namesTable)
        {
            thisNamesTable = namesTable;
        }
    }
}
