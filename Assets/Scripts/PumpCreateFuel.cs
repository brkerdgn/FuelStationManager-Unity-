using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PumpCreateFuel : MonoBehaviour
{
    Material objectMaterial;
    public GameObject objectPrefab;
    public float progressSteps,maxFuel = 1.8f;
    [HideInInspector]
    public float _fillRateValue;
    float timerFuel = 0f;

    public Animator anim;

    private void Awake()
    {
        objectMaterial = objectPrefab.GetComponent<MeshRenderer>().material;
        _fillRateValue = 0;
        objectMaterial.SetFloat("_FillRate", _fillRateValue); 
    }

    public void CreateFuel()
    { 
        if(_fillRateValue <= maxFuel)
        {
            timerFuel += Time.deltaTime;
            if (timerFuel >= 4.0f)
            {
                _fillRateValue += progressSteps;
                objectMaterial.SetFloat("_FillRate", _fillRateValue);
                timerFuel = 0;
            }
        }  
    }

    private void FixedUpdate()
    {
        CreateFuel();
        objectMaterial.SetFloat("_FillRate", _fillRateValue);
    }
}
