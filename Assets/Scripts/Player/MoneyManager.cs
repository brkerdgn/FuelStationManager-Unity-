using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public float moneyCount = 0;
    public TextMeshProUGUI text;

    private void OnEnable()
    {
        TriggerManager.OnBuyingStation += BuyStation;
        TriggerManager.OnBuyingTank += BuyTank;
        TriggerManager.OnBuyingPump += BuyPump;

    }
    private void OnDisable()
    {
        TriggerManager.OnBuyingStation -= BuyStation;
        TriggerManager.OnBuyingTank -= BuyTank;
        TriggerManager.OnBuyingPump -= BuyPump;
    }
    private void Update()
    {
        text.SetText(moneyCount.ToString("0"));
    }

    void BuyStation()
    {
        if (gameObject.GetComponent<TriggerManager>().fuel == true)
        {
            if (TriggerManager.stationToBuy != null)
            {
            if (moneyCount >= 1)
               {
                TriggerManager.stationToBuy.Buy(1);
                moneyCount -= 1 * Time.deltaTime * 4;
               }
            }
        }else
        {
            if (TriggerManager.stationToBuy != null)
            {
                if (moneyCount >= 1)
                {
                    TriggerManager.stationToBuy.Buy(1);
                    moneyCount -= 1 * Time.deltaTime * 16;
                }
            }
        }
       
    }

    void BuyTank()
    {
        if (TriggerManager.TankToBuy != null)
        {
            if (moneyCount >= 1)
            {
                TriggerManager.TankToBuy.Buy(1);
                moneyCount -= 1 * Time.deltaTime * 16;
            }
        }
    }

    void BuyPump()
    {
        if (TriggerManager.PumpToBuy != null)
        {
            if (moneyCount >= 1)
            {
                TriggerManager.PumpToBuy.Buy(1);
                moneyCount -= 1 * Time.deltaTime * 16;
            }
        }
    }
}
