namespace RentACar.Models.Vehicles.Cars;

public abstract class Car : Vehicle
{
    public enum Type
    {
        Limousine,
        Hatchback,
        Wagon,
        Coupe,
        Convertible,
        Minivan,
        Suv,
        Pickup
    }
    
    public Type CarType { get; set; }

    protected Car(int id, string model, Type carType, double fuelConsumption) : base(id, model, fuelConsumption, Configuration.CarBasePrice)
    {
        CarType = carType;
    }

    public override void DisplayInformation()
    {
        throw new NotImplementedException();
    }
}