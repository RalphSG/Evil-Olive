using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRendererPM : MonoBehaviour
{
    private int segments;
    public float xRadius;
    public float zRadius;
    LineRenderer lineRend;

    GameObject reflexion;
    Reflexion reflexionChild;

    GameObject mirror;

    void Start()
    {
        lineRend = gameObject.GetComponent<LineRenderer>();

        reflexion = GameObject.FindGameObjectWithTag("Reflexion");
        reflexionChild = reflexion.gameObject.GetComponent<Reflexion>();

        mirror = GameObject.FindGameObjectWithTag("Mirror");

        gameObject.transform.position = new Vector3(mirror.transform.position.x, 2.3f, mirror.transform.position.z);
    }

    private void Update()
    {
        segments = reflexionChild.angleInci;
        lineRend.positionCount = (segments + 1);
        lineRend.useWorldSpace = false;

        CreatePoints();
    }


    void CreatePoints()
    {
        float x;
        float y = 0f;
        float z;

        float angle = 214f; // 214 = 180 + 34 (for the static mirror)

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * xRadius;
            z = Mathf.Cos(Mathf.Deg2Rad * angle) * zRadius;

            lineRend.SetPosition(i, new Vector3(x, y, z));

            angle += 1f;
        }
    }
}
