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

public class CarEquipmentRepository : IRepository<CarEquipment>
{
    private readonly DatabaseContext _dbContext;

    public CarEquipmentRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public ICollection<CarEquipment> GetAll()
    {
        return _dbContext.CarEquipments;
    }
}