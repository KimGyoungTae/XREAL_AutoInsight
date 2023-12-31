using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeModelColor : MonoBehaviour
{
    public GameObject[] CarExternal;
    public GameObject[] CarInternal;

    public Material[] MaterialExternal;
    public Material[] MaterialInternal;

    private int currentExternalIndex = 0;
    private int currentInternalIndex = 0;

    void UpdateMaterialsForExternal(GameObject[] objectsArray)
    {
        // 주어진 배열의 모든 오브젝트에 대해 재질을 설정
        foreach (var obj in objectsArray)
        {
            // Mesh Renderer 컴포넌트 가져오기
            MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();

            // 재질을 배열에서 가져와 설정
            if (meshRenderer != null && MaterialExternal.Length > 0)
            {
                meshRenderer.material = MaterialExternal[currentExternalIndex];
            }
        }
    }


    public void ChangeExternalColor()
    {
        // 변경된 재질로 업데이트
        UpdateMaterialsForExternal(CarExternal);

        // 버튼 클릭 시 재질 인덱스 변경
        currentExternalIndex = (currentExternalIndex + 1) % MaterialExternal.Length;

    }

    void UpdateMaterialsForInternal(GameObject[] objectsArray)
    {
        // 주어진 배열의 모든 오브젝트에 대해 재질을 설정
        foreach (var obj in objectsArray)
        {
            // Mesh Renderer 컴포넌트 가져오기
            MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();

            // 재질을 배열에서 가져와 설정
            if (meshRenderer != null && MaterialInternal.Length > 0)
            {
                meshRenderer.material = MaterialInternal[currentInternalIndex];
            }
        }
    }

    public void ChangeInternalColor()
    {
        UpdateMaterialsForInternal(CarInternal);
        currentInternalIndex = (currentInternalIndex + 1) % MaterialInternal.Length;
    }
}
