using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Ű���带 �����ִ� �ϳ��� ����� ����ϴ� Ŭ����.
/// �⺻������ ��� ���� ���� �� �׷� ������ �����ϸ� ���� ������ ����.
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
}
