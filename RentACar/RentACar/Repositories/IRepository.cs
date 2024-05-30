namespace RentACar.Repositories;

public interface IRepository<out T>
{
    IEnumerable<T> GetAll();
}