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
        Debug.Log("ȭ��Ʈ ���� ��Ʈ �ɼ� ����");
    }

    public void ChoiceBlackOption()
    {
        Debug.Log("�� ���� ��Ʈ �ɼ� ����");
    }

}
