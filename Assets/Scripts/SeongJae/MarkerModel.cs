using UnityEngine;


// ���� ���� ��ü�� �߰��Ǹ� MonoBehaviour ���� ����.
public class MarkerModel : MonoBehaviour
{
    // ���� ������ ���̺��� ����� �� �� ������ ��Ŀ�� ���� ������.
    [Header("Debug")]
    [SerializeField] private MarkerCanvas[] markerCanvas;

    // �������� ������ �ٸ� ��� ��ųʸ��� ��� ��, Instatiate�� ���.
    /*
    private Dictionary<string, GameObject> markerPrefabs;
    private Dictionary<string, GameObject> popUpPanelPrefabs;
    */

    private void Start()
    {
        InitSettings();
    }
    public void InitSettings()
    {   
        // ����� ������ ���̺��� ���� �ϵ��ڵ����� ������.
        PopUpPanel popUpPanel = markerCanvas[0].GetComponentInChildren<PopUpPanel>();
        popUpPanel.gameObject.SetActive(false);
        markerCanvas[0].InitSettings(new Vector3(0, 1, 3.5f), popUpPanel);
    }

    /*private void AddDictionary(Dictionary<string, GameObject> prefabDictionary, string prefabName)
    {
        GameObject prefab = Resources.Load<GameObject>(prefabName);
        prefabDictionary.Add(prefabName, prefab);
    }
    */
}
