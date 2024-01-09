using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public Camera mainCamera;
    public GameObject[] InteractionUI;
    private float distanceFromCamera = 1.75f;

  
    public void UpdateUIToUserPosition(int UIIndex)
    {

        Vector3 cameraPosition = mainCamera.transform.position;
        Vector3 updateForward = new Vector3(mainCamera.transform.forward.x, 0, mainCamera.transform.forward.z).normalized;

        Vector3 updateTabletPos = cameraPosition + updateForward * distanceFromCamera;

        InteractionUI[UIIndex].SetActive(true);
        InteractionUI[UIIndex].transform.position = updateTabletPos;
        InteractionUI[UIIndex].transform.LookAt(cameraPosition);
        InteractionUI[UIIndex].transform.forward *= -1;
    }
}
