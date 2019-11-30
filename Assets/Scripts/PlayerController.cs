using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float currentSpeed;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    GameObject reflexion;
    Reflexion reflexionChild;

    Rigidbody rb;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        reflexion = GameObject.FindGameObjectWithTag("Reflexion");
        reflexionChild = reflexion.gameObject.GetComponent<Reflexion>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

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
            if (reflexionChild.isActive)
            {
                if (Input.GetKeyDown("space"))
                {
                    StartCoroutine(Warping());
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
        yield return new WaitForSeconds(0.9f);
        anim.SetBool("isWarping", false);
        //rb.constraints = RigidbodyConstraints.
        
    }
}
