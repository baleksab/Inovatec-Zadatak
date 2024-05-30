using System.Diagnostics;

namespace RentACar.Models.Vehicles;

public abstract class Vehicle
{
    public int Id { get; set; }
    public VehicleType VehicleType { get; set; }
    public VehicleBrand Brand { get; set; }
    public string Model { get; set; }
    public double FuelConsumption { get; set; }
    public double BaseCost { get; set; }
    
    protected Vehicle(int id, VehicleType vehicleType, VehicleBrand brand, string model, double fuelConsumption, double baseCost)
    {
        Id = id;
        VehicleType = vehicleType;
        Brand = brand;
        Model = model;
        FuelConsumption = fuelConsumption;
        BaseCost = baseCost;
    }

    public abstract double CalculateRentCost();


    public override string ToString()
    {
        return
            $"{nameof(Id)}: {Id}, {nameof(VehicleType)}: {VehicleType}, {nameof(Brand)}: {Brand}, {nameof(Model)}: {Model}, {nameof(FuelConsumption)}: {FuelConsumption}, {nameof(BaseCost)}: {BaseCost}";
    }
}

public enum VehicleType
{
    Car,
    Motorcycle,
    Unknown
}

public static class VehicleTypeExtension
{
    public static VehicleType ParseVehicleType(this string value)
    {
        switch (value.ToLower())
        {
            case "automobil":
                return VehicleType.Car;
            case "motor":
                return VehicleType.Motorcycle;
            default:
                return VehicleType.Unknown;
        }
    }
}

public enum VehicleBrand
{
    Mercedes,
    Bmw,
    Peugeot,
    Yamaha,
    Harley,
    Unknown
}

public static class VehicleBrandExtension {
    public static VehicleBrand ParseVehicleBrand(this string value)
    {
        switch (value.ToLower())
        {
            case "mercedes":
                return VehicleBrand.Mercedes;
            case "bmw":
                return VehicleBrand.Bmw;
            case "peugeot":
                return VehicleBrand.Peugeot;
            case "yamaha":
                return VehicleBrand.Yamaha;
            case "harley":
                return VehicleBrand.Harley;
            default:
                return VehicleBrand.Unknown;
        }
    }
}