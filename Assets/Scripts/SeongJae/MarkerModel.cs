using Unity.VisualScripting;
using UnityEngine;


// ���� ���� ��ü�� �߰��Ǹ� MonoBehaviour ���� ����.
public class MarkerModel : MonoBehaviour
{
    // ���� ������ ���̺��� ����� �� �� ������ ��Ŀ�� ���� ������.
    [Header("Debug")]
    [SerializeField] private MarkerCanvas[] markerCanvases;
    [SerializeField] private Vector3[] popUpPosition; 

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
        // ����� ������ ���̺��� ���� ĵ������ �ε��ϴ� �κ��� ������ �ϵ��ڵ����� ������.
        for(int i = 0; i < popUpPosition.Length; i++)
        {
            MarkerCanvas markerCanvas = Instantiate(markerCanvases[0].gameObject).GetComponent<MarkerCanvas>();
            PopUpPanel popUpPanel = markerCanvas.GetComponentInChildren<PopUpPanel>(true);
            popUpPanel.gameObject.SetActive(false);
            markerCanvas.InitSettings(popUpPosition[i], popUpPanel);
        }
    }

    /*private void AddDictionary(Dictionary<string, GameObject> prefabDictionary, string prefabName)
    {
        GameObject prefab = Resources.Load<GameObject>(prefabName);
        prefabDictionary.Add(prefabName, prefab);
    }
    */
}
