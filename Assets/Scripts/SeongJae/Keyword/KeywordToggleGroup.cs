using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;
using System;
using static Keyword;

/// <summary>
/// KeywordGroupCreator�� KeywordToggle�� �߰����� Ŭ����
/// Toggle�� ������ Toggle�� type ������ presenter�� ������ ����.
/// </summary>
public class KeywordToggleGroup : MonoBehaviour
{
    [Header ("Debug")]
    [SerializeField] GameObject keywordTogglePrefab;

    ToggleGroup toggleGroup;

    //������ ������� ������, presenter�� ������ �����ϱ⿡ Ȥ�� ���� �����س���.
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

        //Default�� ������� �ʱ� ���ؼ� 1 ����.
        int numberOfItems = Enum.GetValues(typeof(T)).Length - 1;

        // ���� �ʱ�ȭ�� ���� Default�� ĳ��
        defaultType = (T)Enum.Parse(typeof(T), DEFAULT_VALUE.ToString());

        // toggle���� ������ �迭.
        keywordToggles = new KeywordToggle[numberOfItems];

        // ���� enum�� ���� �����ϴ� text �迭.
        // toggle�� text�� �ش� string���� �����ϰ� ��.
        string[] keywords = GetKeywordArray(currentCategory);

        for (int i = 0; i < numberOfItems; ++i)
        {
            GameObject go = Instantiate(keywordTogglePrefab, transform);
            KeywordToggle toggle = go.GetComponent<KeywordToggle>();
            if(toggle == null)
            {
                toggle = go.AddComponent<KeywordToggle>();
            }

            // ���� enum�� ������ ���� �ش� enum Ÿ���� toggle�� �Ѱ���.
            // ���� ��� ���� enum�� CarType�̰� i�� 1�̶�� CarType�� 1�� �ش��ϴ� SUV�� �Ѱ���.
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
