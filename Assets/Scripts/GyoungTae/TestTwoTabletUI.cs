using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestTwoTabletUI : MonoBehaviour
{
    public InputActionAsset inputActions;

    public Camera mainCamera;
    public GameObject TestUI;
    public GameObject ControllerTestUI;

    private float distanceFromCamera = 1.5f;

    // ���� �������� primaryButton ���� �����ϱ� ���� ����
    private float previousPrimaryButton = 0;
    private float previousSecondaryButton = 0;

    private bool isHeadTabletOpened = false;
    private bool isControllerTabletOpened = false;


    // Update is called once per frame
    void Update()
    {
        var primaryButton = inputActions.actionMaps[2].actions[9].ReadValue<float>();
        var secondaryButton = inputActions.actionMaps[2].actions[10].ReadValue<float>();


        // ���� �����Ӱ� ���� �������� ���� �ٸ� ���� ���¸� ������Ʈ
        if (primaryButton == 1 && previousPrimaryButton != 1)
        {
            // ���� ������ �ݴ� ���� �Ѱܼ� ������Ʈ
            if(!isControllerTabletOpened && !isHeadTabletOpened)
            {
                ActionTabletUI(!ControllerTestUI.activeSelf, ControllerTestUI);
                isControllerTabletOpened = true;
            }
            
            else if(isControllerTabletOpened)
            {
                ActionTabletUI(!ControllerTestUI.activeSelf, ControllerTestUI);
                isControllerTabletOpened = false;
            }
        }

        // ���� �������� ���� ���� �������� ������ ����
        previousPrimaryButton = primaryButton;



        // ���� �����Ӱ� ���� �������� ���� �ٸ� ���� ���¸� ������Ʈ
        if (secondaryButton == 1 && previousSecondaryButton != 1)
        {
            // ���� ������ �ݴ� ���� �Ѱܼ� ������Ʈ
            if (!isControllerTabletOpened && !isHeadTabletOpened)
            {
                ActionTabletUI(!TestUI.activeSelf, TestUI);
                isHeadTabletOpened = true;
            }

            else if (isHeadTabletOpened)
            {
                ActionTabletUI(!TestUI.activeSelf, TestUI);
                isHeadTabletOpened = false;
            }
        }


        // ���� �������� ���� ���� �������� ������ ����
        previousSecondaryButton = secondaryButton;
        UpdateUIToCameraPosition(); // �� �����Ӹ��� UI�� ī�޶� ��ġ�� ������Ʈ
    }



    void ActionTabletUI(bool isActive, GameObject localTestUI)
    {
        localTestUI.gameObject.SetActive(isActive);
    }

    void UpdateUIToCameraPosition()
    {
        if (TestUI.activeSelf)
        {
            // MainCamera�� ��ġ�� ������ �����ͼ� TestUI�� �ٷ� �տ� ��ġ�մϴ�.

            Vector3 cameraPosition = mainCamera.transform.position;
            Vector3 updateForward = new Vector3(mainCamera.transform.forward.x, 0, mainCamera.transform.forward.z).normalized;
            Vector3 updateTabletPos = cameraPosition + updateForward * distanceFromCamera;


            // TestUI�� ��ġ�� ������Ʈ�մϴ�.

            //TestUI.transform.position = tabletPosition;
            TestUI.transform.position = updateTabletPos;

            TestUI.transform.LookAt(cameraPosition);
            // �ݴ� �������� ���ϰ� �־� ���� ���� �����´�.
            TestUI.transform.forward *= -1;
        }
    }
}
