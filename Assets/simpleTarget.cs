using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class simpleTarget : MonoBehaviour
{
    public Transform[] goals;
    private NavMeshAgent agent;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        count = 0;
        agent.SetDestination(goals[count].position);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("target number" + count);
        if (agent.remainingDistance <= 0)
        {
            if (count >= goals.Length - 1)
            {
                count = 0;
            }
            else
            {
                count++;
            }
        }
        agent.SetDestination(goals[count].position);

    }
}
