namespace RentACar.Models.Vehicles.Cars;

public class Mercedes : Car
{
    public Mercedes(int id, string model, Type carType, double fuelConsumption) : base(id, model, carType, fuelConsumption)
    {
        
    }

    public override double CalculateCost()
    {
        throw new NotImplementedException();
    }
}