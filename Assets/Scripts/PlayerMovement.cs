using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent navMesagent;
    // Start is called before the first frame update
    void Start()
    {
        navMesagent = GetComponent<NavMeshAgent> ();
    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;
        
        if(Physics.Raycast(ray,out raycastHit))
        {
            navMesagent.SetDestination(raycastHit.point);
        }
    }
}
