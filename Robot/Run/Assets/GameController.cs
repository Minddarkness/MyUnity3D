using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public UnityEngine.UI.Text coinLabel;
    public UnityEngine.UI.Text loss;
    public UnityEngine.UI.Text instruction;
    public GameObject floor;
    // Start is called before the first frame update
    int coinsCount = 0;
    int coinsTaken = 0;
    public bool isAlive = true;
    bool isWin = false;

    public static GameController instance;

    void Start()
    {
        instance = this;
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Icon");
        coinsCount = gameObjects.Length;
        coinLabel.text = "Монеты: " + coinsTaken + " / " + coinsCount;

    }

    // Update is called once per frame
    void Update()
    {
        if (coinsTaken == coinsCount)
        {
            isWin = true;
        }
        if (Input.GetButton("Cancel"))
        {
            SceneManager.LoadScene("Menu");
        }
      
        if (!isAlive)
        {
            loss.text = "Гравитация взяла своё. Для выхода в меню нажмите клавишу 'esc'";
        }
        if (isWin)
        {
            floor.SetActive(true);
            if (SceneManager.GetActiveScene().name == "level3")
            {
                instruction.text = " Проверка на ловкость прошла успешно. Для выхода в меню нажми клавишу 'esc'";
                return;
            }
            instruction.text = " Успешно. Чтобы перейти на следующий уровень, найдите статую. Переход в меню - клавиша 'esc'";

        }
    }

    public void PickupCoin( )
    {
        coinsTaken += 1;
        coinLabel.text = "Монеты: " + coinsTaken + " / " + coinsCount;
    }
}
