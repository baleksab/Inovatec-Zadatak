using RentACar.Services.Interfaces;

namespace RentACar.Services;

public class SimulatorService : ISimulatorService
{
    private readonly VehicleService _vehicleService;

    public SimulatorService(VehicleService vehicleService)
    {
        _vehicleService = vehicleService;
    }
    
    public void ShowVehicleInformation()
    {
        var vehicles = _vehicleService.GetAllVehiclesWithEquipment();

        foreach (var vehicle in vehicles)
        {
            Console.WriteLine(vehicle);
        }
    }

    public void ShowCustomerInformation()
    {
        throw new NotImplementedException();
    }

    public void SimulateRenting()
    {
        throw new NotImplementedException();
    }
}