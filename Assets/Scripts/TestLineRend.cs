using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLineRend : MonoBehaviour
{
    public Transform playerTrans;
    public GameObject[] mirrors;
    public GameObject mirror;
    public int currentNumMirrors;
    public Transform mirrorTrans;

    public Transform reflexionTrans;
    private Vector3 lineStart;
    private Vector3 lineMiddle;
    private Vector3 lineEnd;
    public LineRenderer lineRendererPM;
    public LineRenderer lineRendererMR;
    public GameObject lineRendPMObject;
    public GameObject lineRendMRObject;
    public GameObject circleAnglePMObject;
    public GameObject circleAngleMRObject;

    Reflexion reflexion;
    GameObject reflexionChild;

    PlayerController playerCont;

    CapsuleCollider capsulePM;
    CapsuleCollider capsuleMR;

    private int segments;
    public float xRadius;
    public float zRadius;
    LineRenderer lineRendCirclePM;
    LineRenderer lineRendCircleMR;
    public GameObject circlePM;
    public GameObject circleMR;
    private bool isPM;


    // Start is called before the first frame update
    void Start()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        mirrors = GameObject.FindGameObjectsWithTag("Mirror");
        currentNumMirrors = 0;
        mirror = mirrors[currentNumMirrors];
        mirrorTrans = mirror.transform;


        reflexionTrans = GameObject.FindGameObjectWithTag("ReflexionChild").transform;
        circlePM = GameObject.FindGameObjectWithTag("CirclePM");
        lineRendCirclePM = circlePM.GetComponent<LineRenderer>();
        circleMR = GameObject.FindGameObjectWithTag("CircleMR");
        lineRendCircleMR = circleMR.GetComponent<LineRenderer>();

        circlePM.transform.position = new Vector3(mirror.transform.position.x, 2.3f, mirror.transform.position.z);
        circleMR.transform.position = new Vector3(mirror.transform.position.x, 2.3f, mirror.transform.position.z);

        reflexion = GameObject.FindGameObjectWithTag("Reflexion").GetComponent<Reflexion>();
        reflexionChild = GameObject.FindGameObjectWithTag("ReflexionChild");

        playerCont = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        lineRendererPM = GameObject.FindGameObjectWithTag("LinePM").GetComponent<LineRenderer>();
        lineRendererMR = GameObject.FindGameObjectWithTag("LineMR").GetComponent<LineRenderer>();
        lineRendPMObject = GameObject.FindGameObjectWithTag("LinePM");
        lineRendMRObject = GameObject.FindGameObjectWithTag("LineMR");
        circleAnglePMObject = GameObject.FindGameObjectWithTag("CirclePM");
        circleAngleMRObject = GameObject.FindGameObjectWithTag("CircleMR");

        // Create capsule colliders for each line
        capsulePM = GameObject.FindGameObjectWithTag("ColliderPM").GetComponent<CapsuleCollider>();
        capsulePM.isTrigger = true;
        capsulePM.radius = 0.5f;
        capsulePM.center = Vector3.zero;
        capsulePM.direction = 2; // Z-axis for easier "LookAt" orientation

        capsuleMR = GameObject.FindGameObjectWithTag("ColliderMR").GetComponent<CapsuleCollider>();
        capsuleMR.isTrigger = true;
        capsuleMR.radius = 0.5f;
        capsuleMR.center = Vector3.zero;
        capsuleMR.direction = 2; // Z-axis for easier "LookAt" orientation
    }

    // Update is called once per frame
    void Update()
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
            mirrorTrans = mirror.transform;
            circlePM.transform.position = new Vector3(mirror.transform.position.x, 2.3f, mirror.transform.position.z);
            circleMR.transform.position = new Vector3(mirror.transform.position.x, 2.3f, mirror.transform.position.z);
        }

        if (reflexion.isActive)
        {
            lineRendererPM.startColor = new Color(0, 0.8652894f, 1, 1);
            lineRendererPM.endColor = new Color(0, 0.8652894f, 1, 1);
            lineRendererMR.startColor = new Color(0, 0.8652894f, 1, 1);
            lineRendererMR.endColor = new Color(0, 0.8652894f, 1, 1);
        }
        else
        {
            lineRendererPM.startColor = new Color(0, 0.8652894f, 1, 0.1f);
            lineRendererPM.endColor = new Color(0, 0.8652894f, 1, 0.1f);
            lineRendererMR.startColor = new Color(0, 0.8652894f, 1, 0.1f);
            lineRendererMR.endColor = new Color(0, 0.8652894f, 1, 0.1f);
        }


        //if (!reflexionChild.isFrontMirror)
        //{
        //    lineRendererMR.isVisible = false;
        //}

        if (!playerCont.isFrontMirror)
        {
            lineRendMRObject.SetActive(false);
            lineRendPMObject.SetActive(false);
            circleAnglePMObject.SetActive(false);
            circleAngleMRObject.SetActive(false);
            reflexionChild.gameObject.SetActive(false);
        }
        else
        {
            lineRendMRObject.SetActive(true);
            lineRendPMObject.SetActive(true);
            circleAnglePMObject.SetActive(true);
            circleAngleMRObject.SetActive(true);
            reflexionChild.gameObject.SetActive(true);
        }


        lineStart = new Vector3(playerTrans.position.x, playerTrans.position.y + 2f, playerTrans.position.z);
        lineMiddle = new Vector3(mirrorTrans.position.x, 2.3f, mirrorTrans.position.z);
        lineEnd = new Vector3(reflexionTrans.position.x, reflexionTrans.position.y + 2f, reflexionTrans.position.z);

        lineRendererPM.SetPosition(0, lineStart);
        lineRendererPM.SetPosition(1, lineMiddle);
        lineRendererMR.SetPosition(0, lineMiddle);
        lineRendererMR.SetPosition(1, lineEnd);

        //Collider location update
        capsulePM.transform.position = lineStart + (lineMiddle - lineStart) / 2;
        capsulePM.transform.LookAt(lineStart);
        capsulePM.height = (lineMiddle - lineStart).magnitude;

        capsuleMR.transform.position = lineMiddle + (lineEnd - lineMiddle) / 2;
        capsuleMR.transform.LookAt(lineMiddle);
        capsuleMR.height = (lineEnd - lineMiddle).magnitude;

        // Circle for angle display Player-Mirror
        segments = reflexion.angleInci;
        lineRendCirclePM.positionCount = (segments + 1);
        lineRendCirclePM.useWorldSpace = false;

        isPM = true;
        CreatePoints();

        circlePM.transform.localEulerAngles = new Vector3(gameObject.transform.localEulerAngles.x, mirror.transform.localEulerAngles.y - 180f, gameObject.transform.localEulerAngles.z);

        // Circle for angle display Mirror-Reflexion
        lineRendCircleMR.positionCount = (segments + 1);
        lineRendCircleMR.useWorldSpace = false;

        isPM = false;
        CreatePoints();

        circleMR.transform.localEulerAngles = new Vector3(gameObject.transform.localEulerAngles.x, mirror.transform.localEulerAngles.y - 180f, gameObject.transform.localEulerAngles.z);
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

            if (isPM)
            {
                lineRendCirclePM.SetPosition(i, new Vector3(x, y, z));
                angle += 1f;
            }
            else
            {
                lineRendCircleMR.SetPosition(i, new Vector3(x, y, z));
                angle -= 1f;
            }
        }
    }

}
