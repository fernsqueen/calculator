using CALCULATOR.Expression;
using ConsoleUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALCULATOR.Expound
{
    class ExpoundCommand : ICommand
    {
        NamesTable namesTable;
        public ExpoundCommand(NamesTable namesTable)
        {
            this.namesTable = namesTable;
        }
        public string Name { get { return "expound"; } }
        public string Help { get { return "Подстановка переменной. Параметры: 1) в какое выражение подстановка 2) имя заменяемой переменной"; } }
        public string[] Synonyms
        {
            get { return new string[] { " " }; }
        }
        public string Description
        {
            get { return " "; }
        }
        public void Execute(params string[] parameters)
        {
            var expound = new Expound();

            string name1 = "y";
            string name2 = "x";

            namesTable.TryAddName("y", new FuncExpression("sin", new BinaryOperator("+", new ConstantExpression<int>("2"), new NameExpression("x"))));
            namesTable.TryAddName("x", new FuncExpression("cos", new NameExpression("t")));

            var root1 = namesTable.NameSearch(name1);
            var root2 = namesTable.NameSearch(name2);

            IExpression parent = null;
            
            if(expound.IsPartOfAST(name2, root1, ref parent))
            {
                if (parent.GetType() == typeof(FuncExpression))
                {
                    FuncExpression parent1 = (FuncExpression)parent;
                    parent1.ExpoundArgument(root2);
                }
                if (parent.GetType() == typeof(UnaryOperator))
                {
                    UnaryOperator parent1 = (UnaryOperator)parent;
                    parent1.ExpoundArgument(root2);
                }
                if (parent.GetType() == typeof(BinaryOperator))
                {
                    BinaryOperator parent1 = (BinaryOperator)parent;
                    parent1.ExpoundArgument(root2, name2);
                }
            }
        }
    }
}
