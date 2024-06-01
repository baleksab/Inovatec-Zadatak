using RentACar.Models;

namespace RentACar.Repositories.Interfaces;

public interface IReservationRepository : IRepository<Reservation>
{
    void AddNewReservation(Reservation reservation);
}