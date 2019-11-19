using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator transitionAnim;
    public string sceneName1;

    public void NewGame()
    {
        StartCoroutine(LoadScene1());
    }

    IEnumerator LoadScene1()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName1);
    }

    public void Quit()
    {
        StartCoroutine(LoadScene4());
    }

    IEnumerator LoadScene4()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        Application.Quit();
    }
}
