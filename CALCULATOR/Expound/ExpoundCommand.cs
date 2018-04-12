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
        Application app;
        public ExpoundCommand(Application app)
        {
            this.app = app;
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
            
        }
    }
}
