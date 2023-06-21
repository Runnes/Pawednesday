namespace PAwednesday;

public abstract class Product
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Product(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public abstract bool CanBeSold();
}

public enum FoodType
{
    Liquid,
    Solid
}

public class FoodProduct : Product
{
    public bool IsLiquid { get; }
    public DateTime DateOfManufacture { get; set; }

    protected int LiquidUseByDays { get; set; } = 12;
    protected int SolidUseByDays { get; set; } = 20;

    public FoodProduct(int id, string name, bool isLiquid, DateTime dateOfManufacture) : base(id, name)
    {
        IsLiquid = isLiquid;
        DateOfManufacture = dateOfManufacture;
    }

    public override bool CanBeSold()
    {
        int days = IsLiquid ? LiquidUseByDays : SolidUseByDays;
        return DateTime.Now <= DateOfManufacture.AddDays(days);
    }
}

public class PackagedFoodProduct : FoodProduct
{
    public PackagedFoodProduct(int id, string name, bool isLiquid, DateTime dateOfManufacture) : base(id, name, isLiquid, dateOfManufacture)
    {
        LiquidUseByDays++;
        SolidUseByDays++;
    }
}


public class ElectronicsProduct : Product
{
    private bool hasWarranty;

    public ElectronicsProduct(int id, string name)
        : base(id, name)
    {
    }

    public bool HasWarranty
    {
        get;
        private set;
    }

    public void AddWarranty(int id)
    {
        hasWarranty = true;
    }

    public override bool CanBeSold()
    {
        return HasWarranty;
    }
}