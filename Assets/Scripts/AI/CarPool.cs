using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarPool : MonoBehaviour
{
    public static CarPool instance;
    public Queue<GameObject> cars;

    int carCount;
    [SerializeField] GameObject[] carPrefabs;
    
    GameObject go;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        carCount = GetComponent<CarSpawner>().maxCars;
        cars = new Queue<GameObject>();
        Generate(carCount);
    }

    public void Generate(int count)
    {
        for (int i = 0; i < count; i++)
        {
            go = Instantiate(carPrefabs[Random.Range(0, carPrefabs.Length)], transform);
            go.SetActive(false);
            cars.Enqueue(go);    
        }
    }
    public GameObject GetCar()
    {
        return cars.Dequeue();
    }

    public void ReturnToPool(GameObject car)
    {
        cars.Enqueue(car);
    }

}
