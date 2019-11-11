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


    Rigidbody rb;
    Animator anim;
    BoxCollider colSize;

    private Vector3 moveDirection = Vector3.zero;
    public float maxTurnSpeed = 200f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        colSize = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update() {


        Vector2 input = new Vector2(-Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal"));
        Vector2 inputDir = input.normalized;

        if (inputDir != Vector2.zero) {
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
        }

        float targetSpeed = speed * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        transform.Translate (transform.forward * currentSpeed * Time.deltaTime, Space.World);

        //float moveVertical = Input.GetAxis("Vertical");
        //float moveHorizontal = Input.GetAxis("Horizontal");

        //Vector3 newPosition = new Vector3(-moveVertical, 0.0f, moveHorizontal);
        //transform.LookAt(newPosition + transform.position);
        //transform.Translate(newPosition * speed * Time.deltaTime, Space.World);


    }
}
