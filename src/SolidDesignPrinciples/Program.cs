using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace SolidDesignPrinciples
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Single Responsibility
            var j = new Journal();
            j.AddEntry("I cried today");
            j.AddEntry("I ate a bug");
            Console.WriteLine(j);

            var p = new Persistence();
            var filename = @"c:\temp\journal.txt";
            p.SaveToFile(j, filename, true);
            //Process.Start(filename);
            #endregion

            #region Open Closed Principle
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);

            Product[] products = { apple, tree, house };

            var pf = new ProductFilter();
            Console.WriteLine("Green products (old):");
            foreach (var pr in pf.FilterByColor(products, Color.Green))
            {
                Console.WriteLine($" - {pr.Name} is green");
            }

            var bf = new BetterFilter();
            Console.WriteLine("Green producs (new):");
            foreach (var prr in bf.Filter(products, new ColorSpecification(Color.Green)))
            {
                Console.WriteLine($" - {prr.Name} is green");
            }

            Console.WriteLine("Large blue items:");
            foreach (var prrr in bf.Filter(products,new AndSpecification<Product>(
                new ColorSpecification(Color.Blue),
                new SizeSpecification(Size.Large)
                )))
            {
                Console.WriteLine($" - {prrr.Name} is large and blue");
            }
            #endregion

            #region Liskov Substitution Principle
            Rectangle rc = new Rectangle(2,3);
            Console.WriteLine($"{rc} has area {rc.Area(rc)}");

            Rectangle sq = new Square();
            sq.Width = 4;
            Console.WriteLine($"{sq} has area {rc.Area(sq)}");
            #endregion
        }
    }


}
