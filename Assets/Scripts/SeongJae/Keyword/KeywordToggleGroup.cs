using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;
using System;
using static Keyword;

/// <summary>
/// KeywordGroupCreator와 KeywordToggle의 중간관리 클래스
/// Toggle의 생성과 Toggle의 type 전달의 presenter의 역할을 수행.
/// </summary>
public class KeywordToggleGroup : MonoBehaviour
{
    [Header ("Debug")]
    [SerializeField] GameObject keywordTogglePrefab;

    ToggleGroup toggleGroup;

    //아직은 사용하지 않지만, presenter의 역할을 수행하기에 혹시 몰라 생성해놓음.
    private KeywordToggle[] keywordToggles;

    private Enum currentType;
    public Enum CurrentType { get { return currentType; } }
    private Enum defaultType;
    private KeywordGroupManager manager;
    private const int DEFAULT_VALUE = -1;

    public void InitSettings<T>(T currentCategory, KeywordGroupManager manager) where T : Enum
    {
        this.manager = manager;
        toggleGroup = GetComponent<ToggleGroup>();
        if(toggleGroup == null)
        {
            toggleGroup = transform.AddComponent<ToggleGroup>();
        }

        //Default는 고려하지 않기 위해서 1 빼줌.
        int numberOfItems = Enum.GetValues(typeof(T)).Length - 1;

        // 추후 초기화를 위해 Default는 캐싱
        defaultType = (T)Enum.Parse(typeof(T), DEFAULT_VALUE.ToString());

        // toggle들을 저장할 배열.
        keywordToggles = new KeywordToggle[numberOfItems];

        // 현재 enum에 따라 전달하는 text 배열.
        // toggle의 text를 해당 string으로 변경하게 됨.
        string[] keywords = GetKeywordArray(currentCategory);

        for (int i = 0; i < numberOfItems; ++i)
        {
            GameObject go = Instantiate(keywordTogglePrefab, transform);
            KeywordToggle toggle = go.GetComponent<KeywordToggle>();
            if(toggle == null)
            {
                toggle = go.AddComponent<KeywordToggle>();
            }

            // 현재 enum의 순서에 따라 해당 enum 타입을 toggle에 넘겨줌.
            // 예를 들어 현재 enum이 CarType이고 i가 1이라면 CarType의 1에 해당하는 SUV를 넘겨줌.
            T currentEnum = (T)Enum.Parse(typeof(T), i.ToString());
            toggle.InitSettings(currentEnum, keywords[i], toggleGroup, this);
            toggle.BindEvent(ChangeType, ResetType);
            keywordToggles[i] = toggle;
        }
    }

    private void ChangeType<T>(T currentType) where T : Enum
    {
        manager.SetType(currentType);
        this.currentType = currentType;
    }

    private void ResetType()
    {
        currentType = defaultType;
        manager.SetType(defaultType);
    }
}
