using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitWayPoints : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            other.gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("CarSpawn").GetComponent<CarSpawner>().cars.Remove(other.gameObject);
        }
    }
}
