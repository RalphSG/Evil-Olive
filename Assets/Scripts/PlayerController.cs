﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float currentSpeed;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public bool isExiting;
    public bool isMoving;
    public bool isFrontMirror;

    Reflexion reflexion;
    GameObject reflexionChild;

    public Transform startPoint;

    Rigidbody rb;
    Animator anim;
    ParticleSystem puff;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<audiomanager>().Play("MainTheme");
        isExiting = true;
        reflexion = GameObject.FindGameObjectWithTag("Reflexion").GetComponent<Reflexion>();
        reflexionChild = GameObject.FindGameObjectWithTag("ReflexionChild"); ;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        puff = GameObject.FindGameObjectWithTag("Puff").GetComponent<ParticleSystem>();
        StartCoroutine(StartWalk(transform, startPoint.position, 1.5f));
    }

    // Update is called once per frame
    void Update() {
        if (!isExiting)
        {
            
            if (!anim.GetBool("isWarping"))
            {
                Vector2 input = new Vector2(-Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal"));
                Vector2 inputDir = input.normalized;
                

                // Walking animation trigger
                if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
                {
                    anim.SetBool("isWalking", true);
                    
                }
                else
                {
                    anim.SetBool("isWalking", false);
                    FindObjectOfType<audiomanager>().Play("Walking");
                }
               
          
                if (inputDir != Vector2.zero)
                {
                    float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;
                    transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
                }

                // Walking controller
                float targetSpeed = speed * inputDir.magnitude;
                currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

                transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);




                //warping controller
                if (reflexion.isActive && isFrontMirror)
                {
                    if (Input.GetKeyDown("space"))
                    {
                        StartCoroutine(Warping());
                        FindObjectOfType<audiomanager>().Play("Warp");
                    }
                }
                else if (reflexionChild.gameObject.activeSelf == true && Input.GetKeyDown("space"))
                {
                
                        FindObjectOfType<audiomanager>().Play("Error");
                   
                }
            }
        }
    }

    IEnumerator Warping()
    {
        currentSpeed = 0;
        transform.position = reflexion.transform.position;
        transform.rotation = reflexion.transform.rotation;
        anim.SetBool("isWarping", true);
        puff.Play();
        yield return new WaitForSeconds(0.9f);
        anim.SetBool("isWarping", false);     
    }

    IEnumerator StartWalk(Transform transform, Vector3 position, float timeToMove)
    {
       // FindObjectOfType<audiomanager>().P("Walking");
        Vector3 currentPos = transform.position;
        float t = 0f;

        anim.speed = 0.5f;
        anim.SetBool("isWalking", true);
        FindObjectOfType<audiomanager>().Play("Walking");

        while (t < 1)
        {

            t += Time.deltaTime / timeToMove;
            transform.position = Vector3.Lerp(currentPos, position, t);
            yield return null;
           
        }

        anim.SetBool("isWalking", false);
      
        anim.speed = 1f;
        isExiting = false;
        FindObjectOfType<audiomanager>().Pause("Walking");

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ColliderInFront")
        {
            isFrontMirror = true;
        }
    
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "ColliderInFront")
        {
            isFrontMirror = true;

        }
       
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "ColliderInFront")
        {
            isFrontMirror = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Torch")
        {
            FindObjectOfType<audiomanager>().Play("Torch");
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Torch")
        {
            FindObjectOfType<audiomanager>().Play("Torch");
        }
    }

}
