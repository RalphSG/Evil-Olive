using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleScript : MonoBehaviour
{
    public GameObject other;
    public float rotspeed = 800f;
    public bool position;
   
    public float smoothing = 30f;
    
    [SerializeField] public GameObject mirror;
    private Vector3 zAngle;

    void Start()
    {
       position = false;
        
    }

    private void OnTriggerStay(Collider other)
    {
        if ((position == false) & (other.tag == "Player") & (Input.GetKey(KeyCode.E)))
        {
            transform.Rotate(0.0f, 0.0f, -rotspeed * Time.deltaTime);
            position = true;
            
            StartCoroutine(RotationMirror(mirror));

        }
        else if ((position == true) & (other.tag == "Player") & (Input.GetKey(KeyCode.E)) )
        {
            transform.Rotate(0.0f, 0.0f, rotspeed * Time.deltaTime);
            position = false;
            
            StartCoroutine(RotationMirror2( mirror));
        }
    }
  
    IEnumerator RotationMirror( GameObject target)
    {
        if (position == true)
        {
            target.transform.Rotate(0.0f,0.0f,smoothing*Time.deltaTime);
            yield return null;
            
        }
       
    }
    IEnumerator RotationMirror2( GameObject target)
    {
        if (position == false)
        {
            target.transform.Rotate(0.0f, 0.0f, -smoothing * Time.deltaTime);
            yield return null;
        }

    }

}

