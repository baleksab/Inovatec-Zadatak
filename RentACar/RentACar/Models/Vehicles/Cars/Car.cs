namespace RentACar.Models.Vehicles.Cars;

public abstract class Car : Vehicle
{
    public CarType CarType { get; set; }
    public double Mileage { get; set; }
    
    public ICollection<Equipment> Equipments { get; set; } = new List<Equipment>();
    
    protected Car(int id, VehicleBrand brand, string model, CarType carType, double mileage, double fuelConsumption) 
        : base(id, VehicleType.Car, brand, model, fuelConsumption, Configuration.CarBasePrice)
    {
        CarType = carType;
        Mileage = mileage;
    }
    
    protected Car(int id, VehicleBrand brand, string model, CarType carType, double mileage, double fuelConsumption, ICollection<Equipment> equipments) 
        : base(id, VehicleType.Car, brand, model, fuelConsumption, Configuration.CarBasePrice)
    {
        CarType = carType;
        Mileage = mileage;
        Equipments = equipments;
    }

    protected override double GetFinalRentCost()
    {
        var adjustedCost = GetAdjustedBaseCost();

        foreach (var equipment in Equipments)
        {
            switch (equipment.IncreasesPrice)
            {
                case 1:
                    adjustedCost += equipment.Cost;
                    break;
                case 0:
                    adjustedCost -= equipment.Cost;
                    break;
            }
        }

        return adjustedCost;
    }

    public override string ToString()
    {
        var equipmentsString = Equipments != null 
            ? string.Join(",\n",  Equipments.Select(e => "\t - " + e.ToString())) 
            : "No Equipments";
        
        return $"{base.ToString()}" +
               $"  - Type: {CarType}\n" +
               $"  - Mileage: {Mileage}km\n" +
               $"  - Equipments: (Cost of each item was already applied to adjusted rent cost)  \n{equipmentsString}\n";
    }
}

public enum CarType
{
    Limousine,
    Hatchback,
    Caravan,
    Coupe,
    Convertible,
    Minivan,
    Suv,
    Pickup,
    Unknown
}

public static class CarTypeExtension {
    public static CarType ParseCarType(this string value)
    {
        switch (value.ToLower())
        {
            case "limuzina":
                return CarType.Limousine;
            case "hecbek":
                return CarType.Hatchback;
            case "karavan":
                return CarType.Caravan;
            case "kupe":
                return CarType.Coupe;
            case "kabriolet":
                return CarType.Convertible;
            case "minivan":
                return CarType.Minivan;
            case "suv":
                return CarType.Suv;
            case "pickup":
                return CarType.Pickup;
            default:
                return CarType.Unknown;
        }
    }
}