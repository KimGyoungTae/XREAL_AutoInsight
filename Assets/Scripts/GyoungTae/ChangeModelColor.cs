using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeModelColor : MonoBehaviour
{
    
    public GameObject[] CarExternal;
    public GameObject[] CarInternal;
    public GameObject[] CarWheel;

    public Material[] MaterialExternal;
    public Material[] MaterialInternal;
    public Material[] MaterialWheel;


    private int currentExternalIndex = 0;
    private int currentInternalIndex = 0;
    private int currentWheelIndex = 0;

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


    // 버튼 하나로 순차적으로 색상을 비교하는 방식
    public void ChangeExternalColor()
    {
        // 변경된 재질로 업데이트
        UpdateMaterialsForExternal(CarExternal);

        // 버튼 클릭 시 재질 인덱스 변경
        currentExternalIndex = (currentExternalIndex + 1) % MaterialExternal.Length;

    }

    // 여러 개의 버튼을 두고, 각각 클릭해서 색상을 비교하는 방식
    public void CompareExternalColor(int externalColorIndex)
    {
        currentExternalIndex = externalColorIndex;
        
        UpdateMaterialsForExternal(CarExternal);
        TabletUIManager.Instance.UpdateOutColor(currentExternalIndex);
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

    public void CompareInternalColor(int internalColorIndex)
    {
        currentInternalIndex = internalColorIndex;
        UpdateMaterialsForInternal(CarInternal);
        TabletUIManager.Instance.UpdateSeatColor(currentInternalIndex);
    }


    void UpdateMaterialsForWheel(GameObject[] objectsArray)
    {
        foreach (var obj in objectsArray)
        {
            // Mesh Renderer 컴포넌트 가져오기
            MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();

            // 재질을 배열에서 가져와 설정
            if (meshRenderer != null && MaterialWheel.Length > 0)
            {
                meshRenderer.material = MaterialWheel[currentWheelIndex];
            }
        }
    }

    public void CompareWheelsColor(int wheelColorIndex)
    {
        currentWheelIndex = wheelColorIndex;
        UpdateMaterialsForWheel(CarWheel);
        TabletUIManager.Instance.UpdateWheel(currentWheelIndex);
    }

}
