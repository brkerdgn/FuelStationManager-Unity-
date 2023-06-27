using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnerControl : MonoBehaviour
{
    [SerializeField] GameObject[] customerPrefabs;
    [SerializeField] Transform spawnPoint;
    [SerializeField] StationControl station;

    // spawn süresi
    [SerializeField] float min, max;

    float timer;
    int j;

    private void Update()
    {
        if (station.stationCount != 0)
            timer += Time.deltaTime;

        if (timer > Random.Range(min, max) && station.stationCount != 0)
        {
            timer = 0f;

            // müsait olan masayý belirleme
            for (j = 0; j < station.stations.Length; j++)
            {
                if (station.isStationEmpty[j])
                {
                    station.isStationEmpty[j] = false;
                    station.stationCount--;
                    break;
                }
            }
            GameObject go = Instantiate(customerPrefabs[Random.Range(0, customerPrefabs.Length)], spawnPoint.position, Quaternion.identity);
            go.GetComponent<CarNavmesh>().WalkToTable(station.stations[j]);
            go.GetComponent<CarNavmesh>().settedTable = j;
            station.transform.GetChild(j).GetComponent<StationManager>().customer.Add(go);
        }
    }
}

