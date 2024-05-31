using RentACar.Models;
using RentACar.Models.Vehicles;
using RentACar.Models.Vehicles.Cars;
using RentACar.Models.Vehicles.Factories;
using RentACar.Repositories.Interfaces;

namespace RentACar.Services;

public class VehicleService
{
    private readonly IRepository<Vehicle> _vehicleRepository;
    private readonly IRepository<CarEquipment> _carEquipmentRepository;
    private readonly EquipmentService _equipmentService;
    
    public VehicleService(IRepository<Vehicle> vehicleRepository, IRepository<CarEquipment> carEquipmentRepository,
        EquipmentService equipmentService)
    {
        _vehicleRepository = vehicleRepository;
        _carEquipmentRepository = carEquipmentRepository;
        _equipmentService = equipmentService;
    }

    public ICollection<Vehicle> GetAllVehicles()
    {
        return _vehicleRepository.GetAll();
    }

    public ICollection<Vehicle> GetAllVehiclesWithEquipment()
    {
        var vehicles = GetAllVehicles();
        var carEquipments = _carEquipmentRepository.GetAll();
        var equipments = _equipmentService.GetAllEquipments();
        
        var joinedEquipment = from ce in carEquipments
            join e in equipments on ce.EquipmentId equals e.Id
            group e by ce.VehicleId into g
            select new
            {
                VehicleId = g.Key,
                Equipments = g.ToList()
            };

        foreach (var data in joinedEquipment)
        {
            var vehicle = vehicles.FirstOrDefault(v => v.Id == data.VehicleId && v.VehicleType == VehicleType.Car);
            
            if (vehicle != null)
                ((Car)vehicle).Equipments = data.Equipments;
        }
        return vehicles;
    }
}