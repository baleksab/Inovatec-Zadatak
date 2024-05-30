namespace RentACar.Models.Vehicles.Cars;

public class Peugeot : Car
{
    public Peugeot(int id, string model, Type carType, double mileage, double fuelConsumption) 
        : base(id, "Peugeot", model, carType, mileage, fuelConsumption)
    {
        
    }


    public override double CalculateRentCost()
    {
        double cost = BaseCost;
        
        if (CarType == Type.Limousine) // ako je limuzina cena se uvećava za 15%
            cost += BaseCost * 0.15;
        else if (CarType == Type.Caravan) // ako je karavan cena se uvećava za 20%,
            cost += BaseCost * 0.20;
        else // u suprotnom se smanjuje za 5%.
            cost -= BaseCost * 0.05;

        return cost;
    }
}