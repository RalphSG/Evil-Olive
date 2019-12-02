using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderLightningLevels : MonoBehaviour
{
    public float minFlickerIntensity = 4f;
    public float maxFlickerIntensity = 7f;
    public float idleItensity = 2f;
    public float flickerSpeed = 0.035f;

    private int randlight = 0;
    private int randInitiation = 0;
    private int randPourcent = 0;

    public Light light1;
    public Light light2;
    public Light light3;
    public Light light4;
    public Light light5;

    public void Start()
    {
        StartCoroutine("initiateLightning");
    }

    IEnumerator initiateLightning()
    {
        while (true)
        {
            randInitiation = Random.Range(0, 10);
            yield return new WaitForSeconds(randInitiation);
            StartCoroutine("lightningFlickering");
        }
    }

    IEnumerator lightningFlickering()
    {
        randlight = Random.Range(20, 30);
        for (int i = 0; i < randlight; i++)
        {
            randPourcent = Random.Range(0, 100);
            float intensity = ((maxFlickerIntensity - minFlickerIntensity) * randPourcent * 0.01f) + minFlickerIntensity;
            light1.intensity = intensity;
            light2.intensity = intensity;
            light3.intensity = intensity;
            light4.intensity = intensity;
            light5.intensity = intensity;
            yield return new WaitForSeconds(flickerSpeed);
        }
        light1.intensity = idleItensity;
        light2.intensity = idleItensity;
        light3.intensity = idleItensity;
        light4.intensity = idleItensity;
        light5.intensity = idleItensity;
    }
}
