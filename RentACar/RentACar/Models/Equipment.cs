namespace RentACar.Models;

public class Equipment
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Cost { get; set; }
    public int IncreasesPrice { get; set; }

    public Equipment(int id, string name, double cost, int increasesPrice)
    {
        Id = id;
        Name = name;
        Cost = cost;
        IncreasesPrice = increasesPrice;
    }

    public override string ToString()
    {
        return
            $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Cost)}: {Cost}, {nameof(IncreasesPrice)}: {IncreasesPrice}";
    }
}