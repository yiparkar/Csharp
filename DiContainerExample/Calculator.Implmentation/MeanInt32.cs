using Calculator.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.Implementation
{
    public class MeanInt32 : IMean<Int32> 
    {
        List<Int32> _values;
        public MeanInt32(List<Int32> values)
        {
            _values = values;
        }

        public Int32 Calculate(Int32 v1, Int32 v2)
        {
            return (v1 + v2) / 2;
        }

        public Int32 Calculate(List<Int32> values)
        {
            return (values.Sum() / values.Count);
        }
    }
}
