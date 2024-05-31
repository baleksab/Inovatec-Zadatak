using System.Collections.Generic;

namespace RentACar.Repositories.Interfaces;

public interface IRepository<T>
{
    ICollection<T> GetAll();
}