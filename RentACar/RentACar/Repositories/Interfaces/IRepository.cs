namespace RentACar.Repositories.Interfaces;

public interface IRepository<out T>
{
    IEnumerable<T> GetAll();
}