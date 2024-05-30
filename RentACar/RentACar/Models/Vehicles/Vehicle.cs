namespace RentACar.Models.Vehicles;

public abstract class Vehicle
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public double FuelConsumption { get; set; }
    public double BaseCost { get; set; }
    
    protected Vehicle(int id, string brand, string model, double fuelConsumption, double baseCost)
    {
        Id = id;
        Brand = brand;
        Model = model;
        FuelConsumption = fuelConsumption;
        BaseCost = baseCost;
    }

    public abstract void DisplayInformation();
    public abstract double CalculateRentCost();
}