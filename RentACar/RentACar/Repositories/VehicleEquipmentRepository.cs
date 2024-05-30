using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using RentACar.Models;
using RentACar.Repositories.Interfaces;

namespace RentACar.Repositories;

public class VehicleEquipmentRepository : IRepository<CarEquipment>
{
    public IEnumerable<CarEquipment> GetAll()
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
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