using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPopUpOption : MonoBehaviour
{
    public GameObject optionPopUp;
    public VideoControl videoControl;

    void Start()
    {
        optionPopUp.SetActive(false);
    }

    public void ActiveAutoPilot()
    {
        Debug.Log("�������Ϸ� ����");
        videoControl.OnPlayVideo();
    }

    public void ActiveFSD()
    {
        Debug.Log("FSD ����");
    }
}
