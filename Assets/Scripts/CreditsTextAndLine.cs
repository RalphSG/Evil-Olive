using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsTextAndLine : MonoBehaviour
{
    public string sceneName;

    public ParticleSystem puffPS;
    public LineRenderer lineRend;

    float colorPourcent;

    public float timeBeforeTrans;

    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        puffPS = GameObject.FindGameObjectWithTag("Puff").GetComponent<ParticleSystem>();
        lineRend = GameObject.FindGameObjectWithTag("LineMR").GetComponent<LineRenderer>();
        anim = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<Animator>();
        StartCoroutine("puff");
    }

    IEnumerator puff()
    {
        FindObjectOfType<audiomanager>().Play("Walking");
        yield return new WaitForSeconds(1.95f);
        FindObjectOfType<audiomanager>().Pause("Walking");
        FindObjectOfType<audiomanager>().Play("Warp");
        puffPS.Play();
        int steps = 5;
        for (float i = 100; i > 0; i= i-steps)
        {
            colorPourcent = i / 100;
            if (i <= steps)
            {
                colorPourcent = 0;
            }
            //Debug.Log(i);
            //Debug.Log(colorPourcent);
            lineRend.endColor = new Color(0, 0.8666667f, 1, colorPourcent);
            colorPourcent = colorPourcent / 2;
            lineRend.startColor = new Color(0, 0.8666667f, 1, colorPourcent);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(timeBeforeTrans);
        StartCoroutine(LoadNextScene());
    }

    IEnumerator LoadNextScene()
    {
        anim.SetTrigger("end");
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene(sceneName);
    }
}
