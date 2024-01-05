using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeatPopUpOption : MonoBehaviour
{
    public GameObject optionPopUp;

    
    void Start()
    {
        optionPopUp.SetActive(false);
    }

    public void ChoiceWhiteOption()
    {
        Debug.Log("화이트 내장 시트 옵션 선택");
    }

    public void ChoiceBlackOption()
    {
        Debug.Log("블랙 내장 시트 옵션 선택");
    }

}
