using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrip : MonoBehaviour
{
    [SerializeField]
    private float _pushForce;
    
    void Start()
    {
        
    }

  
    void Update()
    {
        
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rigid = hit.collider.attachedRigidbody;
        if(rigid!=null)
        {
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();

            rigid.AddForceAtPosition(forceDirection * _pushForce, transform.position, ForceMode.Impulse);
        }
    }
}
