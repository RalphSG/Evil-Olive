using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    public BoxCollider collid;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.LookAt(Camera.main.transform);
    }

    private void Update()
    {
        if (collid.enabled)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
