using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float rotSpeed;
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


        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 newPosition = new Vector3(-moveVertical, 0.0f, moveHorizontal);
        transform.LookAt(newPosition + transform.position);
        transform.Translate(newPosition * speed * Time.deltaTime, Space.World);


    }
}
