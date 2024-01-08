using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ChangeView : MonoBehaviour
{
    // 다른 GameObject를 받아올 변수
    public GameObject targetObject;

    // 버튼 클릭 시 변경할 값들을 위한 변수들
    public Vector3 InsidePosition = new Vector3(0.6f, 0.9f, 6.3f);
    public Quaternion InsideRotation = Quaternion.Euler(0f, 0f, 0f);

    public Vector3 OutsidePosition = new Vector3(2.6f, 0f, 6.3f);
    public Quaternion OutsideRotation = Quaternion.Euler(0f, 0f, 0f);

    public ContinuousMoveProviderBase continuousMove;
    public GameObject ExteriorLight;
    private float saveMoveSpeedValue;

    private void Start()
    {
       
        // moveSpeed 값을 가져와서 저장
        if (continuousMove != null)
        {
            saveMoveSpeedValue = continuousMove.moveSpeed;
            Debug.Log("moveSpeed Value: " + saveMoveSpeedValue);
        }
        else
        {
            Debug.LogError("ContinuousMoveProviderBase 컴포넌트를 찾을 수 없습니다.");
        }
    }

    public void ChangeInsideViewPoint()
    {
        if (targetObject != null)
        {

         //  ExteriorLight.SetActive(false);

            // 클릭 시 targetObject의 transform의 position과 rotation을 변경
            targetObject.transform.position = InsidePosition;
            targetObject.transform.rotation = InsideRotation;

            continuousMove.moveSpeed = 0;
        }
    }

    public void ChangeInsideView(int moveIndex)
    {
        ExteriorLight.SetActive(false);

        switch (moveIndex)
        {
            case 0:
                Vector3 zeroIndex_InsidePosition = new Vector3(7.1f, 1.35f, 2.95f);
                InsidePosition = zeroIndex_InsidePosition;
                break;
            case 1:
                Vector3 oneIndex_InsidePosition = new Vector3(6.2f, 1.35f, 2.95f);
                InsidePosition = oneIndex_InsidePosition;
                break;
            case 2:
                Vector3 twoIndex_InsidePosition = new Vector3(6.2f, 1.35f, 3.88f);
                InsidePosition = twoIndex_InsidePosition;
                break;
            case 3:
                Vector3 thirdIndex_InsidePosition = new Vector3(6.9f, 1.35f, 3.88f);
                InsidePosition = thirdIndex_InsidePosition;
                break;

            default:
                break;
        }

        continuousMove.moveSpeed = 0;
        targetObject.transform.position = InsidePosition;
        targetObject.transform.rotation = InsideRotation;

    }

    public void ChangeOutSidesideViewPoint()
    {
        if (targetObject != null)
        {

            ExteriorLight.SetActive(true); 

            // 클릭 시 targetObject의 transform의 position과 rotation을 변경
            targetObject.transform.position = OutsidePosition;
            targetObject.transform.rotation = OutsideRotation;

            continuousMove.moveSpeed = saveMoveSpeedValue;
        }
    }
}
