using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleNumber : MonoBehaviour
{
    private TextMesh angleText;
    private int angleNumber;

    GameObject reflexion;
    Reflexion reflexionChild;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localEulerAngles = new Vector3(0, 180, 0);
        angleText = gameObject.GetComponent<TextMesh>();

        reflexion = GameObject.FindGameObjectWithTag("Reflexion");
        reflexionChild = reflexion.gameObject.GetComponent<Reflexion>();
    }

    // Update is called once per frame
    void Update()
    {
        angleNumber = reflexionChild.angleInci;
        angleText.text = angleNumber.ToString();
    }
}
