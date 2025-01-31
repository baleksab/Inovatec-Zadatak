﻿using System.Diagnostics;
using RentACar.Models.Interfaces;

namespace RentACar.Models.Vehicles;

public abstract class Vehicle
{
    public int Id { get; set; }
    public VehicleType VehicleType { get; set; }
    public VehicleBrand Brand { get; set; }
    public string Model { get; set; }
    public double FuelConsumption { get; set; }
    public double BaseCost { get; set; }
    public double RentCost => GetFinalRentCost();
    
    protected Vehicle(int id, VehicleType vehicleType, VehicleBrand brand, string model, double fuelConsumption, double baseCost)
    {
        Id = id;
        VehicleType = vehicleType;
        Brand = brand;
        Model = model;
        FuelConsumption = fuelConsumption;
        BaseCost = baseCost;
    }

    protected abstract double GetAdjustedBaseCost();
    protected abstract double GetFinalRentCost();
    
    public override string ToString()
    {
        return $"Vehicle Details:\n" +
               $"  - ID: {Id}\n" +
               $"  - Type: {VehicleType}\n" +
               $"  - Brand: {Brand}\n" +
               $"  - Model: {Model}\n" +
               $"  - Fuel Consumption: {FuelConsumption} liters per 100km\n" +
               $"  - Base Cost Per Day: {BaseCost}$\n" +
               $"  - Adjusted Rent Cost Per Day: {RentCost}$\n";;
        
    }
}

public enum VehicleType
{
    Car,
    Motorcycle,
    Unknown
}

public static class VehicleTypeExtension
{
    public static VehicleType ParseVehicleType(this string value)
    {
        switch (value.ToLower())
        {
            case "automobil":
                return VehicleType.Car;
            case "motor":
                return VehicleType.Motorcycle;
            default:
                return VehicleType.Unknown;
        }
    }
}

public enum VehicleBrand
{
    Mercedes,
    Bmw,
    Peugeot,
    Yamaha,
    Harley,
    Unknown
}

public static class VehicleBrandExtension {
    public static VehicleBrand ParseVehicleBrand(this string value)
    {
        switch (value.ToLower())
        {
            case "mercedes":
                return VehicleBrand.Mercedes;
            case "bmw":
                return VehicleBrand.Bmw;
            case "peugeot":
                return VehicleBrand.Peugeot;
            case "yamaha":
                return VehicleBrand.Yamaha;
            case "harley":
                return VehicleBrand.Harley;
            default:
                return VehicleBrand.Unknown;
        }
    }
}