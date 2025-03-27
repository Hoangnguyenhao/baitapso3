using System;
using System.Collections.Generic;

class Product
{
    public int ID { get; set; }
    public string ProductName { get; set; }
    public double Price { get; set; }

    public void Display()
    {
        Console.WriteLine($"ID: {ID}, Ten san pham: {ProductName}, Gia: {Price:C}");
    }
}

class Validate
{
    public static int GetInt(string message)
    {
        int result;
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out result))
                return result;
            Console.WriteLine("Vui lòng nhập một số nguyên hợp lệ!");
        }
    }

    public static double GetDouble(string message)
    {
        double result;
        while (true)
        {
            Console.Write(message);
            if (double.TryParse(Console.ReadLine(), out result))
                return result;
            Console.WriteLine("Vui lòng nhập một số hợp lệ!");
        }
    }

    public static string GetString(string message)
    {
        string result;
        while (true)
        {
            Console.Write(message);
            result = Console.ReadLine().Trim();
            if (!string.IsNullOrEmpty(result))
                return result;
            Console.WriteLine("Vui lòng không để trống!");
        }
    }
}

class Program
{
    static List<Product> products = new List<Product>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. Nhập sản phẩm");
            Console.WriteLine("2. Hiển thị các sản phẩm đã nhập");
            Console.WriteLine("3. Thoát");
            int choice = Validate.GetInt("Chọn: ");

            switch (choice)
            {
                case 1:
                    AddProduct();
                    break;
                case 2:
                    ShowProducts();
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                    break;
            }
        }
    }

    static void AddProduct()
    {
        int id = Validate.GetInt("Nhập ID: ");
        string name = Validate.GetString("Nhập tên sản phẩm: ");
        double price = Validate.GetDouble("Nhập giá: ");

        products.Add(new Product { ID = id, ProductName = name, Price = price });
        Console.WriteLine("Sản phẩm đã được thêm!");
    }

    static void ShowProducts()
    {
        if (products.Count == 0)
        {
            Console.WriteLine("Chưa có sản phẩm nào!");
            return;
        }

        Console.WriteLine("\nDanh sách sản phẩm:");
        foreach (var product in products)
        {
            product.Display();
        }
    }
}
