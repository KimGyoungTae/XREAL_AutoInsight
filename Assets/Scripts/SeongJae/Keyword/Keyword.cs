using System;
using UnityEngine;

/// <summary>
/// 차량의 종류와 관련된 키워드를 저장하는 클래스.
/// </summary>
public static class Keyword
{
    //모든 차는 해당 세 가지 type으로 분류됨.
    //현재는 확장이 어렵다는 단점이 있음. 이를 해결하기 위한 고민이 더 필요함.
    public enum KeywordTypes
    { 
        FuelType,
        CarType,
        CarPrice
    }

    public enum FuelType
    {
        Default = -1,
        Gasoline,
        Hybrid,
        Electric
    }

    public enum CarType
    {
        Default = -1,
        Sedan,
        SUV,
        Hatchback,
        Truck
    }

    public enum CarPrice
    {
        Default = -1,
        Under4000,
        From4000To5000,
        From5000To6000,
        Over6000
    }

    //TMP는 한글 폰트를 따로 설치해야해서 우선 영어로 대체.
    private static string[] Fuel = new string[] { "Gasoline", "Hybrid", "Electic" };
    private static string[] TypeOfCar = new string[] { "Sedan", "SUV", "Hatchback", "Truck" };
    // 4000이상과 5000이상의 범위가 겹치는 건 알지만, 간단하게 하기 위해 우선 이렇게..
    private static string[] Price = new string[] { "Under4000", "Over4000", "Over5000", "Over6000" };

    // 메뉴 등을 만들거나 할 때 enum을 해당하는 string으로 반환하는 함수.
    // 조잡한 함수이기에 추후 구조에 대한 논의가 더 나오면 처분 예정.
    public static string[] GetKeywordArray<T>(T someType) where T : Enum
    {
        if (typeof(T) == typeof(FuelType))
        {
            return Fuel;
        }
        else if (typeof(T) == typeof(CarType))
        {
            return TypeOfCar;
        }
        else if (typeof(T) == typeof(CarPrice))
        {
            return Price;
        }
        else
        {
            Debug.Log("잘못된 타입을 입력했습니다!");
            return null;
        }
    }
}
