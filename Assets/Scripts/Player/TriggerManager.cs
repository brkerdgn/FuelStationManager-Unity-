using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class TriggerManager : MonoBehaviour
{

    public delegate void OnBuyStation();
    public static event OnBuyStation OnBuyingStation;
    public static BuyStations stationToBuy;

    public delegate void OnTankArea();
    public static event OnTankArea OnBuyingTank;
    public static TankArea TankToBuy;

    public delegate void OnPumpArea();
    public static event OnPumpArea OnBuyingPump;
    public static PumpArea PumpToBuy;

    public delegate void OnPumpTakeArea();
    public static event OnPumpTakeArea OnFuelTaking;
    public static PlayerFuelCan FuelToTake;

    public delegate void OnTankGiveArea();
    public static event OnTankGiveArea OnFuelGiving;
    public static PlayerFuelCan FuelToGive;

    public delegate void OnMineArea();
    public static event OnMineArea OnMining;
    public static PlayerFuelCan MineToTake;

    public GameObject pumpCable1,pumpCable2,pumpCable3,tankCable1,tankCable2;
    public  Animator fuelArea1, fuelArea2, fuelArea3,fuelArea4,tankArea,pumpArea1,pumpArea2,miningAnim;

    bool isUpgrading,isTaking,isGiving,isMining;
    public bool fuel;
    public GameObject shopDuvar1, shopDuvar2,tavan,sparks,shopIcon;
    public MoneyPool stationMoney1,stationMoney2,stationMoney3,stationMoney4;
    public MoneyManager moneyManager;
    public Camera camera;
    private void Start()
    {
        StartCoroutine(PlayerEnum());
    }

    IEnumerator PlayerEnum()
    {
        if(isUpgrading)
        {
            OnBuyingStation();   
        }
        if (isTaking)
        {
            OnFuelTaking();

        }if (isGiving)
        {
            OnFuelGiving();
        }
        if (isMining)
        {
            OnMining();
        }
        yield return new WaitForSeconds(0.5f);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Money"))
        {
            GameObject money = other.gameObject;
            stationMoney1.ReturnToPool(money);
            moneyManager.moneyCount += 5;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("ShopZemin"))
        {
            // camera.DOShakePosition(0.1f, 0.2f);
            shopDuvar1.SetActive(false);
            shopDuvar2.SetActive(true);
            tavan.SetActive(false);
            shopIcon.SetActive(true);
        }
        if (other.CompareTag("Fuel1"))
        {
            fuel = true;
            OnBuyingStation();
            stationToBuy = other.gameObject.GetComponent<BuyStations>();
            fuelArea1.SetBool("Fuel1", true);
        }
        if (other.CompareTag("Fuel2"))
        {
            fuel = true;
            OnBuyingStation();
            stationToBuy = other.gameObject.GetComponent<BuyStations>();
            fuelArea2.SetBool("Fuel2", true);
        }
        if (other.CompareTag("Fuel3"))
        {
            OnBuyingStation();
            stationToBuy = other.gameObject.GetComponent<BuyStations>();
            fuelArea3.SetBool("Fuel3", true);
        }
        if (other.CompareTag("Fuel4"))
        {
            OnBuyingStation();
            stationToBuy = other.gameObject.GetComponent<BuyStations>();
            fuelArea4.SetBool("Fuel4", true);
        }
        if (other.CompareTag("TankArea"))
        {
            OnBuyingTank();
            TankToBuy = other.gameObject.GetComponent<TankArea>();
            tankArea.SetBool("TankArea", true);
        }
        if (other.CompareTag("PumpArea1"))
        {
            OnBuyingPump();
            PumpToBuy = other.GetComponent<PumpArea>();
            pumpArea1.SetBool("PumpArea1", true);
        }
        if (other.CompareTag("PumpArea2"))
        {
            OnBuyingPump();
            PumpToBuy = other.GetComponent<PumpArea>();
            pumpArea2.SetBool("PumpArea2", true);
        }
        if (other.CompareTag("Pump1"))
        {
            OnFuelTaking();
            FuelToTake = other.GetComponent<PlayerFuelCan>();
            pumpCable1.SetActive(true);
        }
        if (other.CompareTag("Pump2"))
        {
            OnFuelTaking();
            FuelToTake = other.GetComponent<PlayerFuelCan>();
            pumpCable2.SetActive(true);
        }
        if (other.CompareTag("Pump3"))
        {
            OnFuelTaking();
            FuelToTake = other.GetComponent<PlayerFuelCan>();
            pumpCable3.SetActive(true);
        }

        if (other.CompareTag("Tank1"))
        {
            tankCable1.SetActive(true);
            OnFuelGiving();
            FuelToGive = other.GetComponent<PlayerFuelCan>();
        }
        if (other.CompareTag("Tank2"))
        {
            tankCable2.SetActive(true);
            OnFuelGiving();
            FuelToGive = other.GetComponent<PlayerFuelCan>();
        }
        if (other.CompareTag("Mine"))
        {
            miningAnim.SetBool("isMining", true);
            OnMining();
            MineToTake = other.GetComponent<PlayerFuelCan>();
            sparks.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ShopZemin"))
        {
            shopDuvar1.SetActive(true);
            shopDuvar2.SetActive(false);
            tavan.SetActive(true);
            shopIcon.SetActive(false);
        }
        if (other.CompareTag("Fuel1"))
        {
            fuel = false;
            isUpgrading = false;
            stationToBuy = null;
            fuelArea1.SetBool("Fuel1", false);
        }

        if (other.CompareTag("Fuel2"))
        {
            fuel = false;
            isUpgrading = false;
            stationToBuy = null;
            fuelArea2.SetBool("Fuel2", false);
        }

        if (other.CompareTag("Fuel3"))
        {
            isUpgrading = false;
            stationToBuy = null;
            fuelArea3.SetBool("Fuel3", false);
        }
        if (other.CompareTag("Fuel4"))
        {
            isUpgrading = false;
            stationToBuy = null;
            fuelArea4.SetBool("Fuel4", false);
        }
        if (other.CompareTag("TankArea"))
        {
            TankToBuy = null;
            tankArea.SetBool("TankArea", false);
        }
        if (other.CompareTag("PumpArea1"))
        {
            PumpToBuy = null;
            pumpArea1.SetBool("PumpArea1", false);
        }
        if (other.CompareTag("PumpArea2"))
        {
            PumpToBuy = null;
            pumpArea2.SetBool("PumpArea2", false);
        }
        if (other.CompareTag("Pump1"))
        {
            FuelToTake = null;
            isTaking = false;
            pumpCable1.SetActive(false);
        }
        if (other.CompareTag("Pump2"))
        {
            FuelToTake = null;
            isTaking = false;
            pumpCable2.SetActive(false);
        }
        if (other.CompareTag("Pump3"))
        {
            FuelToTake = null;
            isTaking = false;
            pumpCable3.SetActive(false);
        }
        if (other.CompareTag("Tank1"))
        {
            tankCable1.SetActive(false);
            FuelToGive = null;
            isGiving = false;
        }
        if (other.CompareTag("Tank2"))
        {
            tankCable2.SetActive(false);
            FuelToGive = null;
            isGiving = false;
        }
        if (other.CompareTag("Mine"))
        {   
            sparks.SetActive(false);
            miningAnim.SetBool("isMining", false);
            MineToTake = null;
            isMining = false;
        }
    }
}
