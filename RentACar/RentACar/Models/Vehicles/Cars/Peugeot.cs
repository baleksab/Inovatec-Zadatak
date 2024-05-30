namespace RentACar.Models.Vehicles.Cars;

public class Peugeot : Car
{
    public Peugeot(int id, string model, CarType carType, double mileage, double fuelConsumption) 
        : base(id, VehicleBrand.Peugeot, model, carType, mileage, fuelConsumption)
    {
        
    }


    public override double CalculateRentCost()
    {
        double cost = BaseCost;
        
        switch (CarType)
        {
            case CarType.Limousine: // ako je limuzina cena se uvećava za 15%
                cost += BaseCost * 0.15;
                break;
            case CarType.Caravan:  // ako je karavan cena se uvećava za 20%,
                cost += BaseCost * 0.20;
                break;
            default:  // u suprotnom se smanjuje za 5%.
                cost -= BaseCost * 0.05;
                break;
        }

        return cost;
    }
}