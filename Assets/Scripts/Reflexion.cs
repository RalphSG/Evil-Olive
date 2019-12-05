using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflexion : MonoBehaviour
{
    public float speed;

    public GameObject player;
    public float playerX;
    public float playerZ;

    public Renderer materialColor;
    Color reflexionOn = new Color(0f, 0.7230554f, 1f, 0f);
    Color reflexionOff = new Color(0f, 0.624114f, 1f, 0f);

    public GameObject mirror;
    public float mirrorX;
    public float mirrorZ;
    public float mirrorRot;

    public float multiplier;
    public float targetX;
    public float targetZ;
    private Vector3 targetPos;

    // Constant describing the mirror line (as in aMirror*x + bMirror = z)
    // aMirror => Mathf.Tan(Mathf.Deg2Rad*(45-(mirrorRot)))
    public float bMirror;

    // Constant describing the normal to the mirror line (aNormal * x + bNormal = z)
    public float aNormal;
    public float bNormal;

    public float anglePM;

    // Distance Player-Mirror, Player-Reflection and angle of insidence
    public float lengthPM;
    public float lengthPR;
    public int angleInci;

    public bool isActive;
    public bool isFrontMirror;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        speed = 5000f;
        mirror = GameObject.FindGameObjectWithTag("Mirror");
        mirrorX = mirror.transform.position.x;
        mirrorZ = mirror.transform.position.z;

        isActive = true;
    }

    void Update()
    {
        // Movement of reflexion
        playerX = player.transform.position.x;
        playerZ = player.transform.position.z;
        mirrorRot = mirror.transform.localEulerAngles.y;

        // Find all the variables of the equation ax+b=z describing the line following the mirror
        bMirror = mirrorZ - (Mathf.Tan(Mathf.Deg2Rad * (146 - mirrorRot)) * mirrorX);

        // Find all the variables of the equation ax+b=z describing the line normal to the mirror
        aNormal = -1 / (Mathf.Tan(Mathf.Deg2Rad * (146 -mirrorRot)));
        bNormal = mirrorZ - (aNormal * mirrorX);

        multiplier = (-2 * ((aNormal) * playerX - playerZ + bNormal))/(Mathf.Pow((aNormal), 2) + 1);
        targetX = multiplier * (aNormal) + playerX;
        targetZ = - multiplier + playerZ;

        targetPos = new Vector3 (targetX, gameObject.transform.position.y, targetZ);

        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        // Find distance Player-Mirror and Mirror-Reflection in order to find the angle of incidence
        lengthPM = Mathf.Sqrt(Mathf.Pow(playerX - mirrorX, 2) + Mathf.Pow(playerZ - mirrorZ, 2));
        lengthPR = Mathf.Sqrt(Mathf.Pow(playerX - targetX, 2) + Mathf.Pow(playerZ - targetZ, 2));
        angleInci = Mathf.RoundToInt(Mathf.Rad2Deg*(Mathf.Asin(((Mathf.Deg2Rad*lengthPR) / 2) / (Mathf.Deg2Rad*lengthPM))));

        // Is the player behind the mirror or in front (in order to block warping if behind)
        anglePM = Mathf.Rad2Deg * (Mathf.Atan((mirrorZ - playerZ) / (mirrorX - playerX)));
        if (playerX < mirrorX)
        {
            if (((anglePM - 179f) < (146 - mirrorRot)) && ((146 - mirrorRot) < (anglePM - 1)))
            {
                isFrontMirror = true;
            }
            else {
                isFrontMirror = false;
            }
        }
        if (mirrorX <= playerX)
        {
            if (((anglePM + 179f) > (146 - mirrorRot)) && ((146 - mirrorRot) > (anglePM - 1)))
            {
                isFrontMirror = true;
            }
            else
            {
                isFrontMirror = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (Transform child in transform)
        {
            //child.gameObject.SetActive(false);
            materialColor = child.gameObject.GetComponent<Renderer>();
            materialColor.material.SetColor("_EmissionColor", reflexionOff);
        }

        isActive = false;
    }
    private void OnTriggerStay(Collider other)
    {
        foreach (Transform child in transform)
        {
            //child.gameObject.SetActive(false);
            materialColor = child.gameObject.GetComponent<Renderer>();
            materialColor.material.SetColor("_EmissionColor", reflexionOff);
        }

        isActive = false;
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (Transform child in transform)
        {
            //child.gameObject.SetActive(true);
            materialColor = child.gameObject.GetComponent<Renderer>();
            materialColor.material.SetColor("_EmissionColor", reflexionOn);
        }

        isActive = true;
    }
}
