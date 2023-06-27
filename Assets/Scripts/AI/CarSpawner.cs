using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public List<GameObject> cars = new List<GameObject>();

    public int maxCars;

    public bool canCreateCarNow;
    [Range(0.1f, 1f)]
    public float minSpawnTime;

    [Range(1f, 2f)]
    public float maxSpawnTime;

    private void Start()
    {
        StartCoroutine(SpawnCar());
    }

    IEnumerator SpawnCar()
    {
        while (true)
        {
            if (cars.Count < maxCars)
            {
                canCreateCarNow = true;

                yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));

                canCreateCarNow = false;

                GameObject car = CarPool.instance.GetCar();
                cars.Add(car);
                car.transform.position = this.transform.position;
                car.transform.rotation = this.transform.rotation;

                car.SetActive(true);
            }
            yield return null;
        }
    }
}
