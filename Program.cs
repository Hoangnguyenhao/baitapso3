using System;
using System.Collections.Generic;

class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }

    public void Display()
    {
        Console.WriteLine($"ID: {Id}, Ten: {Name}, Gia: {Price:C}");
    }
}

static class InputHelper
{
    public static int GetInt(string message)
    {
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out int result))
                return result;
            Console.WriteLine("Vui long nhap mot so nguyen hop le!");
        }
    }

    public static double GetDouble(string message)
    {
        while (true)
        {
            Console.Write(message);
            if (double.TryParse(Console.ReadLine(), out double result))
                return result;
            Console.WriteLine("Vui long nhap mot so hop le!");
        }
    }

    public static string GetString(string message)
    {
        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(input))
                return input;
            Console.WriteLine("Vui long khong de trong!");
        }
    }
}

class ProductManager
{
    private readonly List<Product> _products = new();

    public void AddProduct()
    {
        int id = InputHelper.GetInt("Nhap ID: ");
        string name = InputHelper.GetString("Nhap ten san pham: ");
        double price = InputHelper.GetDouble("Nhap gia: ");
        
        _products.Add(new Product { Id = id, Name = name, Price = price });
        Console.WriteLine("San pham da duoc them!");
    }

    public void ShowProducts()
    {
        if (_products.Count == 0)
        {
            Console.WriteLine("Chua co san pham nao!");
            return;
        }

        Console.WriteLine("\nDanh sach san pham:");
        _products.ForEach(p => p.Display());
    }
}

class Program
{
    static void Main()
    {
        var productManager = new ProductManager();

        while (true)
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. Nhap san pham");
            Console.WriteLine("2. Hien thi san pham");
            Console.WriteLine("3. Thoat");
            int choice = InputHelper.GetInt("Chon: ");

            switch (choice)
            {
                case 1:
                    productManager.AddProduct();
                    break;
                case 2:
                    productManager.ShowProducts();
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Lua chon khong hop le!");
                    break;
            }
        }
    }
}
