using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuyStations : MonoBehaviour
{
    public GameObject buyArea, buyStationNew,buStationOld,seconBuyArea,secondBuyStationOld,fuel;
    public float cost,speed;
    public int tableNo;
    public StationControl stationControl;
    bool isDone;
    public TextMeshProUGUI textmesh;

    private void Update()
    {
        textmesh.text = Mathf.CeilToInt(cost).ToString();
    }
    public void Buy(int moneyAmount)
    {
        cost -= moneyAmount * Time.deltaTime * speed;

        if (cost <= 0 && !isDone)
        {
            isDone = true;
            buyArea.SetActive(false);
            buyStationNew.SetActive(true);
            buStationOld.SetActive(false);
            seconBuyArea.SetActive(true);
            secondBuyStationOld.SetActive(true);
            stationControl.stationCount++;
            stationControl.isStationEmpty[tableNo] = true;
            fuel.GetComponent<TriggerManager>().fuel = false;
        }
    }
}
