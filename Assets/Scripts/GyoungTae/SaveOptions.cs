using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveOptions : MonoBehaviour
{
    public static SaveOptions Instance;

    // 다른 스크립트에서 받을 int 리스트 선언
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

        Debug.Log("저장된 가격은 " +  receivedPrice);
    }
}
