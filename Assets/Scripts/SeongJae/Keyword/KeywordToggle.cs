using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 키워드를 보여주는 하나의 토글을 담당하는 클래스.
/// 기본적으로 토글 글자 설정 및 그룹 설정을 제외하면 아직 역할이 없음.
/// </summary>
public class KeywordToggle : MonoBehaviour
{
    private Toggle toggle;

    public void InitSettings(string keyword, ToggleGroup toggleGroup)
    {
        SetText(keyword);
        SetGroup(toggleGroup);
        toggle = GetComponent<Toggle>();
        if(toggle == null)
        {
            toggle = transform.AddComponent<Toggle>();
        }
    }

    private void SetText(string keyword)
    {
        TextMeshProUGUI text = GetComponentInChildren<TextMeshProUGUI>();

        // TMP가 없으면 새로운 객체 만들어서 TMP 부착.
        if (text == null)
        {
            GameObject go = new GameObject("Label");
            go.transform.parent = transform;
            go.AddComponent<TextMeshProUGUI>();
        }

        text.text = keyword;
    }
    private void SetGroup(ToggleGroup toggleGroup)
    {
        Toggle toggle = GetComponent<Toggle>();

        if(toggle == null)
        {
            Debug.Log("토글을 찾을 수 없습니다!");
            return;
        }

        toggle.group = toggleGroup;
    }
}
