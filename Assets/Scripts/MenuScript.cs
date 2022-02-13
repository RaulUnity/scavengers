using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void MainMenu(int scene)
    {
        StartCoroutine(waitForScene(scene));
    }

    public void ControlsMenu(int scene)
    {
        StartCoroutine(waitForScene(scene));
    }

    public void StartMenu(int scene)
    {
        StartCoroutine(waitForScene(scene));
    }

    public void ExitMenu()
    {
        Application.Quit();
    }

    IEnumerator waitForScene(int scene)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);
    }

    IEnumerator waitForExit()
    {
        yield return new WaitForSeconds(1);
        Application.Quit();
    }
}
