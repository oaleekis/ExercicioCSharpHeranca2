using ExercicioCSharpHeranca2.Entities;
using System.Globalization;

namespace ExercicioCSharpHeranca2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());

            List<Product> products = new List<Product>();

            for (int i = 0; i < n; i++) 
            {
                Console.WriteLine("Product #1 data: ");
                Console.Write("Common, Used or Imported (c/u/i)? ");
                char type = char.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);


                if(type == 'u' | type == 'U' )
                {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    Product product = new UsedProduct(name, price, date);
                    products.Add(product);
                }
                else if (type == 'i' |  type == 'I')
                {
                    Console.Write("Customs fee: ");
                    double customFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Product product = new ImportedProduct(name, price, customFee);
                    products.Add(product);
                } else
                {
                    Product product = new Product(name, price);
                    products.Add(product);
                }
            }

            Console.WriteLine("\nPRICE TAGS: ");
            foreach (var item in products)
            {
                Console.WriteLine($"{item.Name}  {item.PriceTag()}");
            }
        }
    }
}