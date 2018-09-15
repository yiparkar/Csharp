using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.OCPrinciple
{
    public class OpenClosePrincipleDemo : IExecutor
    {
        public OpenClosePrincipleDemo()
        {
            Console.WriteLine("**********Open Close principle*************");
        }
        public void Execute()
        {
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);
            Product[] products = { apple, tree, house };

            var pf = new ProductFilter();
            Console.WriteLine("Green products (old) :");
            foreach (var item in pf.FilterByColor(products, Color.Green))
            {
                Console.WriteLine($"- {item.Name} is green");
            }

            /// Open Close Principle
            /// Create a functionality which can be easily be extend with 
            /// the existing functionality without modifying the existing functionality

            var bf = new BetterFilter();
            Console.WriteLine("Green products (new) :");
            foreach (var item in bf.Filter(products, new ColorSpecification(Color.Green)))
            {
                Console.WriteLine($"- {item.Name} is green");
            }


            Console.WriteLine("Large and Blue products (new) :");
            foreach (var item in bf.Filter(products,
                new AndSpecification<Product>(
                    new ColorSpecification(Color.Blue),
                    new SizeSpecification(Size.Large)
                    )))
            {
                Console.WriteLine($"- {item.Name} is large and blue");
            }
        }
    }
}
