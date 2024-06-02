using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using RentACar.Data;
using RentACar.Models.Vehicles;
using RentACar.Models.Vehicles.Cars;
using RentACar.Models.Vehicles.Factories;
using RentACar.Models.Vehicles.Motorcycles;
using RentACar.Repositories.Interfaces;

namespace RentACar.Repositories;

public class VehicleRepository : IRepository<Vehicle>
{
    private readonly DatabaseContext _dbContext;

    public VehicleRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ICollection<Vehicle> GetAll()
    {
        return _dbContext.Vehicles;
    }
}