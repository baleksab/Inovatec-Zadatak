using RentACar.Models.Vehicles;
using RentACar.Models.Vehicles.Cars;

namespace RentACar;

class Program
{
    static void Main(string[] args)
    {
        Vehicle mercedes = new Mercedes(1, "S-Class", Car.Type.Limousine, 45000, 7);

        Console.WriteLine(mercedes.CalculateRentCost());
    }
}