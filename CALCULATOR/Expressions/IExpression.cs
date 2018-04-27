using CALCULATOR.Expound;

namespace CALCULATOR
{
    public interface IExpression
    {
        string Representation();
        IExpression Clone();
        IExpression Accept(Visitior v);
    }
}
