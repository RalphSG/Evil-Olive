using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRendererPM : MonoBehaviour
{
    private int segmentsPM;
    public float xRadius;
    public float zRadius;
    LineRenderer lineRendPM;

    Reflexion reflexion;

    public GameObject[] mirrors;
    public GameObject mirror;
    public int currentNumMirrors;

    void Start()
    {
        lineRendPM = GameObject.FindGameObjectWithTag("CirclePM").GetComponent<LineRenderer>();

        reflexion = GameObject.FindGameObjectWithTag("Reflexion").GetComponent<Reflexion>();

        mirrors = GameObject.FindGameObjectsWithTag("Mirror");
        currentNumMirrors = 0;
        mirror = mirrors[currentNumMirrors];

        gameObject.transform.position = new Vector3(mirror.transform.position.x, 2.3f, mirror.transform.position.z);
    }

    private void Update()
    {
        // Selection of the used mirror
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            currentNumMirrors++;
            if (currentNumMirrors == mirrors.Length)
            {
                currentNumMirrors = 0;
            }

            mirror = mirrors[currentNumMirrors];

            gameObject.transform.position = new Vector3(mirror.transform.position.x, 2.3f, mirror.transform.position.z);
        }

        segmentsPM = reflexion.angleInci;
        lineRendPM.positionCount = (segmentsPM + 1);
        lineRendPM.useWorldSpace = false;

        CreatePoints();

        gameObject.transform.localEulerAngles = new Vector3(gameObject.transform.localEulerAngles.x, mirror.transform.localEulerAngles.y - 180f, gameObject.transform.localEulerAngles.z);
    }


    void CreatePoints()
    {
        float x;
        float y = 0f;
        float z;

        float angle = 214f; // 214 = 180 + 34 (for the static mirror)

        for (int i = 0; i < (segmentsPM + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * xRadius;
            z = Mathf.Cos(Mathf.Deg2Rad * angle) * zRadius;

            lineRendPM.SetPosition(i, new Vector3(x, y, z));

            angle += 1f;
        }
    }
}
