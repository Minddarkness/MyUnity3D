using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public UnityEngine.UI.Text scoreLabel;
    public UnityEngine.UI.Text looser;
    public UnityEngine.UI.Text instruction;
    //public UnityEngine.UI.Image menu;
    //public UnityEngine.UI.Button startButton;
    // public GameObject ship;

    int score = 0;

  //  public bool isStarted = false;
    public bool isAlive = true;
    public bool isWin = false;
    public bool stay = false;

    public static GameController instance;

    public void incrementScore(int increment)
    {
        score += increment;
        scoreLabel.text = "Счёт: " + score;
    }
    public void resetScore( )
    {
        score = 0;
        scoreLabel.text = "Счёт: " + score;
    }
    // Start is called before the first frame update

    void Start()
    {
        instance = this;
        /*
        startButton.onClick.AddListener(delegate
        {
            menu.gameObject.SetActive(false);
            isStarted = true;
            isAlive = true;
        });*/
        if (SceneManager.GetActiveScene().name == "level3")
        {
            instance.stay = true;
            ///scoreLabel.text = "Жизни: ";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Cancel"))
        {
            SceneManager.LoadScene("Menu");
        }
        if (Input.GetButton("Submit")&& isWin)
        {
            if (SceneManager.GetActiveScene().name == "level1")
            {
                SceneManager.LoadScene("level2");
            }
            else if (SceneManager.GetActiveScene().name == "level2")
            {
                SceneManager.LoadScene("level3");
            }

        }
        if (!isAlive)
        {
            looser.text = "ПОБЕДА!!! но не ваша. Для выхода в меню нажмите клавишу 'esc'";
        }
        if (isWin)
        {
            //looser.text = "ПОБЕДА!";
            instruction.color = Color.black;
            if (SceneManager.GetActiveScene().name == "level3")
            {
                instruction.text = " Ты повелитель галактик! Чтобы пойти отмечать, нажми клавишу 'esc'";
                return;
            }
            instruction.text = " ПОБЕДА! Чтобы перейти на следующий уровень, нажмите 'Enter' Для выхода в меню - клавишу 'esc'";
            
        }
    }
}
