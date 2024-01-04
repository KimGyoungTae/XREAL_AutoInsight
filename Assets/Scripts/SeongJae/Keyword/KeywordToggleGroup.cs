using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;
using System;
/// <summary>
/// KeywordGroupCreator�� KeywordToggle�� �߰����� Ŭ����
/// Toggle�� ������ ���.
/// </summary>
public class KeywordToggleGroup : MonoBehaviour
{
    ToggleGroup toggleGroup;

    [Header ("Debug")]
    [SerializeField] GameObject keywordTogglePrefab;

    public void InitSettings<T>(T currentType) where T : Enum
    {
        toggleGroup = GetComponent<ToggleGroup>();
        if(toggleGroup == null)
        {
            toggleGroup = transform.AddComponent<ToggleGroup>();
        }

        //Default�� ������� �ʱ� ���ؼ� 1 ����.
        int numberOfItems = Enum.GetValues(typeof(T)).Length - 1;
        string[] keywords = Keyword.GetKeywordArray<T>(currentType);

        for (int i = 0; i < numberOfItems; ++i)
        {
            GameObject go = Instantiate(keywordTogglePrefab, transform);
            KeywordToggle toggle = go.GetComponent<KeywordToggle>();
            if(toggle == null)
            {
                toggle = go.AddComponent<KeywordToggle>();
            }

            toggle.InitSettings(keywords[i], toggleGroup);
        }
    }
}
