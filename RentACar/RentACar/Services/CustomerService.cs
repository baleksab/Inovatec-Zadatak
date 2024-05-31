using RentACar.Models;
using RentACar.Repositories.Interfaces;

namespace RentACar.Services;

public class CustomerService
{
    private readonly IRepository<Customer> _customerRepository;

    public CustomerService(IRepository<Customer> customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public ICollection<Customer> GetAllCustomers()
    {
        return _customerRepository.GetAll();
    }
}