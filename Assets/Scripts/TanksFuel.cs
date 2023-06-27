using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanksFuel : MonoBehaviour
{
    Material objectMaterial;
    public GameObject objectPrefab;

    [HideInInspector]
    public float progressSteps = 0.2f;

    public float _fillRateValue;

    public float minValue = -1.0f;
    public float maxValue = 1.1f;

    private void Awake()
    {
        objectMaterial = objectPrefab.GetComponent<MeshRenderer>().material;
        _fillRateValue = minValue;
        objectMaterial.SetFloat("_FillRate", _fillRateValue);
    }
    private void Update()
    {
        objectMaterial.SetFloat("_FillRate", _fillRateValue);
    }
    public void FuelTakingTanks()
    {
        if (_fillRateValue <= maxValue)
        {
            _fillRateValue += progressSteps;
            objectMaterial.SetFloat("_FillRate", _fillRateValue);
        }
    }
}
