namespace ProductShop.Services;

using ProductShop.Models;

public static class ProductsService
{
    static List<Product> Products { get; }
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
}

