namespace RentACar.Models.Customers;

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