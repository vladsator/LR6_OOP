using System;

namespace LR_6_code_Cch
{
    class Program
    {
        static void Main()
        {
            var myList = new MyList<Product>();
            myList.Add(new Product("Колбаса", DateTime.Today, new DateTime(2017, 3, 24)));
            myList.Add(new Product("Хлеб", new DateTime(2016, 11, 29), DateTime.Today));
            myList.Add(new Product("Молоко", new DateTime(2016, 10, 14), new DateTime(2016, 10, 20)));

            myList.Clear();

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
