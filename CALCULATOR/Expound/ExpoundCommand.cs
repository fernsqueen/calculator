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
        public string Help { get { return "Подстановка значений переменных. Параметр - имя выражения."; } }
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
            var nameTable = new Dictionary<string, IExpression>();
            nameTable["y"] = new FuncExpression("sin", new BinaryOperator("+", new NameExpression("z"), new NameExpression("x")));
            nameTable["x"] = new FuncExpression("cos", new NameExpression("t"));
            nameTable["t"] = new ConstantExpression("10");

            IExpression y1 = null;
            nameTable.TryGetValue("y", out y1);
            nameTable["y1"] = y1;

            var visitor = new ExpoundVisitor(nameTable);


            Console.WriteLine(y1.Accept(visitor).Representation());


        }
    }
}
