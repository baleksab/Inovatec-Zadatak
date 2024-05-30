using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using RentACar.Models;

namespace RentACar.Repositories;

public class CustomerRepository : IRepository<Customer>
{
    public IEnumerable<Customer> GetAll()
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
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