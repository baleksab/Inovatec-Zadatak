﻿namespace RentACar.Models.Vehicles.Cars;

public class Bmw : Car
{
    public Bmw(int id, string model, Type carType, double mileage, double fuelConsumption) 
        : base(id, "BMW", model, carType, mileage, fuelConsumption)
    {
        
    }

    public override double CalculateRentCost()
    {
        double cost = BaseCost;
        
        if (FuelConsumption < 7) // ako troši manje od 7 litara na 100km cena se povećava za 15%,
            cost += BaseCost * 0.15;
        else if (FuelConsumption > 7) // ako troši više od 7 litara na 100km cena se umanjuje za 10% ,
            cost -= BaseCost * 0.10;
        else // u suprotnom cena se smanjuje za 15%.
            cost -= BaseCost * 0.15;

        return cost;
    }
}