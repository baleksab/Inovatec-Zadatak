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

    protected Motorcycle(int id, string model, Type motorcycleType, double fuelConsumption) : base(id, model, fuelConsumption, Configuration.MotorcycleBasePrice)
    {
        MotorcycleType = motorcycleType;
    }

    public override void DisplayInformation()
    {
        throw new NotImplementedException();
    }
}