using System;
using UnityEngine;

/// <summary>
/// ������ ������ ���õ� Ű���带 �����ϴ� Ŭ����.
/// </summary>
public static class Keyword
{
    //��� ���� �ش� �� ���� type���� �з���.
    //����� Ȯ���� ��ƴٴ� ������ ����. �̸� �ذ��ϱ� ���� ����� �� �ʿ���.
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
        Electic
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
        From3000To4000,
        From4000To5000,
        From5000To6000,
        Over6000
    }

    //TMP�� �ѱ� ��Ʈ�� ���� ��ġ�ؾ��ؼ� �켱 ����� ��ü.
    private static string[] Fuel = new string[] { "Gasoline", "Hybrid", "Electic" };
    private static string[] TypeOfCar = new string[] { "Sedan", "SUV", "Hatchback", "Truck" };
    // 3000�̻�� 4000�̻��� ������ ��ġ�� �� ������, �����ϰ� �ϱ� ���� �켱 �̷���..
    private static string[] Price = new string[] { "Over3000", "Over4000", "Over5000", "Over6000" };

    // �޴� ���� ����ų� �� �� enum�� �ش��ϴ� string���� ��ȯ�ϴ� �Լ�.
    // ������ �Լ��̱⿡ ���� ������ ���� ���ǰ� �� ������ ó�� ����.
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
            Debug.Log("�߸��� Ÿ���� �Է��߽��ϴ�!");
            return null;
        }
    }
}
