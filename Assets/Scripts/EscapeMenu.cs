using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscapeMenu : MonoBehaviour
{
    public static bool isPaused = false;

    private Color escapePanelColor;

    //public GameObject mouseCursor;

    public GameObject pausePanel;

    // Use this for initialization
    void Start()
    {
        escapePanelColor = GetComponent<Image>().color;
        escapePanelColor.a = 0f;
        gameObject.GetComponent<Image>().color = escapePanelColor;
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
            //mouseCursor.SetActive(isPaused);
            //Cursor.visible = false;
        }
    }

    public void Resume()
    {
        isPaused = false;
        pausePanel.SetActive(isPaused);
        escapePanelColor.a = 0f;
        gameObject.GetComponent<Image>().color = escapePanelColor;
        Time.timeScale = 1f;
    }

    void Pause()
    {
        isPaused = true;
        pausePanel.SetActive(isPaused);
        escapePanelColor.a = 0.59f;
        gameObject.GetComponent<Image>().color = escapePanelColor;
        Time.timeScale = 0f;
    }
}
