using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALCULATOR
{
    class GrammarTest
    {
        public void TestGr()
        {
            EquationGrammar g = new EquationGrammar();
            LanguageData grammar = new LanguageData(g);
            Parser parser = new Parser(grammar);
            ParseTree parseTree = parser.Parse("2*x^2+2*x-9=0");


            //g.LanguageFlags = LanguageFlags.CreateAst;
            //g.LanguageFlags = LanguageFlags.CreateAst | LanguageFlags.NewLineBeforeEOF;
            ///LanguageFlags languageFlags = LanguageFlags.CreateAst;
            /// AstNode rootNode = parser.Parse("2*x-1=0");

            ////g.LanguageFlags = LanguageFlags.CreateAst | LanguageFlags.NewLineBeforeEOF;
            /// g.BuildAst(grammar, parseTree);
            ///parseTree.Root.
            // var a = parseTree.Root.AstNode;
            /// Console.WriteLine(parseTree.Root.AstNode);
            /// 

            //// В дереве(чтобы различать их)
            //// Квадратное вида A*x^2+B=0: A=[0], B=[5], 7 элементов
            //// Квадратное вида A*x^2+Bx=0: A=[0], B=[5], 10 элементов
            //// Квадратное вида A*x^2+Bx+c=0: A=[0], B=[5], C=[1], 12 элементов
            //// Нужно дописать преобразование если после равно не 0(позже, не суть важно)
            //// Простое вида А*х+B=0: A=[0], B=[4], 7 элементов
            //// Простое вида A*x=B: A=[0], B=[4], 5 элементов

            ParseTreeNode root = parseTree.Root;

            ParseTreeNode lastNode = root.ChildNodes.Last();
            Console.WriteLine((root == null ? "Parse tree unsuccessful!" : "Parse tree created!"));

            ///parseTree.
        }
    }
}
