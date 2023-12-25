using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class PopUpPanel : MonoBehaviour
{
    public event Action OnPopUpClose;

    public void InitSettings(GameObject marker)
    {
        OnPopUpClose -= () => marker.SetActive(true);
        OnPopUpClose += () => marker.SetActive(true);

        Button button = GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(ClosePopUp);
    }

    public void OpenPopUp()
    {
        gameObject.SetActive(true);
    }
    public void ClosePopUp()
    {
        gameObject.SetActive(false);
        OnPopUpClose?.Invoke();
    }

    private void OnDestroy()
    {
        //���� �ݺ� ���� �������� �޼���� static Ŭ������ �̵� ����.
        foreach(Delegate d in OnPopUpClose.GetInvocationList())
        {
            OnPopUpClose -= (Action)d;
        }
    }
}
