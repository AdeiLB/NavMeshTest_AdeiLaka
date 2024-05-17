using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostMovement : MonoBehaviour
{
    public GameObject[] pathPositions;
    public bool playerNear;

    public GameObject player;

    private NavMeshAgent agent;
    private int count;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        playerNear = false;
        agent = GetComponent<NavMeshAgent>();
        count = 0;
        agent.SetDestination(pathPositions[count].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if(!playerNear)
        {
            normalPhating();
        }
        else
        {
            //Chase
            agent.SetDestination(player.transform.position);
        }

        if(distance < 2)
        {
            playerNear = true;
        }

        if (distance < 5)
        {
            playerNear = false;
        }


    }

    private void normalPhating()
    {
        if (agent.remainingDistance <= 0)
        {
            if (count >= pathPositions.Length - 1)
            {
                count = 0;
            }
            else
            {
                count++;
            }
            agent.SetDestination(pathPositions[count].transform.position);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colision detetcada");
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            
            collision.gameObject.GetComponent<PlayerMovement>().die();
        }
    }

}
