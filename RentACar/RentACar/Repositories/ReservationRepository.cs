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

public class ReservationRepository : IReservationRepository
{
    public ICollection<Reservation> GetAll()
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            MissingFieldFound = null,
            IgnoreBlankLines = true,
            ShouldSkipRecord = args => args.Row.Parser.Record.All(string.IsNullOrWhiteSpace)
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

    public void SaveNewReservations(ICollection<Reservation> reservations)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false,
            MissingFieldFound = null,
            IgnoreBlankLines = true,
            ShouldSkipRecord = args => args.Row.Parser.Record.All(string.IsNullOrWhiteSpace)
        };
        
        using var streamWriter = new StreamWriter(Path.Combine(Configuration.PathToOuputCsv, Configuration.OutputCsv));
        using var csvWriter = new CsvWriter(streamWriter, config);
        
        csvWriter.WriteField("VoziloId");
        csvWriter.WriteField("KupacId");
        csvWriter.WriteField("PocetakRezervacije");
        csvWriter.WriteField("KrajRezervacije");
        csvWriter.NextRecord();

        foreach (var reservation in reservations)
        {
            csvWriter.WriteField(reservation.VehicleId);
            csvWriter.WriteField(reservation.CustomerId);
            csvWriter.WriteField(reservation.StartDate.ToString("yyyy-MM-dd"));
            csvWriter.WriteField(reservation.EndDate.ToString("yyyy-MM-dd"));
            csvWriter.NextRecord();
        }
    }
}