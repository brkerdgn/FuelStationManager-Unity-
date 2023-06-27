using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationControl : MonoBehaviour
{
    // tablelar�n tutuldu�u transform arrayi
    public GameObject[] fuels,stationCables;
    public Transform[] stations;

    // masa m�saitli�ini kontrol eden array
    public bool[] isStationEmpty,isCame,isConnected;

    // m�sait olan say� miktar�
    public int stationCount;
    public void ClearStation(int stationNo)
    {
        stationCables[stationNo].SetActive(false);
        fuels[stationNo].SetActive(false);
        isCame[stationNo] = false;
        isStationEmpty[stationNo] = true;
        stationCount++;
        isConnected[stationNo] = false;
    }
}
