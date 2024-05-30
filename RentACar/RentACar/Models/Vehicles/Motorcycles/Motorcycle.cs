namespace RentACar.Models.Vehicles.Motorcycles;

public abstract class Motorcycle : Vehicle
{
    public enum Type {
        Adventure,
        Heritage,
        Tour,
        Roadster,
        UrbanMobility,
        Sport
    }
    
    public Type MotorcycleType { get; set; }
    public double EngineSize { get; set; }
    public double EnginePower { get; set; }

    protected Motorcycle(int id, string brand, string model, Type motorcycleType, double engineSize, double enginePower, double fuelConsumption) 
        : base(id, brand, model, fuelConsumption, Configuration.MotorcycleBasePrice)
    {
        MotorcycleType = motorcycleType;
        EngineSize = engineSize;
        EnginePower = enginePower;
    }

    public override void DisplayInformation()
    {   
        throw new NotImplementedException();
    }
}