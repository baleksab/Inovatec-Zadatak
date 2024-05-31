using RentACar.Models;
using RentACar.Repositories.Interfaces;

namespace RentACar.Services;

public class EquipmentService
{
    private readonly IRepository<Equipment> _equipmentRepository;

    public EquipmentService(IRepository<Equipment> equipmentRepository)
    {
        _equipmentRepository = equipmentRepository;
    }

    public ICollection<Equipment> GetAllEquipments()
    {
        return _equipmentRepository.GetAll();
    }
}