using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class CarDataParser
{
    private const string PATH = "/Scripts/SeongJae/Keyword/CarData.csv";
    private const int ID = 0;
    private const int NAME = 1;
    private const int FUEL_TYPE = 2;
    private const int CAR_TYPE = 3;
    private const int CAR_PRICE = 4;
    public void ParseDataTable(CarDataStorage storage)
    {
        StreamReader streamReader = new StreamReader(Application.dataPath + PATH);
        // ����κ� ����
        streamReader.ReadLine();

        while (!streamReader.EndOfStream)
        {
            // �� �پ� �о����
            string[] line = streamReader.ReadLine().Split(",");

            //���ο� CarData ���� �� ������ ����.
            CarData data = new CarData();
            data.InitSettings(int.Parse(line[ID]),
                line[NAME], 
                line[FUEL_TYPE], 
                line[CAR_TYPE], 
                int.Parse(line[CAR_PRICE]));
            storage.RegisterData(data);
        }
    }
}
