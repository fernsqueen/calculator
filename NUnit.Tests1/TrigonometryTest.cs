using CALCULATOR.Expression;
using CALCULATOR.Trigonometry;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests1
{
    [TestFixture]
    public class TrigonometryTest
    {
        [Test]
        public void TestAddDiv()
        {
            var visitor = new AddDivVisitor();

            var x1 = new BinaryOperator("+", new FuncExpression("sin", new ConstantExpression("2")), 
                                          new FuncExpression("sin", new ConstantExpression("5")));
            var x2 = x1.Accept(visitor);
            Console.WriteLine("{0} => {1}", x1.Representation(), x2.Representation());

            var y1 = new BinaryOperator("-", new FuncExpression("sin", new ConstantExpression("2")),
                                         new FuncExpression("sin", new ConstantExpression("5")));
            var y2 = y1.Accept(visitor);
            Console.WriteLine("{0} => {1}", y1.Representation(), y2.Representation());

            var z1 = new BinaryOperator("+", new FuncExpression("cos", new ConstantExpression("2")),
                                         new FuncExpression("cos", new ConstantExpression("5")));
            var z2 = z1.Accept(visitor);
            Console.WriteLine("{0} => {1}", z1.Representation(), z2.Representation());

            var t1 = new BinaryOperator("-", new FuncExpression("cos", new ConstantExpression("2")),
                             new FuncExpression("cos", new ConstantExpression("5")));
            var t2 = t1.Accept(visitor);
            Console.WriteLine("{0} => {1}", t1.Representation(), t2.Representation());
        }

        [Test]
        public void TestSinCosQuadrate()
        {
            var visitor = new SinCosQuadrateVisitor();
            var y = new BinaryOperator("^", new FuncExpression("sin", new NameExpression("x")), new ConstantExpression("2"));
            var y1 = y.Accept(visitor);
            Console.WriteLine("{0} => {1}", y.Representation(), y1.Representation());

            var x = new BinaryOperator("^", new FuncExpression("cos", new NameExpression("x")), new ConstantExpression("2"));
            var x1 = x.Accept(visitor);
            Console.WriteLine("{0} => {1}", x.Representation(), x1.Representation());
        }

        [Test]
        public void DoubleAngle()
        {
            var visitor = new DoubleAngleVisitor();

            var y = new FuncExpression("sin", new BinaryOperator("*", new ConstantExpression("2"), new NameExpression("z")));
            var y1 = y.Accept(visitor);
            Console.WriteLine("{0} => {1}", y.Representation(), y1.Representation());

            var x = new FuncExpression("cos", new BinaryOperator("*", new ConstantExpression("2"), new NameExpression("y")));
            var x1 = x.Accept(visitor);
            Console.WriteLine("{0} => {1}", x.Representation(), x1.Representation());
        }
    }
}
