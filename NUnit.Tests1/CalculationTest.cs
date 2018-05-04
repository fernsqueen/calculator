using CALCULATOR.Calculation;
using CALCULATOR.Expression;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests1
{
    [TestFixture]
    public class Calculation
    {
        [Test]
        public void TestBinaryCalculations()
        {
            var visitor = new CalculationVisitor();

            var x1 = new BinaryOperator("+", new ConstantExpression("4"), new ConstantExpression("5"));
            var x2 = x1.Accept(visitor);
            Console.WriteLine("{0} => {1}", x1.Representation(), x2.Representation());

            var y1 = new BinaryOperator("-", new ConstantExpression("4"), new ConstantExpression("5"));
            var y2 = y1.Accept(visitor);
            Console.WriteLine("{0} => {1}", y1.Representation(), y2.Representation());

            var z1 = new BinaryOperator("/", new ConstantExpression("4"), new ConstantExpression("5"));
            var z2 = z1.Accept(visitor);
            Console.WriteLine("{0} => {1}", z1.Representation(), z2.Representation());

            var m1 = new BinaryOperator("*", new ConstantExpression("4"), new ConstantExpression("5"));
            var m2 = m1.Accept(visitor);
            Console.WriteLine("{0} => {1}", m1.Representation(), m2.Representation());

            var n1 = new BinaryOperator("^", new ConstantExpression("4"), new ConstantExpression("5"));
            var n2 = n1.Accept(visitor);
            Console.WriteLine("{0} => {1}", n1.Representation(), n2.Representation());

            var a1 = new BinaryOperator("log", new ConstantExpression("4"), new ConstantExpression("16"));
            var a2 = a1.Accept(visitor);
            Console.WriteLine("{0} => {1}", a1.Representation(), a2.Representation());

            var b1 = new BinaryOperator("+", new NameExpression("y"), new BinaryOperator("log", new ConstantExpression("4"), new ConstantExpression("16")));
            var b2 = b1.Accept(visitor);
            Console.WriteLine("{0} => {1}", b1.Representation(), b2.Representation());
        }

        [Test]
        public void TestFuncCalculations()
        {
            var visitor = new CalculationVisitor();

            var x1 = new FuncExpression("sin", new ConstantExpression("0"));
            var x2 = x1.Accept(visitor);
            Console.WriteLine("{0} => {1}", x1.Representation(), x2.Representation());

            var y1 = new FuncExpression("cos", new ConstantExpression("0"));
            var y2 = y1.Accept(visitor);
            Console.WriteLine("{0} => {1}", y1.Representation(), y2.Representation());

            var z1 = new FuncExpression("asin", new ConstantExpression("0,5"));
            var z2 = z1.Accept(visitor);
            Console.WriteLine("{0} => {1}", z1.Representation(), z2.Representation());

            var m1 = new FuncExpression("acos", new ConstantExpression("0,5"));
            var m2 = m1.Accept(visitor);
            Console.WriteLine("{0} => {1}", m1.Representation(), m2.Representation());

            var n1 = new FuncExpression("ln", new ConstantExpression("9"));
            var n2 = n1.Accept(visitor);
            Console.WriteLine("{0} => {1}", n1.Representation(), n2.Representation());

            var b1 = new BinaryOperator("+", new NameExpression("y"), new FuncExpression("sin", new ConstantExpression("0")));
            var b2 = b1.Accept(visitor);
            Console.WriteLine("{0} => {1}", b1.Representation(), b2.Representation());

            var a1 = new BinaryOperator("+", new ConstantExpression("5"), new FuncExpression("sin", new ConstantExpression("0")));
            var a2 = a1.Accept(visitor);
            Console.WriteLine("{0} => {1}", a1.Representation(), a2.Representation());
        }
    }
}
