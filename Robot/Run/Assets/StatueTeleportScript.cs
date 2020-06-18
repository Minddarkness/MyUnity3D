using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatueTeleportScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (SceneManager.GetActiveScene().name == "level1")
            {
                SceneManager.LoadScene("level2");
            }
            else if (SceneManager.GetActiveScene().name == "level2")
            {
                SceneManager.LoadScene("level3");
            }
            else if (SceneManager.GetActiveScene().name == "level3")
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }

}