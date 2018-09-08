using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Interface
{
    public interface IFactorial<T> : ICalculate<T>
    {
        T Calculate(T value);
    }
}
