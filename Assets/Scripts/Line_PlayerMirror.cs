using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line_PlayerMirror : MonoBehaviour
{
    public Transform origin;
    public Transform target;
    public LineRenderer lineRenderer;
    public Camera mainCamera;
    public MeshCollider meshCollider;
     
    GameObject reflexion;
    Reflexion reflexionChild;
   

    // Start is called before the first frame update
    void Start()
    {
        
        reflexion = GameObject.FindGameObjectWithTag("Reflexion");
        reflexionChild = reflexion.gameObject.GetComponent<Reflexion>();

        mainCamera = Camera.main;

        LineRenderer lineRenderer = this.lineRenderer.GetComponent<LineRenderer>();
        MeshCollider meshCollider = this.lineRenderer.GetComponent<MeshCollider>();

        Mesh mesh = new Mesh();
        lineRenderer.BakeMesh(mesh, mainCamera, true);
        meshCollider.sharedMesh = mesh;
        meshCollider.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (reflexionChild.isActive )
        {
            lineRenderer.startColor = new Color(0, 0.8652894f, 1, 1);
            lineRenderer.endColor = new Color(0, 0.8652894f, 1, 1);
        }
        else
        {
            lineRenderer.startColor = new Color(0, 0.8652894f, 1, 0.1f);
            lineRenderer.endColor = new Color(0, 0.8652894f, 1, 0.1f);
        }

        lineRenderer.SetPosition(0, origin.position);
        lineRenderer.SetPosition(1, target.position);

        

      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            reflexionChild.isActive = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            reflexionChild.isActive = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            reflexionChild.isActive = false;
        }
    }
}
