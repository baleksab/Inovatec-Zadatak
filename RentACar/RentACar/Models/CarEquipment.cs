namespace RentACar.Models;

public class CarEquipment
{
    public int VehicleId { get; set; }
    public int EquipmentId { get; set; }

    public CarEquipment(int vehicleId, int equipmentId)
    {
        VehicleId = vehicleId;
        EquipmentId = equipmentId;
    }

    public override string ToString()
    {
        return $"{nameof(VehicleId)}: {VehicleId}, {nameof(EquipmentId)}: {EquipmentId}";
    }
}