using RentACar.Models;
using RentACar.Models.Vehicles.Cars;
using RentACar.Models.Vehicles.Motorcycles;
using RentACar.Repositories.Interfaces;

namespace RentACar.Services;

public class ReservationService
{
    private readonly CustomerService _customerService;
    private readonly VehicleService _vehicleService;
    private readonly IReservationRepository _reservationRepository;
    private readonly IRepository<ReservationRequest> _reservationRequestRepository;

    public ReservationService(CustomerService customerService, VehicleService vehicleService, 
        IReservationRepository reservationRepository, IRepository<ReservationRequest> reservationRequestRepository)
    {
        _customerService = customerService;
        _vehicleService = vehicleService;
        _reservationRepository = reservationRepository;
        _reservationRequestRepository = reservationRequestRepository;
    }

    public ICollection<ReservationRequest> GetAllReservationRequests()
    {
        return _reservationRequestRepository.GetAll();
    }

    public ICollection<Reservation> GetAllReservations()
    {
        return _reservationRepository.GetAll();
    }

    public void ProcessReservations()
    {
        var requests = GetAllReservationRequests();
        var vehicles = _vehicleService.GetAllVehiclesWithEquipment();
        var customers = _customerService.GetAllCustomers();
        var reservations = GetAllReservations();
        
        var query = from request in requests
            join customer in customers on request.CustomerId equals customer.Id
            join vehicle in vehicles on request.VehicleId equals vehicle.Id
            select new
            {
                Customer  = customer,
                Vehicle = vehicle,
                ReservationRequest = request
            };
        
        var sortedQuery = query
            .OrderBy(row => row.ReservationRequest.DateOfArrival)
            .ThenBy(row => row.Customer.MembershipType);
        
        foreach (var row in sortedQuery)
        {
            var vehicle = row.Vehicle;
            var customer = row.Customer;
            var request = row.ReservationRequest;
            
            Console.WriteLine($"{customer.FirstName + " " + customer.LastName} has arrived to " +
                              $"RentACar at date {request.DateOfArrival:dd/MM/yyyy} with a budget of {customer.Budget}$. " +
                              $"{(customer.MembershipType != MembershipType.None ? "They are a " + customer.MembershipType + " member" : "")}");
            Console.WriteLine($"They wish to rent a {vehicle.VehicleType}, {vehicle.Brand} {vehicle.Model} " +
                              $"({(vehicle is Car ? ((Car) vehicle).CarType : ((Motorcycle) vehicle).MotorcycleType)}), " +
                              $"on {request.DateOfReservation:dd/MM/yyyy} for {request.Duration} days until {request.DateOfReservation.AddDays(request.Duration):dd/MM/yyyy}.");

            var alreadyHasReservation = reservations
                .Any(reservation => reservation.CustomerId == customer.Id && 
                                               reservation.StartDate <= request.DateOfReservation && 
                                               request.DateOfReservation <= reservation.EndDate);

            if (alreadyHasReservation)
            {
                Console.WriteLine("RESERVATION FAILED: Customer already has a reservation during this period!\n");
                
                continue;
            }
            
            var vehicleIsReserved = reservations
                .Any(reservation => reservation.VehicleId == vehicle.Id &&
                                    reservation.StartDate <= request.DateOfReservation && 
                                    request.DateOfReservation <= reservation.EndDate);

            if (vehicleIsReserved)
            {
                Console.WriteLine("RESERVATION FAILED: Vehicle is already reserved during this period!\n");

                continue;
            }
            
            var rentCost = vehicle.RentCost;

            Console.Write($"This vehicle costs {vehicle.RentCost}$ per day to rent, ");

            if (customer.MembershipType != MembershipType.None)
            {
                rentCost -= ( rentCost * customer.GetMembershipDiscount() / 100);
                Console.Write($"they are a {customer.MembershipType} member so they get a {customer.GetMembershipDiscount()}% discount adjusting their rent cost to {rentCost}$, ");
            }

            var total = rentCost * request.Duration;
            
            Console.WriteLine($"since they want to rent for {request.Duration} days it would total them {total}$");

            if (customer.Budget < total)
            {
                Console.WriteLine("RESERVATION FAILED: Customer doesn't have enough money for this reservation!\n");
                
                continue;
            }

            customer.Budget -= total;
            
            var reservation = new Reservation(vehicle.Id, customer.Id, request.DateOfReservation,
                request.DateOfReservation.AddDays(request.Duration));
            
            reservations.Add(reservation);
            
            Console.WriteLine($"RESERVARTION SUCCESSFUL: Customer has successfully reserved this vehicle and his new budget is {customer.Budget}$\n");
            
            _reservationRepository.AddNewReservation(reservation);
        }
    }
}