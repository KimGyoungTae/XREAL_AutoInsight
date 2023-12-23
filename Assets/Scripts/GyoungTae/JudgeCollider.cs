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

            Debug.Log("천장 충돌 ");

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
                Debug.Log("보정 작업");
                // target.isTrigger = false;

                // 앉아 있는 위치 값으로 조정.
               // playerCollider.transform.parent.position = new Vector3(0.63f, -0.3f, 6.3f);
                playerCollider.transform.parent.position = new Vector3(transform.parent.position.x, -0.2f, transform.parent.position.z);
            }

            //// Calculate the excess Y position
            //float excessY = transform.position.y - allowedMaxYPosition;
            //// 1.5-1.3  

        }

        if (target.gameObject.tag == "Floor")
        {

            Debug.Log("바닥 보정 필요");
            // 2023.12.24
            // 사용자가 기기를 일어서 있는 상태에서 차 안으로 들어갔을 때 앉아 있는 위치로 보정은 되어 있지만,
            // 보정을 한 후 다시 사용자가 앉아버리면 보정된 위치에서 앉아 버리기 때문에 원하지 않는 현상이 보이게 됨.
            // 서 있는 상태에서 보정 후 MainCamera(사용자의 HMD 머리 위치)를 추적하여
            // 일정 위치(y값) 만큼 떨어질 경우 다시 위로 올려주는 추가 보정 작업이 필요해보임.. 

        }
    }


    //void OnTriggerStay(Collider target)
    //{
    //    if (target.gameObject.tag == "Floor")
    //    {
    //        Vector3 playerCenter = playerCollider.transform.position;
    //        Vector3 targetCenter = targetCollider.transform.position;
    //        Debug.Log(playerCenter.y);  // 앉아있을 때 기준 : 1.1f
    //        Debug.Log(targetCenter.y);

    //    }
    //}

}
