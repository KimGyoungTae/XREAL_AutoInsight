using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TabletUIManager : MonoBehaviour
{
    public static TabletUIManager Instance;

    [Space]
    [Header("�º� UI ����")]
    [SerializeField] private Image CarOutColor;
    [SerializeField] private Sprite[] OutColorSprite;
    [SerializeField] private Image CarWheel;
    [SerializeField] private Sprite[] WheelSprite;
    [SerializeField] private Image CarSeatColor;
    [SerializeField] private Sprite[] SeatSprite;
    [SerializeField] private Image AutoPilot;
    [SerializeField] private Sprite[] AutoPilotSprite;

    [Space]
    [Header("���� �� ����")]
    [SerializeField] private Text priceText;
    public int currentCarPrice = 56990000; // �ʱ� ���� ����

    public List<int> chocieIndexValue = new List<int>();

    private int previousPlusOutColorPrice = 0;
    private int previousPlusWheelPrice = 0;
    private int previousPlusSeatColorPrice = 0;
    private int previousPlusAutoPilotPrice = 0;

 

    void Start()
    {
        // �ʱ� ������ �ؽ�Ʈ�� ǥ��
        UpdatePriceText(currentCarPrice);
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
    
        }
    }

    public void SaveOption()
    {
        Debug.Log("���� ��ư Ŭ��");
        SaveOptions.Instance.ReceiveIndex(chocieIndexValue, currentCarPrice);
    }

    
    public void UpdateOutColor(int outColorIndex)
    {
        CarOutColor.enabled = true;
        if (outColorIndex >= 0 && outColorIndex < OutColorSprite.Length)
        {
            // outColorIndex�� ���� �ش��ϴ� Sprite�� �����մϴ�.
            CarOutColor.sprite = OutColorSprite[outColorIndex];

            // ����� �α׸� ���� � ���� �÷��� �ݿ��Ǵ��� Ȯ���մϴ�.
         //   Debug.Log($"���� ���� �÷� �ݿ�: {outColorIndex}");
            ChangeCarPrice("OutColor", outColorIndex);

            chocieIndexValue[0] = outColorIndex;
        }
        else
        {
            Debug.LogWarning("��ȿ���� ���� ���� ���� �÷� �ε����Դϴ�.");
        }
    }

    public void UpdateWheel(int wheelIndex)
    {
        CarWheel.enabled = true;
        if (wheelIndex >= 0 && wheelIndex < WheelSprite.Length)
        {
            CarWheel.sprite = WheelSprite[wheelIndex];

         //   Debug.Log($"���� �� �ݿ�: {wheelIndex}");
            ChangeCarPrice("Wheel", wheelIndex);

            chocieIndexValue[1] = wheelIndex;
        }
        else
        {
            Debug.LogWarning("��ȿ���� ���� ���� �� �ε����Դϴ�.");
        }
    }

    public void UpdateSeatColor(int seatColorIndex)
    {
        CarSeatColor.enabled = true;
        if (seatColorIndex >= 0 && seatColorIndex < SeatSprite.Length)
        {
            CarSeatColor.sprite = SeatSprite[seatColorIndex];

         //   Debug.Log($"���� ��Ʈ �÷� �ݿ�: {seatColorIndex}");
            ChangeCarPrice("SeatColor", seatColorIndex);

            chocieIndexValue[2] = seatColorIndex;
        }
        else
        {
            Debug.LogWarning("��ȿ���� ���� ���� ��Ʈ �÷� �ε����Դϴ�.");
        }
    }

    public void UpdateAutoPilot(int autoPilotIndex)
    {
        AutoPilot.enabled = true;
        if (autoPilotIndex >= 0 && autoPilotIndex < AutoPilotSprite.Length)
        {
            AutoPilot.sprite = AutoPilotSprite[autoPilotIndex];

        //    Debug.Log($"�������Ϸ� �ݿ�: {autoPilotIndex}");
            ChangeCarPrice("AutoPilot", autoPilotIndex);

            chocieIndexValue[3] = autoPilotIndex;
        }
        else
        {
            Debug.LogWarning("��ȿ���� ���� �������Ϸ� �ε����Դϴ�.");
        }
    }


    void UpdatePriceText(int price)
    {
        // ���ڸ� õ���� ������ ǥ���ϴ� �������� ����
        string formattedPrice = string.Format("{0:#,##0}", price);

        // �ؽ�Ʈ ������Ʈ
        priceText.text = formattedPrice;
    }

    // ������ �����ϴ� �޼���
    public void ChangeCarPrice(string typeName, int changeIndex)
    {
        
       if(typeName == "OutColor")
        {
            switch (changeIndex)
            {
              
                case 0:
                    currentCarPrice -= previousPlusOutColorPrice;
                    int plusPrice = 0;
                    currentCarPrice += plusPrice;
                    previousPlusOutColorPrice = plusPrice;
                    break;
                
                case 1:
                case 2:
                    currentCarPrice -= previousPlusOutColorPrice;
                    plusPrice = 1318500;
                    currentCarPrice += plusPrice;
                    previousPlusOutColorPrice = plusPrice;
                    break;

                case 3:
                    currentCarPrice -= previousPlusOutColorPrice;
                    plusPrice = 1384425;
                    currentCarPrice += plusPrice;
                    previousPlusOutColorPrice = plusPrice;
                    break;

                case 4:
                    currentCarPrice -= previousPlusOutColorPrice;
                    plusPrice = 2637000;
                    currentCarPrice += plusPrice;
                    previousPlusOutColorPrice = plusPrice;
                    break;

                default:
                    // ����ó��: �ٸ� �ε����� ��쿡 ���� ó��
                    Debug.LogWarning("��ȿ���� ���� ���� �÷� �ε����Դϴ�.");
                    break;
            }
            UpdatePriceText(currentCarPrice);
        }

      else if(typeName == "Wheel")
        {
            switch(changeIndex)
            {
                case 0:
                    currentCarPrice -= previousPlusWheelPrice;
                    int plusPrice = 0;
                    currentCarPrice += plusPrice;
                    previousPlusWheelPrice = plusPrice;
                    break;

                    case 1:
                    currentCarPrice -= previousPlusWheelPrice;
                    plusPrice = 1976284;
                    currentCarPrice += plusPrice;
                    previousPlusWheelPrice = plusPrice;
                    break;

                default:
                    // ����ó��: �ٸ� �ε����� ��쿡 ���� ó��
                    Debug.LogWarning("��ȿ���� ���� ���� �� �ε����Դϴ�.");
                    break;
            }
            UpdatePriceText(currentCarPrice);
        }


      else if(typeName == "SeatColor")
        {
            switch(changeIndex)
            {
                case 0:
                    currentCarPrice -= previousPlusSeatColorPrice;
                    int plusPrice = 0;
                    currentCarPrice += plusPrice;
                    previousPlusSeatColorPrice = plusPrice;
                    break;

                case 1:
                    currentCarPrice -= previousPlusSeatColorPrice;
                    plusPrice = 1318500;
                    currentCarPrice += plusPrice;
                    previousPlusSeatColorPrice = plusPrice;
                    break;

                default:
                    // ����ó��: �ٸ� �ε����� ��쿡 ���� ó��
                    Debug.LogWarning("��ȿ���� ���� ��Ʈ �÷� �ε����Դϴ�.");
                    break;

            }
            UpdatePriceText(currentCarPrice);
        }

        else if (typeName == "AutoPilot")
        {
            switch (changeIndex)
            {
                case 0:
                    currentCarPrice -= previousPlusAutoPilotPrice;
                    int plusPrice = 7911000;
                    currentCarPrice += plusPrice;
                    previousPlusAutoPilotPrice = plusPrice;
                    break;

                case 1:
                    currentCarPrice -= previousPlusAutoPilotPrice;
                    plusPrice = 15822000;
                    currentCarPrice += plusPrice;
                    previousPlusAutoPilotPrice = plusPrice;
                    break;

                default:
                    // ����ó��: �ٸ� �ε����� ��쿡 ���� ó��
                    Debug.LogWarning("��ȿ���� ���� �������Ϸ� �ε����Դϴ�.");
                    break;

            }
            UpdatePriceText(currentCarPrice);
        }

        else
        {
            Debug.LogWarning("��ȿ���� ���� ���� Ÿ���Դϴ�.");
        }
    }
}


