namespace PAwednesday;

using System.Collections.Generic;
using System.Linq;

public class Store
{
    private List<Product> products;

    public Store()
    {
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public int CountProductsInStock()
    {
        return products.Count;
    }

    public int CountProductsCanBeSold()
    {
        return products.Count(p => p.CanBeSold());
    }
}