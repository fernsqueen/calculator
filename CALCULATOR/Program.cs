using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleUI;

namespace CALCULATOR
{
    class Program
    {
        static void Main(string[] args)
        {
            ////var gr_test = new GrammarTest();
            /////gr_test.TestGr();
            var app = new Application();

            app.AddCommand(new ExitCommand(app));

            app.Run(Console.In);


            ///var result = new OldQuadraticEquation();
            ///OldQuadraticEquation.TryParse("x^2+2x-3=0", out result);
        }
    }
}
