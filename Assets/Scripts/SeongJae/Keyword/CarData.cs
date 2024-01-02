using System;
using System.ComponentModel.Design.Serialization;

public class CarData
{
    private int id;
    private string name;
    public string Name { get => name; }

    private Keyword.FuelType fuelType;
    public Keyword.FuelType FuelType { get => fuelType; }

    private Keyword.CarType carType;
    public Keyword.CarType CarType { get => carType; }

    private Keyword.CarPrice carPrice;
    public Keyword.CarPrice CarPrice { get => carPrice; }

    public void InitSettings(int id, string name, string fuelType, string carType, int carPrice)
    {
        this.id = id;   
        this.name = name;
        SetFuelType(fuelType);
        SetCarType(carType);
        SetCarPrice(carPrice);
    }

    private void SetFuelType(string fuelType)
    {
        this.fuelType = (Keyword.FuelType)Enum.Parse(typeof(Keyword.FuelType), fuelType, true);
    }

    private void SetCarType(string carType) 
    {
        this.carType = (Keyword.CarType)Enum.Parse(typeof(Keyword.CarType), carType, true);
    }

    private void SetCarPrice(int carPrice)
    {
        if(carPrice > 6000)
        {
            this.carPrice = Keyword.CarPrice.Over6000;
        }
        else if(carPrice > 5000)
        {
            this.carPrice = Keyword.CarPrice.From5000To6000;
        }
        else if (carPrice > 4000)
        {
            this.carPrice = Keyword.CarPrice.From4000To5000;
        }
        else
        {
            this.carPrice = Keyword.CarPrice.Under4000;
        }
    }
}
