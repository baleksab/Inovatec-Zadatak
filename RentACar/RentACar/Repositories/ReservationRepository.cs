using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using RentACar.Data;
using RentACar.Models;
using RentACar.Repositories.Interfaces;

namespace RentACar.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly DatabaseContext _dbContext;

    public ReservationRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public ICollection<Reservation> GetAll()
    {
        return _dbContext.Reservations;
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