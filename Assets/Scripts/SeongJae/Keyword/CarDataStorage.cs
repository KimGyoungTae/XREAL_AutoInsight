using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// CarData�� �����ϰ�, ������ �� �ִ� Ŭ����
/// </summary>
public class CarDataStorage
{
    private List<CarData>[][][] carData;
    public List<CarData>[][][] CarData { get => carData; }

    private const int EXCEPT_FUEL_TYPE = 0;
    private const int EXCEPT_CAR_TYPE = 1;
    private const int EXCEPT_CAR_PRICE = 2;

    // ���� �˼��մϴ�.. �ɷ� �������� List�� 3���� �迭�� �з��� �����ϰ� �� �� ���׿�
    // �̴� ī�װ� �߰��� �־� ������ �����Ǿ� �ֱ⿡ ���� ���̵�� ������ �� ���� �ͽ��ϴ�.
    // Ʈ���� �����ұ ���������� ��������� �ϴ� ���� �����ؼ� �ϵ� �ڵ����� �����߽��ϴ�.

    public void RegisterData(CarData data)
    {
        if (carData == null)
        {
            carData = new List<CarData>[Enum.GetValues(typeof(Keyword.FuelType)).Length - 1][][];
            for (int i = 0; i < carData.Length; ++i)
            {
                carData[i] = new List<CarData>[Enum.GetValues(typeof(Keyword.CarType)).Length - 1][];
                for (int j = 0; j < carData[i].Length; ++j)
                {
                    carData[i][j] = new List<CarData>[Enum.GetValues(typeof(Keyword.CarPrice)).Length - 1];
                }
            }
        }

        if (carData[(int)data.FuelType][(int)data.CarType][(int)data.CarPrice] == null)
        {
            carData[(int)data.FuelType][(int)data.CarType][(int)data.CarPrice] = new List<CarData>();
        }
        carData[(int)data.FuelType][(int)data.CarType][(int)data.CarPrice].Add(data);
    }

    /// <summary>
    /// CarDataStorage���� ���ǿ� �´� CarData�� �ҷ����� �Լ�
    /// </summary>
    /// <param name="fuelType"></param>
    /// <param name="carType"></param>
    /// <param name="carPrice"></param>
    /// <returns></returns>
    public List<CarData> GetData(Keyword.FuelType fuelType, Keyword.CarType carType, Keyword.CarPrice carPrice)
    {
        List<CarData> requestedData = carData[(int)fuelType][(int)carType][(int)carPrice];
        if (requestedData == null)
        {
            requestedData = new List<CarData>();
            int dataLength = (int)Keyword.KeywordTypes.NumberOfKeywords;
            // KeywordToggleGroup�� ���������� Default���� ���� ���� -1
            int fuelTypeLength = Enum.GetValues(typeof(Keyword.FuelType)).Length - 1;
            int carTypeLength = Enum.GetValues(typeof(Keyword.CarType)).Length - 1;
            int carPriceLength = Enum.GetValues(typeof(Keyword.CarType)).Length - 1;

            // Ư�� ������ �ΰ� �����ϴ� CarData ����Ʈ ����.
            List<CarData>[] secondaryData = new List<CarData>[dataLength];

            //���� � ������ �����ϰ� �����ϴ� �� ����.
            //������ ��Ȯ�� ���� ������ �ƴϱ⿡ ������ �ѹ��� ������ ������ ���ϰ� �Ѿ�� ������.
            //���� ��Ŀ���� ��������.
            secondaryData[EXCEPT_FUEL_TYPE] = carData[UnityEngine.Random.Range(0, fuelTypeLength)][(int)carType][(int)carPrice];
            secondaryData[EXCEPT_CAR_TYPE] = carData[(int)fuelType][UnityEngine.Random.Range(0, carTypeLength)][(int)carPrice];
            secondaryData[EXCEPT_CAR_PRICE] = carData[(int)fuelType][(int)carType][UnityEngine.Random.Range(0, carPriceLength)];

            foreach (var data in secondaryData)
            {
                if(data != null)
                    requestedData.AddRange(data);
            }

            if(requestedData.Count == 0)
            {
                Debug.Log("���ǿ� �´� ���� ����");
                return null;
            }

            foreach (var carData in requestedData)
            {
                Debug.Log("Ư�� ���� �� ���� ����");
                Debug.Log(carData.Name);
            }
        }
        else
        {
            foreach (var carData in requestedData)
            {
                Debug.Log("���� �� ���� ��� ����");
                Debug.Log(carData.Name);
            }
        }

        return requestedData;
    }
}
