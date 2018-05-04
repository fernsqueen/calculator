using CALCULATOR.Expression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALCULATOR.Calculation
{
    public class Calculate
    {
        public ConstantExpression FuncCalculate(FuncExpression expression)
        {
            if (expression.Name == "sin") return SinCalculation(expression);
            if (expression.Name == "cos") return CosCalculation(expression);
            if (expression.Name == "asin") return AsinCalculation(expression);
            if (expression.Name == "acos") return AcosCalculation(expression);
            if (expression.Name == "ln") return LnCalculation(expression);
            return null;
        }

        public ConstantExpression BinaryCalculate(BinaryOperator expression)
        {
            if (expression.Name == "+") return AddCalculation(expression);
            if (expression.Name == "-") return DivCalculation(expression);
            if (expression.Name == "*") return MulCalculation(expression);
            if (expression.Name == "/") return SubCalculation(expression);
            if (expression.Name == "^") return PowCalculation(expression);
            if (expression.Name == "log") return LogCalculation(expression);
            return null;
        }

        private ConstantExpression AddCalculation(BinaryOperator expression)
        {
            ConstantExpression left = (ConstantExpression)expression.Left;
            ConstantExpression right = (ConstantExpression)expression.Right;
            double result = Double.Parse(left.Name) + Double.Parse(right.Name);
            return new ConstantExpression(result.ToString());
        }

        private ConstantExpression DivCalculation(BinaryOperator expression)
        {
            ConstantExpression left = (ConstantExpression)expression.Left;
            ConstantExpression right = (ConstantExpression)expression.Right;
            double result = Double.Parse(left.Name) - Double.Parse(right.Name);
            return new ConstantExpression(result.ToString());
        }

        private ConstantExpression MulCalculation(BinaryOperator expression)
        {
            ConstantExpression left = (ConstantExpression)expression.Left;
            ConstantExpression right = (ConstantExpression)expression.Right;
            double result = Double.Parse(left.Name) * Double.Parse(right.Name);
            return new ConstantExpression(result.ToString());
        }

        private ConstantExpression SubCalculation(BinaryOperator expression)
        {
            ConstantExpression left = (ConstantExpression)expression.Left;
            ConstantExpression right = (ConstantExpression)expression.Right;
            double result = Double.Parse(left.Name) / Double.Parse(right.Name);
            return new ConstantExpression(result.ToString());
        }

        private ConstantExpression PowCalculation(BinaryOperator expression)
        {
            ConstantExpression left = (ConstantExpression)expression.Left;
            ConstantExpression right = (ConstantExpression)expression.Right;
            double result = Math.Pow(Double.Parse(left.Name), Double.Parse(right.Name));
            return new ConstantExpression(result.ToString());
        }

        private ConstantExpression LogCalculation(BinaryOperator expression)
        {
            ConstantExpression left = (ConstantExpression)expression.Left;
            ConstantExpression right = (ConstantExpression)expression.Right;
            double result = Math.Log(Double.Parse(right.Name), Double.Parse(left.Name));
            return new ConstantExpression(result.ToString());
        }

        private ConstantExpression SinCalculation(FuncExpression expression)
        {
            ConstantExpression argument = (ConstantExpression)expression.Argument;
            double result = Math.Sin(Double.Parse(argument.Name));
            return new ConstantExpression(result.ToString());
        }

        private ConstantExpression CosCalculation(FuncExpression expression)
        {
            ConstantExpression argument = (ConstantExpression)expression.Argument;
            double result = Math.Cos(Double.Parse(argument.Name));
            return new ConstantExpression(result.ToString());
        }

        private ConstantExpression AcosCalculation(FuncExpression expression)
        {
            ConstantExpression argument = (ConstantExpression)expression.Argument;
            double result = Math.Acos(Double.Parse(argument.Name));
            return new ConstantExpression(result.ToString());
        }

        private ConstantExpression AsinCalculation(FuncExpression expression)
        {
            ConstantExpression argument = (ConstantExpression)expression.Argument;
            double result = Math.Asin(Double.Parse(argument.Name));
            return new ConstantExpression(result.ToString());
        }

        private ConstantExpression LnCalculation(FuncExpression expression)
        {
            ConstantExpression argument = (ConstantExpression)expression.Argument;
            double result = Math.Log(Double.Parse(argument.Name));
            return new ConstantExpression(result.ToString());
        }
    }
}
