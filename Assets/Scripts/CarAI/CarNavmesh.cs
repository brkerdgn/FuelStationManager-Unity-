using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CarNavmesh : MonoBehaviour
{
    Transform tablePos;
    NavMeshAgent agent;
    public Transform exitPoint;
    public bool isExit,isOk;
    public int settedTable;
    float distance;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ExitPoint"))
        {
            isExit = true;
            Destroy(gameObject);
        }
    }
    public void WalkToTable(Transform pos)
    {
        tablePos = pos;
        agent.SetDestination(pos.position);
    }
 
    public void RemainingDistance()
    {
       distance = Vector3.Distance(tablePos.position, transform.position);
        if(distance <= 3.0f)
        {
            transform.rotation = tablePos.rotation;
        }
    }

    private void FixedUpdate()
    {
        RemainingDistance();
    }

    public void LeaveStation()
    {
        agent.SetDestination(exitPoint.position);
    }
}
