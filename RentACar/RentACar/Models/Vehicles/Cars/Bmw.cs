namespace RentACar.Models.Vehicles.Cars;

public class Bmw : Car
{
    public Bmw(int id, string model, Type carType, double fuelConsumption) : base(id, model, carType, fuelConsumption)
    {
        
    }


    public override double CalculateCost()
    {
        throw new NotImplementedException();
    }
}