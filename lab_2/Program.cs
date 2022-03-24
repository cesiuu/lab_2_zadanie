using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main()
        {
            Seller treacher = new Seller("Jan Kowalski", 50);

            Buyer buyer1 = new Buyer("Jaś Fasola 1", 25);
            Buyer buyer2 = new Buyer("Jaś Fasola 2", 21);
            Buyer buyer3 = new Buyer("Jaś Fasola 3", 23);

            buyer1.AddProduct(new Fruit("Apple", 6));
            buyer1.AddProduct(new Meat("Fish", 0.5));

            Person[] persons = { treacher, buyer1, buyer2, buyer3 };

            Product[] products = {
                new Fruit("Apple", 1000),
                new Fruit("Banana", 700),
                new Fruit("Orange", 500),
                new Meat("Fish", 100.0),
                new Meat("Beef", 75.0)
            };

            Shop shop = new Shop("Super Market", persons, products);

            shop.Print();
        }
    }
    interface IThing
    {
        string Name { get; set; }
    }
    public class Person : IThing
    {
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string name;
        public int age;
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public virtual void Print(string prefix)
        {

        }
    }
    public class Buyer : Person
    {
        List<Product> tasks = new List<Product>();
        public Buyer(string name, int age) : base(name, age)
        {

        }
        public void AddProduct(Product product)
        {
            tasks.Add(product);
        }
        public void RemoveProduct(int index)
        {
            tasks.RemoveAt(index);
        }
        public override void Print(string prefix)
        {
            Console.WriteLine($"{prefix}Buyer: " + name.ToString() + " (" + this.age + " y.o.)");
            if (tasks.Count > 0)
            {
                Console.WriteLine($"{prefix}{prefix}-- Products: --");
                foreach (Product product in tasks)
                {
                    Console.Write(prefix);
                    product.Print(prefix);
                }
            }
        }
    }
    public class Seller : Person
    {
        public Seller(string name, int age) : base(name, age)
        {

        }
        public override void Print(string prefix)
        {
            Console.WriteLine($"{prefix}Seller: " + name.ToString() + " (" + this.age + " y.o)");
        }
    }
    public class Product : IThing
    {
        public string Name { get => name; set => name = value; }
        public string name;
        public Product(string name)
        {
            this.name = name;
        }
        public virtual void Print(string prefix)
        {

        }
    }
    public class Fruit : Product
    {
        public int Count { get => count; set => count = value; }
        private int count;
        public Fruit(string name, int count) : base(name)
        {
            this.count = count;
        }
        public override void Print(string prefix)
        {
            Console.WriteLine($"{prefix}" + this.name + "(" + this.count + " fruits)");
        }
    }
    public class Meat : Product
    {
        protected double Weight { get; set; }
        public double weight;
        public Meat(string name, double weight) : base(name)
        {
            this.name = name;
            this.weight = weight;
        }
        public override void Print(string prefix)
        {
            Console.WriteLine($"{prefix}" + this.name + "(" + this.weight + " kg)");
        }
    }
    public class Shop : IThing
    {
        public string Name { get => name; set => name = value; }
        public string name;
        public Person[] people = new Person[5];
        public Product[] products = new Product[5];
        public Shop(string name, Person[] people, Product[] products)
        {
            this.name = name;
            this.people = people;
            this.products = products;
        }
        public void Print()
        {
            Console.WriteLine("Shop: " + name.ToString());
            Console.WriteLine("-- People: --");
            foreach (Person? p in people)
            {
                p.Print("\t");
            }

            Console.WriteLine("-- Products: --");
            foreach (Product? p in products)
            {
                p.Print("\t");
            }
        }
    }
}