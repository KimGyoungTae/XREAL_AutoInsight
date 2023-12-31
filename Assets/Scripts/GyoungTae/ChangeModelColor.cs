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


    public void ChangeExternalColor()
    {
        // ����� ������ ������Ʈ
        UpdateMaterialsForExternal(CarExternal);

        // ��ư Ŭ�� �� ���� �ε��� ����
        currentExternalIndex = (currentExternalIndex + 1) % MaterialExternal.Length;

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
}
