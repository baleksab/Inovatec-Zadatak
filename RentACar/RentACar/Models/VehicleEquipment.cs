namespace RentACar.Models;

public class VehicleEquipment
{
    public int VehicleId { get; set; }
    public int EquipmentId { get; set; }

    public VehicleEquipment(int vehicleId, int equipmentId)
    {
        VehicleId = vehicleId;
        EquipmentId = equipmentId;
    }

    public override string ToString()
    {
        return $"{nameof(VehicleId)}: {VehicleId}, {nameof(EquipmentId)}: {EquipmentId}";
    }
}