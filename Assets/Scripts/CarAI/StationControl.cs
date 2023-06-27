using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationControl : MonoBehaviour
{
    // tablelarýn tutulduðu transform arrayi
    public GameObject[] fuels,stationCables;
    public Transform[] stations;

    // masa müsaitliðini kontrol eden array
    public bool[] isStationEmpty,isCame,isConnected;

    // müsait olan sayý miktarý
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
