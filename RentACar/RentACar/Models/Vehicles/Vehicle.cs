namespace RentACar.Models.Vehicles;

public abstract class Vehicle
{
    public int Id { get; set; }
    public string Model { get; set; }
    public double FuelConsumption { get; set; }
    public double PricePerDay { get; set; }
    
    protected Vehicle(int id, string model, double fuelConsumption, double pricePerDay)
    {
        Id = id;
        Model = model;
        FuelConsumption = fuelConsumption;
        PricePerDay = pricePerDay;
    }

    public abstract double CalculateCost();
    public abstract void DisplayInformation();
}