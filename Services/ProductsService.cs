using System.ComponentModel;
using System.Reflection.Metadata;

namespace ProductShop.Services;

using ProductShop.Models;

using System;
using System.Reflection;

public static class ProductsService
{
    private static List<Product> Products { get; }
    static int nextId = 3;
    static ProductsService()
    {
        Products = new List<Product>
        {
            new Product {
                Id = 1,
                Name = "Classic Italian",
                Description = "kek",
                Price = 123,
                Category = Category.FOOD,
                IsGlutenFree = false,
            },
        };
    }

    public static List<Product> GetAll() => Products;

    public static Product? Get(int id) => Products.FirstOrDefault(p => p.Id == id);

    public static void Add(Product pizza)
    {
        pizza.Id = nextId++;
        Products.Add(pizza);
    }

    public static void Delete(int id)
    {
        var pizza = Get(id);
        if(pizza is null)
            return;

        Products.Remove(pizza);
    }

    public static void Update(Product pizza)
    {
        var index = Products.FindIndex(p => p.Id == pizza.Id);
        if(index == -1)
            return;

        Products[index] = pizza;
    }

    public static List<Product> Sort(string field, bool sortType)
    {
        switch (field)
        {
            case "name":
                return sortType? Products.OrderBy(x => x.Name).ToList() : Products.OrderByDescending(x => x.Name).ToList();
            case "price":
                return sortType? Products.OrderBy(x => x.Price).ToList() : Products.OrderByDescending(x => x.Price).ToList();
            default:
                return Products;
        }
    }
    
    public static List<Product> Filter(string field,  string value)
    {
        switch (field)
        {
            case "name":
                return Products.FindAll(x => x.Name == value);
            case "price":
                return Products.FindAll(x => x.Price == int.Parse(value));
            default:
                return Products;
        }
    }
    
}

