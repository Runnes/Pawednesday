namespace PAwednesday;

using System;
using System.Collections.Generic;

public enum FoodType
{
    Liquid,
    Solid
}

public abstract class Product
{
    private int Id { get; set; }
    private string Name { get; set; }

    protected Product(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public abstract bool CanBeSold();
}

public class FoodProduct : Product
{
    private FoodType Type { get;  }
    private DateTime DateOfManufacture { get;  }

    protected Dictionary<FoodType, int> UseByDays = new Dictionary<FoodType, int>
    {
        { FoodType.Liquid, 12 },
        { FoodType.Solid, 20 },
        // { FoodType.Other, 15 }
    };

    public FoodProduct(int id, string name, FoodType type, DateTime dateOfManufacture) : base(id, name)
    {
        Type = type;
        DateOfManufacture = dateOfManufacture;
    }

    public override bool CanBeSold()
    {
        if (!UseByDays.ContainsKey(Type))
            throw new Exception("Invalid food type");

        int days = UseByDays[Type];
        return DateTime.Now <= DateOfManufacture.AddDays(days);
    }
}

public class PackagedFoodProduct : FoodProduct
{
    public PackagedFoodProduct(int id, string name, FoodType type, DateTime dateOfManufacture) : base(id, name, type, dateOfManufacture)
    {
        UseByDays[FoodType.Liquid]++;
        UseByDays[FoodType.Solid]++;
        // UseByDays[FoodType.Other]++;
    }
}

public class ElectronicsProduct : Product
{
    private bool hasWarranty;

    public ElectronicsProduct(int id, string name, bool hasWarranty)
        : base(id, name)
    {
    }

    private bool HasWarranty
    {
        get;
        set;
    }

    public void AddWarranty()
    {
        HasWarranty = true;
        if (HasWarranty) //pewnie redundant, ale dla testow zostawilem
        {
            Console.WriteLine("Warranty hass been added");
            return;
        }
        Console.WriteLine("WARRANTY HAS NOT BEEN ADDED");
        
    }

    public override bool CanBeSold()
    {
        return HasWarranty;
    }
}