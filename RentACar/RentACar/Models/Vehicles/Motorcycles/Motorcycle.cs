namespace RentACar.Models.Vehicles.Motorcycles;

public abstract class Motorcycle : Vehicle
{
    public MotorcycleType MotorcycleType { get; set; }
    public double EngineSize { get; set; }
    public double EnginePower { get; set; }

    protected Motorcycle(int id, VehicleBrand brand, string model, MotorcycleType motorcycleType, double engineSize, double enginePower, double fuelConsumption) 
        : base(id, VehicleType.Motorcycle, brand, model, fuelConsumption, Configuration.MotorcycleBasePrice)
    {
        MotorcycleType = motorcycleType;
        EngineSize = engineSize;
        EnginePower = enginePower;
    }

    public override string ToString()
    {
        return
            $"{base.ToString()}, {nameof(MotorcycleType)}: {MotorcycleType}, {nameof(EngineSize)}: {EngineSize}, {nameof(EnginePower)}: {EnginePower}";
    }
}

public enum MotorcycleType
{
    Adventure,
    Heritage,
    Tour,
    Roadster,
    UrbanMobility,
    Sport,
    Unknown
}

public static class MotorcycleTypeExtension {
    public static MotorcycleType ParseMotorcycleType(this string value)
    {
        switch (value.ToLower())
        {
            case "adventure":
                return MotorcycleType.Adventure;
            case "heritage":
                return MotorcycleType.Heritage;
            case "tour":
                return MotorcycleType.Tour;
            case "roadster":
                return MotorcycleType.Roadster;
            case "urban mobility":
                return MotorcycleType.UrbanMobility;
            case "sport":
                return MotorcycleType.Sport;
            default:
                return MotorcycleType.Unknown;
        }
    }
}