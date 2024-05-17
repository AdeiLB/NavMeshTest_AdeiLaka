using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

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
        
        if(Physics.Raycast(ray,out raycastHit)&&Input.GetMouseButton(0))
        {
            navMesagent.SetDestination(raycastHit.point);
        }
    }

    private void OnMouseDown()
    {
        if(Input.GetMouseButton(1))
        {
            //attack
        }
    }


    public void die()
    {
        SceneManager.LoadScene(0);
    }
}
