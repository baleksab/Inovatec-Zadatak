namespace RentACar.Services.Interfaces;

public interface ISimulatorService
{
    void ShowVehicleInformation(); // na standardni izlaz ispisuju podaci o vozilima i njihovim cenama
    void ShowCustomerInformation(); // podaci o korisnicima kao i koji tip članske karitce imaju (ako je imaju uopšte) i koliki su popust ostvarili.
    void ShowSimulation(); // Na kraju se simulira iznajmljivanje
}