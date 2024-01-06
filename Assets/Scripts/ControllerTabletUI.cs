using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ControllerTabletUI : MonoBehaviour
{

    public InputActionAsset inputActions;
    public GameObject TestUI;
 
    // ���� �������� primaryButton ���� �����ϱ� ���� ����
    private float previousPrimaryButton = 0;

    // Update is called once per frame
    void Update()
    {
        var primaryButton = inputActions.actionMaps[2].actions[9].ReadValue<float>();

        // ���� �����Ӱ� ���� �������� ���� �ٸ� ���� ���¸� ������Ʈ
        if (primaryButton == 1 && previousPrimaryButton != 1)
        {
            // ���� ������ �ݴ� ���� �Ѱܼ� ������Ʈ
            ActionTabletUI(!TestUI.activeSelf);
        }

        // ���� �������� ���� ���� �������� ������ ����
        previousPrimaryButton = primaryButton;
    }

    

    void ActionTabletUI(bool isActive)
    {
        TestUI.gameObject.SetActive(isActive);
    }
}
