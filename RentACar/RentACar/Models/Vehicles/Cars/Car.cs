namespace RentACar.Models.Vehicles.Cars;

public abstract class Car : Vehicle
{
    public CarType CarType { get; set; }
    public double Mileage { get; set; }
    
    protected Car(int id, VehicleBrand brand, string model, CarType carType, double mileage, double fuelConsumption) 
        : base(id, VehicleType.Car, brand, model, fuelConsumption, Configuration.CarBasePrice)
    {
        CarType = carType;
        Mileage = mileage;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, {nameof(CarType)}: {CarType}, {nameof(Mileage)}: {Mileage}";
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