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
        // �־��� �迭�� ��� ������Ʈ�� ���� ������ ����
        foreach (var obj in objectsArray)
        {
            // Mesh Renderer ������Ʈ ��������
            MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();

            // ������ �迭���� ������ ����
            if (meshRenderer != null && MaterialExternal.Length > 0)
            {
                meshRenderer.material = MaterialExternal[currentExternalIndex];
            }
        }
    }


    // ��ư �ϳ��� ���������� ������ ���ϴ� ���
    public void ChangeExternalColor()
    {
        // ����� ������ ������Ʈ
        UpdateMaterialsForExternal(CarExternal);

        // ��ư Ŭ�� �� ���� �ε��� ����
        currentExternalIndex = (currentExternalIndex + 1) % MaterialExternal.Length;

    }

    // ���� ���� ��ư�� �ΰ�, ���� Ŭ���ؼ� ������ ���ϴ� ���
    public void CompareExternalColor(int externalColorIndex)
    {
        currentExternalIndex = externalColorIndex;
        
        UpdateMaterialsForExternal(CarExternal);
    }

    void UpdateMaterialsForInternal(GameObject[] objectsArray)
    {
        // �־��� �迭�� ��� ������Ʈ�� ���� ������ ����
        foreach (var obj in objectsArray)
        {
            // Mesh Renderer ������Ʈ ��������
            MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();

            // ������ �迭���� ������ ����
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

    public void CompareInternalColor(int internalColorIndex)
    {
        currentInternalIndex = internalColorIndex;
        UpdateMaterialsForInternal(CarInternal);
    }


    void UpdateMaterialsForWheel(GameObject[] objectsArray)
    {
        foreach (var obj in objectsArray)
        {
            // Mesh Renderer ������Ʈ ��������
            MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();

            // ������ �迭���� ������ ����
            if (meshRenderer != null && MaterialWheel.Length > 0)
            {
                meshRenderer.material = MaterialWheel[currentWheelIndex];
            }
        }
    }

    public void ChangeWheelColor()
    {
        UpdateMaterialsForWheel(CarWheel);
        currentWheelIndex = (currentWheelIndex + 1) % MaterialWheel.Length;
    }

    public void CompareWheelsColor(int wheelColorIndex)
    {
        currentWheelIndex = wheelColorIndex;
        UpdateMaterialsForWheel(CarWheel);
    }

}
