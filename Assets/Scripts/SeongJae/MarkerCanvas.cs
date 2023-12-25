using UnityEngine;
using UnityEngine.UI;

public class MarkerCanvas : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField] private Button button;
    [SerializeField] private PopUpPanel popUpPanel;

    public void InitSettings(Vector3 position, PopUpPanel popUpObject)
    {
        // 필요한 정보 연결
        transform.position = position;
        popUpPanel = popUpObject;

        // 마커 버튼 설정 및 이벤트 연결
        Transform marker = transform.Find("Marker");
        button = marker.GetComponent<Button>();

        if (button == null)
        {
            button = marker.gameObject.AddComponent<Button>();
            Debug.Log("버튼 컴포넌트 부착.");
            // 추후 버튼의 색상 설정 부분 추가.
        }
        button.onClick.RemoveAllListeners(); // 에러 방지를 위해 이벤트 연결 해제.
        button.onClick.AddListener(ShowPopUp);

        // 팝업창 초기설정
        popUpPanel.InitSettings(button.gameObject);
    }

    public void ShowPopUp()
    {
        button.gameObject.SetActive(false);
        popUpPanel.OpenPopUp();
    }
}
