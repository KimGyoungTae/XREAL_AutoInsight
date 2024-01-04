using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Ű���带 �����ִ� �ϳ��� ����� ����ϴ� Ŭ����.
/// �⺻������ ��� ���� ���� �� �׷� ������ ���.
/// ���� ����� currentType�� �ٸ� ��ü�� �����ϴ� ���ҵ� �ð� ����.
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

        // TMP�� ������ ���ο� ��ü ���� TMP ����.
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
            Debug.Log("����� ã�� �� �����ϴ�!");
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
