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
            //  Debug.Log("천장 감지");
            initializationPosition = new Vector3(transform.parent.position.x, 0f, transform.parent.position.z);

            playerCenter = playerCollider.transform.position;
            targetCenter = targetCollider.transform.position;

            // Debug.Log(playerCenter.y);
            //Debug.Log(targetCenter.y);

            targetRange = targetCenter.y - playerCenter.y; // 천장과 유저의 머리 높이 차이 
          //  Debug.Log(targetRange);

  
            if (targetRange <= 0.08f)
            {
                Debug.Log("앉아있을 때 -> 일어설 때 보정 작업");
                collisionCheck = true;

                // 앉아 있는 위치 값으로 조정.
               // playerCollider.transform.parent.position = new Vector3(0.63f, -0.3f, 6.3f);
                playerCollider.transform.parent.position = new Vector3(transform.parent.position.x, -0.2f, transform.parent.position.z);

                //   Debug.Log(playerCollider.transform.position.y); //1.37

            }

            //if (collisionCheck && targetRange >= 0.35f)
            //{
            //    Debug.Log("보정 후 일어설 때 -> 앉을 때 추가 보정");
            //    playerCollider.transform.parent.position = initializationPosition;
            //}

        }


        /*
            ------------------------------------------------------
                //     2023.12.24
                // 사용자가 기기를 일어서 있는 상태에서 차 안으로 들어갔을 때 앉아 있는 위치로 보정은 되어 있지만,
                // 보정을 한 후 다시 사용자가 앉아버리면 보정된 위치에서 앉아 버리기 때문에 원하지 않는 현상이 보이게 됨.
                // 서 있는 상태에서 보정 후 MainCamera(사용자의 HMD 머리 위치)를 추적하여
                // 일정 위치(y값) 만큼 떨어질 경우 다시 위로 올려주는 추가 보정 작업이 필요해보임..
         ------------------------------------------------------
        */


    }

}
