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
            Debug.Log("��ư ������Ʈ ���� �̻�.");
            // ���� ��ư�� ���� ���� �κ� �߰�.
        }
    }

    public void ShowPopUp()
    {
        gameObject.SetActive(false);
        popUpPanel.OpenPopUp();
    }
}
