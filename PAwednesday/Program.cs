using System;
using PAwednesday;

class Program
{
    static void Main(string[] args)
    {
        Store store = new Store();

// tworzenie obiektow 
        FoodProduct juice = new FoodProduct(1, "Juice", FoodType.Liquid, DateTime.Now.AddDays(-5));
        FoodProduct bread = new FoodProduct(2, "Bread", FoodType.Solid, DateTime.Now.AddDays(-10));
        PackagedFoodProduct milk = new PackagedFoodProduct(3, "Milk", FoodType.Liquid, DateTime.Now.AddDays(-13));
        ElectronicsProduct phone = new ElectronicsProduct(4, "Phone", false);
        // phone.id = 2;

        
// dodawanie produktow
        store.AddProduct(juice);
        store.AddProduct(bread);
        store.AddProduct(milk);
        store.AddProduct(phone);

// ile jest w sklepie
        int productsInStock = store.CountProductsInStock();
        Console.WriteLine($"There are {productsInStock} products in stock.");

// ile mozna sprzedac
        int productsCanBeSold = store.CountProductsCanBeSold();
        Console.WriteLine($"There are {productsCanBeSold} products that can currently be sold."); 
//add warranty        
        phone.AddWarranty();
        int productsCanBeSold2 = store.CountProductsCanBeSold();
        Console.WriteLine($"There are {productsCanBeSold2} products that can currently be sold.");
    }
}