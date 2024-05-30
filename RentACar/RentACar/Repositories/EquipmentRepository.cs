using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using RentACar.Models;
using RentACar.Repositories.Interfaces;

namespace RentACar.Repositories;

public class EquipmentRepository : IRepository<Equipment>
{
    public IEnumerable<Equipment> GetAll()
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
        };
        
        using var streamReader = new StreamReader(Path.Combine(Configuration.PathToCsv, Configuration.EquipmentCsv));
        using var csvReader = new CsvReader(streamReader, config);

        csvReader.Read();

        var equipments = new List<Equipment>();

        while (csvReader.Read())
        {
            var id = csvReader.GetField(0);
            var name = csvReader.GetField(1);
            var cost = csvReader.GetField(2);
            var increasesPrice = csvReader.GetField(3);

            var equipment = new Equipment(int.Parse(id), name, double.Parse(cost), int.Parse(increasesPrice));
           
            equipments.Add(equipment);
        }

        return equipments;
    }
}