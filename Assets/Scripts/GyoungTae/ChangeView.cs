using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ChangeView : MonoBehaviour
{
    // �ٸ� GameObject�� �޾ƿ� ����
    public GameObject targetObject;

    // ��ư Ŭ�� �� ������ ������ ���� ������
    public Vector3 InsidePosition = new Vector3(0.6f, 0.9f, 6.3f);
    public Quaternion InsideRotation = Quaternion.Euler(0f, 0f, 0f);

    public Vector3 OutsidePosition = new Vector3(2.6f, 0f, 6.3f);
    public Quaternion OutsideRotation = Quaternion.Euler(0f, 0f, 0f);

    public ContinuousMoveProviderBase continuousMove;
    public GameObject ExteriorLight;
    private float saveMoveSpeedValue;

    private void Start()
    {
       
        // moveSpeed ���� �����ͼ� ����
        if (continuousMove != null)
        {
            saveMoveSpeedValue = continuousMove.moveSpeed;
            Debug.Log("moveSpeed Value: " + saveMoveSpeedValue);
        }
        else
        {
            Debug.LogError("ContinuousMoveProviderBase ������Ʈ�� ã�� �� �����ϴ�.");
        }
    }

    public void ChangeInsideViewPoint()
    {
        if (targetObject != null)
        {

         //  ExteriorLight.SetActive(false);

            // Ŭ�� �� targetObject�� transform�� position�� rotation�� ����
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

            // Ŭ�� �� targetObject�� transform�� position�� rotation�� ����
            targetObject.transform.position = OutsidePosition;
            targetObject.transform.rotation = OutsideRotation;

            continuousMove.moveSpeed = saveMoveSpeedValue;
        }
    }
}
