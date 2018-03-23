using Irony.Parsing;
using Irony.Ast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Interpreter.Ast;

[Language("Equation")]
public class EquationGrammar : Grammar
{
    public EquationGrammar()
    {

        /// nonterms
        ///  var A = new NonTerminal("coefficient A");
        ///  var B = new NonTerminal("coefficient B");
        ///  var C = new NonTerminal("coefficient C");
        var degree = ToTerm("^");
        // Terminal n = new NumberLiteral("number"); /// нужен терминал для числа
        //  Terminal v = new IdentifierTerminal("variable");

        NonTerminal n = new NonTerminal("number"); /// нужен терминал для любых чисел
        NonTerminal v = new NonTerminal("variable", typeof(BinaryOperationNode));

        ////  var n1 = new NumberOptions("n2");

        ////var NUMBER = new NumberLiteral("NUMBER", NumberOptions.IntOnly);

        Terminal number = new NumberLiteral("number");


        // 2. Non-terminals
        NonTerminal sEquation = new NonTerminal("SimpleEquation", typeof(BinaryOperationNode));
        NonTerminal qEquation = new NonTerminal("QuadraticEquation", typeof(BinaryOperationNode));
        NonTerminal Equation = new NonTerminal("Equation", typeof(BinaryOperationNode));
        NonTerminal BinOp = new NonTerminal("BinOp", typeof(BinaryOperationNode));

        //  NonTerminal UnOp = new NonTerminal("UnOp");
        //  NonTerminal ExprLine = new NonTerminal("ExprLine");

        // 3. BNF rules
        Equation.Rule = sEquation | qEquation;

        /// Я уверена, что можно сделать проще, но без конкретных +/- я пока не знаю как, мб таки нужно строить АСТ

        sEquation.Rule = number + "*" + v + "+" + number + "=" + "0" |
                          number + "*" + v + "-" + number + "=" + "0" |
                           number + "*" + v + "=" + number;


        qEquation.Rule = number + "*" + v + "^2" + "+" + number + "*" + v + "+" + number + "=" + "0" |
                          number + "*" + v + "^2" + "+" + number + "*" + v + "-" + number + "=" + "0" |
                           number + "*" + v + "^2" + "-" + number + "*" + v + "-" + number + "=" + "0" |
                             number + "*" + v + "^2" + "-" + number + "*" + v + "-" + number + "=" + "0" |
                               number + "*" + v + "^2" + "+" + number + "*" + v + "=" + "0" |
                                number + "*" + v + "^2" + "-" + number + "*" + v + "=" + "0" |
                                 number + "*" + v + "^2" + "+" + number + "=" + "0";

        BinOp.Rule = ToTerm("+") | "-";
        n.Rule = ToTerm("2") | "1" | "0" | "3" | "4" | "5" | "6" | "7" | "8" | "9"; 
        v.Rule = ToTerm("x") | "y" | "z";
       /// NUMBER.R

        Root = Equation;


        /*

        Expr.Rule = n | v | Expr + BinOp + Expr | UnOp + Expr |
                          "(" + Expr + ")";
        BinOp.Expression = Symbol("+") | "-" | "*" | "/" | "**";
        UnOp.Expression = "-";            //Irony provides default conversion here 
        ExprLine.Expression = Expr + Eof; //Eof is a predefined EOF terminal
        this.Root = ExprLine;             //Set grammar top element

        // 4. Set operators precedence and associativity
        RegisterOperators(1, "+", "-");
        RegisterOperators(2, "*", "/");
        RegisterOperators(3, Associativity.Right, "**");

        // 5. Register parenthesis as punctuation symbols
        //    so they will not appear in the syntax tree
        MarkPunctuation.Add
        PunctuationSymbols.AddRange(new string[] { "(", ")" });



        //syntax terminals
        var lpar = ToTerm("(");
        var rpar = ToTerm(")");
        var comma = ToTerm(",");
        var trueTerm = ToTerm("1") | "true";
        var falseTerm = ToTerm("0") | "false";

        //nonterms
        var predicate = new NonTerminal("Predicate");
        var connective = new NonTerminal("Connective");
        var pexp = new NonTerminal("PredExpression");
        var formula = new NonTerminal("Formula");
        var literal = new NonTerminal("Literal");
        var singleTerm = new NonTerminal("SingleTerm");
        var multiTerm = new NonTerminal("MultiTerm");

        //formulat non terms
        var negation = new NonTerminal("Negation");
        var implication = new NonTerminal("Implication");
        var biImplication = new NonTerminal("Bi-Implication");
        var andTerm = new NonTerminal("And");
        var orTerm = new NonTerminal("Or");

        literal.Rule = trueTerm | falseTerm;
        singleTerm.Rule = lpar + pexp + rpar; //single term is (pexp)
        multiTerm.Rule = lpar + pexp + comma + pexp + rpar; //mult term = (pexp, pexp)

        //formula rules
        negation.Rule = ToTerm("~") + singleTerm;
        implication.Rule = ToTerm(">") + multiTerm;
        biImplication.Rule = ToTerm("=") + multiTerm;
        andTerm.Rule = ToTerm("&") + multiTerm;
        orTerm.Rule = ToTerm("|") + multiTerm;

        //predicate terms
        predicate.Rule = ToTerm("A") | "B" | "C" | "D" | "E" | "F" | "G" |
                            "H" | "I" | "J" | "K" | "L" | "M" | "N" | "O" |
                            "P" | "Q" | "R" | "S" | "T" | "U" | "V" | "W" |
                            "X" | "Y" | "Z" | literal;

        //predicate rule
        pexp.Rule = predicate | negation | implication | biImplication | andTerm | orTerm;

        //a base formulat
        formula.Rule = MakeStarRule(formula, pexp);

        RegisterOperators(10, "&", "~", ">", "=", "|");
        MarkPunctuation(",", "(", ")");
        MarkTransient(pexp, singleTerm);

        Root = formula;
        */
    }
}

