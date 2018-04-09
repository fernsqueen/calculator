using Irony.Parsing;
using Irony.Ast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Interpreter.Ast;

[Language("Expression")]
public class ExpressionGrammar : Grammar
{
    public ExpressionGrammar()
    {
        NonTerminal expression = new NonTerminal("expression");

        NonTerminal funcExpression = new NonTerminal("FuncExpression");
        NonTerminal binaryOperator = new NonTerminal("BinaryOperator");
        NonTerminal unaryOperator = new NonTerminal("unaryOperator");
        Terminal constantExpression = new NumberLiteral("ConstantExpression");
        NonTerminal nameExpression = new NonTerminal("NameExpression");


        NonTerminal unaryMinus = new NonTerminal("unaryMinus");
        NonTerminal sin = new NonTerminal("Sin");
        NonTerminal cos = new NonTerminal("Cos");
        NonTerminal ln = new NonTerminal("Ln");

        expression.Rule = constantExpression | funcExpression | unaryMinus+expression | nameExpression | 
                                          expression + binaryOperator + expression;
        funcExpression.Rule = sin | cos | ln;
        unaryMinus.Rule = ToTerm("-");
        sin.Rule = ToTerm("sin") + ToTerm("(") + expression + ToTerm(")");
        cos.Rule = ToTerm("cos") + ToTerm("(")+ expression + ToTerm(")");
        ln.Rule = ToTerm("ln") + ToTerm("(") + expression + ToTerm(")");

        nameExpression.Rule = ToTerm("a") | "b" | "c" | "d" | "e" | "f" | "g" |
                            "h" | "i" | "j" | "k" | "l" | "m" | "n" | "o" |
                            "p" | "q" | "r" | "s" | "t" | "u" | "v" | "w" |
                            "x" | "y" | "z" ;

        binaryOperator.Rule = ToTerm("+") | "-" | "^" | "/" | "*";
        RegisterOperators(1, "+", "-");
        RegisterOperators(2, "*", "/");
        RegisterOperators(3, Associativity.Right, "^");


        Root = expression;

    }
}
