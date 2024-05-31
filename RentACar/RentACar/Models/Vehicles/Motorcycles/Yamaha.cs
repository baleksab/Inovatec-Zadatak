namespace RentACar.Models.Vehicles.Motorcycles;

public class Yamaha : Motorcycle
{
    public Yamaha(int id, string model, MotorcycleType motorcycleType, double engineSize, double enginePower, double fuelConsumption) 
        : base(id, VehicleBrand.Yamaha, model, motorcycleType, engineSize, enginePower, fuelConsumption)
    {
        
    }


    protected override double GetAdjustedBaseCost()
    {
        double cost = BaseCost;

        cost += BaseCost * 0.10; // u startu se cena uvećava za 10%,

        if (EnginePower > 180) // zatim ako mu je snaga veća od 180 KS cena se uvećava za 5%,
            cost += BaseCost * 0.05;
        else // u suprotnom se smanjuje za 10%,
            cost -= BaseCost * 0.10;

        switch (MotorcycleType)
        {
            case MotorcycleType.Heritage: // ako je Heritage onda se uvećava za 50e
                cost += 50;
                break;
            case MotorcycleType.Sport: // ako je Sport uvećava se za 100e
                cost += 100;
                break;
            default: // u suprotnom se smanjuje za 10e
                cost -= 10;
                break;
        }

        return cost;
    }
}