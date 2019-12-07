using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLineRend : MonoBehaviour
{
    public Transform playerTrans;
    public Transform mirrorTrans;
    public Transform reflexionTrans;
    private Vector3 lineStart;
    private Vector3 lineMiddle;
    private Vector3 lineEnd;
    public LineRenderer lineRendererPM;
    public LineRenderer lineRendererMR;
    public GameObject lineRendPMObject;
    public GameObject lineRendMRObject;

    GameObject reflexion;
    Reflexion reflexionChild;

    CapsuleCollider capsulePM;
    CapsuleCollider capsuleMR;


    // Start is called before the first frame update
    void Start()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        mirrorTrans = GameObject.FindGameObjectWithTag("Mirror").transform;
        reflexionTrans = GameObject.FindGameObjectWithTag("ReflexionChild").transform;

        reflexion = GameObject.FindGameObjectWithTag("Reflexion");
        reflexionChild = reflexion.gameObject.GetComponent<Reflexion>();

        lineRendererPM = GameObject.FindGameObjectWithTag("LinePM").GetComponent<LineRenderer>();
        lineRendererMR = GameObject.FindGameObjectWithTag("LineMR").GetComponent<LineRenderer>();

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
        if (reflexionChild.isActive)
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

        lineStart = new Vector3(playerTrans.position.x, playerTrans.position.y + 2f, playerTrans.position.z);
        lineMiddle = new Vector3(mirrorTrans.position.x, mirrorTrans.position.y + 2f, mirrorTrans.position.z);
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

    }

}
