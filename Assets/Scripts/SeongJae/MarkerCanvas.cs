using UnityEngine;
using UnityEngine.UI;

public class MarkerCanvas : MonoBehaviour
{
    [SerializeField] private PopUpPanel popUpPanel;

    public void InitSettings(Vector3 position, PopUpPanel popUpObject)
    {
        // 필요한 정보 연결
        transform.position = position;
        popUpPanel = popUpObject;

        // 마커 버튼 설정 및 이벤트 연결
        Transform marker = transform.Find("Marker");
        Button button = marker.GetComponent<Button>();

        if (button == null)
        {
            button = marker.gameObject.AddComponent<Button>();
            Debug.Log("버튼 컴포넌트 부착.");
            // 추후 버튼의 색상 설정 부분 추가.
        }
        button.onClick.RemoveAllListeners(); // 에러 방지를 위해 이벤트 연결 해제.
        button.onClick.AddListener(ShowPopUp);
    }

    public void ShowPopUp()
    {
        gameObject.SetActive(false);
        popUpPanel.OpenPopUp();
    }
}
