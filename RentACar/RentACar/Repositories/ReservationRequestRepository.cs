using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using RentACar.Models;
using RentACar.Repositories.Interfaces;

namespace RentACar.Repositories;

public class ReservationRequestRepository : IRepository<ReservationRequest>
{
    public ICollection<ReservationRequest> GetAll()
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            MissingFieldFound = null,
            IgnoreBlankLines = true,
            ShouldSkipRecord = args => args.Row.Parser.Record.All(string.IsNullOrWhiteSpace)
        };
        
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
}