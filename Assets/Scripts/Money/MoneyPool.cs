using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using static UnityEditor.PlayerSettings;

public class MoneyPool : MonoBehaviour
{
    private Queue<GameObject> moneyList = new Queue<GameObject>();
    [SerializeField] private GameObject moneyPrefab;
    [SerializeField] private int moneyNeeded = 8, moneyFlow = 0;
    float startPoint = -18.50f;
    
    private void Awake()
    {
        moneyList = new Queue<GameObject>();
        float x = 0f;
        for (int i = 0; i < moneyNeeded; i++)
        {   
            GameObject tmp = Instantiate(moneyPrefab, transform.position, Quaternion.LookRotation(Vector3.up));
            tmp.transform.position = new Vector3(tmp.transform.position.x, (startPoint + (x / 3)) , tmp.transform.position.z);
            tmp.SetActive(false);
            x++;
            moneyList.Enqueue(tmp);
        }
    }

    public IEnumerator Money(int amount)
    {
        while (true)
        {
            if (moneyFlow < amount)
            {
                yield return new WaitForSeconds(0.1f);
                GameObject money = moneyList.Dequeue(); 
                money.SetActive(true);
                Debug.Log(moneyFlow);
                moneyFlow++;
            }
            yield return null;
        }
    }

    public void ReturnToPool(GameObject tmp)
    {
        tmp.SetActive(false);
        moneyList.Enqueue(tmp);
    }

        public void CreateMoney(int howMany)
    {
        StartCoroutine(Money(howMany));
    }
}
