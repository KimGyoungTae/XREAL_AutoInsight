using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TabletUIManager : MonoBehaviour
{
    public static TabletUIManager Instance;

    [Space]
    [Header("태블릿 UI 정보")]
    [SerializeField] private Image CarOutColor;
    [SerializeField] private Sprite[] OutColorSprite;
    [SerializeField] private Image CarWheel;
    [SerializeField] private Sprite[] WheelSprite;
    [SerializeField] private Image CarSeatColor;
    [SerializeField] private Sprite[] SeatSprite;
    [SerializeField] private Image AutoPilot;
    [SerializeField] private Sprite[] AutoPilotSprite;

    [Space]
    [Header("차량 총 가격")]
    [SerializeField] private Text priceText;
    public int currentCarPrice = 56990000; // 초기 가격 설정

    public List<int> chocieIndexValue = new List<int>();

    private int previousPlusOutColorPrice = 0;
    private int previousPlusWheelPrice = 0;
    private int previousPlusSeatColorPrice = 0;
    private int previousPlusAutoPilotPrice = 0;

 

    void Start()
    {
        // 초기 가격을 텍스트로 표시
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
        Debug.Log("저장 버튼 클릭");
        SaveOptions.Instance.ReceiveIndex(chocieIndexValue, currentCarPrice);
    }

    
    public void UpdateOutColor(int outColorIndex)
    {
        CarOutColor.enabled = true;
        if (outColorIndex >= 0 && outColorIndex < OutColorSprite.Length)
        {
            // outColorIndex에 따라 해당하는 Sprite를 설정합니다.
            CarOutColor.sprite = OutColorSprite[outColorIndex];

            // 디버그 로그를 통해 어떤 차량 컬러가 반영되는지 확인합니다.
         //   Debug.Log($"차량 외장 컬러 반영: {outColorIndex}");
            ChangeCarPrice("OutColor", outColorIndex);

            chocieIndexValue[0] = outColorIndex;
        }
        else
        {
            Debug.LogWarning("유효하지 않은 차량 외장 컬러 인덱스입니다.");
        }
    }

    public void UpdateWheel(int wheelIndex)
    {
        CarWheel.enabled = true;
        if (wheelIndex >= 0 && wheelIndex < WheelSprite.Length)
        {
            CarWheel.sprite = WheelSprite[wheelIndex];

         //   Debug.Log($"차량 휠 반영: {wheelIndex}");
            ChangeCarPrice("Wheel", wheelIndex);

            chocieIndexValue[1] = wheelIndex;
        }
        else
        {
            Debug.LogWarning("유효하지 않은 차량 휠 인덱스입니다.");
        }
    }

    public void UpdateSeatColor(int seatColorIndex)
    {
        CarSeatColor.enabled = true;
        if (seatColorIndex >= 0 && seatColorIndex < SeatSprite.Length)
        {
            CarSeatColor.sprite = SeatSprite[seatColorIndex];

         //   Debug.Log($"차량 시트 컬러 반영: {seatColorIndex}");
            ChangeCarPrice("SeatColor", seatColorIndex);

            chocieIndexValue[2] = seatColorIndex;
        }
        else
        {
            Debug.LogWarning("유효하지 않은 차량 시트 컬러 인덱스입니다.");
        }
    }

    public void UpdateAutoPilot(int autoPilotIndex)
    {
        AutoPilot.enabled = true;
        if (autoPilotIndex >= 0 && autoPilotIndex < AutoPilotSprite.Length)
        {
            AutoPilot.sprite = AutoPilotSprite[autoPilotIndex];

        //    Debug.Log($"오토파일럿 반영: {autoPilotIndex}");
            ChangeCarPrice("AutoPilot", autoPilotIndex);

            chocieIndexValue[3] = autoPilotIndex;
        }
        else
        {
            Debug.LogWarning("유효하지 않은 오토파일럿 인덱스입니다.");
        }
    }


    void UpdatePriceText(int price)
    {
        // 숫자를 천만원 단위로 표시하는 포맷으로 변경
        string formattedPrice = string.Format("{0:#,##0}", price);

        // 텍스트 업데이트
        priceText.text = formattedPrice;
    }

    // 가격을 변경하는 메서드
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
                    // 예외처리: 다른 인덱스일 경우에 대한 처리
                    Debug.LogWarning("유효하지 않은 차량 컬러 인덱스입니다.");
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
                    // 예외처리: 다른 인덱스일 경우에 대한 처리
                    Debug.LogWarning("유효하지 않은 차량 휠 인덱스입니다.");
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
                    // 예외처리: 다른 인덱스일 경우에 대한 처리
                    Debug.LogWarning("유효하지 않은 시트 컬러 인덱스입니다.");
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
                    // 예외처리: 다른 인덱스일 경우에 대한 처리
                    Debug.LogWarning("유효하지 않은 오토파일럿 인덱스입니다.");
                    break;

            }
            UpdatePriceText(currentCarPrice);
        }

        else
        {
            Debug.LogWarning("유효하지 않은 차량 타입입니다.");
        }
    }
}


