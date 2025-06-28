namespace ConsoleApp1
{
    class Product
    {
        public required string Name { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set; }
    }

    static class InventoryManagementSystem
    {
        static readonly List<Product> inventory = [];

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("What would you like to do today? (Enter 1 - 5):");
                Console.WriteLine("1. Add new product");
                Console.WriteLine("2. Update stock");
                Console.WriteLine("3. View inventory");
                Console.WriteLine("4. Remove items from inventory");
                Console.WriteLine("5. Exit");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        UpdateStock();
                        break;
                    case "3":
                        ViewInventory();
                        break;
                    case "4":
                        RemoveItems();
                        break;
                    case "5":
                        Console.WriteLine("Exiting the program.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddProduct()
        {
            Console.Write("Enter name of product: ");
            string? name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Product name cannot be empty.");
                return;
            }

            Console.Write("Enter price: ");
            string? priceInput = Console.ReadLine();
            if (!double.TryParse(priceInput, out double price) || price <= 0)
            {
                Console.WriteLine("Invalid price.");
                return;
            }

            Console.Write("Enter stock quantity: ");
            string? stockInput = Console.ReadLine();
            int stockQuantity;

            while (string.IsNullOrWhiteSpace(stockInput) || !int.TryParse(stockInput, out stockQuantity) || stockQuantity <= 0)
            {
                Console.Write("Invalid stock quantity. Please enter a valid number: ");
                stockInput = Console.ReadLine();
            }

            inventory.Add(new Product { Name = name, Price = price, StockQuantity = stockQuantity });

            Console.WriteLine();
            Console.WriteLine("Successfully added product to inventory.");
            Console.WriteLine();
            Console.WriteLine($"Product Name: {name}, Price: ${price}, Stock Quantity: {stockQuantity}");
            Console.WriteLine();
        }

        static void UpdateStock()
        {
            Console.Write("Enter product name to update stock: ");
            string? productName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(productName))
            {
                Console.WriteLine("Product name cannot be empty.");
                return;
            }

            Product? product = inventory.Find(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));

            if (product != null)
            {
                Console.Write("Enter new stock quantity: ");
                string? newStockInput = Console.ReadLine();
                int newStockQuantity;
                while (string.IsNullOrWhiteSpace(newStockInput) || !int.TryParse(newStockInput, out newStockQuantity) || newStockQuantity < 0)
                {
                    Console.Write("Invalid stock quantity. Please enter a valid number: ");
                    newStockInput = Console.ReadLine();
                }
                product.StockQuantity = newStockQuantity;
                Console.WriteLine($"Stock quantity for '{productName}' updated.");
            }
            else
            {
                Console.WriteLine($"Product '{productName}' not found in inventory.");
            }
            
            Console.WriteLine();
        }

        static void ViewInventory()
        {
            Console.WriteLine("Current Inventory:");
            Console.WriteLine();

            foreach (var product in inventory)
            {
                Console.WriteLine($"Name: {product.Name}, Price: ${product.Price}, Stock: {product.StockQuantity}");
            }

            Console.WriteLine();
        }

        static void RemoveItems()
        {
            Console.Write("Enter product name to remove: ");
            string? productName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(productName))
            {
                Console.WriteLine("Product name cannot be empty.");
                return;
            }

            Product? product = inventory.Find(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));

            if (product != null)
            {
                inventory.Remove(product);
                Console.WriteLine($"Product '{productName}' removed from inventory.");
            }
            else
            {
                Console.WriteLine($"Product '{productName}' not found in inventory.");
            }

            Console.WriteLine();
        }
    }
}
