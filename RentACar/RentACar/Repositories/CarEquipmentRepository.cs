using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using RentACar.Models;
using RentACar.Repositories.Interfaces;

namespace RentACar.Repositories;

public class CarEquipmentRepository : IRepository<CarEquipment>
{
    public ICollection<CarEquipment> GetAll()
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            MissingFieldFound = null,
            IgnoreBlankLines = true,
            ShouldSkipRecord = args => args.Row.Parser.Record.All(string.IsNullOrWhiteSpace)
        };
        
        using var streamReader = new StreamReader(Path.Combine(Configuration.PathToCsv, Configuration.CarEquipmentCsv));
        using var csvReader = new CsvReader(streamReader, config);

        csvReader.Read();

        var vehicleEquipments = new List<CarEquipment>();

        while (csvReader.Read())
        {
            var vehicleId = csvReader.GetField(0);
            var equipmentId = csvReader.GetField(1);

            var vehicleEquipment = new CarEquipment(int.Parse(vehicleId), int.Parse(equipmentId));
           
            vehicleEquipments.Add(vehicleEquipment);
        }

        return vehicleEquipments;
    }
}