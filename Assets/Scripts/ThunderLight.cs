using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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

    public ParticleSystem lightning1;
    public ParticleSystem lightning2;
    public ParticleSystem lightning3;
    public ParticleSystem lightning4;
    public ParticleSystem lightning5;
    private int randPSInit;

    public void Start()
    {
        StartCoroutine(initiateLightning());
        

    }

    IEnumerator initiateLightning()
    {
       
        while (true)
        {
            
            randInitiation = Random.Range(1, 4);
            switch (randInitiation)
            {
                case 1:
                    StartCoroutine(lightningFlickering1());
                    

                    break;
                case 2:
                    StartCoroutine(lightningFlickering2());
                    

                    break;
                case 3:
                    StartCoroutine(lightningFlickering3());
                    

                    break;
                default:
                    break;
            }
            randInitiation = Random.Range(0, 6);
            
            yield return new WaitForSeconds(randInitiation);
        }
    }

    IEnumerator lightningFlickering1()
    {
        lightning3.Play();
        

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
        
        lightning3.Stop();
    }

    IEnumerator lightningFlickering2()
    {
        
        randlight2 = Random.Range(15, 20);
        for (int i = 0; i < randlight2; i++)
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
        randPSInit = Random.Range(1, 5);
        
        switch (randPSInit)
        {
            case 1:
                lightning1.Play();
                break;
            case 2:
                lightning2.Play();
                break;
            case 3:
                lightning4.Play();
                break;
            case 4:
                lightning5.Play();
                break;
            default:
                Debug.Log(randPSInit);
                break;
        }
        randlight3 = Random.Range(15, 20);
        for (int i = 0; i < randlight3; i++)
        {
            randPourcent = Random.Range(0, 100);
            globalLight3.intensity = ((maxGlobalFlickerInt - minGlobalFlickerInt) * randPourcent * 0.01f) + minGlobalFlickerInt;
            light3.intensity = ((maxFlickerIntensity - minFlickerIntensity) * randPourcent * 0.01f) + minFlickerIntensity;
            yield return new WaitForSeconds(flickerSpeed);
        }
        light3.intensity = 0;
        globalLight3.intensity = 0;
        
        lightning1.Stop();
        lightning2.Stop();
        lightning4.Stop();
        lightning5.Stop();
    }
}
