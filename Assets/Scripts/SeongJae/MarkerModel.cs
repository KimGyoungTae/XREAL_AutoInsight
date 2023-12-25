using Unity.VisualScripting;
using UnityEngine;


// 추후 상위 객체가 추가되면 MonoBehaviour 제거 예정.
public class MarkerModel : MonoBehaviour
{
    // 추후 데이터 테이블을 사용할 때 각 차량별 마커의 수를 가져옴.
    [Header("Debug")]
    [SerializeField] private MarkerCanvas[] markerCanvases;
    [SerializeField] private Vector3[] popUpPosition; 

    // 프리팹의 종류가 다를 경우 딕셔너리에 등록 후, Instatiate로 사용.
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
        // 현재는 데이터 테이블이 없어 캔버스를 로드하는 부분의 구현을 하드코딩으로 진행함.
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
