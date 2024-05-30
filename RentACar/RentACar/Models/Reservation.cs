namespace RentACar.Models;

public class Reservation
{
    public int VehicleId { get; set; }
    public int CustomerId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public Reservation(int vehicleId, int customerId, DateTime startDate, DateTime endDate)
    {
        VehicleId = vehicleId;
        CustomerId = customerId;
        StartDate = startDate;
        EndDate = endDate;
    }

    public override string ToString()
    {
        return
            $"{nameof(VehicleId)}: {VehicleId}, {nameof(CustomerId)}: {CustomerId}, {nameof(StartDate)}: {StartDate}, {nameof(EndDate)}: {EndDate}";
    }
}