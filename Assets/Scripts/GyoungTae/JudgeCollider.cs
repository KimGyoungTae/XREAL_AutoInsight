using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeCollider : MonoBehaviour
{

  //  [SerializeField] private float allowedMaxYPosition;
    //[SerializeField] private Collider playerCollider;
    //[SerializeField] private Collider targetCollider;

    [SerializeField] private GameObject playerCollider;
    [SerializeField] private GameObject targetCollider;

    private void OnTriggerStay(Collider target)
    {
        // Check if the collision is with the ceiling
        if (target.gameObject.tag == "Ceiling")
        {

            Debug.Log("õ�� �浹 ");

            //Vector3 playerCenter = playerCollider.bounds.center;
            //Vector3 targetCenter = targetCollider.bounds.center;

            Vector3 playerCenter = playerCollider.transform.position;
            Vector3 targetCenter = targetCollider.transform.position;

            // Debug.Log(playerCenter.y);
            //Debug.Log(targetCenter.y);

            // Debug.Log(targetCenter.y - playerCenter.y);

            float targetRange = targetCenter.y - playerCenter.y; //0.15

            if (targetRange <= 0.15f)
            {
                Debug.Log("���� �۾�");
                // target.isTrigger = false;

                // �ɾ� �ִ� ��ġ ������ ����.
               // playerCollider.transform.parent.position = new Vector3(0.63f, -0.3f, 6.3f);
                playerCollider.transform.parent.position = new Vector3(transform.parent.position.x, -0.2f, transform.parent.position.z);
            }

            //// Calculate the excess Y position
            //float excessY = transform.position.y - allowedMaxYPosition;
            //// 1.5-1.3  

        }

        if (target.gameObject.tag == "Floor")
        {

            Debug.Log("�ٴ� ���� �ʿ�");
            // 2023.12.24
            // ����ڰ� ��⸦ �Ͼ �ִ� ���¿��� �� ������ ���� �� �ɾ� �ִ� ��ġ�� ������ �Ǿ� ������,
            // ������ �� �� �ٽ� ����ڰ� �ɾƹ����� ������ ��ġ���� �ɾ� ������ ������ ������ �ʴ� ������ ���̰� ��.
            // �� �ִ� ���¿��� ���� �� MainCamera(������� HMD �Ӹ� ��ġ)�� �����Ͽ�
            // ���� ��ġ(y��) ��ŭ ������ ��� �ٽ� ���� �÷��ִ� �߰� ���� �۾��� �ʿ��غ���.. 

        }
    }


    //void OnTriggerStay(Collider target)
    //{
    //    if (target.gameObject.tag == "Floor")
    //    {
    //        Vector3 playerCenter = playerCollider.transform.position;
    //        Vector3 targetCenter = targetCollider.transform.position;
    //        Debug.Log(playerCenter.y);  // �ɾ����� �� ���� : 1.1f
    //        Debug.Log(targetCenter.y);

    //    }
    //}

}
