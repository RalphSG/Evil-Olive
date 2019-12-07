using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsTextAndLine : MonoBehaviour
{
    public ParticleSystem puffPS;
    public LineRenderer lineRend;

    float colorPourcent;


    // Start is called before the first frame update
    void Start()
    {
        puffPS = GameObject.FindGameObjectWithTag("Puff").GetComponent<ParticleSystem>();
        lineRend = GameObject.FindGameObjectWithTag("LineMR").GetComponent<LineRenderer>();
        StartCoroutine("puff");
    }

    IEnumerator puff()
    {
        yield return new WaitForSeconds(1.95f);
        puffPS.Play();
        for (float i = 100; i > 0; i--)
        {
            Debug.Log(i);
            colorPourcent = i / 100;
            Debug.Log(colorPourcent);
            lineRend.endColor = new Color(0, 0.8666667f, 1, colorPourcent);
            colorPourcent = colorPourcent / 2;
            lineRend.startColor = new Color(0, 0.8666667f, 1, colorPourcent);
            yield return new WaitForSeconds(0.00005f);

        }
    }
}
