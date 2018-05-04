using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleUI;
using CALCULATOR.Expression;
using CALCULATOR.Expound;
using CALCULATOR.Calculation;

namespace CALCULATOR
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new Application();
            var namesTable = new NamesTable();

            app.AddCommand(new ExitCommand(app));
            app.AddCommand(new ExpoundCommand(namesTable));

            app.Run(Console.In);


            ///var result = new OldQuadraticEquation();
            ///OldQuadraticEquation.TryParse("x^2+2x-3=0", out result);
        }
    }
}
