using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    public void Play1Pressed()
    {
        SceneManager.LoadScene("level1");
    }
    public void Play2Pressed()
    {
        SceneManager.LoadScene("level2");
    }
    public void Play3Pressed()
    {
        SceneManager.LoadScene("level3");
    }
    public void ExitPressed()
    {
        Application.Quit();
        Debug.Log("Exit pressed!");
    }
}
