using RentACar.Models.Vehicles.Cars;
using RentACar.Models.Vehicles.Motorcycles;

namespace RentACar.Models.Vehicles.Factories;

public class VehicleFactory : IVehicleFactory
{
    public Car CreateCar(int id, VehicleBrand brand, string model, CarType type, double mileage, double fuelConsumption)
    {
        switch (brand)
        {
            case VehicleBrand.Bmw:
                return new Bmw(id, model, type, mileage, fuelConsumption);
            case VehicleBrand.Mercedes:
                return new Mercedes(id, model, type, mileage, fuelConsumption);
            case VehicleBrand.Peugeot:
                return new Peugeot(id, model, type, mileage, fuelConsumption);
            default:
                return null;
        }
    }

    public Motorcycle CreateMotorcycle(int id, VehicleBrand brand, string model, MotorcycleType motorcycleType, double engineSize, double enginePower, double fuelConsumption)
    {
        switch (brand)
        {
            case VehicleBrand.Yamaha:
                return new Yamaha(id, model, motorcycleType, engineSize, enginePower, fuelConsumption);
            case VehicleBrand.Harley:
                return new Harley(id, model, motorcycleType, engineSize, enginePower, fuelConsumption);
            default:
                return null;
        }
    }
}