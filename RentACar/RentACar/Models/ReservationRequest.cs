using System;
using System.Runtime.InteropServices.JavaScript;

namespace RentACar.Models;

public class ReservationRequest
{
    public int VehicleId { get; set; }
    public int CustomerId { get; set; }
    public DateTime DateOfArrival { get; set; }
    public DateTime DateOfReservation { get; set; }
    public int Duration { get; set; }

    public ReservationRequest(int vehicleId, int customerId, DateTime dateOfArrival, DateTime dateOfReservation, int duration)
    {
        VehicleId = vehicleId;
        CustomerId = customerId;
        DateOfArrival = dateOfArrival;
        DateOfReservation = dateOfReservation;
        Duration = duration;
    }

    public override string ToString()
    {
        return
            $"{nameof(VehicleId)}: {VehicleId}, {nameof(CustomerId)}: {CustomerId}, {nameof(DateOfArrival)}: {DateOfArrival}, " +
            $"{nameof(DateOfReservation)}: {DateOfReservation}, {nameof(Duration)}: {Duration}";
    }
}