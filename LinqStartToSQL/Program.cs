using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqStartToSQL
{
    class Product 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Product(int id, string name, int price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
        public override string ToString()
        {
            return Id.ToString() + " " + Name + " " + Price.ToString();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var queryResults = from c in db.goods
                               where c.Count > 2
                               select new Product (c.Id,c.Name,c.Price);
            var queryResults2 = from c in db.goods
                               where c.Count > 2
                               select new
                               {ID = c.Id,Name = c.Name,Price = c.Price};
            foreach (var item in queryResults)
            {
                Console.WriteLine(item);
            }
            foreach (var item in queryResults2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Press any key to complete...");
            Console.ReadLine();
        }
    }
}
