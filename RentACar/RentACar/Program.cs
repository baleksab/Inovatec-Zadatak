using RentACar.Models.Customers;
using RentACar.Models.Vehicles;
using RentACar.Models.Vehicles.Cars;
using RentACar.Models.Vehicles.Factories;
using RentACar.Repositories;

namespace RentACar;

class Program
{
    static void Main(string[] args)
    {
        IVehicleFactory vehicleFactory = new VehicleFactory();
        
        IRepository<Vehicle> vehicleRepository = new VehicleRepository(vehicleFactory);
        IRepository<Customer> customerRepository = new CustomerRepository();
        
        foreach (var vehicle in vehicleRepository.GetAll())
        {
            Console.WriteLine(vehicle);
        }

        foreach (var customer in customerRepository.GetAll())
        {
            Console.WriteLine(customer);
        }
    }
}