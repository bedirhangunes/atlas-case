using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerScr : MonoBehaviour
{
    float horizontal, vertical,normalizedTime=5;
    Vector3 vector,firstPosition=new Vector3(15.98f,0.35f,-119.55f);
    Animator animator;
    Rigidbody rigid;
    GameObject box1, box2;
    Joystick joystick;
    void Start()
    {
        vector = new Vector3();
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        joystick = FindObjectOfType<Joystick>();
        box1 = GameObject.Find("white");
        box2 = GameObject.Find("red");
        box1.SetActive(true);
        box2.SetActive(false);
    }

  
    void Update()
    {
        runToTarget();
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(joystick.Horizontal * 20f, rigid.velocity.y, joystick.Vertical * 20f);

      //  animator.SetBool("Run", true);
    }
    void runToTarget()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        vector.Set(horizontal, 0, vertical);
        transform.Translate(vector * Time.deltaTime * 30f);
        animator.SetBool("Run", true);
    }
    void runToStop()
    {
        vector.Set(0, 0, 0);
        transform.Translate(vector * Time.deltaTime * 0f);
        animator.SetBool("Run", false);
    }
     void OnTriggerEnter(Collider col)
    {
        if (col.tag == "banner")
        {
            animator.SetBool("Run", false);

            animator.SetBool("fal", true);

            rigid.useGravity = true;
           // transform.position = firstPosition;

        }
        if (col.tag == "cism")
        {
            animator.SetBool("Run", false);

            animator.SetBool("fal", true);
            rigid.useGravity = true;
        }
        if (col.tag == "rotate")
        {
            animator.SetBool("Run", false);

            animator.SetBool("fal", true);

            rigid.useGravity = true;
        }
        if (col.tag == "zemin")
        {


            animator.SetBool("Run", false);
            animator.SetBool("getting", true);
            rigid.useGravity = true;
           
        }
        if (col.tag == "dusman")
        {
            rigid.isKinematic = true;
            animator.SetBool("fal", false);
            animator.SetBool("getting", false);
            animator.SetBool("Run", true);
            //SceneManager.LoadScene("level1");
           transform.position = firstPosition;
            rigid.useGravity = false;

            
        }
        if (col.tag == "Finish")
        {
            animator.SetBool("Run", false);
            animator.SetBool("magic", true);
          //  runToStop();
            StartCoroutine(redWall());
            //rigid.useGravity = true;
        }
        else
        {
            rigid.isKinematic = false;
            //rigid.useGravity = false;
        }
    }
     void OnCollisionEnter(Collision coll)
    {
        float force = 3;
        if (coll.gameObject.tag == "dusman")
        {
            Vector3 dir = coll.contacts[0].point - transform.position;
            dir = -dir.normalized;
            GetComponent<Rigidbody>().AddForce(dir * force);
        }
    }
    IEnumerator redWall()
    {
        yield return new WaitForSeconds(1.2f);
        box1.SetActive(false);
        box2.SetActive(true);
    }
   
}
