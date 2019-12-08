using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRendererMR : MonoBehaviour
{
    private int segments;
    public float xRadius;
    public float zRadius;
    LineRenderer lineRendCircleMR;

    GameObject reflexion;
    Reflexion reflexionChild;

    public GameObject[] mirrors;
    public GameObject mirror;
    public int currentNumMirrors;

    void Start()
    {
        lineRendCircleMR = gameObject.GetComponent<LineRenderer>();

        reflexion = GameObject.FindGameObjectWithTag("Reflexion");
        reflexionChild = reflexion.gameObject.GetComponent<Reflexion>();

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

        segments = reflexionChild.angleInci;
        lineRendCircleMR.positionCount = (segments + 1);
        lineRendCircleMR.useWorldSpace = false;

        CreatePoints();

        gameObject.transform.localEulerAngles = new Vector3(gameObject.transform.localEulerAngles.x, mirror.transform.localEulerAngles.y - 180f, gameObject.transform.localEulerAngles.z);
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

            lineRendCircleMR.SetPosition(i, new Vector3(x, y, z));

            angle -= 1f;
        }
    }
}
