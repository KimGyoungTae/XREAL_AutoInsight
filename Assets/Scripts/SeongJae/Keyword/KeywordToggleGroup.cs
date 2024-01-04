using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;
using System;
using static Keyword;
using UnityEngine.InputSystem;
/// <summary>
/// KeywordGroupCreator�� KeywordToggle�� �߰����� Ŭ����
/// Toggle�� ������ ���.
/// </summary>
public class KeywordToggleGroup : MonoBehaviour
{
    ToggleGroup toggleGroup;

    [Header ("Debug")]
    [SerializeField] GameObject keywordTogglePrefab;

    public void InitSettings<T>(T currentCategory) where T : Enum
    {
        toggleGroup = GetComponent<ToggleGroup>();
        if(toggleGroup == null)
        {
            toggleGroup = transform.AddComponent<ToggleGroup>();
        }

        //Default�� ������� �ʱ� ���ؼ� 1 ����.
        int numberOfItems = Enum.GetValues(typeof(T)).Length - 1;
        string[] keywords = Keyword.GetKeywordArray<T>(currentCategory);

        for (int i = 0; i < numberOfItems; ++i)
        {
            GameObject go = Instantiate(keywordTogglePrefab, transform);
            KeywordToggle toggle = go.GetComponent<KeywordToggle>();
            if(toggle == null)
            {
                toggle = go.AddComponent<KeywordToggle>();
            }

            T currentEnum = (T)Enum.Parse(typeof(T), i.ToString());
            toggle.InitSettings(currentEnum, keywords[i], toggleGroup);
        }
    }
}
