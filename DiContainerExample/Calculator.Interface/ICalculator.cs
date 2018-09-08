using System;

namespace Calculator.Interface
{
    public interface ICalculate<T>
    {
        T Calculate(T v1, T v2);
    }
}
