using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeCollider : MonoBehaviour
{

    [SerializeField] private GameObject playerCollider;
    [SerializeField] private GameObject targetCollider;
    [SerializeField] private Vector3 playerCenter;
    private Vector3 targetCenter;

    private Vector3 initializationPosition;
    private bool collisionCheck = false;
    private float targetRange;

   
    private void OnTriggerStay(Collider target)
    {
        // Check if the collision is with the ceiling
        if (target.gameObject.tag == "Ceiling")
        {
            //  Debug.Log("õ�� ����");
            initializationPosition = new Vector3(transform.parent.position.x, 0f, transform.parent.position.z);

            playerCenter = playerCollider.transform.position;
            targetCenter = targetCollider.transform.position;

            // Debug.Log(playerCenter.y);
            //Debug.Log(targetCenter.y);

            targetRange = targetCenter.y - playerCenter.y; // õ��� ������ �Ӹ� ���� ���� 
          //  Debug.Log(targetRange);

  
            if (targetRange <= 0.08f)
            {
                Debug.Log("�ɾ����� �� -> �Ͼ �� ���� �۾�");
                collisionCheck = true;

                // �ɾ� �ִ� ��ġ ������ ����.
               // playerCollider.transform.parent.position = new Vector3(0.63f, -0.3f, 6.3f);
                playerCollider.transform.parent.position = new Vector3(transform.parent.position.x, -0.2f, transform.parent.position.z);

                //   Debug.Log(playerCollider.transform.position.y); //1.37

            }

            //if (collisionCheck && targetRange >= 0.35f)
            //{
            //    Debug.Log("���� �� �Ͼ �� -> ���� �� �߰� ����");
            //    playerCollider.transform.parent.position = initializationPosition;
            //}

        }


        /*
            ------------------------------------------------------
                //     2023.12.24
                // ����ڰ� ��⸦ �Ͼ �ִ� ���¿��� �� ������ ���� �� �ɾ� �ִ� ��ġ�� ������ �Ǿ� ������,
                // ������ �� �� �ٽ� ����ڰ� �ɾƹ����� ������ ��ġ���� �ɾ� ������ ������ ������ �ʴ� ������ ���̰� ��.
                // �� �ִ� ���¿��� ���� �� MainCamera(������� HMD �Ӹ� ��ġ)�� �����Ͽ�
                // ���� ��ġ(y��) ��ŭ ������ ��� �ٽ� ���� �÷��ִ� �߰� ���� �۾��� �ʿ��غ���..
         ------------------------------------------------------
        */


    }

}
