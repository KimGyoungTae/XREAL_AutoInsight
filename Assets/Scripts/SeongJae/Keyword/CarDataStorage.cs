using System.Collections.Generic;
using UnityEngine;

public class CarDataStorage
{
    private Dictionary<string, CarData> carData;
    
    public Dictionary<string, CarData> CarData { get => carData; }

    public void RegisterData(CarData data)
    {
        if(carData == null)
        {
            carData = new Dictionary<string, CarData>();
        }
        carData.Add(data.Name, data);
        Debug.Log(data.Name);
    }
}
