using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public enum Color
    {
        Red, Green, Blue
    }

    public enum Size
    {
        Small, Meduim, Large, Huge
    }
    
    public class Product
    {
        public string Name;
        public Color Color;
        public Size Size;
        public Product(string name, Color color, Size size)
        {
            Name = name;
            Color = color;
            Size = size;
        }

    }

    public class ProductFilter
    {
        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var p in products)
                if (p.Size == size)
                    yield return p;
        }

        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (var p in products)
                if (p.Color == color)
                    yield return p;
        }
    }
}
