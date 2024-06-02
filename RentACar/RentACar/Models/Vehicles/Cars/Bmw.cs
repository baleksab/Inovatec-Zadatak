namespace RentACar.Models.Vehicles.Cars;

public class Bmw : Car
{
    public Bmw(int id, string model, CarType carType, double mileage, double fuelConsumption) 
        : base(id, VehicleBrand.Bmw, model, carType, mileage, fuelConsumption)
    {
        
    }

    protected override double GetAdjustedBaseCost()
    {
        var cost = BaseCost;
        
        switch (FuelConsumption)
        {
            case < 7: // ako troši manje od 7 litara na 100km cena se povećava za 15%,
                cost += BaseCost * 0.15;
                break;
            case > 7: // ako troši više od 7 litara na 100km cena se umanjuje za 10% ,
                cost -= BaseCost * 0.10;
                break;
            default:  // u suprotnom cena se smanjuje za 15%.
                cost -= BaseCost * 0.15;
                break;
        }

        return cost;
    }
}