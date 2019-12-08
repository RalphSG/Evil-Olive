using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipL02 : MonoBehaviour
{
    public Text bubbleText;
    private bool helpOpen;

    public GameObject helpPanel;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartTooltip());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && helpOpen == false)
        {
            StartCoroutine(HelpTooltip());
        }
    }

    IEnumerator StartTooltip()
    {
        helpOpen = true;
        yield return new WaitForSeconds(2f);
        helpPanel.SetActive(true);
        bubbleText.text = "Well done, that room was a piece of cake to you!";
        yield return new WaitForSeconds(4f);
        bubbleText.text = "Uhm this room looks tougher, it got more than one mirror.";
        yield return new WaitForSeconds(4f);
        bubbleText.text = "By pressing tab you can select what mirror should be used for your powers.";
        yield return new WaitForSeconds(6f);
        bubbleText.text = "Oh and look it seems like the mirrors are mounted on a rotating mechanism.";
        yield return new WaitForSeconds(4f);
        bubbleText.text = "Use e to interact with the levers.";
        yield return new WaitForSeconds(6f);
        bubbleText.text = "Alright, you can do this! We are counting on you! If you need my help again just press h!";
        yield return new WaitForSeconds(6f);
        helpPanel.SetActive(false);
        helpOpen = false;
    }

    IEnumerator HelpTooltip()
    {
        helpOpen = true;
        helpPanel.SetActive(true);
        bubbleText.text = "If you want to change the mirror you are interacting with press tab.";
        yield return new WaitForSeconds(6f);
        bubbleText.text = "In order to rotate the mirror press e next to the corresponding lever.";
        yield return new WaitForSeconds(6f);
        bubbleText.text = "But be careful, your powers work only if you are reflected by the mirror so stay in front of it!";
        yield return new WaitForSeconds(6f);
        bubbleText.text = "If you need my help again just press h, but you did great until now it won't probably be necessary!";
        yield return new WaitForSeconds(6f);
        helpPanel.SetActive(false);
        helpOpen = false;
    }
}
