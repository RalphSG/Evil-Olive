using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflexionUnactive : MonoBehaviour
{
    Reflexion reflexion;
    GameObject reflexionChild;

    // Start is called before the first frame update
    void Start()
    {
        reflexion = GameObject.FindGameObjectWithTag("Reflexion").GetComponent<Reflexion>(); ;
        reflexionChild = GameObject.FindGameObjectWithTag("ReflexionChild");
    }

    //private void Update()
    //{
    //    reflexionChild.gameObject.SetActive(true);
    //    reflexion.isActive = true;
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            reflexionChild.gameObject.SetActive(false);
            reflexion.isActive = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Wall")
        {
            reflexionChild.gameObject.SetActive(false);
            reflexion.isActive = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wall")
        {
            reflexionChild.gameObject.SetActive(true);
            reflexion.isActive = true;
        }
    }
}
