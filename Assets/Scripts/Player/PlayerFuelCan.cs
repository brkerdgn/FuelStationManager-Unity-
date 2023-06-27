using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFuelCan : MonoBehaviour
{
    Material objectMaterial;
    public GameObject objectPrefab;
    [HideInInspector]
    float progressSteps = 0.4f;

    float _fillRateValue;
    float timerFuel = 0f;

    float maxFuel = 0.48f;
    float minFuel = -1.10f;

    public PumpCreateFuel pumpCreateFuel;
    public TanksFuel tanksFuel;

    private void Awake()
    {
        objectMaterial = objectPrefab.GetComponent<MeshRenderer>().material;
        _fillRateValue = minFuel;
        objectMaterial.SetFloat("_FillRate", _fillRateValue);
    }


    private void OnEnable()
    {
        TriggerManager.OnFuelTaking += FuelTaken;
        TriggerManager.OnFuelGiving += FuelGiven;
        TriggerManager.OnMining += Mining;
    }

    private void OnDisable()
    {
        TriggerManager.OnFuelTaking -= FuelTaken;
        TriggerManager.OnFuelGiving -= FuelGiven;
        TriggerManager.OnMining -= Mining;
    }
   
    void FuelTaken()
    {
        if (_fillRateValue <= maxFuel)
        {
            timerFuel += Time.deltaTime;
            if (timerFuel >= 1.0f && pumpCreateFuel._fillRateValue > 0)
            {
                _fillRateValue += progressSteps;
                pumpCreateFuel._fillRateValue -= pumpCreateFuel.progressSteps;
                objectMaterial.SetFloat("_FillRate", _fillRateValue);
                timerFuel = 0;
            }
        }
    }

    void Mining()
    {
        if (_fillRateValue <= maxFuel)
        {
            timerFuel += Time.deltaTime;
            if (timerFuel >= 2.0f)
            {
                _fillRateValue += progressSteps;
                objectMaterial.SetFloat("_FillRate", _fillRateValue);
                timerFuel = 0;
            }
        }
    }

    void FuelGiven()
    {
        if (_fillRateValue > minFuel)
        {
            timerFuel += Time.deltaTime;
            if (timerFuel >= 1.0f)
            {
                _fillRateValue -= progressSteps;
                objectMaterial.SetFloat("_FillRate", _fillRateValue);
                timerFuel = 0;
                tanksFuel.FuelTakingTanks();
            }
        }  
    }
}
