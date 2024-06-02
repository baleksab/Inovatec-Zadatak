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

public class CustomerRepository : IRepository<Customer>
{
    private readonly DatabaseContext _dbContext;

    public CustomerRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public ICollection<Customer> GetAll()
    {
        return _dbContext.Customers;
    }
}