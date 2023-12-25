using UnityEngine;
using UnityEngine.UI;

public class Marker : MonoBehaviour
{
    private Vector3 initialPosition;
    private Button button;
    [SerializeField] private PopUpPanel popUpPanel;

    public void InitSettings(Vector3 position, PopUpPanel popUpObject)
    {
        initialPosition = position;
        popUpPanel = popUpObject;
        button = GetComponent<Button>();
        if (button == null)
        {
            button = gameObject.AddComponent<Button>();
            Debug.Log("버튼 컴포넌트 부착 이상.");
            // 추후 버튼의 색상 설정 부분 추가.
        }
    }

    public void ShowPopUp()
    {
        gameObject.SetActive(false);
        popUpPanel.OpenPopUp();
    }
}
