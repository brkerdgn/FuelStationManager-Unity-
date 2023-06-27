using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TankArea : MonoBehaviour
{
    public GameObject tankArea,tank;
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
            tankArea.SetActive(false);
            tank.SetActive(true);

        }
    }
}
