using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using RentACar.Models;
using RentACar.Repositories.Interfaces;

namespace RentACar.Repositories;

public class CustomerRepository : IRepository<Customer>
{
    public ICollection<Customer> GetAll()
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            MissingFieldFound = null,
            IgnoreBlankLines = true,
            ShouldSkipRecord = args => args.Row.Parser.Record.All(string.IsNullOrWhiteSpace)
        };
        
        using var streamReader = new StreamReader(Path.Combine(Configuration.PathToCsv, Configuration.CustomerCsv));
        using var csvReader = new CsvReader(streamReader, config);

        csvReader.Read();

        var customers = new List<Customer>();

        while (csvReader.Read())
        {
            var id = csvReader.GetField(0);
            var firstName = csvReader.GetField(1);
            var lastName = csvReader.GetField(2);
            var budget = csvReader.GetField(3);
            var membership = csvReader.GetField(4);

            var customer = new Customer(int.Parse(id), firstName, lastName, double.Parse(budget), membership.ParseMembershipType());
           
            customers.Add(customer);
        }

        return customers;
    }
}