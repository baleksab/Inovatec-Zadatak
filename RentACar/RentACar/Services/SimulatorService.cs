using RentACar.Services.Interfaces;

namespace RentACar.Services;

public class SimulatorService : ISimulatorService
{
    private readonly VehicleService _vehicleService;
    private readonly CustomerService _customerService;
    private readonly ReservationService _reservationService;

    public SimulatorService(VehicleService vehicleService, CustomerService customerService,
        ReservationService reservationService)
    {
        _vehicleService = vehicleService;
        _customerService = customerService;
        _reservationService = reservationService;
    }
    
    public void ShowVehicleInformation()
    {
        ShowHeader("Vehicle information");
        
        var vehicles = _vehicleService.GetAllVehiclesWithEquipment();

        foreach (var vehicle in vehicles)
        {
            Console.WriteLine(vehicle);
        }
    }

    public void ShowCustomerInformation()
    {
        ShowHeader("Customer information");
        
        var customers = _customerService.GetAllCustomers();

        foreach (var customer in customers)
        {
            Console.WriteLine(customer);
        }
    }
    
    public void ShowSimulation()
    {
        ShowHeader("Renting simulation");
        
        _reservationService.ProcessReservations();
    }
    
    private void ShowHeader(string title)
    {
        Console.WriteLine();
        Console.WriteLine("=====================================================");
        Console.WriteLine("\t" + title);
        Console.WriteLine("=====================================================");
        Console.WriteLine();
    }
}