using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line_Graph : MonoBehaviour
{
    public Transform origin;
    public Transform target;
    public LineRenderer lineRenderer;

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, origin.position);
        lineRenderer.SetPosition(1, target.position);
    }
}

