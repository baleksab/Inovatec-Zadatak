using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using RentACar.Models;
using RentACar.Repositories.Interfaces;

namespace RentACar.Repositories;

public class ReservationRepository : IReservationRepository
{
    public IEnumerable<Reservation> GetAll()
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
        };
        
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

    public void AddReservation(Reservation reservation)
    {
        throw new NotImplementedException();
    }
}