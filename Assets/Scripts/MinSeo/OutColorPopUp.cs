using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutColorPopUp : MonoBehaviour
{
    public GameObject optionPopUp;
    public Button markerButton;

    void Start()
    {
        optionPopUp.SetActive(false);
    }

    public void OpenPopUp()
    {
        optionPopUp.SetActive(true);
        Debug.Log("clicked");
        //optionPopUp.transform.position = Input.mousePosition;
    }
}
