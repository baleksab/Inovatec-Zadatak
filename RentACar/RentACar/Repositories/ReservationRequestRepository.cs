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

public class ReservationRequestRepository : IRepository<ReservationRequest>
{
    private readonly DatabaseContext _dbContext;

    public ReservationRequestRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public ICollection<ReservationRequest> GetAll()
    {
        return _dbContext.ReservationRequests;
    }
}