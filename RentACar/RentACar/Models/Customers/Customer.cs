namespace RentACar.Models.Customers;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double Budget { get; set; }
    public MembershipType MembershipType { get; set; }

    public Customer(int id, string firstName, string lastName, double budget, MembershipType membershipType)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Budget = budget;
        MembershipType = membershipType;
    }

    public override string ToString()
    {
        return
            $"{nameof(Id)}: {Id}, {nameof(FirstName)}: {FirstName}, {nameof(LastName)}: {LastName}, {nameof(Budget)}: {Budget}, {nameof(MembershipType)}: {MembershipType}";
    }
}