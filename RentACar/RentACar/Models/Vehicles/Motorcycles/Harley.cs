namespace RentACar.Models.Vehicles.Motorcycles;

public class Harley : Motorcycle
{
    public Harley(int id, string model, Type motorcycleType, double fuelConsumption) : base(id, model, motorcycleType, fuelConsumption)
    {
        
    }

    public override double CalculateCost()
    {
        throw new NotImplementedException();
    }
}