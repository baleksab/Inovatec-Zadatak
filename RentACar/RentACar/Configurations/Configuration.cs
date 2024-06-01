namespace RentACar;

public class Configuration
{
    public static readonly double CarBasePrice = 200;
    public static readonly double MotorcycleBasePrice = 100;

    public static readonly double VipDiscount = 20;
    public static readonly double BasicDiscount = 10;
    
    public static readonly string PathToCsv = "Resources";
    
    public static readonly string VehicleCsv = "vozila.csv";
    public static readonly string CarEquipmentCsv = "vozilo_oprema.csv"; 
    public static readonly string CustomerCsv = "kupci.csv";
    public static readonly string EquipmentCsv = "oprema.csv";
    public static readonly string ReservationCsv = "rezervacije.csv";
    public static readonly string ReservationRequestCsv = "zahtevi_za_rezervacije.csv";

    public static readonly string PathToOuputCsv = ".";
    public static readonly string OutputCsv = "nove_rezervacije.csv";
}