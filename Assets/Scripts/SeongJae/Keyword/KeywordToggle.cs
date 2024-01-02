using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 키워드를 보여주는 하나의 토글을 담당하는 클래스.
/// 기본적으로 토글 글자 설정 및 그룹 설정을 담당.
/// 켜진 토글의 currentType을 다른 객체로 전달하는 역할도 맡고 있음.
/// </summary>
public class KeywordToggle : MonoBehaviour
{
    private Toggle toggle;
    private Enum currentType;
    public event Action<Enum> OnToggleOn;
    public event Action OnToggleOff;

    public void InitSettings<T>(T currentEnum, string keyword, ToggleGroup toggleGroup, KeywordToggleGroup group) where T : Enum
    {
        currentType = currentEnum;
        SetText(keyword);
        SetGroup(toggleGroup);
        toggle = GetComponent<Toggle>();
        if(toggle == null)
        {
            toggle = transform.AddComponent<Toggle>();
        }
        toggle.onValueChanged.AddListener(ChangeType);
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

    public void ChangeType(bool isOn)
    {
        if (isOn)
        {
            OnToggleOn?.Invoke(currentType);
        }
        else
        {
            OnToggleOff?.Invoke();
        }
    }

    public void BindEvent(Action<Enum> onToggleOn, Action onToggleOff)
    {
        OnToggleOn -= onToggleOn;
        OnToggleOn += onToggleOn;
        OnToggleOff -= onToggleOff;
        OnToggleOff += onToggleOff;
    }

    private void OnDestroy()
    {
        foreach (Delegate d in OnToggleOn.GetInvocationList())
        {
            OnToggleOn -= (Action<Enum>)d;
        }

        foreach (Delegate d in OnToggleOff.GetInvocationList())
        {
            OnToggleOff -= (Action)d;
        }
    }
}
