using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Mirror : MonoBehaviour
{
    public float speed = 3f;
    public GameObject rmirror;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(0, 0, speed);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(0, 0, speed);
            }
        }
    }
}
