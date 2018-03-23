using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALCULATOR.Equation
{
    class QuadraticEquation : IEquation
    {
        public float A { get; private set; }
        public float B { get; private set; }
        public float C { get; private set; }

        public float Discriminant { get; private set; }

        public void DrawGraph()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Ниже просто реализация этих трёх строчек, которые я получила, посмотрев в отладчике на расположение элементов дерева
        /// </summary>
        /// <param name="equationTypeNode"></param>
        //// Квадратное вида A*x^2+C=0: A=[0], C=[5], 7 элементов
        //// Квадратное вида A*x^2+Bx=0: A=[0], B=[5], 10 элементов
        //// Квадратное вида A*x^2+Bx+c=0: A=[0], B=[5], C=[1], 12 элементов
        public QuadraticEquation(ParseTreeNode equationTypeNode)
        {
            A = int.Parse(equationTypeNode.ChildNodes[0].ToString()[0].ToString());

            if (equationTypeNode.ChildNodes.Count() == 7)
            {
                B = 0;
                if (equationTypeNode.ChildNodes[4].ToString()[0].ToString() == "-")
                {
                    C = -int.Parse(equationTypeNode.ChildNodes[5].ToString()[0].ToString());
                }
                else
                {
                    C = int.Parse(equationTypeNode.ChildNodes[5].ToString()[0].ToString());
                }
            }
            else if (equationTypeNode.ChildNodes.Count() == 10)
            {
                C = 0;
                if (equationTypeNode.ChildNodes[4].ToString()[0].ToString() == "-")
                {
                    B = -int.Parse(equationTypeNode.ChildNodes[5].ToString()[0].ToString());
                }
                else
                {
                    B = int.Parse(equationTypeNode.ChildNodes[5].ToString()[0].ToString());
                }
            }
            else
            {
                if (equationTypeNode.ChildNodes[4].ToString()[0].ToString() == "-")
                {
                    B = -int.Parse(equationTypeNode.ChildNodes[5].ToString()[0].ToString());
                }
                else
                {
                    B = int.Parse(equationTypeNode.ChildNodes[5].ToString()[0].ToString());
                }
                if (equationTypeNode.ChildNodes[8].ToString()[0].ToString() == "-")
                {
                    C = -int.Parse(equationTypeNode.ChildNodes[9].ToString()[0].ToString());
                }
                else
                {
                    C = int.Parse(equationTypeNode.ChildNodes[9].ToString()[0].ToString());
                }
            }
            
            if ((A!=0) && (B!=0) && (C != 0))
            {
                Discriminant = B * B - 4 * A * C;
            }
        }
    }
}
