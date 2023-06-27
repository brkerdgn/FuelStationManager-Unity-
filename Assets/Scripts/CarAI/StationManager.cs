using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StationManager : MonoBehaviour
{
    [Header("Stations")]
    public int stationNo;
    public List<GameObject> customer = new List<GameObject>();
    public StationControl station;

    [Header("Car Fuel Materials")]
    Material carFuelMaterial;
    public GameObject carFuelObject;
    [HideInInspector]
    float progressSteps = 0.4f;
    float minFuel = -1.10f;
    float maxFuel = 0.48f;
    float _fillRateValue;
    float timerFuel = 0f;

    [Header ("Money")]
    int moneyCount;
    int min = 2, max = 8;

    [Header("Call Scripts")]
    public StationControl stationControl;
    public TanksFuel tanksFuel;
    [SerializeField] private MoneyPool money = null;

    private void Awake()
    {
        carFuelMaterial = carFuelObject.GetComponent<MeshRenderer>().material;
        _fillRateValue = minFuel;
        carFuelMaterial.SetFloat("_FillRate", _fillRateValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Car"))
        {
            station.fuels[stationNo].SetActive(true);
            station.isCame[stationNo] = true;
            moneyCount = Random.Range(min, max);
            _fillRateValue = minFuel;
        }
        if (other.gameObject.CompareTag("Player") && station.isCame[stationNo] == true)
        {
            station.isConnected[stationNo] = true;
            station.stationCables[stationNo].SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        FuelTaken();
        carFuelMaterial.SetFloat("_FillRate", _fillRateValue);
    }

    void FuelTaken()
    {
        if(station.isConnected[stationNo] == true)
        {
            if (tanksFuel._fillRateValue >= tanksFuel.minValue && _fillRateValue <= maxFuel)
            {
                timerFuel += Time.deltaTime;
                if (timerFuel >= 1.0f)
                {
                    _fillRateValue += progressSteps;
                    tanksFuel._fillRateValue -= tanksFuel.progressSteps;
                    carFuelMaterial.SetFloat("_FillRate", _fillRateValue);
                    timerFuel = 0;
                }
            }
            isGone();   
        } 
    }

    void isGone()
    {
        if (_fillRateValue >= maxFuel)
        {
            MoneyDrop();
            customer[stationNo].GetComponent<CarNavmesh>().LeaveStation();
            stationControl.ClearStation(stationNo);
            customer.Clear(); 
        }
    }
    
    public void MoneyDrop()
    {
        StartCoroutine(money.Money(moneyCount));
    }
}
