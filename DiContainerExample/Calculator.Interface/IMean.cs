using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Interface
{
    public interface IMean<T> : ICalculate<T>
    {
        T Calculate(List<T> values);
    }
}
