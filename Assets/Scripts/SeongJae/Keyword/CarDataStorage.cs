using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// CarData를 보관하고, 꺼내올 수 있는 클래스
/// </summary>
public class CarDataStorage
{
    private List<CarData>[][][] carData;
    public List<CarData>[][][] CarData { get => carData; }

    private const int EXCEPT_FUEL_TYPE = 0;
    private const int EXCEPT_CAR_TYPE = 1;
    private const int EXCEPT_CAR_PRICE = 2;

    // 정말 죄송합니다.. 능력 부족으로 List의 3차원 배열로 분류를 구현하게 될 것 같네요
    // 이는 카테고리 추가에 있어 굉장히 경직되어 있기에 좋은 아이디어 있으면 좀 배우고 싶습니다.
    // 트리로 구현할까도 생각했지만 결과적으로 하는 일은 동일해서 하드 코딩으로 진행했습니다.

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
    /// CarDataStorage에서 조건에 맞는 CarData를 불러오는 함수
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
            // KeywordToggleGroup과 마찬가지로 Default값을 빼기 위해 -1
            int fuelTypeLength = Enum.GetValues(typeof(Keyword.FuelType)).Length - 1;
            int carTypeLength = Enum.GetValues(typeof(Keyword.CarType)).Length - 1;
            int carPriceLength = Enum.GetValues(typeof(Keyword.CarType)).Length - 1;

            // 특정 조건을 두개 만족하는 CarData 리스트 생성.
            List<CarData>[] secondaryData = new List<CarData>[dataLength];

            //이후 어떤 조건을 제외하고 만족하는 지 설정.
            //유저가 정확히 원한 설정이 아니기에 랜덤은 한번만 돌리고 없으면 쿨하게 넘어가는 식으로.
            //추후 매커니즘 수정예정.
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
                Debug.Log("조건에 맞는 차량 없음");
                return null;
            }

            foreach (var carData in requestedData)
            {
                Debug.Log("특정 조건 두 개를 만족");
                Debug.Log(carData.Name);
            }
        }
        else
        {
            foreach (var carData in requestedData)
            {
                Debug.Log("조건 세 개를 모두 만족");
                Debug.Log(carData.Name);
            }
        }

        return requestedData;
    }
}
