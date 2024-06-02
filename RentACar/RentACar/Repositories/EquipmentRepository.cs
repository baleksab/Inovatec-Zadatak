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

public class EquipmentRepository : IRepository<Equipment>
{
    private readonly DatabaseContext _dbContext;

    public EquipmentRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public ICollection<Equipment> GetAll()
    {
        return _dbContext.Equipments;
    }
}