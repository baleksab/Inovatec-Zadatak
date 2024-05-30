using RentACar.Models;

namespace RentACar.Repositories.Interfaces;

public interface IReservationRepository : IRepository<Reservation>
{
    void AddReservation(Reservation reservation);
}