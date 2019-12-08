﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleScript : MonoBehaviour
{
    private float rotSpeedHandle;
    public bool position;
   
    public int mirrorAngle;

    public GameObject mirror;

    void Start()
    {
        rotSpeedHandle = 1500f;
        position = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if ((position == false) & (other.tag == "Player") & (Input.GetKeyDown(KeyCode.E)))
        {
            transform.Rotate(0.0f, 0.0f, -rotSpeedHandle * Time.deltaTime);
            position = true;
            
            StartCoroutine(RotationMirror(mirror));

        }
        else if ((position == true) & (other.tag == "Player") & (Input.GetKeyDown(KeyCode.E)) )
        {
            transform.Rotate(0.0f, 0.0f, rotSpeedHandle * Time.deltaTime);
            position = false;
            
            StartCoroutine(RotationMirror2( mirror));
        }
    }
  
    IEnumerator RotationMirror( GameObject target)
    {
            for (int i = 0; i < mirrorAngle; i++)
            {
                target.transform.Rotate(0.0f, 1f, 0f, Space.Self);
                yield return new WaitForSeconds(0.01f);
            }                   
    }

    IEnumerator RotationMirror2( GameObject target)
    {
        for (int i = 0; i < mirrorAngle; i++)
        {
            target.transform.Rotate(0.0f, -1f, 0f, Space.Self);
            yield return new WaitForSeconds(0.01f);
        }
    }

}

