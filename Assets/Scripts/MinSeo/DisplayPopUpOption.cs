using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DisplayPopUpOption : MonoBehaviour
{
    public GameObject optionPopUp;
    public VideoControl videoControl;

    void Start()
    {
        optionPopUp.SetActive(false);
    }

    public void CompareAutoPilot(int choiceIndex)
    {
        TabletUIManager.Instance.UpdateAutoPilot(choiceIndex);
    }

    public void PlayAutoPilotVideo()
    {
        videoControl.OnPlayVideo();
    }
}
