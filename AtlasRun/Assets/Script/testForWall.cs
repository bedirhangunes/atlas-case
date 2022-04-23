using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testForWall : MonoBehaviour
{

    public float moveSpeed = 0.25f;
    public float rotationState = 15f;
    public Transform bariyer;
    private Rigidbody rigid;
    private Vector3 moveInput;
  private  void Awake()
    {
        TryGetComponent(out rigid);
    }

    
   private void Update()
    {
      //  moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));   
    }
    private void FixedUpdate()
    {
        rigid.position += moveInput * moveSpeed;
        if (moveInput.sqrMagnitude > 0)
        {
            Quaternion rotation = Quaternion.LookRotation(moveInput, Vector3.up);
            rigid.rotation = Quaternion.Lerp(rigid.rotation, rotation, Time.fixedDeltaTime * rotationState);
        }
    }
}
