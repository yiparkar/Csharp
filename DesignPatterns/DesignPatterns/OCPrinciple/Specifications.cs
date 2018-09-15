using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.OCPrinciple
{
    public class ColorSpecification : ISpecification<Product>
    {
        private Color _color;
        public ColorSpecification(Color color)
        {
            _color = color;
        }
        public bool IsSatified(Product t)
        {
            return _color == t.Color;
        }
    }
    public class SizeSpecification : ISpecification<Product>
    {
        private Size _size;
        public SizeSpecification(Size size)
        {
            _size = size;
        }
        public bool IsSatified(Product t)
        {
            return _size == t.Size;
        }
    }

    public class AndSpecification<T> : ISpecification<T>
    {
        ISpecification<T> first, second;
        public AndSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            this.first = first;
            this.second = second;
        }
        public bool IsSatified(T t)
        {
            return first.IsSatified(t) && second.IsSatified(t);
        }
    }

    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> specification)
        {
            foreach (var p in items)
                if (specification.IsSatified(p))
                    yield return p;
        }
    }
}
