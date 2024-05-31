using RentACar.Models.Interfaces;

namespace RentACar.Models;

public class Customer : IMembershipDiscount
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
        return $"Customer Details:\n" +
               $"  - ID: {Id}\n" +
               $"  - First Name: {FirstName}\n" +
               $"  - Last Name: {LastName}\n" +
               $"  - Budget: {Budget}$\n" +
               $"  - Membership Type: {MembershipType}\n" +
               $"  - Membership Discount: {(GetMembershipDiscount() > 0 ? GetMembershipDiscount() + "%" : "None")}\n";
    }

    public double GetMembershipDiscount()
    {
        switch (MembershipType)
        {
            case MembershipType.Vip:
                return Configuration.VipDiscount;
            case MembershipType.Basic:
                return Configuration.BasicDiscount;
            default:
                return 0;
        }
    }
}

public enum MembershipType
{
    Vip,
    Basic,
    None,
}

public static class MembershipTypeExtension {
    public static MembershipType ParseMembershipType(this string value)
    {
        switch (value.ToLower())
        {
            case "vip":
                return MembershipType.Vip;
            case "basic":
                return MembershipType.Basic;
            default:
                return MembershipType.None;
        }
    }
}