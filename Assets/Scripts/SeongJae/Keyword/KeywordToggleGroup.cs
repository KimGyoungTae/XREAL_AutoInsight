using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;
using System;
using static Keyword;
using UnityEngine.InputSystem;
/// <summary>
/// KeywordGroupCreator와 KeywordToggle의 중간관리 클래스
/// Toggle의 생성을 담당.
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

        //Default는 고려하지 않기 위해서 1 빼줌.
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
