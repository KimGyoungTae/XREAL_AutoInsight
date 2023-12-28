using UnityEngine;
using UnityEngine.UI;

public class MarkerCanvas : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField] private Button button;
    [SerializeField] private PopUpPanel popUpPanel;

    public void InitSettings(Vector3 position, PopUpPanel popUpObject)
    {
        // �ʿ��� ���� ����
        transform.position = position;
        popUpPanel = popUpObject;

        // ��Ŀ ��ư ���� �� �̺�Ʈ ����
        Transform marker = transform.Find("Marker");
        button = marker.GetComponent<Button>();

        if (button == null)
        {
            button = marker.gameObject.AddComponent<Button>();
            Debug.Log("��ư ������Ʈ ����.");
            // ���� ��ư�� ���� ���� �κ� �߰�.
        }
        button.onClick.RemoveAllListeners(); // ���� ������ ���� �̺�Ʈ ���� ����.
        button.onClick.AddListener(ShowPopUp);

        // �˾�â �ʱ⼳��
        popUpPanel.InitSettings(button.gameObject);
    }

    public void ShowPopUp()
    {
        button.gameObject.SetActive(false);
        popUpPanel.OpenPopUp();
    }
}
