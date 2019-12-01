using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutSkirtColliders : MonoBehaviour
{
    Collider coll;

    void Start()
    {
        coll = GetComponent<Collider>();
        coll.enabled = false;
        StartCoroutine(ActivateColliders());
    }

    IEnumerator ActivateColliders()
    {
        yield return new WaitForSeconds(1.3f);
        coll.enabled = true;
    }

}
