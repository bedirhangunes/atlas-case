using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class opponentScr : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject target;
    float mesafe,menzil=180f;
    Animator animator;
    Vector3 firstPos = new Vector3(12, 0.55f, -123f);
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        agent.SetDestination(new Vector3(9.18f, 0.55f, 163.9f));
        //  mesafe = Vector3.Distance(target.transform.position, transform.position);
        //if (mesafe <= menzil)
        //{
           
           animator.SetBool("run", true);
        //}
        //else
        //{
        //    animator.SetBool("run", false);
        //}

    }
    // void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.black;
    //    Gizmos.DrawWireSphere(transform.position, menzil);
    //}
     void OnTriggerEnter(Collider col)
    {
        if (col.tag == "banner")
        {
            transform.position = firstPos;
        }
        if (col.tag == "rotate")
        {
            transform.position = firstPos;
        }

    }
}
