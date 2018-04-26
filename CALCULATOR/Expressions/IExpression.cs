using CALCULATOR.Expound;

namespace CALCULATOR
{
    interface IExpression
    {
        string Representation();
        IExpression Clone();
        IExpression Accept(Visitior v);
    }
}
