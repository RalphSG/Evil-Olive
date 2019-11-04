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

        var z = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        var x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.Translate(x, 0, -z);
    }
}
