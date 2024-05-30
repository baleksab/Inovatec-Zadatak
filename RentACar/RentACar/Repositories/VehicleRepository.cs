using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using RentACar.Models.Vehicles;
using RentACar.Models.Vehicles.Cars;
using RentACar.Models.Vehicles.Factories;
using RentACar.Models.Vehicles.Motorcycles;
using RentACar.Repositories.Interfaces;

namespace RentACar.Repositories;

public class VehicleRepository : IRepository<Vehicle>
{
    private readonly IVehicleFactory _vehicleFactory;

    public VehicleRepository(IVehicleFactory vehicleFactory)
    {
        _vehicleFactory = vehicleFactory;
    }

    public IEnumerable<Vehicle> GetAll()
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
        };
        
        using var streamReader = new StreamReader(Path.Combine(Configuration.PathToCsv, Configuration.VehicleCsv));
        using var csvReader = new CsvReader(streamReader, config);

        csvReader.Read();
        
        var vehicles = new List<Vehicle>();

        while (csvReader.Read())
        {
            var id = csvReader.GetField(0);
            var vehicleType = csvReader.GetField(1);
            var brand = csvReader.GetField(2);
            var model = csvReader.GetField(3);
            var fuelConsumption = csvReader.GetField(4);
            var engineSize = csvReader.GetField(5);
            var mileage = csvReader.GetField(6);
            var enginePower = csvReader.GetField(7);
            var bodyType = csvReader.GetField(8);
        
            switch (vehicleType.ParseVehicleType())
            {
                case VehicleType.Car:
                    var car = _vehicleFactory.CreateCar(int.Parse(id), brand.ParseVehicleBrand(), model, bodyType.ParseCarType(), 
                        double.Parse(mileage), double.Parse(fuelConsumption));
                    
                    if (car is null)
                        Console.WriteLine("Preskocem jedno vozilo tipa automobil, nije prepoznata marka!");
                    else 
                        vehicles.Add(car);
                    
                    break;
                case VehicleType.Motorcycle:
                    Motorcycle motorcycle = _vehicleFactory.CreateMotorcycle(int.Parse(id), brand.ParseVehicleBrand(), model, bodyType.ParseMotorcycleType(), 
                        double.Parse(engineSize), double.Parse(enginePower), double.Parse(fuelConsumption));
                    
                    if (motorcycle is null)
                        Console.WriteLine("Preskocem jedno vozilo tipa motor, nije prepoznata marka!");
                    else 
                        vehicles.Add(motorcycle);

                    break;
            }
        }

        return vehicles;
    }
}