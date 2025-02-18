namespace CalculatorPackage
{
    public class Calculator
    {
        int Add( int a, int b)
        {
            return a + b;
        }
        int Subtract( int a, int b)
        {
            return a - b;
        }
        int Multiply( int a, int b)
        {
            return a * b;
        }
        int Divide( int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Division by zero is not defined");
            }
            return a / b;
        }
    }
}
