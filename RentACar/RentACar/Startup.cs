using Microsoft.Extensions.DependencyInjection;
using RentACar.Models;
using RentACar.Models.Vehicles;
using RentACar.Models.Vehicles.Factories;
using RentACar.Repositories;
using RentACar.Repositories.Interfaces;
using RentACar.Services;
using RentACar.Services.Interfaces;

namespace RentACar;

public class Startup
{
    public static void Main(string[] args)
    {
        var serviceProvider = RegisterServices();
        var simulatorService = serviceProvider.GetService<ISimulatorService>();
        
        simulatorService.ShowVehicleInformation();
    }

    private static ServiceProvider RegisterServices()
    {
        var serviceProvider = new ServiceCollection()
            .AddTransient<IVehicleFactory, VehicleFactory>()
            .AddTransient<IRepository<CarEquipment>, CarEquipmentRepository>()
            .AddTransient<IRepository<Customer>, CustomerRepository>()
            .AddTransient<IRepository<Equipment>, EquipmentRepository>()
            .AddTransient<IRepository<Reservation>, ReservationRepository>()
            .AddTransient<IReservationRepository, ReservationRepository>()
            .AddTransient<IRepository<ReservationRequest>, ReservationRequestRepository>()
            .AddTransient<IRepository<Vehicle>, VehicleRepository>()
            .AddTransient<VehicleService>()
            .AddTransient<EquipmentService>()
            .AddTransient<ISimulatorService, SimulatorService>()
            .BuildServiceProvider();

        return serviceProvider;
    }
}