using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirelightFlickering : MonoBehaviour
{
    public float minFlickerIntensity = 1.5f;
    public float maxFlickerIntensity = 2.5f;
    public float flickerSpeed = 0.035f;
 
    private int randomizer = 0;

    private Light light;

    public void Start()
    {
        light = GetComponent<Light>();
        StartCoroutine("lightFlickering");
    }

    IEnumerator lightFlickering() {
        while (true)
        {
            if (randomizer == 0)
            {
                light.intensity = (Random.Range(minFlickerIntensity, maxFlickerIntensity));

            }
            else light.intensity = (Random.Range(minFlickerIntensity, maxFlickerIntensity));

            randomizer = Random.Range(0, 1);
            yield return new WaitForSeconds(flickerSpeed);
        }
    }
}
