using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveOptions : MonoBehaviour
{
    public static SaveOptions Instance;

    // �ٸ� ��ũ��Ʈ���� ���� int ����Ʈ ����
    private List<int> receivedIndexValue;

    private int receivedPrice = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }



    public void ReceiveIndex(List<int> indexValues, int price)
    {
        receivedIndexValue = indexValues;
        receivedPrice = price;

        for(int i = 0; i < receivedIndexValue.Count; i++)
        {
            Debug.Log(receivedIndexValue[i]);
        }

        Debug.Log("����� ������ " +  receivedPrice);
    }
}
