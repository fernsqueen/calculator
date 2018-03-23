using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleUI;
using Irony.Parsing;
using CALCULATOR.Equation;

namespace CALCULATOR
{
    class EquationCommand : ICommand
    {
        Application app;

        public string Name { get { return "equation"; } }
        public string Help { get { return "get the equation solution"; } }
        public string[] Synonyms
        {
            get { return new string[] { "equat" }; }
        }
        public string Description
        {
            get { return " "; }
        }

        public EquationCommand(Application app)
        {
            this.app = app;
        }
        public void Execute(params string[] parameters)
        {
            if (parameters.Length != 1)
            {
                Console.WriteLine("Параметр - уравнение без пробелов");
                return;
            }
            EquationGrammar g = new EquationGrammar();
            LanguageData grammar = new LanguageData(g);
            Parser parser = new Parser(grammar);
            ParseTree parseTree = parser.Parse(parameters[0]);
            if (parseTree.Root == null)
            {
                Console.WriteLine("Вид уравнений  A*x^2+Bx+c=0");
                return;
            }

            ParseTreeNode lastNode = parseTree.Root.ChildNodes.Last();
            if (lastNode.ToString() == "QuadraticEquation")
            {
                var quadrEquat = new QuadraticEquation(lastNode);
                if (quadrEquat.A == 0)
                {
                    Console.WriteLine("0 перед x^2");
                    return;
                }
                if (quadrEquat.B == 0)
                {
                    if (quadrEquat.C > 0)
                    {
                        Console.WriteLine("Нет решений");
                        return;
                    }
                    float x = (float)Math.Sqrt(quadrEquat.C / quadrEquat.A);
                    Console.WriteLine("x = {0}", x);
                    return;
                }
                if (quadrEquat.C == 0)
                {
                    float x = - quadrEquat.B / quadrEquat.A;
                    Console.WriteLine("x1 = 0, x2 = {0}", x);
                    return;
                }

                if (quadrEquat.Discriminant < 0)
                {
                    Console.WriteLine("Нет решений");
                    return;
                }
                if (quadrEquat.Discriminant == 0)
                {
                    Console.WriteLine("x = -{0} / 2*{1}", quadrEquat.B, quadrEquat.A);
                    return;
                }
                Console.WriteLine("x = (-{0} +- SQRT({1}) / 2*{2}", quadrEquat.B, quadrEquat.Discriminant, quadrEquat.A);
            }
  
        }

        private const string line = "================================================";
        private const string line1 = "...............................................";

    }
}

