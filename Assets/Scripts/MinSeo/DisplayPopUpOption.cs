using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPopUpOption : MonoBehaviour
{
    public GameObject optionPopUp;
    public Button optionButton;
    public Button optionButton2;

    public void ClosePopUp()
    {
        optionPopUp.SetActive(false);
    }
}
