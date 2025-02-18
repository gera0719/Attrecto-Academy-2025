using System.Numerics;

namespace CalculatorPackage
{
    public class Calculator<T> where T : INumber<T>
    {
        public T Add(T a, T b)
        {
            return a + b;
        }
        public T Subtract(T a, T b)
        {
            return a - b;
        }
        public T Multiply(T a, T b)
        {
            return a * b;
        }
        public T Divide(T a, T b)
        {
            if (b == T.Zero)
            {
                throw new DivideByZeroException("Division by zero is not defined");
            }
            return a / b;
        }
    }
}