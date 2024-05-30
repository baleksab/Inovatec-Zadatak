namespace RentACar.Models.Vehicles.Cars;

public abstract class Car : Vehicle
{
    public enum Type
    {
        Limousine,
        Hatchback,
        Caravan,
        Coupe,
        Convertible,
        Minivan,
        Suv,
        Pickup
    }
    
    public Type CarType { get; set; }
    public double Mileage { get; set; }
    
    protected Car(int id, string brand, string model, Type carType, double mileage, double fuelConsumption) 
        : base(id, brand, model, fuelConsumption, Configuration.CarBasePrice)
    {
        CarType = carType;
        Mileage = mileage;
    }

    public override void DisplayInformation()
    {
        throw new NotImplementedException();
    }
}