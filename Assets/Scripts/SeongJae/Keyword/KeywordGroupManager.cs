using System;
using UnityEngine;
using UnityEngine.UI;
using static Keyword;

/// <summary>
/// Keyword 씬의 최상위 객체.
/// 각 KeywordToggleGroup을 만들고, 관리함.
/// </summary>
public class KeywordGroupManager : MonoBehaviour
{
    private KeywordToggleGroup[] groups;
    private Enum[] currentTypes;
    private CarDataStorage storage;

    // 디버깅용. 추후 삭제 예정.
    [Header("Debug")]
    [SerializeField] private Button button;

    private void Awake()
    {
        InitSettings();
    }
    public void InitSettings()
    {
        groups = GetComponentsInChildren<KeywordToggleGroup>();
        groups[(int)KeywordTypes.FuelType].InitSettings(FuelType.Default, this);
        groups[(int)KeywordTypes.CarType].InitSettings(CarType.Default, this);
        groups[(int)KeywordTypes.CarPrice].InitSettings(CarPrice.Default, this);

        CarDataParser parser = new CarDataParser();
        storage = new CarDataStorage();

        parser.ParseDataTable(storage);

        currentTypes = new Enum[(int)KeywordTypes.NumberOfKeywords];
        currentTypes[(int)KeywordTypes.FuelType] = FuelType.Default;
        currentTypes[(int)KeywordTypes.CarType] = CarType.Default;
        currentTypes[(int)KeywordTypes.CarPrice] = CarPrice.Default;
        button.onClick.AddListener(FindCar);
    }

    public void SetType<T>(T currentType) where T : Enum
    {
        Debug.Log(currentType);
        Type type = currentType.GetType();

        if (type == typeof(FuelType))
        {
            currentTypes[(int)KeywordTypes.FuelType] = currentType;
        }
        else if (type == typeof(CarType))
        {
            currentTypes[(int)KeywordTypes.CarType] = currentType;
        }
        else if (type == typeof(CarPrice))
        {
            currentTypes[(int)KeywordTypes.CarPrice] = currentType;
        }
        else
        {
            Debug.Log("잘못된 타입을 입력했습니다!");
        }
    }

    public void FindCar()
    {
        storage.GetData((FuelType)currentTypes[(int)KeywordTypes.FuelType], 
            (CarType)currentTypes[(int)KeywordTypes.CarType], 
            (CarPrice)currentTypes[(int)KeywordTypes.CarPrice]);
    }
}
