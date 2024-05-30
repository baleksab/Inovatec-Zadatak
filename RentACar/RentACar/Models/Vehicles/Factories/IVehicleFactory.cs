using RentACar.Models.Vehicles.Cars;
using RentACar.Models.Vehicles.Motorcycles;

namespace RentACar.Models.Vehicles.Factories;

public interface IVehicleFactory
{
    Car CreateCar(int id, VehicleBrand brand, string model, CarType type, double mileage, double fuelConsumption);
    Motorcycle CreateMotorcycle(int id, VehicleBrand brand, string model, MotorcycleType motorcycleType, double engineSize, double enginePower, double fuelConsumption);
}