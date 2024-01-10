using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TabletUI : MonoBehaviour
{

    public InputActionAsset inputActions;

    public Camera mainCamera;
    public GameObject TestUI;
 

    private float distanceFromCamera = 1.5f;

    // ���� �������� primaryButton ���� �����ϱ� ���� ����
    private float previousPrimaryButton = 0;
    private float previousSecondaryButton = 0;

    // Update is called once per frame
    void Update()
    {
     //   var primaryButton = inputActions.actionMaps[2].actions[9].ReadValue<float>();
        
        var secondaryButton = inputActions.actionMaps[2].actions[10].ReadValue<float>();

        // ���� �����Ӱ� ���� �������� ���� �ٸ� ���� ���¸� ������Ʈ
        if (secondaryButton == 1 && previousSecondaryButton != 1)
        {
            // ���� ������ �ݴ� ���� �Ѱܼ� ������Ʈ
            ActionTabletUI(!TestUI.activeSelf);
        }

        // ���� �������� ���� ���� �������� ������ ����
        previousSecondaryButton = secondaryButton;

        UpdateUIToCameraPosition(); // �� �����Ӹ��� UI�� ī�޶� ��ġ�� ������Ʈ
    }

    

    void ActionTabletUI(bool isActive)
    {
        TestUI.gameObject.SetActive(isActive);

        //if (isActive)
        //{
        //    // MainCamera�� ��ġ�� ������ �����ͼ� TestUI�� �ٷ� �տ� ��ġ�մϴ�.
        //    Vector3 cameraPosition = mainCamera.transform.position;
        //    Vector3 cameraForward = mainCamera.transform.forward;
        //    Vector3 tabletPosition = cameraPosition + cameraForward * distanceFromCamera;

        //    // TestUI�� ��ġ�� ������Ʈ�մϴ�.
        //    TestUI.transform.position = tabletPosition;
        //    // �� �κп��� �ʿ信 ���� TestUI�� ȸ�� ���� ������ �� �ֽ��ϴ�.
        //    TestUI.transform.LookAt(cameraPosition);
        //    // �ݴ� �������� ���ϰ� �־� ���� ���� �����´�.
        //    TestUI.transform.forward *= -1;
        //}
    }

    void UpdateUIToCameraPosition()
    {
        if (TestUI.activeSelf)
        {
            // MainCamera�� ��ġ�� ������ �����ͼ� TestUI�� �ٷ� �տ� ��ġ�մϴ�.
           
            Vector3 cameraPosition = mainCamera.transform.position;
     

          // Vector3 cameraForward = mainCamera.transform.forward;  
          // Vector3 tabletPosition = cameraPosition + cameraForward * distanceFromCamera;


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
