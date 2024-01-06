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
 
    // 이전 프레임의 primaryButton 값을 저장하기 위한 변수
    private float previousPrimaryButton = 0;

    // Update is called once per frame
    void Update()
    {
        var primaryButton = inputActions.actionMaps[2].actions[9].ReadValue<float>();

        // 이전 프레임과 현재 프레임의 값이 다를 때만 상태를 업데이트
        if (primaryButton == 1 && previousPrimaryButton != 1)
        {
            // 현재 상태의 반대 값을 넘겨서 업데이트
            ActionTabletUI(!TestUI.activeSelf);
        }

        // 현재 프레임의 값을 이전 프레임의 값으로 저장
        previousPrimaryButton = primaryButton;
    }

    

    void ActionTabletUI(bool isActive)
    {
        TestUI.gameObject.SetActive(isActive);
    }
}
