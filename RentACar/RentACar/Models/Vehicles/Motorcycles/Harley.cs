namespace RentACar.Models.Vehicles.Motorcycles;

public class Harley : Motorcycle
{
    public Harley(int id, string model, MotorcycleType motorcycleType, double engineSize, double enginePower, double fuelConsumption) 
        : base(id, VehicleBrand.Harley, model, motorcycleType, engineSize, enginePower, fuelConsumption)
    {
        
    }


    protected override double GetAdjustedBaseCost()
    {
        var cost = BaseCost;
        
        cost += BaseCost * 0.15;  // u startu se cena uvećava za 15%,
        
        if (EngineSize > 1200) // ako ima više od 1200 kubika cena se povećava za 10%,
            cost += BaseCost * 0.10;
        else //  u suprotnom se smanjuje za 5%.
            cost -= BaseCost * 0.05;

        return cost;
    }
}