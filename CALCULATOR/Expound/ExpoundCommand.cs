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
            namesTable.TryAddName("y", new FuncExpression("sin", new BinaryOperator("+", new NameExpression("z"), new NameExpression("x"))));
            namesTable.TryAddName("x", new FuncExpression("cos", new NameExpression("t")));
            namesTable.TryAddName("t", new ConstantExpression("10"));

            var visitor = new ExpoundVisitor(namesTable);
            namesTable.TryAddName("y1", namesTable.NameSearch("y"));
            namesTable.NameSearch("y1").Accept(visitor);   
        }
    }
}
