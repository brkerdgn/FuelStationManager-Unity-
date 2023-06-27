using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PumpArea : MonoBehaviour
{
    public GameObject pumpArea, pump,secondArea;
    public TextMeshProUGUI textmesh;
    public float cost;
    private void Update()
    {
        textmesh.text = Mathf.CeilToInt(cost).ToString();
    }
    public void Buy(int moneyAmount)
    {
        cost -= moneyAmount * Time.deltaTime * 16;

        if (cost <= 0)
        {
            pumpArea.SetActive(false);
            pump.SetActive(true);
            secondArea.SetActive(true);


        }
    }
}
