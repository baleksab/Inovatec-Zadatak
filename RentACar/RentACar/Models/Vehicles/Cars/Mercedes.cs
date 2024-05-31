namespace RentACar.Models.Vehicles.Cars;

public class Mercedes : Car
{
    public Mercedes(int id, string model, CarType carType, double mileage, double fuelConsumption) 
        : base(id, VehicleBrand.Mercedes, model, carType, mileage, fuelConsumption)
    {
        
    }

    protected override double GetAdjustedBaseCost()
    {
        double cost = BaseCost;
        
        if (Mileage < 50000) // ako je prešao manje od 50000km cena se povećava za 6%
            cost += BaseCost * 0.06;
        
        switch (CarType)
        {
            case CarType.Limousine: // ako je limuzina povećava se za 7%,
                cost += BaseCost * 0.07;
                break;
            case CarType.Hatchback when Mileage > 100000: // ako je hečbek i prešao je više od 100000km, cena se smanjuje za 3%.
                cost -= BaseCost * 0.03;
                break;
        }

        return cost;
    }
}