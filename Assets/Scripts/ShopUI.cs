using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public GameObject panel;
   
    public void ShopPanel()
    {
        panel.SetActive(true);
    }

    public void PanelExit()
    {
        panel.SetActive(false);
    }
}
