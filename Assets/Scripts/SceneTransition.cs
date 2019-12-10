using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator transitionAnim;
    public string sceneName1;
    public string sceneName2;

    public void LoadNextScene()
    {
        StartCoroutine(LoadScene1());
    }

    IEnumerator LoadScene1()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            yield return new WaitForSeconds(2.5f);
        }
        SceneManager.LoadScene(sceneName1);
    }

    public void LoadMenu()
    {
        StartCoroutine(LoadScene2());
    }

    IEnumerator LoadScene2()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName2);
    }

    public void Quit()
    {
        StartCoroutine(QuitGame());
    }

    IEnumerator QuitGame()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        Application.Quit();
    }
}
