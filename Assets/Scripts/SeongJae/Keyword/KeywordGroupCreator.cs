using UnityEngine;

/// <summary>
/// Keyword 씬의 최상위 객체.
/// 각 KeywordToggleGroup을 만들고, 관리함.
/// </summary>
public class KeywordGroupCreator : MonoBehaviour
{
    private KeywordToggleGroup[] groups;

    private void Awake()
    {
        InitSettings();
    }
    public void InitSettings()
    {
        groups = GetComponentsInChildren<KeywordToggleGroup>();
        groups[(int)Keyword.KeywordTypes.CarType].InitSettings(Keyword.CarType.Default);
        groups[(int)Keyword.KeywordTypes.FuelType].InitSettings(Keyword.FuelType.Default);
        groups[(int)Keyword.KeywordTypes.CarPrice].InitSettings(Keyword.CarPrice.Default);
        CarDataParser parser = new CarDataParser();
        CarDataStorage storage = new CarDataStorage();
        parser.ParseDataTable(storage);

    }
}
