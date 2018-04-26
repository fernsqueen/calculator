using NUnit.Framework;
using System;
using System.Collections.Generic;
using CALCULATOR;

namespace NUnit.Tests1
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestMethod()
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
