using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulatePS : MonoBehaviour
{
    private ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        ps = gameObject.GetComponent<ParticleSystem>();
        ps.Simulate(2f);
        ps.Play();
    }
}
