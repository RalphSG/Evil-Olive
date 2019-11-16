using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderLight : MonoBehaviour
{
    public float minFlickerIntensity = 1f;
    public float maxFlickerIntensity = 30f;
    public float minGlobalFlickerInt = 0.2f;
    public float maxGlobalFlickerInt = 5f;
    public float flickerSpeed = 0.035f;

    private int randlight1 = 0;
    private int randlight2 = 0;
    private int randlight3 = 0;
    private int randInitiation = 0;
    private int randPourcent = 0;

    public Light light1;
    public Light light2;
    public Light light3;
    public Light globalLight1;
    public Light globalLight2;
    public Light globalLight3;

    public void Start()
    {
        StartCoroutine("initiateLightning");
    }

    IEnumerator initiateLightning()
    {
        while (true)
        {
            StartCoroutine("lightningFlickering1");
            randInitiation = Random.Range(0, 2);
            yield return new WaitForSeconds(randInitiation);
            StartCoroutine("lightningFlickering2");
            randInitiation = Random.Range(0, 2);
            yield return new WaitForSeconds(randInitiation);
            StartCoroutine("lightningFlickering3");
            randInitiation = Random.Range(0, 4);
            yield return new WaitForSeconds(randInitiation);
        }
    }

    IEnumerator lightningFlickering1()
    {
        randlight1 = Random.Range(15,20);
        for (int i = 0; i < randlight1; i++)
        {
            randPourcent = Random.Range(0, 100);
            globalLight1.intensity = ((maxGlobalFlickerInt - minGlobalFlickerInt) * randPourcent * 0.01f) + minGlobalFlickerInt;
            light1.intensity = ((maxFlickerIntensity - minFlickerIntensity) * randPourcent * 0.01f) + minFlickerIntensity;
            yield return new WaitForSeconds(flickerSpeed);
        }
        light1.intensity = 0;
        globalLight1.intensity = 0;
    }

    IEnumerator lightningFlickering2()
    {
        randlight2 = Random.Range(15, 20);
        for (int i = 0; i < randlight1; i++)
        {
            randPourcent = Random.Range(0, 100);
            globalLight2.intensity = ((maxGlobalFlickerInt - minGlobalFlickerInt) * randPourcent * 0.01f) + minGlobalFlickerInt;
            light2.intensity = ((maxFlickerIntensity - minFlickerIntensity) * randPourcent * 0.01f) + minFlickerIntensity;
            yield return new WaitForSeconds(flickerSpeed);
        }
        light2.intensity = 0;
        globalLight2.intensity = 0;
    }

    IEnumerator lightningFlickering3()
    {
        randlight3 = Random.Range(15, 20);
        for (int i = 0; i < randlight1; i++)
        {
            randPourcent = Random.Range(0, 100);
            globalLight3.intensity = ((maxGlobalFlickerInt - minGlobalFlickerInt) * randPourcent * 0.01f) + minGlobalFlickerInt;
            light3.intensity = ((maxFlickerIntensity - minFlickerIntensity) * randPourcent * 0.01f) + minFlickerIntensity;
            yield return new WaitForSeconds(flickerSpeed);
        }
        light3.intensity = 0;
        globalLight3.intensity = 0;
    }
}
