using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using RentACar.Models;
using RentACar.Models.Vehicles;
using RentACar.Models.Vehicles.Cars;
using RentACar.Models.Vehicles.Factories;
using RentACar.Models.Vehicles.Motorcycles;

namespace RentACar.Data;

public class DatabaseContext
{
    private readonly IVehicleFactory _vehicleFactory;
    
    public ICollection<Vehicle> Vehicles { get; private set; }
    public ICollection<Equipment> Equipments { get; private set; }
    public ICollection<Reservation> Reservations { get; private set; }
    public ICollection<ReservationRequest> ReservationRequests { get; private set; }
    public ICollection<CarEquipment> CarEquipments { get; private set; }
    public ICollection<Customer> Customers { get; private set; }
    
    public DatabaseContext(IVehicleFactory vehicleFactory) // nema potrebe za lock mehanizmom posto MS Dependency Injection biblioteka je menedzuje za nas
    {
        _vehicleFactory = vehicleFactory;
        
       LoadModels();
    }

    private void LoadModels()
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            MissingFieldFound = null,
            IgnoreBlankLines = true,
            ShouldSkipRecord = args => args.Row.Parser.Record.All(string.IsNullOrWhiteSpace)
        };

        Vehicles = LoadVehicleModels(config);
        Equipments = LoadEquipmentModels(config);
        Reservations = LoadReservationModels(config);
        ReservationRequests = LoadReservationRequestModels(config);
        CarEquipments = LoadCarEquipmentModels(config);
        Customers = LoadCustomerModels(config);
    }

    private ICollection<Vehicle> LoadVehicleModels(CsvConfiguration config)
    {
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
                    var motorcycle = _vehicleFactory.CreateMotorcycle(int.Parse(id), brand.ParseVehicleBrand(), model, bodyType.ParseMotorcycleType(), 
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

    private ICollection<Reservation> LoadReservationModels(CsvConfiguration config)
    {
        using var streamReader = new StreamReader(Path.Combine(Configuration.PathToCsv, Configuration.ReservationCsv));
        using var csvReader = new CsvReader(streamReader, config);

        csvReader.Read();

        var reservations = new List<Reservation>();

        while (csvReader.Read())
        {
            var vehicleId = csvReader.GetField(0);
            var customerId = csvReader.GetField(1);
            var startDate = csvReader.GetField(2);
            var endDate = csvReader.GetField(3);

            var reservation = new Reservation(int.Parse(vehicleId), int.Parse(customerId), DateTime.Parse(startDate), DateTime.Parse(endDate));
           
            reservations.Add(reservation);
        }

        return reservations;
    }

    private ICollection<ReservationRequest> LoadReservationRequestModels(CsvConfiguration config)
    {
        using var streamReader = new StreamReader(Path.Combine(Configuration.PathToCsv, Configuration.ReservationRequestCsv));
        using var csvReader = new CsvReader(streamReader, config);

        csvReader.Read();

        var reservationsRequests = new List<ReservationRequest>();

        while (csvReader.Read())
        {
            var vehicleId = csvReader.GetField(0);
            var customerId = csvReader.GetField(1);
            var dateOfArrival = csvReader.GetField(2);
            var dateOfReservation = csvReader.GetField(3);
            var duration = csvReader.GetField(4);
            
            var reservationRequest = new ReservationRequest(int.Parse(vehicleId), int.Parse(customerId), 
                DateTime.Parse(dateOfArrival), DateTime.Parse(dateOfReservation), int.Parse(duration));
           
            reservationsRequests.Add(reservationRequest);
        }

        return reservationsRequests;
    }

    private ICollection<Equipment> LoadEquipmentModels(CsvConfiguration config)
    {
        using var streamReader = new StreamReader(Path.Combine(Configuration.PathToCsv, Configuration.EquipmentCsv));
        using var csvReader = new CsvReader(streamReader, config);

        csvReader.Read();

        var equipments = new List<Equipment>();

        while (csvReader.Read())
        {
            var id = csvReader.GetField(0);
            var name = csvReader.GetField(1);
            var cost = csvReader.GetField(2);
            var increasesPrice = csvReader.GetField(3);

            var equipment = new Equipment(int.Parse(id), name, double.Parse(cost), int.Parse(increasesPrice));
           
            equipments.Add(equipment);
        }

        return equipments;
    }

    private ICollection<Customer> LoadCustomerModels(CsvConfiguration config)
    {
        using var streamReader = new StreamReader(Path.Combine(Configuration.PathToCsv, Configuration.CustomerCsv));
        using var csvReader = new CsvReader(streamReader, config);

        csvReader.Read();

        var customers = new List<Customer>();

        while (csvReader.Read())
        {
            var id = csvReader.GetField(0);
            var firstName = csvReader.GetField(1);
            var lastName = csvReader.GetField(2);
            var budget = csvReader.GetField(3);
            var membership = csvReader.GetField(4);

            var customer = new Customer(int.Parse(id), firstName, lastName, double.Parse(budget), membership.ParseMembershipType());
           
            customers.Add(customer);
        }

        return customers;
    }

    private ICollection<CarEquipment> LoadCarEquipmentModels(CsvConfiguration config)
    {
        using var streamReader = new StreamReader(Path.Combine(Configuration.PathToCsv, Configuration.CarEquipmentCsv));
        using var csvReader = new CsvReader(streamReader, config);

        csvReader.Read();

        var vehicleEquipments = new List<CarEquipment>();

        while (csvReader.Read())
        {
            var vehicleId = csvReader.GetField(0);
            var equipmentId = csvReader.GetField(1);

            var vehicleEquipment = new CarEquipment(int.Parse(vehicleId), int.Parse(equipmentId));
           
            vehicleEquipments.Add(vehicleEquipment);
        }

        return vehicleEquipments;
    }
}