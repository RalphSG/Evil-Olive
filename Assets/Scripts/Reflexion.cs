using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflexion : MonoBehaviour
{
    public float speed;

    public GameObject player;
    public float playerX;
    public float playerZ;

    public GameObject mirror;
    public float mirrorX;
    public float mirrorZ;
    public float mirrorRot;

    public float multiplier;
    public float targetX;
    public float targetZ;
    private Vector3 targetPos;

    //constant describing the mirror line (as in aMirror*x + bMirror = z)
    //aMirror => Mathf.Tan(Mathf.Deg2Rad*(45-(mirrorRot)))
    public float bMirror;

    //constant describing the normal to the mirror line (aNormal * x + bNormal = z)
    public float aNormal;
    public float bNormal;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        speed = 500f;
        mirror = GameObject.FindGameObjectWithTag("Mirror");
        mirrorX = mirror.transform.position.x;
        mirrorZ = mirror.transform.position.z;
    }

    void Update()
    {
        playerX = player.transform.position.x;
        playerZ = player.transform.position.z;
        mirrorRot = mirror.transform.localEulerAngles.y;

        bMirror = mirrorZ - (Mathf.Tan(Mathf.Deg2Rad * (135 - mirrorRot)) * mirrorX);

        aNormal = -1 / (Mathf.Tan(Mathf.Deg2Rad * (135 - mirrorRot)));

        bNormal = mirrorZ - (aNormal * mirrorX);

        multiplier = (-2 * ((aNormal) * playerX - playerZ + bNormal))/(Mathf.Pow((aNormal), 2) + 1);
        targetX = multiplier * (aNormal) + playerX;
        targetZ = - multiplier + playerZ;

        targetPos = new Vector3 (targetX, gameObject.transform.position.y, targetZ);

        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
}
