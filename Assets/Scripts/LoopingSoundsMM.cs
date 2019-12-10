using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingSoundsMM : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<audiomanager>().Play("Rain");
        FindObjectOfType<audiomanager>().Play("Forest");
        FindObjectOfType<audiomanager>().Play("WindBlow");
    }
}
